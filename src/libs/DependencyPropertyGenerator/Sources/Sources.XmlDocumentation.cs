using H.Generators.Extensions;
using System.Net;

namespace H.Generators;

internal static partial class Sources
{
    private static string GenerateXmlDocumentationFrom(string value)
    {
        var lines = value.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        return string.Join(Environment.NewLine, lines.Select(static line => $"        /// {line}"));
    }

    private static string GenerateXmlDocumentationFrom(
        string? value,
        DependencyPropertyData property,
        bool isProperty)
    {
        var name = property.IsAttached
            ? property.Name
            : $"<see cref=\"{property.Name}\"/>";
        var body = isProperty
            ? property.Description != null ? $"{property.Description}<br/>" : " "
            : $"Identifies the {name} dependency property.<br/>";
        value ??= @$"<summary>
{body}
Default value: {property.DefaultValueDocumentation?.ExtractSimpleName() ?? $"default({WebUtility.HtmlEncode(property.Type.ExtractSimpleName())})"}
</summary>".RemoveBlankLinesWhereOnlyWhitespaces();

        return GenerateXmlDocumentationFrom(value);
    }

    private static string GenerateXmlDocumentationFrom(string? value, EventData @event)
    {
        value ??= @$"<summary>
{(@event.Description != null ? $"{@event.Description}" : " ")}
</summary>".RemoveBlankLinesWhereOnlyWhitespaces();

        return GenerateXmlDocumentationFrom(value);
    }
}