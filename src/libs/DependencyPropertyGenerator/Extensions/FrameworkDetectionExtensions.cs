using H.Generators.Extensions;
using Microsoft.CodeAnalysis;

namespace H.Generators;

internal static class FrameworkDetectionExtensions
{
#pragma warning disable RS1032, RS2008
    private static readonly DiagnosticDescriptor FrameworkNotRecognized = new(
        id: "TRF001",
        title: "Framework is not recognized",
        messageFormat: AnalyzerConfigOptionsProviderExtensions.FrameworkIsNotRecognized,
        category: "Usage",
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true);
#pragma warning restore RS1032, RS2008

    public static IncrementalValueProvider<Framework> DetectFrameworkFromOptionsOrReferences(
        this IncrementalGeneratorInitializationContext context)
    {
        var frameworkWithDiagnostic = context.AnalyzerConfigOptionsProvider
            .Combine(context.CompilationProvider)
            .Select(static (tuple, _) =>
            {
                var framework = tuple.Left.TryRecognizeFramework();
                if (framework == Framework.None)
                {
                    framework = InferFramework(tuple.Right);
                }

                var diagnostic = framework == Framework.None
                    ? Diagnostic.Create(FrameworkNotRecognized, Location.None)
                    : null;

                return (Framework: framework, Diagnostic: diagnostic);
            });

        context.RegisterSourceOutput(
            frameworkWithDiagnostic,
            static (sourceProductionContext, tuple) =>
            {
                if (tuple.Diagnostic is { } diagnostic)
                {
                    sourceProductionContext.ReportDiagnostic(diagnostic);
                }
            });

        return frameworkWithDiagnostic.Select(static (tuple, _) => tuple.Framework);
    }

    private static Framework InferFramework(Compilation compilation)
    {
        if (compilation.GetTypeByMetadataName("Microsoft.Maui.Controls.BindableObject") is not null)
        {
            return Framework.Maui;
        }

        if (compilation.GetTypeByMetadataName("Avalonia.AvaloniaObject") is not null)
        {
            return Framework.Avalonia;
        }

        var isUno = compilation.ReferencedAssemblyNames.Any(static assembly =>
            assembly.Name.StartsWith("Uno.UI", StringComparison.OrdinalIgnoreCase) ||
            assembly.Name.StartsWith("Uno.WinUI", StringComparison.OrdinalIgnoreCase));

        if (compilation.GetTypeByMetadataName("Microsoft.UI.Xaml.DependencyObject") is not null)
        {
            return isUno ? Framework.UnoWinUi : Framework.WinUi;
        }

        if (compilation.GetTypeByMetadataName("Windows.UI.Xaml.DependencyObject") is not null)
        {
            return isUno ? Framework.Uno : Framework.Uwp;
        }

        if (compilation.GetTypeByMetadataName("System.Windows.DependencyObject") is not null)
        {
            return Framework.Wpf;
        }

        return Framework.None;
    }
}
