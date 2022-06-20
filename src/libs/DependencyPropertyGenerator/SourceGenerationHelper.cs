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
        public static readonly global::System.Windows.DependencyProperty {property.Name}Property =
            global::System.Windows.DependencyProperty.Register(
                name: ""{property.Name}"",
                propertyType: typeof({property.Type}),
                ownerType: typeof({@class.Name}),
                typeMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    {GenerateDefaultValue(property)},
                    {GenerateOptions(property)},
                    static (sender, args) => On{property.Name}Changed(({@class.Name})sender, ({GenerateType(property)})args.OldValue, ({GenerateType(property)})args.NewValue)));

{GenerateXmlDocumentationFrom(property.PropertyGetterXmlDoc)}
        public {GenerateType(property)} {property.Name}
        {{
            get => ({GenerateType(property)})GetValue({property.Name}Property);
            set => SetValue({property.Name}Property, value);
        }}

        static partial void On{property.Name}Changed({@class.Name} sender, {GenerateType(property)} oldValue, {GenerateType(property)} newValue);
").Inject()}
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
        public static readonly global::System.Windows.DependencyProperty {property.Name}Property =
            global::System.Windows.DependencyProperty.RegisterAttached(
                name: ""{property.Name}"",
                propertyType: typeof({property.Type}),
                ownerType: typeof({@class.Name}),
                defaultMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    {GenerateDefaultValue(property)},
                    {GenerateOptions(property)},
                    static (sender, args) => On{property.Name}Changed(({GenerateBrowsableForType(property)})sender, ({GenerateType(property)})args.OldValue, ({GenerateType(property)})args.NewValue)));
  
{GenerateXmlDocumentationFrom(property.PropertySetterXmlDoc)}
        public static void Set{property.Name}(global::System.Windows.DependencyObject element, {GenerateType(property)} value)
        {{
            element.SetValue({property.Name}Property, value);
        }}

{GenerateXmlDocumentationFrom(property.PropertyGetterXmlDoc)}
        [global::System.Windows.AttachedPropertyBrowsableForType(typeof({GenerateBrowsableForType(property)}))]
        public static {GenerateType(property)} Get{property.Name}(global::System.Windows.DependencyObject element)
        {{
            return ({GenerateType(property)})element.GetValue({property.Name}Property);
        }}

        static partial void On{property.Name}Changed({GenerateBrowsableForType(property)} sender, {GenerateType(property)} oldValue, {GenerateType(property)} newValue);
").Inject()}
    }}
}}";
    }

    public static string GenerateDefaultValue(DependencyPropertyData property)
    {
        return property.DefaultValue ?? $"default({property.Type})";
    }

    public static string GenerateBrowsableForType(DependencyPropertyData property)
    {
        return property.BrowsableForType ?? "global::System.Windows.DependencyObject";
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