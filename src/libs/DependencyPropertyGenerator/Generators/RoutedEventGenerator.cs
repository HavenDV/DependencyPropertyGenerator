using System.Collections.Immutable;
using System.Diagnostics;
using H.Generators.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using RoutedEventAttribute = DependencyPropertyGenerator.RoutedEventAttribute;

namespace H.Generators;

[Generator]
public class RoutedEventGenerator : IIncrementalGenerator
{
    #region Constants

    private const string Name = nameof(RoutedEventGenerator);
    private const string Id = "REG";

    private static string RoutedEventAttributeFullName => typeof(RoutedEventAttribute).FullName;

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
        var classes = context.SyntaxProvider
            .CreateSyntaxProvider(
                predicate: static (node, _) => node is ClassDeclarationSyntax { AttributeLists.Count: > 0 },
                transform: static (context, _) => GetSemanticTargetForGeneration(context))
            .Where(static x => x.Syntax is not null);

        var compilationAndClasses = context.AnalyzerConfigOptionsProvider
            .Combine(classes.Collect());

        context.RegisterSourceOutput(
            compilationAndClasses,
            static (context, source) => Execute(source.Left, source.Right!, context));
    }

    private static void Execute(
        AnalyzerConfigOptionsProvider options,
        ImmutableArray<(SemanticModel, ClassDeclarationSyntax)> classSyntaxes,
        SourceProductionContext context)
    {
        if (!options.IsDesignTime() &&
            options.GetGlobalOption("DebuggerBreak", prefix: Name) != null)
        {
            Debugger.Launch();
        }
        
        if (classSyntaxes.IsDefaultOrEmpty)
        {
            return;
        }
        
        try
        {
            var framework = options.RecognizeFramework(prefix: Name);
            var classes = GetTypesToGenerate(framework, classSyntaxes, context.CancellationToken);
            foreach (var @class in classes)
            {
                if (framework is not Framework.Maui)
                {
                    foreach (var @event in @class.RoutedEvents.Where(static @event => !@event.IsAttached))
                    {
                        context.AddTextSource(
                            hintName: $"{@class.Name}.Events.{@event.Name}.generated.cs",
                            text: SourceGenerationHelper.GenerateRoutedEvent(@class, @event));
                    }
                }
                if (framework is Framework.Wpf)
                {
                    foreach (var @event in @class.RoutedEvents.Where(static @event => @event.IsAttached))
                    {
                        context.AddTextSource(
                            hintName: $"{@class.Name}.AttachedEvents.{@event.Name}.generated.cs",
                            text: SourceGenerationHelper.GenerateAttachedRoutedEvent(@class, @event));
                    }
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
            var routedEvents = new List<EventData>();
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
                if (attributeClass.StartsWith(RoutedEventAttributeFullName, StringComparison.InvariantCulture))
                {
                    var strategy = attributeSyntax.ArgumentList?.Arguments[1].ToFullString()
                        .Replace("RoutedEventStrategy.", string.Empty) ?? string.Empty;
                    var type =
                        attribute.GetGenericTypeArgument(0)?.ToDisplayString() ??
                        attribute.GetProperty(nameof(RoutedEventAttribute.Type))?.Value?.ToString() ??
                        string.Empty;
                    var isValueType =
                        attribute.GetGenericTypeArgument(0)?.IsValueType ??
                        attribute.ConstructorArguments.ElementAtOrDefault(1).Type?.IsValueType ??
                        true;
                    var isSpecialType =
                        attribute.GetGenericTypeArgument(0).IsSpecialType() ??
                        (attribute.ConstructorArguments.ElementAtOrDefault(1).Value as ITypeSymbol)?.IsSpecialType() ??
                        false;
                    var isAttached = attributeSyntax.GetProperty(nameof(RoutedEventAttribute.IsAttached)) ?? bool.FalseString;
                    
                    var description = attribute.GetProperty(nameof(RoutedEventAttribute.Description))?.Value?.ToString();
                    var category = attribute.GetProperty(nameof(RoutedEventAttribute.Category))?.Value?.ToString();

                    var xmlDocumentation = attribute.GetProperty(nameof(RoutedEventAttribute.XmlDocumentation))?.Value?.ToString();
                    var eventXmlDocumentation = attribute.GetProperty(nameof(RoutedEventAttribute.EventXmlDocumentation))?.Value?.ToString();

                    var winRtEvents = attributeSyntax.GetProperty(nameof(RoutedEventAttribute.WinRtEvents)) ?? bool.FalseString;

                    var value = new EventData(
                        Name: name,
                        Strategy: strategy,
                        Type: type,
                        IsValueType: isValueType,
                        IsSpecialType: isSpecialType,
                        IsAttached: bool.Parse(isAttached),
                        Description: description,
                        Category: category,
                        XmlDocumentation: xmlDocumentation,
                        EventXmlDocumentation: eventXmlDocumentation,
                        WinRtEvents: bool.Parse(winRtEvents));
                    
                    routedEvents.Add(value);
                }
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
                RoutedEvents: routedEvents,
                WeakEvents: Array.Empty<EventData>(),
                OverrideMetadata: Array.Empty<DependencyPropertyData>(),
                AddOwner: Array.Empty<DependencyPropertyData>()));
        }

        return values;
    }
    
    private static bool IsGeneratorAttribute(string fullTypeName)
    {
        return
            fullTypeName.StartsWith(RoutedEventAttributeFullName, StringComparison.InvariantCulture);
    }

    #endregion
}
