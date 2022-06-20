using System.Collections.Immutable;
using H.Generators.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace H.Generators;

[Generator]
public class DependencyPropertyGenerator : IIncrementalGenerator
{
    #region Constants

    public const string Name = nameof(DependencyPropertyGenerator);
    public const string Id = "DPG";

    private const string AttachedDependencyPropertyAttribute = "DependencyPropertyGenerator.AttachedDependencyPropertyAttribute";
    private const string DependencyPropertyAttribute = "DependencyPropertyGenerator.DependencyPropertyAttribute";

    #endregion

    #region Methods

    private static ClassDeclarationSyntax? GetSemanticTargetForGeneration(GeneratorSyntaxContext context)
    {
        var syntax = (ClassDeclarationSyntax)context.Node;

        foreach (var attributeListSyntax in syntax.AttributeLists)
        {
            foreach (var attributeSyntax in attributeListSyntax.Attributes)
            {
                if (context.SemanticModel.GetSymbolInfo(attributeSyntax).Symbol is not IMethodSymbol attributeSymbol)
                {
                    continue;
                }

                var attributeContainingTypeSymbol = attributeSymbol.ContainingType;
                var fullName = attributeContainingTypeSymbol.ToDisplayString();
                if (fullName.StartsWith(AttachedDependencyPropertyAttribute) ||
                    fullName.StartsWith(DependencyPropertyAttribute))
                {
                    return syntax;
                }
            }
        }

        return null;
    }

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var classes = context.SyntaxProvider
            .CreateSyntaxProvider(
                predicate: static (node, _) => node is ClassDeclarationSyntax { AttributeLists.Count: > 0 },
                transform: static (context, _) => GetSemanticTargetForGeneration(context))
            .Where(static syntax => syntax is not null);

        var compilationAndClasses = context.CompilationProvider
            .Combine(context.AnalyzerConfigOptionsProvider)
            .Combine(classes.Collect());

