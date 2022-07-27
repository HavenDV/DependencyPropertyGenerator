namespace H.Generators;

public readonly record struct ClassData(
    string Namespace,
    string Name,
    string FullName,
    string Modifiers,
    Platform Platform,
    IReadOnlyCollection<string> Methods,
    IReadOnlyCollection<DependencyPropertyData> DependencyProperties,
    IReadOnlyCollection<DependencyPropertyData> AttachedDependencyProperties,
    IReadOnlyCollection<RoutedEventData> RoutedEvents,
    IReadOnlyCollection<DependencyPropertyData> OverrideMetadata,
    IReadOnlyCollection<DependencyPropertyData> AddOwner);
