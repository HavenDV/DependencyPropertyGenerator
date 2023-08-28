using H.Generators.Extensions;

namespace H.Generators;

public readonly record struct ClassData(
    string Namespace,
    string Name,
    string FullName,
    string Type,
    string Modifiers,
    bool IsStatic,
    Framework Framework,
    EquatableArray<string> Methods);