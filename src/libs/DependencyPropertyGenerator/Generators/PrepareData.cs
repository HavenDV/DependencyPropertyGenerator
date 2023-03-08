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
            attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.DefaultValueExpression)).Value?.ToString() ??
            attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.DefaultValue)).Value?.ToString();
        var defaultValueDocumentation =
            attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.DefaultValueExpression)).Value?.ToString() ??
            attributeSyntax?.GetNamedArgumentExpression(nameof(DependencyPropertyAttribute.DefaultValue));
        var browsableForType =
            attribute.GetGenericTypeArgument(1)?.ToDisplayString() ??
            attribute.GetNamedArgument(nameof(AttachedDependencyPropertyAttribute.BrowsableForType)).Value?.ToString();
        var fromType =
            attribute.GetGenericTypeArgument(1)?.ToDisplayString() ??
            attribute.GetNamedArgument(nameof(AddOwnerAttribute.FromType)).Value?.ToString();
        var isBrowsableForTypeSpecialType =
            attribute.GetGenericTypeArgument(1).IsSpecialType() ??
            (attribute.GetNamedArgument(nameof(AttachedDependencyPropertyAttribute.BrowsableForType)).Value as ITypeSymbol)?.IsSpecialType() ??
            false;
        var isReadOnly = attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.IsReadOnly)).ToBoolean();
        var isDirect = attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.IsDirect)).ToBoolean();

        var description = attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.Description)).Value?.ToString();
        var category = attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.Category)).Value?.ToString();
        var typeConverter = attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.TypeConverter)).Value?.ToString();
        var bindable = attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.Bindable)).ToNullableBoolean();
        var browsable = attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.Browsable)).ToNullableBoolean();
        var designerSerializationVisibility = attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.DesignerSerializationVisibility))
            .ToEnum<DesignerSerializationVisibility>()?
            .ToString("G");
        var clsCompliant = attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.ClsCompliant)).ToNullableBoolean();
        var localizability = attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.Localizability))
            .ToEnum<Localizability>()?
            .ToString("G");

        var xmlDocumentation = attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.XmlDocumentation)).Value?.ToString();
        var propertyXmlDocumentation = attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.PropertyXmlDocumentation)).Value?.ToString();
        var getterXmlDocumentation = attribute.GetNamedArgument(nameof(AttachedDependencyPropertyAttribute.GetterXmlDocumentation)).Value?.ToString();
        var setterXmlDocumentation = attribute.GetNamedArgument(nameof(AttachedDependencyPropertyAttribute.SetterXmlDocumentation)).Value?.ToString();
        var bindEvent = attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.BindEvent)).Value?.ToString();
        var bindEvents = attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.BindEvents));
        var onChanged = attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.OnChanged)).Value?.ToString();

        var affectsMeasure = attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.AffectsMeasure)).ToBoolean();
        var affectsArrange = attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.AffectsArrange)).ToBoolean();
        var affectsParentMeasure = attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.AffectsParentMeasure)).ToBoolean();
        var affectsParentArrange = attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.AffectsParentArrange)).ToBoolean();
        var affectsRender = attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.AffectsRender)).ToBoolean();
        var inherits = attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.Inherits)).ToBoolean();
        var overridesInheritanceBehavior = attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.OverridesInheritanceBehavior)).ToBoolean();
        var notDataBindable = attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.NotDataBindable)).ToBoolean();
        var journal = attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.Journal)).ToBoolean();
        var subPropertiesDoNotAffectRender = attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.SubPropertiesDoNotAffectRender)).ToBoolean();
        var isAnimationProhibited = attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.IsAnimationProhibited)).ToBoolean();
        var defaultUpdateSourceTrigger = attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.DefaultUpdateSourceTrigger))
            .ToEnum<SourceTrigger>()?
            .ToString("G");
        var defaultBindingMode = attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.DefaultBindingMode))
            .ToEnum<DefaultBindingMode>()?
            .ToString("G");
        var enableDataValidation = attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.EnableDataValidation)).ToBoolean();
        var coerce = attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.Coerce)).ToBoolean();
        var validate = attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.Validate)).ToBoolean();
        var createDefaultValueCallback = attribute.GetNamedArgument(nameof(DependencyPropertyAttribute.CreateDefaultValueCallback)).ToBoolean();
        
        return new DependencyPropertyData(
            Name: name,
            Type: type,
            IsValueType: isValueType,
            IsSpecialType: isSpecialType,
            DefaultValue: defaultValue,
            DefaultValueDocumentation: defaultValueDocumentation,
            IsReadOnly:isReadOnly,
            IsDirect: isDirect,
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
                : bindEvents.Kind == TypedConstantKind.Array
                    ? bindEvents.Values
                        .Select(static value => value.Value?.ToString() ?? string.Empty)
                        .Where(value => !string.IsNullOrWhiteSpace(value))
                        .ToArray()
                    : Array.Empty<string>(),
            OnChanged: onChanged ?? string.Empty,
            AffectsMeasure: affectsMeasure,
            AffectsArrange: affectsArrange,
            AffectsParentMeasure: affectsParentMeasure,
            AffectsParentArrange: affectsParentArrange,
            AffectsRender: affectsRender,
            Inherits: inherits,
            OverridesInheritanceBehavior: overridesInheritanceBehavior,
            NotDataBindable: notDataBindable,
            Journal: journal,
            SubPropertiesDoNotAffectRender: subPropertiesDoNotAffectRender,
            IsAnimationProhibited: isAnimationProhibited,
            DefaultUpdateSourceTrigger: defaultUpdateSourceTrigger,
            DefaultBindingMode: defaultBindingMode,
            EnableDataValidation: enableDataValidation,
            Coerce: coerce,
            Validate: validate,
            CreateDefaultValueCallback: createDefaultValueCallback);
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
        var isStatic = attribute.GetNamedArgument(nameof(WeakEventAttribute.IsStatic)).ToBoolean();
        var type =
            attribute.GetGenericTypeArgument(0)?.ToDisplayString() ??
            attribute.GetNamedArgument(nameof(RoutedEventAttribute.Type)).Value?.ToString() ??
            string.Empty;
        var isValueType =
            attribute.GetGenericTypeArgument(0)?.IsValueType ??
            attribute.ConstructorArguments.ElementAtOrDefault(1).Type?.IsValueType ??
            true;
        var isSpecialType =
            attribute.GetGenericTypeArgument(0).IsSpecialType() ??
            (attribute.ConstructorArguments.ElementAtOrDefault(1).Value as ITypeSymbol)?.IsSpecialType() ??
            false;
        var isAttached = attribute.GetNamedArgument(nameof(RoutedEventAttribute.IsAttached)).ToBoolean();
        var description = attribute.GetNamedArgument(nameof(RoutedEventAttribute.Description)).Value?.ToString();
        var category = attribute.GetNamedArgument(nameof(RoutedEventAttribute.Category)).Value?.ToString();

        var xmlDocumentation = attribute.GetNamedArgument(nameof(RoutedEventAttribute.XmlDocumentation)).Value?.ToString();
        var eventXmlDocumentation = attribute.GetNamedArgument(nameof(RoutedEventAttribute.EventXmlDocumentation)).Value?.ToString();

        var winRtEvents = attribute.GetNamedArgument(nameof(RoutedEventAttribute.WinRtEvents)).ToBoolean();

        return new EventData(
            Name: name,
            Strategy: strategy,
            Type: type,
            IsValueType: isValueType,
            IsSpecialType: isSpecialType,
            IsAttached: isAttached || isStatic || isStaticClass,
            Description: description,
            Category: category,
            XmlDocumentation: xmlDocumentation,
            EventXmlDocumentation: eventXmlDocumentation,
            WinRtEvents: winRtEvents);
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
