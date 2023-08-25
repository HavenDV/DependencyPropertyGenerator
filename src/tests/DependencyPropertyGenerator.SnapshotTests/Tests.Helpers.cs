using Microsoft.CodeAnalysis;
using H.Generators.Tests.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;
using System.Collections.Immutable;

namespace H.Generators.SnapshotTests;

public partial class Tests : VerifyBase
{
    private static string GetHeader(
        Framework framework,
        bool nullable,
        bool @namespace,
        params string[] values)
    {
        var prefix = framework switch
        {
            Framework.WinUi or Framework.UnoWinUi => @"Microsoft.UI.Xaml",
            Framework.Uwp or Framework.Uno => @"Windows.UI.Xaml",
            Framework.Avalonia => @"Avalonia",
            Framework.Maui => @"Microsoft.Maui",
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

{(@namespace ? "namespace H.Generators.IntegrationTests;" : string.Empty)}
";
    }

    private static string GetHeader(
        Framework framework,
        params string[] values)
    {
        return GetHeader(framework, nullable: true, @namespace: true, values);
    }

    private static Dictionary<string, string> GetGlobalOptions(Framework framework)
    {
        var globalOptions = new Dictionary<string, string>();
        if (framework == Framework.Wpf)
        {
            globalOptions.Add("build_property.UseWPF", "true");
        }
        else if (framework == Framework.WinUi)
        {
            globalOptions.Add("build_property.UseWinUI", "true");
        }
        else if (framework == Framework.Maui)
        {
            globalOptions.Add("build_property.UseMaui", "true");
        }
        else if (framework == Framework.Uwp)
        {
            globalOptions.Add($"build_property.RecognizeFramework_DefineConstants", "WINDOWS_UWP");
        }
        else if (framework == Framework.Uno)
        {
            globalOptions.Add($"build_property.RecognizeFramework_DefineConstants", "HAS_UNO");
        }
        else if (framework == Framework.UnoWinUi)
        {
            globalOptions.Add($"build_property.RecognizeFramework_DefineConstants", "HAS_UNO;HAS_WINUI");
        }
        else if (framework == Framework.Avalonia)
        {
            globalOptions.Add($"build_property.RecognizeFramework_DefineConstants", "HAS_AVALONIA");
        }

        return globalOptions;
    }

    private async Task CheckSourceAsync<T>(
        string source,
        Framework framework,
        CancellationToken cancellationToken = default,
        params IIncrementalGenerator[] additionalGenerators)
        where T : IIncrementalGenerator, new()
    {
        if (framework == Framework.Wpf)
        {
            source = source
                .Replace("PointerEntered", "MouseEnter")
                .Replace("PointerExited", "MouseLeave")
                .Replace("PointerRoutedEventArgs", "MouseEventArgs");
        }

        if (framework == Framework.Uno ||
            framework == Framework.UnoWinUi ||
            framework == Framework.WinUi ||
            framework == Framework.Uwp)
        {
            source = source
                .Replace("KeyEventArgs", "KeyRoutedEventArgs");
        }

        if (framework == Framework.Avalonia)
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

        if (framework == Framework.Maui)
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

        var referenceAssemblies = framework switch
        {
            Framework.None => ReferenceAssemblies.NetFramework.Net48.Wpf,
            Framework.Wpf => ReferenceAssemblies.NetFramework.Net48.Wpf,
            Framework.Uwp => ReferenceAssemblies.Net.Net60Windows
                .WithPackages(ImmutableArray.Create(
                    new PackageIdentity("Microsoft.NETCore.UniversalWindowsPlatform", "6.2.14"),
                    new PackageIdentity("Microsoft.UI.Xaml", "2.8.2"),
                    new PackageIdentity("Microsoft.Net.UWPCoreRuntimeSdk", "2.2.14"))),
            Framework.WinUi => ReferenceAssemblies.Net.Net60Windows
                .WithPackages(ImmutableArray.Create(
                    new PackageIdentity("Microsoft.WindowsAppSDK", "1.2.230118.102"),
                    new PackageIdentity("Microsoft.UI.Xaml", "2.8.2"),
                    new PackageIdentity("Microsoft.Windows.SDK.NET.Ref", "10.0.22621.28"))),
            Framework.Uno => ReferenceAssemblies.NetStandard.NetStandard20
                .WithPackages(ImmutableArray.Create(new PackageIdentity("Uno.UI", "4.7.30"))),
            Framework.UnoWinUi => ReferenceAssemblies.NetStandard.NetStandard20
                .WithPackages(ImmutableArray.Create(new PackageIdentity("Uno.WinUI", "4.7.30"))),
            Framework.Avalonia => ReferenceAssemblies.NetStandard.NetStandard20
                .WithPackages(ImmutableArray.Create(new PackageIdentity("Avalonia", "0.10.18"))), // 11.0.0-preview6
            Framework.Maui => ReferenceAssemblies.Net.Net60Windows
                .WithPackages(ImmutableArray.Create(
                    new PackageIdentity("Microsoft.Maui.Controls.Ref.any", "6.0.550"),
                    new PackageIdentity("Microsoft.Maui.Core.Ref.any", "6.0.550"))),
            _ => throw new NotImplementedException(),
        };
        var references = await referenceAssemblies.ResolveAsync(null, cancellationToken);
        var compilation = (Compilation)CSharpCompilation.Create(
            assemblyName: "Tests",
            syntaxTrees: new[]
            {
                CSharpSyntaxTree.ParseText(source, options: new CSharpParseOptions(LanguageVersion.Preview),
                    cancellationToken: cancellationToken),
            },
            references: references
                .Add(MetadataReference.CreateFromFile(
                    typeof(global::DependencyPropertyGenerator.AttachedDependencyPropertyAttribute).Assembly.Location)),
            options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
        var generator = new T();
        GeneratorDriver driver = additionalGenerators.Any()
            ? CSharpGeneratorDriver.Create(new IIncrementalGenerator[] { generator }.Concat(additionalGenerators)
                .ToArray())
            : CSharpGeneratorDriver.Create(generator);
        driver = driver
            .WithUpdatedAnalyzerConfigOptions(new DictionaryAnalyzerConfigOptionsProvider(GetGlobalOptions(framework)))
            .RunGeneratorsAndUpdateCompilation(LanguageVersion.Preview, compilation, out compilation, out _,
                cancellationToken);
        var diagnostics = compilation.GetDiagnostics(cancellationToken);

        await Task.WhenAll(
            Verify(diagnostics.NormalizeLocations())
                .UseDirectory("Snapshots")
                .UseTextForParameters($"{framework}_Diagnostics"),
            Verify(driver)
                .UseDirectory("Snapshots")
                .UseTextForParameters($"{framework}"));
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