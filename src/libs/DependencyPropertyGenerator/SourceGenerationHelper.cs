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
                 typeof({@class.Name}));

        public {property.Type} {property.Name}
        {{
            get => ({property.Type})GetValue({property.Name}Property);
            set => SetValue({property.Name}Property, value);
        }}
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
                typeof({@class.Name}));
  
        public static void Set{property.Name}(global::System.Windows.UIElement element, {property.Type} value)
        {{
            element.SetValue({property.Name}Property, value);
        }}

        public static {property.Type} Get{property.Name}(global::System.Windows.UIElement element)
        {{
            return ({property.Type})element.GetValue({property.Name}Property);
        }}
").Inject()}
    }}
}}";
    }
}

public readonly record struct ClassData(
    string Namespace,
    string Name,
    IReadOnlyCollection<DependencyPropertyData> DependencyProperties,
    IReadOnlyCollection<DependencyPropertyData> AttachedDependencyProperties);

public readonly record struct DependencyPropertyData(
    string Name,
    string Type);