        context.RegisterSourceOutput(
            compilationAndClasses,
            static (context, source) => Execute(source.Left.Left, source.Left.Right, source.Right!, context));
    }

    private static void Execute(
        Compilation compilation,
        AnalyzerConfigOptionsProvider options,
        ImmutableArray<ClassDeclarationSyntax> classSyntaxes,
        SourceProductionContext context)
    {
        if (classSyntaxes.IsDefaultOrEmpty)
        {
            return;
        }
        
        try
        {
            var constants = options.GetGlobalOption("DefineConstants") ?? string.Empty;
            var useWpf = bool.Parse(options.GetGlobalOption("UseWPF") ?? bool.FalseString) || constants.Contains("HAS_WPF");
            var useWinUI = bool.Parse(options.GetGlobalOption("UseWinUI") ?? bool.FalseString) || constants.Contains("HAS_WINUI");
            var useUwp = bool.Parse(options.GetGlobalOption("UseUWP") ?? bool.FalseString) || constants.Contains("HAS_UWP");
            var useUno = bool.Parse(options.GetGlobalOption("UseUno") ?? bool.FalseString) || constants.Contains("HAS_UNO");
            var useUnoWinUI = bool.Parse(options.GetGlobalOption("UseUnoWinUI") ?? bool.FalseString) || constants.Contains("HAS_UNO") && constants.Contains("HAS_WINUI");
            var platform = (useWpf, useUwp, useWinUI, useUno, useUnoWinUI) switch
            {
                (_, _, _, true, _) => Platform.Uno,
                (_, _, _, _, true) => Platform.UnoWinUI,
                (_, true, _, _, _) => Platform.UWP,
                (_, _, true, _, _) => Platform.WinUI,
                (true, _, _, _, _) => Platform.WPF,
                _ =>                  Platform.Undefined,
            };

            var classes = GetTypesToGenerate(compilation, platform, classSyntaxes, context.CancellationToken);
            foreach (var @class in classes)
            {
                context.AddTextSource(
                    hintName: $"{@class.Name}_DependencyProperties.generated.cs",
                    text: SourceGenerationHelper.GenerateDependencyProperty(@class));
                context.AddTextSource(
                    hintName: $"{@class.Name}_AttachedDependencyProperties.generated.cs",
                    text: SourceGenerationHelper.GenerateAttachedDependencyProperty(@class));
            }
        }
        catch (Exception exception)
        {
            context.ReportException(
                id: "001",
                exception: exception,
                prefix: Id);
        }
    }

    private static List<ClassData> GetTypesToGenerate(
        Compilation compilation,
        Platform platform,
        IEnumerable<ClassDeclarationSyntax> classes,
        CancellationToken cancellationToken)
    {
        var enumsToGenerate = new List<ClassData>();
        foreach (var @class in classes)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var semanticModel = compilation.GetSemanticModel(@class.SyntaxTree);
            if (semanticModel.GetDeclaredSymbol(
                @class, cancellationToken) is not INamedTypeSymbol classSymbol)
            {
                continue;
            }

            var fullClassName = classSymbol.ToString();
            var @namespace = fullClassName.Substring(0, fullClassName.LastIndexOf('.'));
            var className = fullClassName.Substring(fullClassName.LastIndexOf('.') + 1);
            var classModifiers = classSymbol.IsStatic ? " static" : string.Empty;

            var dependencyProperties = new List<DependencyPropertyData>();
            var attachedDependencyProperties = new List<DependencyPropertyData>();
            foreach (var (attributeSyntax, attribute) in @class.AttributeLists
                .SelectMany(static list => list.Attributes)
                .Zip(classSymbol.GetAttributes(), static (a, b) => (a, b)))
            {
                var name = attribute.ConstructorArguments[0].Value as string ?? string.Empty;
                var type =
                    GetGenericTypeArgumentFromAttributeData(attribute, 0)?.ToDisplayString() ??
                    attribute.ConstructorArguments.ElementAtOrDefault(1).Value?.ToString() ??
                    string.Empty;
                var isValueType =
                    GetGenericTypeArgumentFromAttributeData(attribute, 0)?.IsValueType ??
                    attribute.ConstructorArguments.ElementAtOrDefault(1).Type?.IsValueType ??
                    true;
                var defaultValue = GetPropertyFromAttributeSyntax(attributeSyntax, "DefaultValue");
                var browsableForType =
                    GetGenericTypeArgumentFromAttributeData(attribute, 1)?.ToDisplayString() ??
                    GetPropertyFromAttributeData(attribute, "BrowsableForType")?.Value?.ToString();

                var xmlDoc = GetPropertyFromAttributeData(attribute, "XmlDoc")?.Value?.ToString();
                var propertyXmlDoc = GetPropertyFromAttributeData(attribute, "PropertyXmlDoc")?.Value?.ToString();
                var propertyGetterXmlDoc = GetPropertyFromAttributeData(attribute, "PropertyGetterXmlDoc")?.Value?.ToString();
                var propertySetterXmlDoc = GetPropertyFromAttributeData(attribute, "PropertySetterXmlDoc")?.Value?.ToString();

                var affectsMeasure = GetPropertyFromAttributeSyntax(attributeSyntax, "AffectsMeasure") ?? bool.FalseString;
                var affectsArrange = GetPropertyFromAttributeSyntax(attributeSyntax, "AffectsArrange") ?? bool.FalseString;
                var affectsParentMeasure = GetPropertyFromAttributeSyntax(attributeSyntax, "AffectsParentMeasure") ?? bool.FalseString;
                var affectsParentArrange = GetPropertyFromAttributeSyntax(attributeSyntax, "AffectsParentArrange") ?? bool.FalseString;
                var affectsRender = GetPropertyFromAttributeSyntax(attributeSyntax, "AffectsRender") ?? bool.FalseString;
                var inherits = GetPropertyFromAttributeSyntax(attributeSyntax, "Inherits") ?? bool.FalseString;
                var overridesInheritanceBehavior = GetPropertyFromAttributeSyntax(attributeSyntax, "OverridesInheritanceBehavior") ?? bool.FalseString;
                var notDataBindable = GetPropertyFromAttributeSyntax(attributeSyntax, "NotDataBindable") ?? bool.FalseString;
                var bindsTwoWayByDefault = GetPropertyFromAttributeSyntax(attributeSyntax, "BindsTwoWayByDefault") ?? bool.FalseString;
                var journal = GetPropertyFromAttributeSyntax(attributeSyntax, "Journal") ?? bool.FalseString;
                var subPropertiesDoNotAffectRender = GetPropertyFromAttributeSyntax(attributeSyntax, "SubPropertiesDoNotAffectRender") ?? bool.FalseString;

                var value = new DependencyPropertyData(
                    Name: name,
                    Type: type,
                    IsValueType: isValueType,
                    DefaultValue: defaultValue,
                    BrowsableForType: browsableForType,
                    XmlDoc: xmlDoc ?? "<summary></summary>",
                    PropertyGetterXmlDoc: propertyGetterXmlDoc ?? propertyXmlDoc ?? "<summary></summary>",
                    PropertySetterXmlDoc: propertySetterXmlDoc ?? "<summary></summary>",
                    AffectsMeasure: bool.Parse(affectsMeasure),
                    AffectsArrange: bool.Parse(affectsArrange),
                    AffectsParentMeasure: bool.Parse(affectsParentMeasure),
                    AffectsParentArrange: bool.Parse(affectsParentArrange),
                    AffectsRender: bool.Parse(affectsRender),
                    Inherits: bool.Parse(inherits),
                    OverridesInheritanceBehavior: bool.Parse(overridesInheritanceBehavior),
                    NotDataBindable: bool.Parse(notDataBindable),
                    BindsTwoWayByDefault: bool.Parse(bindsTwoWayByDefault),
                    Journal: bool.Parse(journal),
                    SubPropertiesDoNotAffectRender: bool.Parse(subPropertiesDoNotAffectRender));

                var attributeClass = attribute.AttributeClass?.ToDisplayString() ?? string.Empty;
                if (attributeClass.StartsWith(DependencyPropertyAttribute))
                {
                    dependencyProperties.Add(value);
                }
                else if (attributeClass.StartsWith(AttachedDependencyPropertyAttribute))
                {
                    attachedDependencyProperties.Add(value);
                }
            }

            enumsToGenerate.Add(new ClassData(@namespace, className, classModifiers, platform, dependencyProperties, attachedDependencyProperties));
        }

        return enumsToGenerate;
    }

    private static ITypeSymbol? GetGenericTypeArgumentFromAttributeData(AttributeData data, int position)
{
        return data.AttributeClass?.TypeArguments.ElementAtOrDefault(position);
    }

    private static TypedConstant? GetPropertyFromAttributeData(AttributeData data, string name)
{
        return data.NamedArguments
            .FirstOrDefault(pair => pair.Key == name)
            .Value;
    }

    private static string? GetPropertyFromAttributeSyntax(AttributeSyntax syntax, string name)
    {
        return syntax.ArgumentList?.Arguments
            .FirstOrDefault(pair => pair.NameEquals?.ToFullString().StartsWith(name) == true)?
            .Expression
            .ToFullString();
    }

    #endregion
}
