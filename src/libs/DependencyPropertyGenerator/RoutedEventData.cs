namespace H.Generators;

public readonly record struct RoutedEventData(
    string Name,
    string Strategy,
    string? Type,
    string? Description,
    string? Category,
    string? XmlDocumentation,
    string? EventXmlDocumentation);
