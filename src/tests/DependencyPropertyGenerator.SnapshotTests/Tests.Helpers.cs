using Microsoft.CodeAnalysis;
using H.Generators.Tests.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;
using System.Collections.Immutable;

namespace H.Generators.SnapshotTests;

public partial class Tests : VerifyBase
{
    private static string GetHeader(
        Platform platform,
        bool nullable,
        params string[] values)
    {
        var prefix = platform switch
        {
            Platform.WinUI or Platform.UnoWinUI => @"Microsoft.UI.Xaml",
            Platform.UWP or Platform.Uno => @"Windows.UI.Xaml",
            Platform.Avalonia => @"Avalonia",
            Platform.MAUI => @"Microsoft.Maui",
            _ => @"System.Windows",
        };
        var usings = string.Join(
            Environment.NewLine,
            values.Select(value => string.IsNullOrWhiteSpace(value)
                ? $"using {prefix};"
                : value.StartsWith("System")
                    ? $"using {value};"
                    : $"using {prefix}.{value};"));

        return @$"{usings}
using DependencyPropertyGenerator;

#nullable {(nullable ? "enable" : "disable")}

namespace H.Generators.IntegrationTests;
";
    }

    private static string GetHeader(
        Platform platform,
        params string[] values)
    {
        return GetHeader(platform, true, values);
    }

