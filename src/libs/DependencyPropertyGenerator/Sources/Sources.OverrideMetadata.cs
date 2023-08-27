using H.Generators.Extensions;

namespace H.Generators;

internal static partial class Sources
{
    public static string GenerateRegisterPropertyChangedCallbacksMethod(
        ClassData @class,
        IReadOnlyCollection<DependencyPropertyData> overrideMetadata)
    {
        return @$"#nullable enable

namespace {@class.Namespace}
{{
    public{GenerateModifiers(@class)} partial class {@class.Name}
    {{
        private void RegisterPropertyChangedCallbacks()
        {{
{overrideMetadata.Select(property => {
    var senderType = property.IsAttached
        ? GenerateBrowsableForType(property)
        : GenerateType(@class.FullName, false);

    var (name, isChanged0, isChanged1, isChanged2, isChanged3) = CheckOnChangedMethods(@class, property);
    if (!isChanged0 &&
        !isChanged1 &&
        !isChanged2 &&
        !isChanged3)
    {
        return " ";
    }

    return @$"
            _ = this.RegisterPropertyChangedCallback(
                dp: {property.Name}Property,
                callback: static (sender, dependencyProperty) =>
                {{
                    {(isChanged0 ? @$"(({senderType})sender).{name}();" : "")}
                    {(isChanged1 ? @$"(({senderType})sender).{name}(
                        ({GenerateType(property)})sender.GetValue(dependencyProperty));" : "")}
                    {(isChanged2 ? @$"(({senderType})sender).{name}(
                        ({GenerateType(property)})sender.GetValue(dependencyProperty),
                        ({GenerateType(property)})sender.GetValue(dependencyProperty));" : "")}
                }});
";
}).Inject()}
        }}

{overrideMetadata.Select(GenerateOnChangedMethods).Inject()}
    }}
}}".RemoveBlankLinesWhereOnlyWhitespaces();
    }
}