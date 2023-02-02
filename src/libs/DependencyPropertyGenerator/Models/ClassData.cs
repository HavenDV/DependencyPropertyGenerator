namespace H.Generators;

public readonly record struct ClassData(
    string Namespace,
    string Name,
    string FullName,
    string Modifiers,
    bool IsStatic,
    Platform Platform,
    IReadOnlyCollection<string> Methods,
    IReadOnlyCollection<DependencyPropertyData> DependencyProperties,
    IReadOnlyCollection<DependencyPropertyData> AttachedDependencyProperties,
    IReadOnlyCollection<EventData> RoutedEvents,
    IReadOnlyCollection<EventData> WeakEvents,
    IReadOnlyCollection<DependencyPropertyData> OverrideMetadata,
    IReadOnlyCollection<DependencyPropertyData> AddOwner);
