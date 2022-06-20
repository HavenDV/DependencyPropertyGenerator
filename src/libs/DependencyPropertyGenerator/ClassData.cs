namespace H.Generators;

public readonly record struct ClassData(
    string Namespace,
    string Name,
    string Modifiers,
    IReadOnlyCollection<DependencyPropertyData> DependencyProperties,
    IReadOnlyCollection<DependencyPropertyData> AttachedDependencyProperties);