    public async Task CheckSourceAsync(
        string source,
        Platform platform,
        CancellationToken cancellationToken = default)
    {
        if (platform == Platform.WPF)
        {
            source = source
                .Replace("PointerEntered", "MouseEnter")
                .Replace("PointerExited", "MouseLeave")
                .Replace("PointerRoutedEventArgs", "MouseEventArgs");
        }
        if (platform == Platform.Uno ||
            platform == Platform.UnoWinUI ||
            platform == Platform.WinUI ||
            platform == Platform.UWP)
        {
            source = source
                .Replace("KeyEventArgs", "KeyRoutedEventArgs");
        }
        if (platform == Platform.Avalonia)
        {
            source = source
                .ReplaceType("DispatcherObject", "Avalonia.AvaloniaObject")
                .ReplaceType("DependencyObject", "Avalonia.AvaloniaObject")
                .ReplaceType("Visual", "Avalonia.Interactivity.Interactive")
                .ReplaceType("UIElement", "Avalonia.Input.InputElement")
                .ReplaceType("FrameworkElement", "Avalonia.Controls.Control")
                .Replace("static partial class", "partial class")
                .Replace("Brush", "IBrush")
                .Replace("PointerEntered", "PointerEnter")
                .Replace("PointerExited", "PointerLeave")
                .Replace("PointerRoutedEventArgs", "PointerEventArgs");
        }
        if (platform == Platform.MAUI)
        {
            source = source
                .Replace("using Microsoft.Maui.Input;", string.Empty)
                .Replace("using Microsoft.Maui.Controls;", string.Empty)
                .Replace("using Microsoft.Maui.Media;", string.Empty)
                .Replace("UIElement", "VisualElement")
                .Replace("FrameworkElement", "VisualElement")
                .Replace("TextBox", "Entry")
                .Replace("UserControl", "Grid")
                .Replace("TreeView", "Grid")
                .Replace("MyControl", "MyGrid")
                .Replace("KeyUp", "SizeChanged")
                .Replace("KeyEventArgs", "global::System.EventArgs")
                .Replace("PointerEntered", "Loaded")
                .Replace("PointerExited", "Unloaded")
                .Replace("PointerRoutedEventArgs", "global::System.EventArgs");
            source = @$"using Microsoft.Maui.Controls;
{source}";
        }

        var referenceAssemblies = platform switch
        {
            Platform.WPF => ReferenceAssemblies.NetFramework.Net48.Wpf,
            Platform.UWP => ReferenceAssemblies.Net.Net60Windows
                .WithPackages(ImmutableArray.Create(
                    new PackageIdentity("Microsoft.NETCore.UniversalWindowsPlatform", "6.2.14"),
                    new PackageIdentity("Microsoft.UI.Xaml", "2.7.1"),
                    new PackageIdentity("Microsoft.Net.UWPCoreRuntimeSdk", "2.2.14"))),
            Platform.WinUI => ReferenceAssemblies.Net.Net60Windows
                .WithPackages(ImmutableArray.Create(
                    new PackageIdentity("Microsoft.WindowsAppSDK", "1.1.2"),
                    new PackageIdentity("Microsoft.UI.Xaml", "2.7.1"),
                    new PackageIdentity("Microsoft.Windows.SDK.NET.Ref", "10.0.22621.26"))),
            Platform.Uno => ReferenceAssemblies.NetStandard.NetStandard20
                .WithPackages(ImmutableArray.Create(new PackageIdentity("Uno.UI", "4.3.8"))),
            Platform.UnoWinUI => ReferenceAssemblies.NetStandard.NetStandard20
                .WithPackages(ImmutableArray.Create(new PackageIdentity("Uno.WinUI", "4.3.8"))),
            Platform.Avalonia => ReferenceAssemblies.NetStandard.NetStandard20
                .WithPackages(ImmutableArray.Create(new PackageIdentity("Avalonia", "0.10.15"))),
            Platform.MAUI => ReferenceAssemblies.Net.Net60Windows
                .WithPackages(ImmutableArray.Create(
                    new PackageIdentity("Microsoft.Maui.Controls.Ref.any", "6.0.400"))),
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
        else if (platform == Platform.Avalonia)
        {
            globalOptions.Add("build_property.DependencyPropertyGenerator_DefineConstants", "HAS_AVALONIA");
        }
        else if (platform == Platform.MAUI)
        {
            globalOptions.Add("build_property.UseMaui", "true");
        }
        var driver = CSharpGeneratorDriver
            .Create(generator)
            .WithUpdatedAnalyzerConfigOptions(new DictionaryAnalyzerConfigOptionsProvider(globalOptions))
            .RunGeneratorsAndUpdateCompilation(LanguageVersion.Preview, compilation, out compilation, out _, cancellationToken);
        var diagnostics = compilation.GetDiagnostics(cancellationToken);

        await Task.WhenAll(
            Verify(diagnostics
                    .Select(static diagnostic => diagnostic.Location.ToString().Contains('\\') || diagnostic.Location.ToString().Contains('/')
                        ? Diagnostic.Create(
                            id: diagnostic.Id,
                            category: diagnostic.Descriptor.Category,
                            message: diagnostic.GetMessage(),
                            severity: diagnostic.Severity,
                            defaultSeverity: diagnostic.DefaultSeverity,
                            isEnabledByDefault: diagnostic.Descriptor.IsEnabledByDefault,
                            warningLevel: diagnostic.WarningLevel,
                            title: diagnostic.Descriptor.Title,
                            description: diagnostic.Descriptor.Description,
                            isSuppressed: diagnostic.IsSuppressed,
                            helpLink: diagnostic.Descriptor.HelpLinkUri,
                            location: Location.Create(
                                filePath: string.Empty,
                                textSpan: diagnostic.Location.SourceSpan,
                                lineSpan: diagnostic.Location.GetLineSpan().Span),
                            additionalLocations: diagnostic.AdditionalLocations,
                            properties: diagnostic.Properties,
                            customTags: diagnostic.Descriptor.CustomTags)
                        : diagnostic)
                    .ToArray())
                .UseDirectory("Snapshots")
                .UseTextForParameters($"{platform}_Diagnostics"),
            Verify(driver)
                .UseDirectory("Snapshots")
                .UseTextForParameters($"{platform}"));
    }
}

internal static class StringExtensions
{
    internal static string ReplaceType(this string source, string from, string to)
    {
        return source
            .Replace($": {from}", $": global::{to}")
            .Replace($"{from}.", $"global::{to}.")
            .Replace($", {from}", $", global::{to}");
    }
}