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
        public static readonly global::System.Windows.DependencyProperty {property.Name}Property =
            global::System.Windows.DependencyProperty.Register(
                name: ""{property.Name}"",
                propertyType: typeof({property.Type}),
                ownerType: typeof({@class.Name}),
                typeMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    {GenerateDefaultValue(property)},
                    {GenerateOptions(property)},
                    static (sender, args) => On{property.Name}Changed(({@class.Name})sender, ({GenerateType(property)})args.OldValue, ({GenerateType(property)})args.NewValue)));

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
        public static readonly global::System.Windows.DependencyProperty {property.Name}Property =
            global::System.Windows.DependencyProperty.RegisterAttached(
                name: ""{property.Name}"",
                propertyType: typeof({property.Type}),
                ownerType: typeof({@class.Name}),
                defaultMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    {GenerateDefaultValue(property)},
                    {GenerateOptions(property)},
                    static (sender, args) => On{property.Name}Changed(({GenerateBrowsableForType(property)})sender, ({GenerateType(property)})args.OldValue, ({GenerateType(property)})args.NewValue)));
  
        public static void Set{property.Name}(global::System.Windows.DependencyObject element, {GenerateType(property)} value)
        {{
            element.SetValue({property.Name}Property, value);
        }}

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

    public static string GenerateOptions(DependencyPropertyData property)
    {
        var value = string.Empty;
        if (property.BindsTwoWayByDefault)
        {
            value += "global::System.Windows.FrameworkPropertyMetadataOptions.BindsTwoWayByDefault";
        }
        if (!string.IsNullOrWhiteSpace(value))
        {
            return value;
        }

        return "global::System.Windows.FrameworkPropertyMetadataOptions.None";
    }
}