﻿using System.Collections.Immutable;
using System.Diagnostics;
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
    private const string RoutedEventAttribute = "DependencyPropertyGenerator.RoutedEventAttribute";

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
                    fullName.StartsWith(DependencyPropertyAttribute) ||
                    fullName.StartsWith(RoutedEventAttribute))
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
            var constants = options.GetGlobalOption("DefineConstants", prefix: Name) ?? string.Empty;
            var useWpf = bool.Parse(options.GetGlobalOption("UseWPF") ?? bool.FalseString) || constants.Contains("HAS_WPF");
            var useWinUI = bool.Parse(options.GetGlobalOption("UseWinUI") ?? bool.FalseString) || constants.Contains("HAS_WINUI");
            var useUwp = constants.Contains("WINDOWS_UWP") || constants.Contains("HAS_UWP");
            var useUno = constants.Contains("HAS_UNO");
            var useUnoWinUI = constants.Contains("HAS_UNO_WINUI") || (constants.Contains("HAS_UNO") && constants.Contains("HAS_WINUI"));
            var useAvalonia = constants.Contains("HAS_AVALONIA");
            var platform = (useWpf, useUwp, useWinUI, useUno, useUnoWinUI, useAvalonia) switch
            {
                (_, _, _, _, _, true) => Platform.Avalonia,
                (_, _, _, _, true, _) => Platform.UnoWinUI,
                (_, _, _, true, _, _) => Platform.Uno,
                (_, _, true, _, _, _) => Platform.WinUI,
                (_, true, _, _, _, _) => Platform.UWP,
                (true, _, _, _, _, _) => Platform.WPF,
                _ =>                  Platform.Undefined,
            };

            var classes = GetTypesToGenerate(compilation, platform, classSyntaxes, context.CancellationToken);
            foreach (var @class in classes)
            {
                foreach(var property in @class.DependencyProperties)
                {
                    context.AddTextSource(
                        hintName: $"{@class.Name}.Properties.{property.Name}.generated.cs",
                        text: SourceGenerationHelper.GenerateDependencyProperty(@class, property));
                }
                foreach (var property in @class.AttachedDependencyProperties)
                {
                    context.AddTextSource(
                        hintName: $"{@class.Name}.AttachedProperties.{property.Name}.generated.cs",
                        text: SourceGenerationHelper.GenerateAttachedDependencyProperty(@class, property));
                }
                if (platform == Platform.WPF)
                {
                    foreach (var @event in @class.RoutedEvents.Where(static @event => !@event.IsAttached))
                    {
                        context.AddTextSource(
                            hintName: $"{@class.Name}.Events.{@event.Name}.generated.cs",
                            text: SourceGenerationHelper.GenerateRoutedEvent(@class, @event));
                    }
                    foreach (var @event in @class.RoutedEvents.Where(static @event => @event.IsAttached))
                    {
                        context.AddTextSource(
                            hintName: $"{@class.Name}.AttachedEvents.{@event.Name}.generated.cs",
                            text: SourceGenerationHelper.GenerateAttachedRoutedEvent(@class, @event));
                    }
                }
                if (platform == Platform.Avalonia && @class.AttachedDependencyProperties.Any())
                {
                    context.AddTextSource(
                        hintName: $"{@class.Name}.StaticConstructor.generated.cs",
                        text: SourceGenerationHelper.GenerateStaticConstructor(@class, @class.AttachedDependencyProperties));
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
        Compilation compilation,
        Platform platform,
        IEnumerable<ClassDeclarationSyntax> classes,
        CancellationToken cancellationToken)
    {
        var values = new List<ClassData>();
        foreach (var group in classes.GroupBy(@class => GetFullClassName(compilation, @class)))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var @class = group.First();

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
            var routedEvents = new List<RoutedEventData>();
            var attributes = @classSymbol.GetAttributes()
                .Where(static attribute => attribute.ConstructorArguments.ElementAtOrDefault(0).Value is string)
                .ToDictionary(static attribute => attribute.ConstructorArguments[0].Value as string ?? string.Empty);
            foreach (var attributeSyntax in group
                .SelectMany(static list => list.AttributeLists)
                .SelectMany(static list => list.Attributes))
            {
                var name = attributeSyntax.ArgumentList?.Arguments[0].ToFullString()?.Trim('"') ?? string.Empty;
                var attribute = attributes[name];
                var attributeClass = attribute.AttributeClass?.ToDisplayString() ?? string.Empty;
                if (attributeClass.StartsWith(RoutedEventAttribute))
                {
                    var strategy = attribute.ConstructorArguments[1].Value?.ToString() ?? string.Empty;
                    var type =
                        GetGenericTypeArgumentFromAttributeData(attribute, 0)?.ToDisplayString() ??
                        GetPropertyFromAttributeData(attribute, nameof(RoutedEventData.Type))?.Value?.ToString();
                    var isAttached = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(RoutedEventData.IsAttached)) ?? bool.FalseString;
                    
                    var description = GetPropertyFromAttributeData(attribute, nameof(RoutedEventData.Description))?.Value?.ToString();
                    var category = GetPropertyFromAttributeData(attribute, nameof(RoutedEventData.Category))?.Value?.ToString();

                    var xmlDocumentation = GetPropertyFromAttributeData(attribute, nameof(RoutedEventData.XmlDocumentation))?.Value?.ToString();
                    var eventXmlDocumentation = GetPropertyFromAttributeData(attribute, nameof(RoutedEventData.EventXmlDocumentation))?.Value?.ToString();

                    var value = new RoutedEventData(
                        Name: name,
                        Strategy: strategy,
                        Type: type,
                        IsAttached: bool.Parse(isAttached),
                        Description: description,
                        Category: category,
                        XmlDocumentation: xmlDocumentation,
                        EventXmlDocumentation: eventXmlDocumentation);
                    
                    routedEvents.Add(value);
                    continue;
                }
                else
                {
                    var type =
                        GetGenericTypeArgumentFromAttributeData(attribute, 0)?.ToDisplayString() ??
                        attribute.ConstructorArguments.ElementAtOrDefault(1).Value?.ToString() ??
                        string.Empty;
                    var isValueType =
                        GetGenericTypeArgumentFromAttributeData(attribute, 0)?.IsValueType ??
                        attribute.ConstructorArguments.ElementAtOrDefault(1).Type?.IsValueType ??
                        true;
                    var isSpecialType =
                        IsSpecialType(GetGenericTypeArgumentFromAttributeData(attribute, 0)) ??
                        IsSpecialType(attribute.ConstructorArguments.ElementAtOrDefault(1).Type) ??
                        false;
                    var defaultValue =
                        GetPropertyFromAttributeData(attribute, "DefaultValueExpression")?.Value?.ToString() ??
                        GetPropertyFromAttributeData(attribute, nameof(DependencyPropertyData.DefaultValue))?.Value?.ToString();
                    var defaultValueDocumentation =
                        GetPropertyFromAttributeData(attribute, "DefaultValueExpression")?.Value?.ToString() ??
                        GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyData.DefaultValue));
                    var browsableForType =
                        GetGenericTypeArgumentFromAttributeData(attribute, 1)?.ToDisplayString() ??
                        GetPropertyFromAttributeData(attribute, nameof(DependencyPropertyData.BrowsableForType))?.Value?.ToString();
                    var isBrowsableForTypeSpecialType =
                        IsSpecialType(GetGenericTypeArgumentFromAttributeData(attribute, 1)) ??
                        IsSpecialType(GetPropertyFromAttributeData(attribute, nameof(DependencyPropertyData.BrowsableForType))?.Type) ??
                        false;
                    var isReadOnly = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyData.IsReadOnly)) ?? bool.FalseString;
                    var isAttached = attributeClass.StartsWith(AttachedDependencyPropertyAttribute);

                    var description = GetPropertyFromAttributeData(attribute, nameof(DependencyPropertyData.Description))?.Value?.ToString();
                    var category = GetPropertyFromAttributeData(attribute, nameof(DependencyPropertyData.Category))?.Value?.ToString();
                    var typeConverter = GetPropertyFromAttributeData(attribute, nameof(DependencyPropertyData.TypeConverter))?.Value?.ToString();
                    var bindable = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyData.Bindable));
                    var browsable = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyData.Browsable));
                    var designerSerializationVisibility = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyData.DesignerSerializationVisibility));
                    var clsCompliant = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyData.CLSCompliant));
                    var localizability = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyData.Localizability))?
                        .Replace("global::DependencyPropertyGenerator.Localizability.", string.Empty)
                        .Replace("DependencyPropertyGenerator.Localizability.", string.Empty)
                        .Replace("Localizability.", string.Empty);

                    var xmlDocumentation = GetPropertyFromAttributeData(attribute, nameof(DependencyPropertyData.XmlDocumentation))?.Value?.ToString();
                    var propertyXmlDocumentation = GetPropertyFromAttributeData(attribute, "PropertyXmlDocumentation")?.Value?.ToString();
                    var getterXmlDocumentation = GetPropertyFromAttributeData(attribute, nameof(DependencyPropertyData.GetterXmlDocumentation))?.Value?.ToString();
                    var setterXmlDocumentation = GetPropertyFromAttributeData(attribute, nameof(DependencyPropertyData.SetterXmlDocumentation))?.Value?.ToString();

                    var affectsMeasure = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyData.AffectsMeasure)) ?? bool.FalseString;
                    var affectsArrange = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyData.AffectsArrange)) ?? bool.FalseString;
                    var affectsParentMeasure = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyData.AffectsParentMeasure)) ?? bool.FalseString;
                    var affectsParentArrange = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyData.AffectsParentArrange)) ?? bool.FalseString;
                    var affectsRender = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyData.AffectsRender)) ?? bool.FalseString;
                    var inherits = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyData.Inherits)) ?? bool.FalseString;
                    var overridesInheritanceBehavior = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyData.OverridesInheritanceBehavior)) ?? bool.FalseString;
                    var notDataBindable = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyData.NotDataBindable)) ?? bool.FalseString;
                    var bindsTwoWayByDefault = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyData.BindsTwoWayByDefault)) ?? bool.FalseString;
                    var journal = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyData.Journal)) ?? bool.FalseString;
                    var subPropertiesDoNotAffectRender = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyData.SubPropertiesDoNotAffectRender)) ?? bool.FalseString;
                    var isAnimationProhibited = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyData.IsAnimationProhibited)) ?? bool.FalseString;
                    var defaultUpdateSourceTrigger = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyData.DefaultUpdateSourceTrigger))?
                        .Replace("global::DependencyPropertyGenerator.SourceTrigger.", string.Empty)
                        .Replace("DependencyPropertyGenerator.SourceTrigger.", string.Empty)
                        .Replace("SourceTrigger.", string.Empty);
                    var coerce = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyData.Coerce)) ?? bool.FalseString;
                    var validate = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyData.Validate)) ?? bool.FalseString;

                    var value = new DependencyPropertyData(
                        Name: name,
                        Type: type,
                        IsValueType: isValueType,
                        IsSpecialType: isSpecialType,
                        DefaultValue: defaultValue,
                        DefaultValueDocumentation: defaultValueDocumentation,
                        IsReadOnly: bool.Parse(isReadOnly),
                        IsAttached: isAttached,
                        Platform: platform,
                        Description: description,
                        Category: category,
                        TypeConverter: typeConverter,
                        Bindable: bindable,
                        Browsable: browsable,
                        DesignerSerializationVisibility: designerSerializationVisibility,
                        CLSCompliant: clsCompliant,
                        Localizability: localizability,
                        BrowsableForType: browsableForType,
                        IsBrowsableForTypeSpecialType: isBrowsableForTypeSpecialType,
                        XmlDocumentation: xmlDocumentation,
                        GetterXmlDocumentation: getterXmlDocumentation ?? propertyXmlDocumentation,
                        SetterXmlDocumentation: setterXmlDocumentation,
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
                        SubPropertiesDoNotAffectRender: bool.Parse(subPropertiesDoNotAffectRender),
                        IsAnimationProhibited: bool.Parse(isAnimationProhibited),
                        DefaultUpdateSourceTrigger: defaultUpdateSourceTrigger,
                        Coerce: bool.Parse(coerce),
                        Validate: bool.Parse(validate));

                    if (isAttached)
                    {
                        attachedDependencyProperties.Add(value);
                    }
                    else
                    {
                        dependencyProperties.Add(value);
                    }
                }
            }

            values.Add(new ClassData(
                Namespace: @namespace,
                Name: className,
                FullName: fullClassName,
                Modifiers: classModifiers,
                Platform: platform,
                DependencyProperties: dependencyProperties,
                AttachedDependencyProperties: attachedDependencyProperties,
                RoutedEvents: routedEvents));
        }

        return values;
    }

    private static string? GetFullClassName(Compilation compilation, ClassDeclarationSyntax classDeclarationSyntax)
    {
        var semanticModel = compilation.GetSemanticModel(classDeclarationSyntax.SyntaxTree);
        if (semanticModel.GetDeclaredSymbol(classDeclarationSyntax) is not INamedTypeSymbol classSymbol)
        {
            return null;
        }

        return classSymbol.ToString();
    }

    private static bool? IsSpecialType(ITypeSymbol? symbol)
    {
        if (symbol == null)
        {
            return null;
        }

        return symbol.SpecialType != SpecialType.None;
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
            .FirstOrDefault(syntax =>
            {
                var nameEquals = syntax.NameEquals?.ToFullString()?.Trim();
                
                return nameEquals?.StartsWith(name) == true;
            })?
            .Expression
            .ToFullString();
    }

    #endregion
}
