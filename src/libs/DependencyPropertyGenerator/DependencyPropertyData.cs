namespace H.Generators;

public readonly record struct DependencyPropertyData(
    string Name,
    string Type,
    bool IsValueType,
    string? DefaultValue = null,
    bool BindsTwoWayByDefault = false,
    string? BrowsableForType = null);
