using System.Collections.Immutable;
using H.Generators.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace H.Generators;

public static class CommonSteps
{
    public static void RegisterSourceOutputOfFiles(
        this IncrementalGeneratorInitializationContext context,
        IncrementalValuesProvider<FileWithName> source)
    {
        context.RegisterSourceOutput(source, static (context, file) =>
        {
            if (file.IsEmpty)
            {
                return;
            }

            context.AddSource(
                hintName: file.Name,
                source: file.Text);
        });
    }
    
    public static void RegisterSourceOutputOfFiles(
        this IncrementalGeneratorInitializationContext context,
        IncrementalValueProvider<FileWithName> source)
    {
        context.RegisterSourceOutput(source, static (context, file) =>
        {
            if (file.IsEmpty)
            {
                return;
            }
            
            context.AddSource(
                hintName: file.Name,
                source: file.Text);
        });
    }

    public static IncrementalValuesProvider<GeneratorAttributeSyntaxContext>
        ForAttributeWithMetadataName(
            this SyntaxValueProvider source,
            string fullyQualifiedMetadataName)
    {
        return source
            .ForAttributeWithMetadataName(
                fullyQualifiedMetadataName: fullyQualifiedMetadataName,
                predicate: static (node, _) =>
                    node is ClassDeclarationSyntax { AttributeLists.Count: > 0 } or RecordDeclarationSyntax { AttributeLists.Count: > 0 },
                transform: static (context, _) => context);
    }

    public static IncrementalValuesProvider<(SemanticModel SemanticModel, ImmutableArray<AttributeData> Attributes, ClassDeclarationSyntax ClassSyntax, INamedTypeSymbol ClassSymbol)>
        SelectAllAttributes(
            this IncrementalValuesProvider<GeneratorAttributeSyntaxContext> source)
    {
        return source
            .Select(static (context, _) => (
                context.SemanticModel,
                context.Attributes,
                ClassSyntax: (ClassDeclarationSyntax)context.TargetNode,
                ClassSymbol: (INamedTypeSymbol)context.TargetSymbol));
    }

    public static IncrementalValuesProvider<(SemanticModel SemanticModel, AttributeData AttributeData, ClassDeclarationSyntax ClassSyntax, INamedTypeSymbol ClassSymbol)>
        SelectManyAllAttributesOfCurrentClassSyntax(
        this IncrementalValuesProvider<GeneratorAttributeSyntaxContext> source)
    {
        return source
            .SelectMany(static (context, _) => context.Attributes
                .Where(x =>
                {
                    var classSyntax = (ClassDeclarationSyntax)context.TargetNode;
                    var attributeSyntax = classSyntax.TryFindAttributeSyntax(x);
                    
                    return attributeSyntax != null;
                })
                .Select(x => (
                    context.SemanticModel,
                    AttributeData: x,
                    ClassSyntax: (ClassDeclarationSyntax)context.TargetNode,
                    ClassSymbol: (INamedTypeSymbol)context.TargetSymbol)));
    }

    internal static AttributeSyntax? TryFindAttributeSyntax(this ClassDeclarationSyntax classSyntax, AttributeData attribute)
    {
        var name = attribute.ConstructorArguments.ElementAtOrDefault(0).Value?.ToString();
        
        return classSyntax.AttributeLists
            .SelectMany(static x => x.Attributes)
            .FirstOrDefault(x => x.ArgumentList?.Arguments.FirstOrDefault()?.ToString().Trim('"').RemoveNameof() == name);
    }

    public static IncrementalValueProvider<Framework> DetectFramework(
        this IncrementalGeneratorInitializationContext initializationContext,
        string name)
    {
        var frameworkWithDiagnostic = initializationContext.AnalyzerConfigOptionsProvider
            .Select<AnalyzerConfigOptionsProvider, (Framework Framework, Diagnostic? Diagnostic)>((options, _) =>
            {
                var framework = options.TryRecognizeFramework(prefix: name);

                var diagnostic = framework == Framework.None
                    ? Diagnostic.Create(
                        new DiagnosticDescriptor(
                            id: "TRF001",
                            title: "Framework is not recognized",
                            messageFormat: @"Framework is not recognized.
You can explicitly specify the framework by setting one of the following constants in your project:
HAS_WPF, HAS_WINUI, HAS_UWP, HAS_UNO, HAS_UNO_WINUI, HAS_AVALONIA, HAS_MAUI",
                            "Usage",
                            DiagnosticSeverity.Error,
                            true),
                        Location.None)
                    : null;
                
                return (Framework: framework, Diagnostic: diagnostic);
            });
        
        initializationContext.RegisterSourceOutput(
            frameworkWithDiagnostic,
            (context, tuple) =>
            {
                if (tuple.Diagnostic == null)
                {
                    return;
                }
                
                context.ReportDiagnostic(tuple.Diagnostic);
            });
        
        return frameworkWithDiagnostic
            .Select(static (x, _) => x.Framework);
    }

    public static IncrementalValuesProvider<TResult>
        PrepareData<TResult, TLeft>(
            this IncrementalValuesProvider<(TLeft Left, Framework Right)> source,
            Func<Framework, TLeft, TResult?> selector,
            IncrementalGeneratorInitializationContext context,
            string id) where TResult : struct
    {
        return source
            .SafeSelect(x => selector(x.Right, x.Left), context, prefix: id)
            .Where(static x => x is not null)
            .Select(static (x, _) => x!.Value);
    }
}
