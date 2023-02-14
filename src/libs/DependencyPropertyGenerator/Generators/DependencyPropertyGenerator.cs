using System.Collections.Immutable;
using System.Diagnostics;
using H.Generators.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using AttachedDependencyPropertyAttribute = DependencyPropertyGenerator.AttachedDependencyPropertyAttribute;
using DependencyPropertyAttribute = DependencyPropertyGenerator.DependencyPropertyAttribute;
using OverrideMetadataAttribute = DependencyPropertyGenerator.OverrideMetadataAttribute;
using AddOwnerAttribute = DependencyPropertyGenerator.AddOwnerAttribute;

namespace H.Generators;

[Generator]
public class DependencyPropertyGenerator : IIncrementalGenerator
{
    #region Constants

    private const string Name = nameof(DependencyPropertyGenerator);
    private const string Id = "DPG";

    private static string AttachedDependencyPropertyAttributeFullName => typeof(AttachedDependencyPropertyAttribute).FullName;
    private static string DependencyPropertyAttributeFullName => typeof(DependencyPropertyAttribute).FullName;
    private static string OverrideMetadataAttributeFullName => typeof(OverrideMetadataAttribute).FullName;
    private static string AddOwnerAttributeFullName => typeof(AddOwnerAttribute).FullName;

    #endregion

    #region Methods

