namespace H.Generators;

public readonly record struct RoutedEventData(
    string Name,
    string Strategy,
    string? Type,
    bool IsAttached,
    string? Description,
    string? Category,
    string? XmlDocumentation,
    string? EventXmlDocumentation,
    bool WinRTEvents);
