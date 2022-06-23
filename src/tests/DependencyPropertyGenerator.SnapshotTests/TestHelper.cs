using H.Generators.Tests.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;
using System.Collections.Immutable;

namespace H.Generators.SnapshotTests;

public static class TestHelper
{
    public static async Task CheckSourceAsync(
        this VerifyBase verifier,
        string source,
        Platform platform,
        CancellationToken cancellationToken = default)
    {
        var referenceAssemblies = platform switch
        {
            Platform.WPF => ReferenceAssemblies.NetFramework.Net48.Wpf,
            Platform.UWP => ReferenceAssemblies.Net.Net60Windows
                .WithPackages(ImmutableArray.Create(
                    new PackageIdentity("Microsoft.NETCore.UniversalWindowsPlatform", "6.2.14"),
                    new PackageIdentity("Microsoft.UI.Xaml", "2.7.1"))),
            Platform.WinUI => ReferenceAssemblies.Net.Net60Windows
                .WithPackages(ImmutableArray.Create(new PackageIdentity("Microsoft.WindowsAppSDK", "1.1.1"))),
            Platform.Uno => ReferenceAssemblies.NetStandard.NetStandard20
                .WithPackages(ImmutableArray.Create(new PackageIdentity("Uno.UI", "4.3.8"))),
            Platform.UnoWinUI => ReferenceAssemblies.NetStandard.NetStandard20
                .WithPackages(ImmutableArray.Create(new PackageIdentity("Uno.WinUI", "4.3.8"))),
            _ => throw new NotImplementedException(),
        };
        var references = await referenceAssemblies.ResolveAsync(null, cancellationToken);
        var compilation = (Compilation)CSharpCompilation.Create(
            assemblyName: "Tests",
            syntaxTrees: new[]
            {
                CSharpSyntaxTree.ParseText(source, options: new CSharpParseOptions(LanguageVersion.Preview), cancellationToken: cancellationToken),
            },
            references: references
                .Add(MetadataReference.CreateFromFile(typeof(global::DependencyPropertyGenerator.AttachedDependencyPropertyAttribute).Assembly.Location)),
            options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
        var generator = new DependencyPropertyGenerator();
        var globalOptions = new Dictionary<string, string>();
        if (platform == Platform.WPF)
        {
            globalOptions.Add("build_property.UseWPF", "true");
        }
        else if (platform == Platform.UWP)
        {
            globalOptions.Add("build_property.DependencyPropertyGenerator_DefineConstants", "WINDOWS_UWP");
        }
        else if (platform == Platform.WinUI)
        {
            globalOptions.Add("build_property.UseWinUI", "true");
        }
        else if (platform == Platform.Uno)
        {
            globalOptions.Add("build_property.DependencyPropertyGenerator_DefineConstants", "HAS_UNO");
        }
        else if (platform == Platform.UnoWinUI)
        {
            globalOptions.Add("build_property.DependencyPropertyGenerator_DefineConstants", "HAS_UNO;HAS_WINUI");
        }
        var driver = CSharpGeneratorDriver
            .Create(generator)
            .WithUpdatedAnalyzerConfigOptions(new DictionaryAnalyzerConfigOptionsProvider(globalOptions))
            .RunGeneratorsAndUpdateCompilation(LanguageVersion.Preview, compilation, out compilation, out _, cancellationToken);
        var diagnostics = compilation.GetDiagnostics(cancellationToken);

        await Task.WhenAll(
            verifier
                .Verify(diagnostics)
                .UseDirectory("Snapshots")
                .UseTextForParameters($"{platform}_Diagnostics"),
            verifier
                .Verify(driver)
                .UseDirectory("Snapshots")
                .UseTextForParameters($"{platform}"));
    }
}