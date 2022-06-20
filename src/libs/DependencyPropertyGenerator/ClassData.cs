namespace H.Generators;

public readonly record struct ClassData(
    string Namespace,
    string Name,
    string Modifiers,
    Platform Platform,
    IReadOnlyCollection<DependencyPropertyData> DependencyProperties,
    IReadOnlyCollection<DependencyPropertyData> AttachedDependencyProperties);
