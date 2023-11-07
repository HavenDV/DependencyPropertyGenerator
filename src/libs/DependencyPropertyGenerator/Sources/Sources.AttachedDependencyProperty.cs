using H.Generators.Extensions;

namespace H.Generators;

internal static partial class Sources
{
    public static string GenerateAttachedDependencyProperty(ClassData @class, DependencyPropertyData property)
    {
        return @$"
#nullable enable

namespace {@class.Namespace}
{{
    {GenerateModifiers(@class)}partial class {@class.Name}{GenerateBaseType(@class)}
    {{
{GenerateXmlDocumentationFrom(property.XmlDocumentation, property, isProperty: false)}
{GenerateGeneratedCodeAttribute()}
        {GeneratePropertyModifier(property)} static readonly {GeneratePropertyType(@class, property)} {GenerateDependencyPropertyName(property)} =
            {GenerateManagerType(@class)}.{GenerateRegisterMethod(@class, property)}(
                {GenerateRegisterAttachedMethodArguments(@class, property)});

{GenerateAdditionalPropertyForReadOnlyProperties(property)}
{GenerateXmlDocumentationFrom(property.SetterXmlDocumentation, property, isProperty: true)}
{GenerateCategoryAttribute(property.Category)}
{GenerateDescriptionAttribute(property.Description)}
{GenerateTypeConverterAttribute(property.TypeConverter)}
{GenerateBindableAttribute(property.Bindable)}
{GenerateBrowsableAttribute(property.Browsable)}
{GenerateDesignerSerializationVisibilityAttribute(property.DesignerSerializationVisibility)}
{GenerateClsCompliantAttribute(property.ClsCompliant)}
{GenerateLocalizabilityAttribute(property.Localizability, @class.Framework)}
{GenerateGeneratedCodeAttribute()}
{GenerateExcludeFromCodeCoverageAttribute()}
        {(property.IsReadOnly ? "internal" : "public")} static void Set{property.Name}({GenerateDependencyObjectType(@class.Framework)} element, {GenerateType(property)} value)
        {{
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue({GenerateDependencyPropertyName(property)}, value);
        }}

{GenerateXmlDocumentationFrom(property.GetterXmlDocumentation, property, isProperty: true)}
{GenerateCategoryAttribute(property.Category)}
{GenerateDescriptionAttribute(property.Description)}
{GenerateTypeConverterAttribute(property.TypeConverter)}
{GenerateBindableAttribute(property.Bindable)}
{GenerateBrowsableAttribute(property.Browsable)}
{GenerateDesignerSerializationVisibilityAttribute(property.DesignerSerializationVisibility)}
{GenerateBrowsableForTypeAttribute(property)}
{GenerateClsCompliantAttribute(property.ClsCompliant)}
{GenerateLocalizabilityAttribute(property.Localizability, @class.Framework)}
{GenerateGeneratedCodeAttribute()}
{GenerateExcludeFromCodeCoverageAttribute()}
        public static {GenerateType(property)} Get{property.Name}({GenerateDependencyObjectType(@class.Framework)} element)
        {{
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return ({GenerateType(property)})element.GetValue({property.Name}Property);
        }}

{GenerateOnChangedMethods(property)}
{GenerateOnChangingMethods(property)}
{GenerateCoercePartialMethod(property)}
{GenerateValidatePartialMethod(property)}
{GenerateCreateDefaultValueCallbackPartialMethod(property)}
{GenerateBindEventMethod(property)}
    }}
}}".RemoveBlankLinesWhereOnlyWhitespaces();
    }
    
    private static string GenerateRegisterAttachedMethodArguments(ClassData @class, DependencyPropertyData property)
    {
        if (@class.Framework == Framework.Maui)
        {
            return GenerateMauiRegisterMethodArguments(@class, property);
        }

        if (@class.Framework == Framework.Avalonia)
        {
            return GenerateAvaloniaRegisterMethodArguments(@class, property);
        }

        if (@class.Framework == Framework.Wpf)
        {
            return @$"
                name: ""{property.Name}"",
                propertyType: typeof({property.Type}),
                ownerType: typeof({@class.Type}),
                {GeneratePropertyMetadata(@class, property)},
                validateValueCallback: {GenerateValidateValueCallback(property)}";
        }

        return @$"
                name: ""{property.Name}"",
                propertyType: typeof({property.Type}),
                ownerType: typeof({@class.Type}),
                {GeneratePropertyMetadata(@class, property)}";
    }

    private static string GenerateModifiers(ClassData @class)
    {
        if (@class.Framework == Framework.Avalonia)
        {
            return string.Empty;
        }

        return @class.Modifiers;
    }

    private static string GenerateBaseType(ClassData @class)
    {
        if (@class.Framework == Framework.Avalonia)
        {
            return $" : {GenerateTypeByPlatform(@class.Framework, "AvaloniaObject")}";
        }

        return string.Empty;
    }
}