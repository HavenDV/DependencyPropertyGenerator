namespace H.Generators;

public readonly record struct EventData(
    string Name,
    string Strategy,
    string Type,
    bool IsValueType,
    bool IsAttached,
    string? Description,
    string? Category,
    string? XmlDocumentation,
    string? EventXmlDocumentation,
    bool WinRtEvents);