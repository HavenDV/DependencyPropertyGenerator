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
                typeMetadata: new global::System.Windows.PropertyMetadata(
                    {GenerateDefaultValue(property)},
                    static (sender, args) => On{property.Name}Changed(({@class.Name})sender, args)));

        public {property.Type} {property.Name}
        {{
            get => ({property.Type})GetValue({property.Name}Property);
            set => SetValue({property.Name}Property, value);
        }}

        static partial void On{property.Name}Changed({@class.Name} sender, global::System.Windows.DependencyPropertyChangedEventArgs args);
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
                defaultMetadata: new global::System.Windows.PropertyMetadata(
                    {GenerateDefaultValue(property)},
                    static (sender, args) => On{property.Name}Changed(({GenerateBrowsableForType(property)})sender, args)));
  
        public static void Set{property.Name}(global::System.Windows.DependencyObject element, {property.Type} value)
        {{
            element.SetValue({property.Name}Property, value);
        }}

        [global::System.Windows.AttachedPropertyBrowsableForType(typeof({GenerateBrowsableForType(property)}))]
        public static {property.Type} Get{property.Name}(global::System.Windows.DependencyObject element)
        {{
            return ({property.Type})element.GetValue({property.Name}Property);
        }}

        static partial void On{property.Name}Changed({GenerateBrowsableForType(property)} sender, global::System.Windows.DependencyPropertyChangedEventArgs args);
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
}

public readonly record struct ClassData(
    string Namespace,
    string Name,
    string Modifiers,
    IReadOnlyCollection<DependencyPropertyData> DependencyProperties,
    IReadOnlyCollection<DependencyPropertyData> AttachedDependencyProperties);

public readonly record struct DependencyPropertyData(
    string Name,
    string Type,
    string? DefaultValue = null,
    string? BrowsableForType = null);
