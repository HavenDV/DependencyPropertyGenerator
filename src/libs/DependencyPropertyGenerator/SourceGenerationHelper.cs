using H.Generators.Extensions;
using Microsoft.CodeAnalysis;

namespace H.Generators;

internal class SourceGenerationHelper
{
    public static string GenerateDependencyProperty(ClassData @class)
    {
        return @$"
#nullable enable

namespace {@class.Namespace}
{{
    public{@class.Modifiers} partial class {@class.Name}
    {{
{@class.DependencyProperties.Select(property => $@"
{GenerateXmlDocumentationFrom(property.XmlDoc)}
        public static readonly {GenerateDependencyPropertyType(@class)} {property.Name}Property =
            {GenerateDependencyPropertyType(@class)}.Register(
                name: ""{property.Name}"",
                propertyType: typeof({property.Type}),
                ownerType: typeof({@class.Name}),
                {GeneratePropertyMetadata(@class, property, false)});

{GenerateXmlDocumentationFrom(property.PropertyGetterXmlDoc)}
{GenerateCategoryAttribute(property.Category)}
{GenerateDescriptionAttribute(property.Description)}
        public {GenerateType(property)} {property.Name}
        {{
            get => ({GenerateType(property)})GetValue({property.Name}Property);
            set => SetValue({property.Name}Property, value);
        }}

        partial void On{property.Name}Changed({GenerateType(property)} oldValue, {GenerateType(property)} newValue);
").Inject().RemoveBlankLinesWhereOnlyWhitespaces()}
    }}
}}";
    }

    public static string GenerateAttachedDependencyProperty(ClassData @class)
    {
        return @$"
#nullable enable

namespace {@class.Namespace}
{{
    public{@class.Modifiers} partial class {@class.Name}
    {{
{@class.AttachedDependencyProperties.Select(property => $@"
{GenerateXmlDocumentationFrom(property.XmlDoc)}
        public static readonly {GenerateDependencyPropertyType(@class)} {property.Name}Property =
            {GenerateDependencyPropertyType(@class)}.RegisterAttached(
                name: ""{property.Name}"",
                propertyType: typeof({property.Type}),
                ownerType: typeof({@class.Name}),
                {GeneratePropertyMetadata(@class, property, true)});

{GenerateXmlDocumentationFrom(property.PropertySetterXmlDoc)}
{GenerateCategoryAttribute(property.Category)}
{GenerateDescriptionAttribute(property.Description)}
        public static void Set{property.Name}({GenerateDependencyObjectType(@class)} element, {GenerateType(property)} value)
        {{
            element.SetValue({property.Name}Property, value);
        }}

{GenerateXmlDocumentationFrom(property.PropertyGetterXmlDoc)}
{GenerateCategoryAttribute(property.Category)}
{GenerateDescriptionAttribute(property.Description)}
{GenerateBrowsableForTypeAttribute(@class, property)}
        public static {GenerateType(property)} Get{property.Name}({GenerateDependencyObjectType(@class)} element)
        {{
            return ({GenerateType(property)})element.GetValue({property.Name}Property);
        }}

        static partial void On{property.Name}Changed({GenerateBrowsableForType(@class, property)} sender, {GenerateType(property)} oldValue, {GenerateType(property)} newValue);
").Inject().RemoveBlankLinesWhereOnlyWhitespaces()}
    }}
}}";
    }

    public static string GeneratePropertyChangedCallback(ClassData @class, DependencyPropertyData property, bool isAttached)
    {
        var senderType = isAttached ? GenerateBrowsableForType(@class, property) : @class.Name;

        return isAttached
            ? $@"propertyChangedCallback: static (sender, args) => On{property.Name}Changed(({senderType})sender, ({GenerateType(property)})args.OldValue, ({GenerateType(property)})args.NewValue)"
            : $@"propertyChangedCallback: static (sender, args) => (({senderType})sender).On{property.Name}Changed(({GenerateType(property)})args.OldValue, ({GenerateType(property)})args.NewValue)";
    }

    public static string GeneratePropertyMetadata(ClassData @class, DependencyPropertyData property, bool isAttached)
    {
        var parameterName = (@class.Platform, isAttached) switch
        {
            (Platform.WPF, true) or (Platform.WinUI, true) => "defaultMetadata",
            _ => "typeMetadata",
        };
        switch (@class.Platform)
        {
            case Platform.WPF:
                return $@"{parameterName}: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: {GenerateDefaultValue(property)},
                    flags: {GenerateOptions(property)},
                    {GeneratePropertyChangedCallback(@class, property, isAttached)})";

            case Platform.UWP:
            case Platform.WinUI:
            case Platform.Uno:
            case Platform.UnoWinUI:
                var type = GenerateTypeByPlatform(@class.Platform, "PropertyMetadata");
                return $@"{parameterName}: new {type}(
                    defaultValue: {GenerateDefaultValue(property)},
                    {GeneratePropertyChangedCallback(@class, property, isAttached)})";
        }

        throw new InvalidOperationException("Platform is not supported.");
    }

    public static string GenerateTypeByPlatform(Platform platform, string name)
    {
        return platform switch
        {
            Platform.WPF => $"global::System.Windows.{name}",
            Platform.UWP or Platform.Uno => $"global::Windows.UI.Xaml.{name}",
            Platform.WinUI or Platform.UnoWinUI => $"global::Microsoft.UI.Xaml.{name}",
            _ => throw new InvalidOperationException("Platform is not supported."),
        };
    }

    public static string GenerateDependencyPropertyType(ClassData @class)
    {
        return GenerateTypeByPlatform(@class.Platform, "DependencyProperty");
    }

    public static string GenerateDependencyObjectType(ClassData @class)
    {
        return GenerateTypeByPlatform(@class.Platform, "DependencyObject");
    }

    public static string GenerateDefaultValue(DependencyPropertyData property)
    {
        return property.DefaultValue ?? $"default({property.Type})";
    }

    public static string GenerateBrowsableForType(ClassData @class, DependencyPropertyData property)
    {
        return property.BrowsableForType ?? GenerateDependencyObjectType(@class);
    }

    public static string GenerateType(DependencyPropertyData property)
    {
        var value = property.Type;
        if (!property.IsValueType)
        {
            value += "?";
        }

        return value;
    }

    public static string GenerateXmlDocumentationFrom(string value)
    {
        var lines = value.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        return string.Join(Environment.NewLine, lines.Select(static line => $"        /// {line}"));
    }

    public static string GenerateCategoryAttribute(string? value)
    {
        if (value == null)
        {
            return " ";
        }

        return $"        [global::System.ComponentModel.Category(\"{value}\")]";
    }

    public static string GenerateDescriptionAttribute(string? value)
    {
        if (value == null)
        {
            return " ";
        }

        return $"        [global::System.ComponentModel.Description(\"{value}\")]";
    }

    public static string GenerateBrowsableForTypeAttribute(ClassData @class, DependencyPropertyData property)
    {
        if (@class.Platform != Platform.WPF)
        {
            return " ";
        }

        return $"        [global::System.Windows.AttachedPropertyBrowsableForType(typeof({GenerateBrowsableForType(@class, property)}))]";
    }

    public static string GenerateOptions(DependencyPropertyData property)
    {
        var values = new List<string>();
        if (property.AffectsMeasure)
        {
            values.Add(nameof(property.AffectsMeasure));
        }
        if (property.AffectsArrange)
        {
            values.Add(nameof(property.AffectsArrange));
        }
        if (property.AffectsParentMeasure)
        {
            values.Add(nameof(property.AffectsParentMeasure));
        }
        if (property.AffectsParentArrange)
        {
            values.Add(nameof(property.AffectsParentArrange));
        }
        if (property.AffectsRender)
        {
            values.Add(nameof(property.AffectsRender));
        }
        if (property.Inherits)
        {
            values.Add(nameof(property.Inherits));
        }
        if (property.OverridesInheritanceBehavior)
        {
            values.Add(nameof(property.OverridesInheritanceBehavior));
        }
        if (property.NotDataBindable)
        {
            values.Add(nameof(property.NotDataBindable));
        }
        if (property.BindsTwoWayByDefault)
        {
            values.Add(nameof(property.BindsTwoWayByDefault));
        }
        if (property.Journal)
        {
            values.Add(nameof(property.Journal));
        }
        if (property.SubPropertiesDoNotAffectRender)
        {
            values.Add(nameof(property.SubPropertiesDoNotAffectRender));
        }
        if (!values.Any())
        {
            values.Add("None");
        }

        return string.Join(" | ", values
            .Select(static value => $"global::System.Windows.FrameworkPropertyMetadataOptions.{value}"));
    }
}