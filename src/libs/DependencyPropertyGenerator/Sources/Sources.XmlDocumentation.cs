using H.Generators.Extensions;
using System.Net;
using System.Security;

namespace H.Generators;

internal static partial class Sources
{
    private readonly static char[] Separator = { '\r', '\n' };
    
    private static string GenerateXmlDocumentationFrom(string value)
    {
        var lines = value.Split(Separator, StringSplitOptions.RemoveEmptyEntries);

        return string.Join("\n", lines.Select(static line => $"        /// {line}"));
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
            ? property.Description != null ? $"{SecurityElement.Escape(property.Description)}<br/>" : " "
            : $"Identifies the {name} dependency property.<br/>";
        value ??= @$"<summary>
{body}
Default value: {property.DefaultValueDocumentation?.ExtractSimpleName() ?? $"default({WebUtility.HtmlEncode(property.ShortType)})"}
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