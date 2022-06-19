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
    public partial class {@class.Name}
    {{
{@class.DependencyProperties.Select(property => $@"
        public static readonly global::System.Windows.DependencyProperty {property.Name}Property =
            global::System.Windows.DependencyProperty.Register(
                ""{property.Name}"",
                typeof({property.Type}),
                typeof({@class.Name}),
                new global::System.Windows.PropertyMetadata({GenerateDefaultValue(property)}, static (sender, args) => On{property.Name}Changed(({@class.Name})sender, args)));

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
    public partial class {@class.Name}
    {{
{@class.AttachedDependencyProperties.Select(property => $@"
        public static readonly global::System.Windows.DependencyProperty {property.Name}Property =
            global::System.Windows.DependencyProperty.RegisterAttached(
                ""{property.Name}"",
                typeof({property.Type}),
                typeof({@class.Name}),
                new global::System.Windows.PropertyMetadata({GenerateDefaultValue(property)}, static (sender, args) => On{property.Name}Changed(({@class.Name})sender, args)));
  
        public static void Set{property.Name}(global::System.Windows.UIElement element, {property.Type} value)
        {{
            element.SetValue({property.Name}Property, value);
        }}

        public static {property.Type} Get{property.Name}(global::System.Windows.UIElement element)
        {{
            return ({property.Type})element.GetValue({property.Name}Property);
        }}

        static partial void On{property.Name}Changed({@class.Name} sender, global::System.Windows.DependencyPropertyChangedEventArgs args);
").Inject()}
    }}
}}";
    }

    public static string GenerateDefaultValue(DependencyPropertyData property)
    {
        return property.DefaultValue ?? $"default({property.Type})";
    }
}

public readonly record struct ClassData(
    string Namespace,
    string Name,
    IReadOnlyCollection<DependencyPropertyData> DependencyProperties,
    IReadOnlyCollection<DependencyPropertyData> AttachedDependencyProperties);

public readonly record struct DependencyPropertyData(
    string Name,
    string Type,
    string? DefaultValue);
