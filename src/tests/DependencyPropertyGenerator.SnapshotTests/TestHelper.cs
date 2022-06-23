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
            Platform.WinUI => ReferenceAssemblies.Net.Net60Windows
                .WithPackages(ImmutableArray.Create(new PackageIdentity("Microsoft.WindowsAppSDK", "1.1.1"))),
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
        else if (platform == Platform.WinUI)
        {
            globalOptions.Add("build_property.UseWinUI", "true");
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