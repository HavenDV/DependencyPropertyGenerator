using System.Collections.Immutable;
using H.Generators.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WeakEventAttribute = DependencyPropertyGenerator.WeakEventAttribute;

namespace H.Generators;

[Generator]
public class WeakEventGenerator : IIncrementalGenerator
{
    #region Constants

    private const string Name = nameof(WeakEventGenerator);
    private const string Id = "WEG";

    private static string WeakEventAttributeFullName => typeof(WeakEventAttribute).FullName;

    #endregion

    #region Methods

    private static (SemanticModel, ClassDeclarationSyntax? Syntax) GetSemanticTargetForGeneration(GeneratorSyntaxContext context)
    {
        var syntax = (ClassDeclarationSyntax)context.Node;

        return syntax
            .AttributeLists
            .SelectMany(static list => list.Attributes)
            .Any(attributeSyntax => attributeSyntax.WhereFullNameIs(context.SemanticModel, IsGeneratorAttribute))
            ? (context.SemanticModel, syntax)
            : (context.SemanticModel, null);
    }

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterSourceOutput(
            context.AnalyzerConfigOptionsProvider
                .Select(static (options, _) => options.RecognizeFramework(prefix: Name))
                .Combine(context.SyntaxProvider
                    .CreateSyntaxProvider(
                        predicate: static (node, _) => node is ClassDeclarationSyntax { AttributeLists.Count: > 0 },
                        transform: static (context, _) => GetSemanticTargetForGeneration(context))
                    .Where(static x => x.Syntax is not null)
                    .Collect()),
            static (context, source) => Execute(source.Left, source.Right!, context));
    }

    private static void Execute(
        Framework framework,
        ImmutableArray<(SemanticModel, ClassDeclarationSyntax)> classSyntaxes,
        SourceProductionContext context)
    {
        if (classSyntaxes.IsDefaultOrEmpty)
        {
            return;
        }
        
        try
        {
            if (framework is not (Framework.Maui or Framework.Wpf))
            {
                return;
            }
            
            var classes = GetTypesToGenerate(framework, classSyntaxes, context.CancellationToken);
            foreach (var @class in classes)
            {
                foreach (var @event in @class.WeakEvents)
                {
                    context.AddSource(
                        hintName: $"{@class.Name}.WeakEvents.{@event.Name}.generated.cs",
                        source: SourceGenerationHelper.GenerateWeakEvent(@class, @event));
                }
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

    private static IReadOnlyCollection<ClassData> GetTypesToGenerate(
        Framework framework,
        IEnumerable<(SemanticModel SemanticModel, ClassDeclarationSyntax Syntax)> classes,
        CancellationToken cancellationToken)
    {
        var values = new List<ClassData>();
        foreach (var group in classes.GroupBy(static data => data.SemanticModel.GetFullClassName(data.Syntax)))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var (semanticModel, @class) = group.First();
            if (semanticModel.GetDeclaredSymbol(
                @class, cancellationToken) is not INamedTypeSymbol classSymbol)
            {
                continue;
            }

            var fullClassName = classSymbol.ToString();
            var @namespace = fullClassName.Substring(0, fullClassName.LastIndexOf('.'));
            var className = fullClassName.Substring(fullClassName.LastIndexOf('.') + 1);
            var isStaticClass = classSymbol.IsStatic;
            var classModifiers = classSymbol.IsStatic ? " static" : string.Empty;
            var methods = classSymbol
                .GetMembers()
                .OfType<IMethodSymbol>()
                // Roslyn bug?
                //.Where(static value => value.PartialImplementationPart != null)
                .Select(static value => value.ToDisplayString()
                    .Replace(value.ReceiverType?.ToDisplayString() ?? string.Empty, string.Empty)
                    .Replace("?", string.Empty)
                    .TrimStart('.'))
                .ToArray();
            var weakEvents = new List<EventData>();
            var attributes = @classSymbol.GetAttributes()
                .Where(static attribute => attribute.WhereFullNameIs(IsGeneratorAttribute))
                .Where(static attribute => attribute.ConstructorArguments.ElementAtOrDefault(0).Value is string)
                .ToDictionary(static attribute => attribute.ConstructorArguments[0].Value as string ?? string.Empty);
            foreach (var attributeSyntax in group
                .SelectMany(static list => list.Syntax.AttributeLists)
                .SelectMany(static list => list.Attributes)
                .Where(attributeSyntax => attributeSyntax.WhereFullNameIs(semanticModel, IsGeneratorAttribute)))
            {
                var name = attributeSyntax.ArgumentList?.Arguments[0].ToFullString().Trim('"') ?? string.Empty;
                name = name.RemoveNameof();
                var attribute = attributes[name];
                var attributeClass = attribute.AttributeClass?.ToDisplayString() ?? string.Empty;
                if (!attributeClass.StartsWith(WeakEventAttributeFullName, StringComparison.InvariantCulture))
                {
                    continue;
                }
                
                var type =
                    attribute.GetGenericTypeArgument(0)?.ToDisplayString() ??
                    attribute.GetProperty(nameof(WeakEventAttribute.Type))?.Value?.ToString() ??
                    string.Empty;
                var isValueType =
                    attribute.GetGenericTypeArgument(0)?.IsValueType ??
                    attribute.ConstructorArguments.ElementAtOrDefault(1).Type?.IsValueType ??
                    true;
                var isSpecialType =
                    attribute.GetGenericTypeArgument(0).IsSpecialType() ??
                    (attribute.ConstructorArguments.ElementAtOrDefault(1).Value as ITypeSymbol)?.IsSpecialType() ??
                    false;
                var isStatic = attributeSyntax.GetProperty(nameof(WeakEventAttribute.IsStatic)) ?? bool.FalseString;
                    
                var description = attribute.GetProperty(nameof(WeakEventAttribute.Description))?.Value?.ToString();
                var category = attribute.GetProperty(nameof(WeakEventAttribute.Category))?.Value?.ToString();

                var xmlDocumentation = attribute.GetProperty(nameof(WeakEventAttribute.XmlDocumentation))?.Value?.ToString();
                var eventXmlDocumentation = attribute.GetProperty(nameof(WeakEventAttribute.EventXmlDocumentation))?.Value?.ToString();

                var value = new EventData(
                    Name: name,
                    Strategy: string.Empty,
                    Type: type,
                    IsValueType: isValueType,
                    IsSpecialType: isSpecialType,
                    IsAttached: bool.Parse(isStatic) || isStaticClass,
                    Description: description,
                    Category: category,
                    XmlDocumentation: xmlDocumentation,
                    EventXmlDocumentation: eventXmlDocumentation,
                    WinRtEvents: false);
                    
                weakEvents.Add(value);
            }

            values.Add(new ClassData(
                Namespace: @namespace,
                Name: className,
                FullName: fullClassName,
                Modifiers: classModifiers,
                IsStatic: isStaticClass,
                Framework: framework,
                Methods: methods,
                DependencyProperties: Array.Empty<DependencyPropertyData>(),
                AttachedDependencyProperties: Array.Empty<DependencyPropertyData>(),
                RoutedEvents: Array.Empty<EventData>(),
                WeakEvents: weakEvents,
                OverrideMetadata: Array.Empty<DependencyPropertyData>(),
                AddOwner: Array.Empty<DependencyPropertyData>()));
        }

        return values;
    }

    private static bool IsGeneratorAttribute(string fullTypeName)
    {
        return
            fullTypeName.StartsWith(WeakEventAttributeFullName, StringComparison.InvariantCulture);
    }

    #endregion
}
