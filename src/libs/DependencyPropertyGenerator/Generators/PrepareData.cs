using System.ComponentModel;
using DependencyPropertyGenerator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace H.Generators;

public static class PrepareData
{
    public static DependencyPropertyData GetDependencyPropertyData(
        this AttributeData attribute,
        Framework framework,
        AttributeSyntax? attributeSyntax = null,
        bool isAddOwner = false,
        bool isAttached = false)
    {
        attribute = attribute ?? throw new ArgumentNullException(nameof(attribute));
        
        var name =
            attribute.ConstructorArguments.ElementAtOrDefault(0).Value?.ToString() ??
            string.Empty;
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
            attributeSyntax?.GetProperty(nameof(DependencyPropertyAttribute.DefaultValue));
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
        var isReadOnly = attribute.GetProperty(nameof(DependencyPropertyAttribute.IsReadOnly))?.Value?.ToString() ?? bool.FalseString;
        var isDirect = attribute.GetProperty(nameof(DependencyPropertyAttribute.IsDirect))?.Value?.ToString() ?? bool.FalseString;

        var description = attribute.GetProperty(nameof(DependencyPropertyAttribute.Description))?.Value?.ToString();
        var category = attribute.GetProperty(nameof(DependencyPropertyAttribute.Category))?.Value?.ToString();
        var typeConverter = attribute.GetProperty(nameof(DependencyPropertyAttribute.TypeConverter))?.Value?.ToString();
        var bindable = attribute.GetProperty(nameof(DependencyPropertyAttribute.Bindable))?.ToBoolean();
        var browsable = attribute.GetProperty(nameof(DependencyPropertyAttribute.Browsable))?.ToBoolean();
        var designerSerializationVisibility = attribute.GetProperty(nameof(DependencyPropertyAttribute.DesignerSerializationVisibility))
            .ToEnum<DesignerSerializationVisibility>()?
            .ToString("G");
        var clsCompliant = attribute.GetProperty(nameof(DependencyPropertyAttribute.ClsCompliant))?.ToBoolean();
        var localizability = attribute.GetProperty(nameof(DependencyPropertyAttribute.Localizability))
            .ToEnum<Localizability>()?
            .ToString("G");

        var xmlDocumentation = attribute.GetProperty(nameof(DependencyPropertyAttribute.XmlDocumentation))?.Value?.ToString();
        var propertyXmlDocumentation = attribute.GetProperty(nameof(DependencyPropertyAttribute.PropertyXmlDocumentation))?.Value?.ToString();
        var getterXmlDocumentation = attribute.GetProperty(nameof(AttachedDependencyPropertyAttribute.GetterXmlDocumentation))?.Value?.ToString();
        var setterXmlDocumentation = attribute.GetProperty(nameof(AttachedDependencyPropertyAttribute.SetterXmlDocumentation))?.Value?.ToString();
        var bindEvent = attribute.GetProperty(nameof(DependencyPropertyAttribute.BindEvent))?.Value?.ToString();
        var bindEvents = attribute.GetProperty(nameof(DependencyPropertyAttribute.BindEvents));
        var onChanged = attribute.GetProperty(nameof(DependencyPropertyAttribute.OnChanged))?.Value?.ToString();

        var affectsMeasure = attribute.GetProperty(nameof(DependencyPropertyAttribute.AffectsMeasure))?.Value?.ToString() ?? bool.FalseString;
        var affectsArrange = attribute.GetProperty(nameof(DependencyPropertyAttribute.AffectsArrange))?.Value?.ToString() ?? bool.FalseString;
        var affectsParentMeasure = attribute.GetProperty(nameof(DependencyPropertyAttribute.AffectsParentMeasure))?.Value?.ToString() ?? bool.FalseString;
        var affectsParentArrange = attribute.GetProperty(nameof(DependencyPropertyAttribute.AffectsParentArrange))?.Value?.ToString() ?? bool.FalseString;
        var affectsRender = attribute.GetProperty(nameof(DependencyPropertyAttribute.AffectsRender))?.Value?.ToString() ?? bool.FalseString;
        var inherits = attribute.GetProperty(nameof(DependencyPropertyAttribute.Inherits))?.Value?.ToString() ?? bool.FalseString;
        var overridesInheritanceBehavior = attribute.GetProperty(nameof(DependencyPropertyAttribute.OverridesInheritanceBehavior))?.Value?.ToString() ?? bool.FalseString;
        var notDataBindable = attribute.GetProperty(nameof(DependencyPropertyAttribute.NotDataBindable))?.Value?.ToString() ?? bool.FalseString;
        var journal = attribute.GetProperty(nameof(DependencyPropertyAttribute.Journal))?.Value?.ToString() ?? bool.FalseString;
        var subPropertiesDoNotAffectRender = attribute.GetProperty(nameof(DependencyPropertyAttribute.SubPropertiesDoNotAffectRender))?.Value?.ToString() ?? bool.FalseString;
        var isAnimationProhibited = attribute.GetProperty(nameof(DependencyPropertyAttribute.IsAnimationProhibited))?.Value?.ToString() ?? bool.FalseString;
        var defaultUpdateSourceTrigger = attribute.GetProperty(nameof(DependencyPropertyAttribute.DefaultUpdateSourceTrigger))
            .ToEnum<SourceTrigger>()?
            .ToString("G");
        var defaultBindingMode = attribute.GetProperty(nameof(DependencyPropertyAttribute.DefaultBindingMode))
            .ToEnum<DefaultBindingMode>()?
            .ToString("G");
        var enableDataValidation = attribute.GetProperty(nameof(DependencyPropertyAttribute.EnableDataValidation))?.Value?.ToString() ?? bool.FalseString;
        var coerce = attribute.GetProperty(nameof(DependencyPropertyAttribute.Coerce))?.Value?.ToString() ?? bool.FalseString;
        var validate = attribute.GetProperty(nameof(DependencyPropertyAttribute.Validate))?.Value?.ToString() ?? bool.FalseString;
        var createDefaultValueCallback = attribute.GetProperty(nameof(DependencyPropertyAttribute.CreateDefaultValueCallback))?.Value?.ToString() ?? bool.FalseString;
        
        return new DependencyPropertyData(
            Name: name,
            Type: type,
            IsValueType: isValueType,
            IsSpecialType: isSpecialType,
            DefaultValue: defaultValue,
            DefaultValueDocumentation: defaultValueDocumentation,
            IsReadOnly: bool.Parse(isReadOnly),
            IsDirect: bool.Parse(isDirect),
            IsAttached: isAttached,
            IsAddOwner: isAddOwner,
            Framework: framework,
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
    }
    
    public static EventData GetEventData(this AttributeData attribute, bool isStaticClass)
    {
        attribute = attribute ?? throw new ArgumentNullException(nameof(attribute));
        
        var name =
            attribute.ConstructorArguments.ElementAtOrDefault(0).Value?.ToString() ??
            string.Empty;
        var strategy = attribute.ConstructorArguments.ElementAtOrDefault(1)
            .ToEnum(defaultValue: RoutedEventStrategy.Direct)
            .ToString("G");
        var isStatic = attribute.GetProperty(nameof(WeakEventAttribute.IsStatic))?.Value?.ToString() ?? bool.FalseString;
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
        var isAttached = attribute.GetProperty(nameof(RoutedEventAttribute.IsAttached))?.Value?.ToString() ?? bool.FalseString;
        var description = attribute.GetProperty(nameof(RoutedEventAttribute.Description))?.Value?.ToString();
        var category = attribute.GetProperty(nameof(RoutedEventAttribute.Category))?.Value?.ToString();

        var xmlDocumentation = attribute.GetProperty(nameof(RoutedEventAttribute.XmlDocumentation))?.Value?.ToString();
        var eventXmlDocumentation = attribute.GetProperty(nameof(RoutedEventAttribute.EventXmlDocumentation))?.Value?.ToString();

        var winRtEvents = attribute.GetProperty(nameof(RoutedEventAttribute.WinRtEvents))?.Value?.ToString() ?? bool.FalseString;

        return new EventData(
            Name: name,
            Strategy: strategy,
            Type: type,
            IsValueType: isValueType,
            IsSpecialType: isSpecialType,
            IsAttached: bool.Parse(isAttached) || bool.Parse(isStatic) || isStaticClass,
            Description: description,
            Category: category,
            XmlDocumentation: xmlDocumentation,
            EventXmlDocumentation: eventXmlDocumentation,
            WinRtEvents: bool.Parse(winRtEvents));
    }
    
    public static ClassData GetClassData(
        this INamedTypeSymbol classSymbol,
        Framework framework)
    {
        classSymbol = classSymbol ?? throw new ArgumentNullException(nameof(classSymbol));
        
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
                .Replace("?", string.Empty)
                .TrimStart('.'))
            .ToArray();
        
        return new ClassData(
            Namespace: @namespace,
            Name: className,
            FullName: fullClassName,
            Modifiers: classModifiers,
            IsStatic: isStaticClass,
            Framework: framework,
            Methods: methods);
    }
}