    private static ClassDeclarationSyntax? GetSemanticTargetForGeneration(GeneratorSyntaxContext context)
    {
        var syntax = (ClassDeclarationSyntax)context.Node;

        return syntax
            .AttributeLists
            .SelectMany(static list => list.Attributes)
            .Any(attributeSyntax => attributeSyntax.WhereFullNameIs(context.SemanticModel, IsGeneratorAttribute))
            ? syntax
            : null;
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
            var platform = options.RecognizePlatform(prefix: Name);
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

                if (@class.OverrideMetadata.Any())
                {
                    if (platform == Platform.WPF)
                    {
                        context.AddTextSource(
                            hintName: $"{@class.Name}.StaticConstructor.generated.cs",
                            text: SourceGenerationHelper.GenerateStaticConstructor(@class, @class.OverrideMetadata));
                    }
                    else if (platform is Platform.UWP or Platform.WinUI or Platform.Uno or Platform.UnoWinUI)
                    {
                        context.AddTextSource(
                            hintName: $"{@class.Name}.Methods.RegisterPropertyChangedCallbacks.generated.cs",
                            text: SourceGenerationHelper.GenerateRegisterPropertyChangedCallbacksMethod(@class, @class.OverrideMetadata));
                    }
                }
                if (platform is Platform.UWP or Platform.WinUI or Platform.Uno or Platform.UnoWinUI)
                {
                    foreach (var @event in @class.RoutedEvents.Where(static @event => !@event.IsAttached))
                    {
                        context.AddTextSource(
                            hintName: $"{@class.Name}.Events.{@event.Name}.generated.cs",
                            text: SourceGenerationHelper.GenerateRoutedEvent(@class, @event));
                    }
                }
                if (platform == Platform.Avalonia)
                {
                    foreach (var @event in @class.RoutedEvents.Where(static @event => !@event.IsAttached))
                    {
                        context.AddTextSource(
                            hintName: $"{@class.Name}.Events.{@event.Name}.generated.cs",
                            text: SourceGenerationHelper.GenerateRoutedEvent(@class, @event));
                    }
                    foreach (var addOwner in @class.AddOwner)
                    {
                        context.AddTextSource(
                            hintName: $"{@class.Name}.AddOwner.{addOwner.Name}.generated.cs",
                            text: SourceGenerationHelper.GenerateDependencyProperty(@class, addOwner));
                    }
                    if (@class.DependencyProperties.Where(static property => !property.IsDirect).Any() ||
                        @class.AttachedDependencyProperties.Where(static property => !property.IsDirect).Any())
                    {
                        var text = SourceGenerationHelper.GenerateStaticConstructor(
                            @class,
                            @class.AttachedDependencyProperties
                                .Where(static property => !property.IsDirect)
                                .Concat(@class.DependencyProperties.Where(static property => !property.IsDirect))
                                .ToArray());

                        if (!string.IsNullOrWhiteSpace(text))
                        {
                            context.AddTextSource(
                                hintName: $"{@class.Name}.StaticConstructor.generated.cs",
                                text: text);
                        }
                    }
                }
                if (platform == Platform.WPF)
                {
                    foreach (var addOwner in @class.AddOwner)
                    {
                        context.AddTextSource(
                            hintName: $"{@class.Name}.AddOwner.{addOwner.Name}.generated.cs",
                            text: SourceGenerationHelper.GenerateDependencyProperty(@class, addOwner));
                    }
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
        foreach (var group in classes.GroupBy(compilation.GetFullClassName))
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
            var isStaticClass = classSymbol.IsStatic;
            var methods = classSymbol
                .GetMembers()
                .OfType<IMethodSymbol>()
                // Roslyn bug?
                //.Where(static value => value.PartialImplementationPart != null)
                .Select(static value => value.ToDisplayString()
                    .Replace("?", string.Empty)
                    .TrimStart('.'))
                .ToArray();
            var dependencyProperties = new List<DependencyPropertyData>();
            var attachedDependencyProperties = new List<DependencyPropertyData>();
            var overrideMetadata = new List<DependencyPropertyData>();
            var addOwner = new List<DependencyPropertyData>();
            var attributes = @classSymbol.GetAttributes()
                .Where(static attribute => attribute.WhereFullNameIs(IsGeneratorAttribute))
                .Where(static attribute => attribute.ConstructorArguments.ElementAtOrDefault(0).Value is string)
                .ToDictionary(static attribute => attribute.ConstructorArguments[0].Value as string ?? string.Empty);
            foreach (var attributeSyntax in group
                .SelectMany(static list => list.AttributeLists)
                .SelectMany(static list => list.Attributes)
                .Where(attributeSyntax => attributeSyntax.WhereFullNameIs(compilation.GetSemanticModel(attributeSyntax.SyntaxTree), IsGeneratorAttribute)))
            {
                var name = attributeSyntax.ArgumentList?.Arguments[0].ToFullString().Trim('"') ?? string.Empty;
                name = name.RemoveNameof();
                var attribute = attributes[name];
                var attributeClass = attribute.AttributeClass?.ToDisplayString() ?? string.Empty;
                var type =
                    attribute.GetGenericTypeArgument(0)?.ToDisplayString() ??
                    attribute.ConstructorArguments.ElementAtOrDefault(1).Value?.ToString() ??
                    string.Empty;
                var isValueType =
                    attribute.GetGenericTypeArgument(0)?.IsValueType ??
                    attribute.ConstructorArguments.ElementAtOrDefault(1).Type?.IsValueType ??
                    true;
                var isSpecialType =
                    attribute.GetGenericTypeArgument(0).IsSpecialType() ??
                    (attribute.ConstructorArguments.ElementAtOrDefault(1).Value as ITypeSymbol)?.IsSpecialType() ??
                    false;
                var defaultValue =
                    attribute.GetProperty(nameof(DependencyPropertyAttribute.DefaultValueExpression))?.Value?.ToString() ??
                    attribute.GetProperty(nameof(DependencyPropertyAttribute.DefaultValue))?.Value?.ToString();
                var defaultValueDocumentation =
                    attribute.GetProperty(nameof(DependencyPropertyAttribute.DefaultValueExpression))?.Value?.ToString() ??
                    attributeSyntax.GetProperty(nameof(DependencyPropertyAttribute.DefaultValue));
                var browsableForType =
                    attribute.GetGenericTypeArgument(1)?.ToDisplayString() ??
                    attribute.GetProperty(nameof(AttachedDependencyPropertyAttribute.BrowsableForType))?.Value?.ToString();
                var fromType =
                    attribute.GetGenericTypeArgument(1)?.ToDisplayString() ??
                    attribute.GetProperty(nameof(AddOwnerAttribute.FromType))?.Value?.ToString();
                var isBrowsableForTypeSpecialType =
                    attribute.GetGenericTypeArgument(1).IsSpecialType() ??
                    (attribute.GetProperty(nameof(AttachedDependencyPropertyAttribute.BrowsableForType))?.Value as ITypeSymbol)?.IsSpecialType() ??
                    false;
                var isReadOnly = attributeSyntax.GetProperty(nameof(DependencyPropertyAttribute.IsReadOnly)) ?? bool.FalseString;
                var isDirect = attributeSyntax.GetProperty(nameof(DependencyPropertyAttribute.IsDirect)) ?? bool.FalseString;
                var isAttached = attributeClass.StartsWith(AttachedDependencyPropertyAttributeFullName, StringComparison.InvariantCulture);

                var description = attribute.GetProperty(nameof(DependencyPropertyAttribute.Description))?.Value?.ToString();
                var category = attribute.GetProperty(nameof(DependencyPropertyAttribute.Category))?.Value?.ToString();
                var typeConverter = attribute.GetProperty(nameof(DependencyPropertyAttribute.TypeConverter))?.Value?.ToString();
                var bindable = attributeSyntax.GetProperty(nameof(DependencyPropertyAttribute.Bindable));
                var browsable = attributeSyntax.GetProperty(nameof(DependencyPropertyAttribute.Browsable));
                var designerSerializationVisibility = attributeSyntax.GetProperty(nameof(DependencyPropertyAttribute.DesignerSerializationVisibility));
                var clsCompliant = attributeSyntax.GetProperty(nameof(DependencyPropertyAttribute.ClsCompliant));
                var localizability = attributeSyntax.GetProperty(nameof(DependencyPropertyAttribute.Localizability))?
                    .Replace("global::DependencyPropertyGenerator.Localizability.", string.Empty)
                    .Replace("DependencyPropertyGenerator.Localizability.", string.Empty)
                    .Replace("Localizability.", string.Empty);

                var xmlDocumentation = attribute.GetProperty(nameof(DependencyPropertyAttribute.XmlDocumentation))?.Value?.ToString();
                var propertyXmlDocumentation = attribute.GetProperty(nameof(DependencyPropertyAttribute.PropertyXmlDocumentation))?.Value?.ToString();
                var getterXmlDocumentation = attribute.GetProperty(nameof(AttachedDependencyPropertyAttribute.GetterXmlDocumentation))?.Value?.ToString();
                var setterXmlDocumentation = attribute.GetProperty(nameof(AttachedDependencyPropertyAttribute.SetterXmlDocumentation))?.Value?.ToString();
                var bindEvent = attribute.GetProperty(nameof(DependencyPropertyAttribute.BindEvent))?.Value?.ToString();
                var bindEvents = attribute.GetProperty(nameof(DependencyPropertyAttribute.BindEvents));
                var onChanged = attribute.GetProperty(nameof(DependencyPropertyAttribute.OnChanged))?.Value?.ToString();

                var affectsMeasure = attributeSyntax.GetProperty(nameof(DependencyPropertyAttribute.AffectsMeasure)) ?? bool.FalseString;
                var affectsArrange = attributeSyntax.GetProperty(nameof(DependencyPropertyAttribute.AffectsArrange)) ?? bool.FalseString;
                var affectsParentMeasure = attributeSyntax.GetProperty(nameof(DependencyPropertyAttribute.AffectsParentMeasure)) ?? bool.FalseString;
                var affectsParentArrange = attributeSyntax.GetProperty(nameof(DependencyPropertyAttribute.AffectsParentArrange)) ?? bool.FalseString;
                var affectsRender = attributeSyntax.GetProperty(nameof(DependencyPropertyAttribute.AffectsRender)) ?? bool.FalseString;
                var inherits = attributeSyntax.GetProperty(nameof(DependencyPropertyAttribute.Inherits)) ?? bool.FalseString;
                var overridesInheritanceBehavior = attributeSyntax.GetProperty(nameof(DependencyPropertyAttribute.OverridesInheritanceBehavior)) ?? bool.FalseString;
                var notDataBindable = attributeSyntax.GetProperty(nameof(DependencyPropertyAttribute.NotDataBindable)) ?? bool.FalseString;
                var journal = attributeSyntax.GetProperty(nameof(DependencyPropertyAttribute.Journal)) ?? bool.FalseString;
                var subPropertiesDoNotAffectRender = attributeSyntax.GetProperty(nameof(DependencyPropertyAttribute.SubPropertiesDoNotAffectRender)) ?? bool.FalseString;
                var isAnimationProhibited = attributeSyntax.GetProperty(nameof(DependencyPropertyAttribute.IsAnimationProhibited)) ?? bool.FalseString;
                var defaultUpdateSourceTrigger = attributeSyntax.GetProperty(nameof(DependencyPropertyAttribute.DefaultUpdateSourceTrigger))?
                    .Replace("global::DependencyPropertyGenerator.SourceTrigger.", string.Empty)
                    .Replace("DependencyPropertyGenerator.SourceTrigger.", string.Empty)
                    .Replace("SourceTrigger.", string.Empty);
                var defaultBindingMode = attributeSyntax.GetProperty(nameof(DependencyPropertyAttribute.DefaultBindingMode))?
                    .Replace("global::DependencyPropertyGenerator.DefaultBindingMode.", string.Empty)
                    .Replace("DefaultBindingMode.SourceTrigger.", string.Empty)
                    .Replace("DefaultBindingMode.", string.Empty);
                var enableDataValidation = attributeSyntax.GetProperty(nameof(DependencyPropertyAttribute.EnableDataValidation)) ?? bool.FalseString;
                var coerce = attributeSyntax.GetProperty(nameof(DependencyPropertyAttribute.Coerce)) ?? bool.FalseString;
                var validate = attributeSyntax.GetProperty(nameof(DependencyPropertyAttribute.Validate)) ?? bool.FalseString;
                var createDefaultValueCallback = attributeSyntax.GetProperty(nameof(DependencyPropertyAttribute.CreateDefaultValueCallback)) ?? bool.FalseString;

                var value = new DependencyPropertyData(
                    Name: name,
                    Type: type,
                    IsValueType: isValueType,
                    IsSpecialType: isSpecialType,
                    DefaultValue: defaultValue,
                    DefaultValueDocumentation: defaultValueDocumentation,
                    IsReadOnly: bool.Parse(isReadOnly),
                    IsDirect: bool.Parse(isDirect),
                    IsAttached: isAttached,
                    IsAddOwner: attributeClass.StartsWith(AddOwnerAttributeFullName, StringComparison.InvariantCulture),
                    Platform: platform,
                    Description: description,
                    Category: category,
                    TypeConverter: typeConverter,
                    Bindable: bindable,
                    Browsable: browsable,
                    DesignerSerializationVisibility: designerSerializationVisibility,
                    ClsCompliant: clsCompliant,
                    Localizability: localizability,
                    BrowsableForType: browsableForType,
                    FromType: fromType,
                    IsBrowsableForTypeSpecialType: isBrowsableForTypeSpecialType,
                    XmlDocumentation: xmlDocumentation,
                    GetterXmlDocumentation: getterXmlDocumentation ?? propertyXmlDocumentation,
                    SetterXmlDocumentation: setterXmlDocumentation,
                    BindEvents: bindEvent != null
                        ? new[] { bindEvent }
                        : bindEvents?.Kind == TypedConstantKind.Array
                            ? bindEvents.Value.Values
                                .Select(static value => value.Value?.ToString() ?? string.Empty)
                                .Where(value => !string.IsNullOrWhiteSpace(value))
                                .ToArray()
                            : Array.Empty<string>(),
                    OnChanged: onChanged ?? string.Empty,
                    AffectsMeasure: bool.Parse(affectsMeasure),
                    AffectsArrange: bool.Parse(affectsArrange),
                    AffectsParentMeasure: bool.Parse(affectsParentMeasure),
                    AffectsParentArrange: bool.Parse(affectsParentArrange),
                    AffectsRender: bool.Parse(affectsRender),
                    Inherits: bool.Parse(inherits),
                    OverridesInheritanceBehavior: bool.Parse(overridesInheritanceBehavior),
                    NotDataBindable: bool.Parse(notDataBindable),
                    Journal: bool.Parse(journal),
                    SubPropertiesDoNotAffectRender: bool.Parse(subPropertiesDoNotAffectRender),
                    IsAnimationProhibited: bool.Parse(isAnimationProhibited),
                    DefaultUpdateSourceTrigger: defaultUpdateSourceTrigger,
                    DefaultBindingMode: defaultBindingMode,
                    EnableDataValidation: bool.Parse(enableDataValidation),
                    Coerce: bool.Parse(coerce),
                    Validate: bool.Parse(validate),
                    CreateDefaultValueCallback: bool.Parse(createDefaultValueCallback));

                if (attributeClass.StartsWith(OverrideMetadataAttributeFullName, StringComparison.InvariantCulture))
                {
                    overrideMetadata.Add(value);
                }
                else if (attributeClass.StartsWith(AddOwnerAttributeFullName, StringComparison.InvariantCulture))
                {
                    addOwner.Add(value);
                }
                else if (isAttached)
                {
                    attachedDependencyProperties.Add(value);
                }
                else
                {
                    dependencyProperties.Add(value);
                }
            }

            values.Add(new ClassData(
                Namespace: @namespace,
                Name: className,
                FullName: fullClassName,
                Modifiers: classModifiers,
                IsStatic: isStaticClass,
                Platform: platform,
                Methods: methods,
                DependencyProperties: dependencyProperties,
                AttachedDependencyProperties: attachedDependencyProperties,
                RoutedEvents: Array.Empty<EventData>(),
                WeakEvents: Array.Empty<EventData>(),
                OverrideMetadata: overrideMetadata,
                AddOwner: addOwner));
        }

        return values;
    }
    
    private static bool IsGeneratorAttribute(string fullTypeName)
    {
        return
            fullTypeName.StartsWith(AttachedDependencyPropertyAttributeFullName, StringComparison.InvariantCulture) ||
            fullTypeName.StartsWith(DependencyPropertyAttributeFullName, StringComparison.InvariantCulture) ||
            fullTypeName.StartsWith(OverrideMetadataAttributeFullName, StringComparison.InvariantCulture) ||
            fullTypeName.StartsWith(AddOwnerAttributeFullName, StringComparison.InvariantCulture);
    }

    #endregion
}
