using System.Collections.Immutable;
using System.Diagnostics;
using H.Generators.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using AttachedDependencyPropertyAttribute = DependencyPropertyGenerator.AttachedDependencyPropertyAttribute;
using DependencyPropertyAttribute = DependencyPropertyGenerator.DependencyPropertyAttribute;
using RoutedEventAttribute = DependencyPropertyGenerator.RoutedEventAttribute;
using OverrideMetadataAttribute = DependencyPropertyGenerator.OverrideMetadataAttribute;
using AddOwnerAttribute = DependencyPropertyGenerator.AddOwnerAttribute;

namespace H.Generators;

[Generator]
public class DependencyPropertyGenerator : IIncrementalGenerator
{
    #region Constants

    public const string Name = nameof(DependencyPropertyGenerator);
    public const string Id = "DPG";

    private static string AttachedDependencyPropertyAttributeFullName => typeof(AttachedDependencyPropertyAttribute).FullName;
    private static string DependencyPropertyAttributeFullName => typeof(DependencyPropertyAttribute).FullName;
    private static string RoutedEventAttributeFullName => typeof(RoutedEventAttribute).FullName;
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
            .Any(attributeSyntax => IsGeneratorAttribute(attributeSyntax, context.SemanticModel))
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
                if (platform == Platform.UWP ||
                    platform == Platform.WinUI ||
                    platform == Platform.Uno ||
                    platform == Platform.UnoWinUI)
                {
                    if (@class.OverrideMetadata.Any())
                    {
                        context.AddTextSource(
                            hintName: $"{@class.Name}.Methods.RegisterPropertyChangedCallbacks.generated.cs",
                            text: SourceGenerationHelper.GenerateRegisterPropertyChangedCallbacksMethod(@class, @class.OverrideMetadata));
                    }
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
                    if (@class.OverrideMetadata.Any())
                    {
                        context.AddTextSource(
                            hintName: $"{@class.Name}.StaticConstructor.generated.cs",
                            text: SourceGenerationHelper.GenerateStaticConstructor(@class, @class.OverrideMetadata));
                    }
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
            var methods = classSymbol
                .GetMembers()
                .OfType<IMethodSymbol>()
                // Roslyn bug?
                //.Where(static value => value.PartialImplementationPart != null)
                .Select(static value => value.ToDisplayString()
                    .Replace(value.ReceiverType?.ToDisplayString(), string.Empty)
                    .Replace("?", string.Empty)
                    .TrimStart('.'))
                .ToArray();
            var dependencyProperties = new List<DependencyPropertyData>();
            var attachedDependencyProperties = new List<DependencyPropertyData>();
            var routedEvents = new List<RoutedEventData>();
            var overrideMetadata = new List<DependencyPropertyData>();
            var addOwner = new List<DependencyPropertyData>();
            var attributes = @classSymbol.GetAttributes()
                .Where(IsGeneratorAttribute)
                .Where(static attribute => attribute.ConstructorArguments.ElementAtOrDefault(0).Value is string)
                .ToDictionary(static attribute => attribute.ConstructorArguments[0].Value as string ?? string.Empty);
            foreach (var attributeSyntax in group
                .SelectMany(static list => list.AttributeLists)
                .SelectMany(static list => list.Attributes)
                .Where(attributeSyntax => IsGeneratorAttribute(attributeSyntax, compilation.GetSemanticModel(attributeSyntax.SyntaxTree))))
            {
                var name = attributeSyntax.ArgumentList?.Arguments[0].ToFullString()?.Trim('"') ?? string.Empty;
                name = RemoveNameof(name);
                var attribute = attributes[name];
                var attributeClass = attribute.AttributeClass?.ToDisplayString() ?? string.Empty;
                if (attributeClass.StartsWith(RoutedEventAttributeFullName))
                {
                    var strategy = attributeSyntax.ArgumentList?.Arguments[1].ToFullString()?
                        .Replace("RoutedEventStrategy.", string.Empty) ?? string.Empty;
                    var type =
                        GetGenericTypeArgumentFromAttributeData(attribute, 0)?.ToDisplayString() ??
                        GetPropertyFromAttributeData(attribute, nameof(RoutedEventAttribute.Type))?.Value?.ToString();
                    var isAttached = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(RoutedEventAttribute.IsAttached)) ?? bool.FalseString;
                    
                    var description = GetPropertyFromAttributeData(attribute, nameof(RoutedEventAttribute.Description))?.Value?.ToString();
                    var category = GetPropertyFromAttributeData(attribute, nameof(RoutedEventAttribute.Category))?.Value?.ToString();

                    var xmlDocumentation = GetPropertyFromAttributeData(attribute, nameof(RoutedEventAttribute.XmlDocumentation))?.Value?.ToString();
                    var eventXmlDocumentation = GetPropertyFromAttributeData(attribute, nameof(RoutedEventAttribute.EventXmlDocumentation))?.Value?.ToString();

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
                        IsSpecialType(attribute.ConstructorArguments.ElementAtOrDefault(1).Value as ITypeSymbol) ??
                        false;
                    var defaultValue =
                        GetPropertyFromAttributeData(attribute, nameof(DependencyPropertyAttribute.DefaultValueExpression))?.Value?.ToString() ??
                        GetPropertyFromAttributeData(attribute, nameof(DependencyPropertyAttribute.DefaultValue))?.Value?.ToString();
                    var defaultValueDocumentation =
                        GetPropertyFromAttributeData(attribute, nameof(DependencyPropertyAttribute.DefaultValueExpression))?.Value?.ToString() ??
                        GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyAttribute.DefaultValue));
                    var browsableForType =
                        GetGenericTypeArgumentFromAttributeData(attribute, 1)?.ToDisplayString() ??
                        GetPropertyFromAttributeData(attribute, nameof(AttachedDependencyPropertyAttribute.BrowsableForType))?.Value?.ToString();
                    var fromType =
                        GetGenericTypeArgumentFromAttributeData(attribute, 1)?.ToDisplayString() ??
                        GetPropertyFromAttributeData(attribute, nameof(AddOwnerAttribute.FromType))?.Value?.ToString();
                    var isBrowsableForTypeSpecialType =
                        IsSpecialType(GetGenericTypeArgumentFromAttributeData(attribute, 1)) ??
                        IsSpecialType(GetPropertyFromAttributeData(attribute, nameof(AttachedDependencyPropertyAttribute.BrowsableForType))?.Value as ITypeSymbol) ??
                        false;
                    var isReadOnly = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyAttribute.IsReadOnly)) ?? bool.FalseString;
                    var isDirect = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyAttribute.IsDirect)) ?? bool.FalseString;
                    var isAttached = attributeClass.StartsWith(AttachedDependencyPropertyAttributeFullName);

                    var description = GetPropertyFromAttributeData(attribute, nameof(DependencyPropertyAttribute.Description))?.Value?.ToString();
                    var category = GetPropertyFromAttributeData(attribute, nameof(DependencyPropertyAttribute.Category))?.Value?.ToString();
                    var typeConverter = GetPropertyFromAttributeData(attribute, nameof(DependencyPropertyAttribute.TypeConverter))?.Value?.ToString();
                    var bindable = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyAttribute.Bindable));
                    var browsable = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyAttribute.Browsable));
                    var designerSerializationVisibility = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyAttribute.DesignerSerializationVisibility));
                    var clsCompliant = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyAttribute.CLSCompliant));
                    var localizability = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyAttribute.Localizability))?
                        .Replace("global::DependencyPropertyGenerator.Localizability.", string.Empty)
                        .Replace("DependencyPropertyGenerator.Localizability.", string.Empty)
                        .Replace("Localizability.", string.Empty);

                    var xmlDocumentation = GetPropertyFromAttributeData(attribute, nameof(DependencyPropertyAttribute.XmlDocumentation))?.Value?.ToString();
                    var propertyXmlDocumentation = GetPropertyFromAttributeData(attribute, nameof(DependencyPropertyAttribute.PropertyXmlDocumentation))?.Value?.ToString();
                    var getterXmlDocumentation = GetPropertyFromAttributeData(attribute, nameof(AttachedDependencyPropertyAttribute.GetterXmlDocumentation))?.Value?.ToString();
                    var setterXmlDocumentation = GetPropertyFromAttributeData(attribute, nameof(AttachedDependencyPropertyAttribute.SetterXmlDocumentation))?.Value?.ToString();
                    var bindEvent = GetPropertyFromAttributeData(attribute, nameof(DependencyPropertyAttribute.BindEvent))?.Value?.ToString();
                    var bindEvents = GetPropertyFromAttributeData(attribute, nameof(DependencyPropertyAttribute.BindEvents));
                    var onChanged = GetPropertyFromAttributeData(attribute, nameof(DependencyPropertyAttribute.OnChanged))?.Value?.ToString();

                    var affectsMeasure = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyAttribute.AffectsMeasure)) ?? bool.FalseString;
                    var affectsArrange = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyAttribute.AffectsArrange)) ?? bool.FalseString;
                    var affectsParentMeasure = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyAttribute.AffectsParentMeasure)) ?? bool.FalseString;
                    var affectsParentArrange = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyAttribute.AffectsParentArrange)) ?? bool.FalseString;
                    var affectsRender = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyAttribute.AffectsRender)) ?? bool.FalseString;
                    var inherits = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyAttribute.Inherits)) ?? bool.FalseString;
                    var overridesInheritanceBehavior = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyAttribute.OverridesInheritanceBehavior)) ?? bool.FalseString;
                    var notDataBindable = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyAttribute.NotDataBindable)) ?? bool.FalseString;
                    var journal = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyAttribute.Journal)) ?? bool.FalseString;
                    var subPropertiesDoNotAffectRender = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyAttribute.SubPropertiesDoNotAffectRender)) ?? bool.FalseString;
                    var isAnimationProhibited = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyAttribute.IsAnimationProhibited)) ?? bool.FalseString;
                    var defaultUpdateSourceTrigger = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyAttribute.DefaultUpdateSourceTrigger))?
                        .Replace("global::DependencyPropertyGenerator.SourceTrigger.", string.Empty)
                        .Replace("DependencyPropertyGenerator.SourceTrigger.", string.Empty)
                        .Replace("SourceTrigger.", string.Empty);
                    var defaultBindingMode = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyAttribute.DefaultBindingMode))?
                        .Replace("global::DependencyPropertyGenerator.DefaultBindingMode.", string.Empty)
                        .Replace("DefaultBindingMode.SourceTrigger.", string.Empty)
                        .Replace("DefaultBindingMode.", string.Empty);
                    var enableDataValidation = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyAttribute.EnableDataValidation)) ?? bool.FalseString;
                    var coerce = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyAttribute.Coerce)) ?? bool.FalseString;
                    var validate = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyAttribute.Validate)) ?? bool.FalseString;
                    var createDefaultValueCallback = GetPropertyFromAttributeSyntax(attributeSyntax, nameof(DependencyPropertyAttribute.CreateDefaultValueCallback)) ?? bool.FalseString;

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
                        IsAddOwner: attributeClass.StartsWith(AddOwnerAttributeFullName),
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
                        FromType: fromType,
                        IsBrowsableForTypeSpecialType: isBrowsableForTypeSpecialType,
                        XmlDocumentation: xmlDocumentation,
                        GetterXmlDocumentation: getterXmlDocumentation ?? propertyXmlDocumentation,
                        SetterXmlDocumentation: setterXmlDocumentation,
                        BindEvents: bindEvent != null
                            ? new[] { bindEvent }
                            : bindEvents?.Kind == TypedConstantKind.Array
                                ? bindEvents?.Values
                                    .Select(static value => value.Value?.ToString() ?? string.Empty)
                                    .Where(value => !string.IsNullOrWhiteSpace(value))
                                    .ToArray() ?? Array.Empty<string>()
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

                    if (attributeClass.StartsWith(OverrideMetadataAttributeFullName))
                    {
                        overrideMetadata.Add(value);
                    }
                    else if (attributeClass.StartsWith(AddOwnerAttributeFullName))
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
            }

            values.Add(new ClassData(
                Namespace: @namespace,
                Name: className,
                FullName: fullClassName,
                Modifiers: classModifiers,
                Platform: platform,
                Methods: methods,
                DependencyProperties: dependencyProperties,
                AttachedDependencyProperties: attachedDependencyProperties,
                RoutedEvents: routedEvents,
                OverrideMetadata: overrideMetadata,
                AddOwner: addOwner));
        }

        return values;
    }

    private static string RemoveNameof(string value)
    {
        return value.Contains("nameof(")
            ? value
                .Substring(value.LastIndexOf('.') + 1)
                .TrimEnd(')', ' ')
            : value;
    }

    private static bool IsGeneratorAttribute(string fullTypeName)
    {
        return
            fullTypeName.StartsWith(AttachedDependencyPropertyAttributeFullName) ||
            fullTypeName.StartsWith(DependencyPropertyAttributeFullName) ||
            fullTypeName.StartsWith(RoutedEventAttributeFullName) ||
            fullTypeName.StartsWith(OverrideMetadataAttributeFullName) ||
            fullTypeName.StartsWith(AddOwnerAttributeFullName);
    }

    private static bool IsGeneratorAttribute(AttributeSyntax attributeSyntax, SemanticModel semanticModel)
    {
        if (semanticModel.GetSymbolInfo(attributeSyntax).Symbol is not IMethodSymbol attributeSymbol)
        {
            return false;
        }

        var attributeContainingTypeSymbol = attributeSymbol.ContainingType;
        var fullName = attributeContainingTypeSymbol.ToDisplayString();

        return IsGeneratorAttribute(fullName);
    }

    private static bool IsGeneratorAttribute(AttributeData attributeData)
{
        var attributeClass = attributeData.AttributeClass?.ToDisplayString() ?? string.Empty;

        return IsGeneratorAttribute(attributeClass);
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

        return
            symbol.SpecialType != SpecialType.None ||
            (symbol.OriginalDefinition.SpecialType == SpecialType.System_Nullable_T &&
            symbol.BaseType != null &&
            symbol.BaseType.SpecialType != SpecialType.None);
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
                var nameEquals = syntax.NameEquals?.ToFullString()?
                    .Trim('=', ' ', '\t', '\r', '\n');
                
                return nameEquals == name;
            })?
            .Expression
            .ToFullString();
    }

    #endregion
}
