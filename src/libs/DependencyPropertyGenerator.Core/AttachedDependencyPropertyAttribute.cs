namespace DependencyPropertyGenerator;

[AttributeUsage(AttributeTargets.Class)]
public sealed class AttachedDependencyPropertyAttribute : Attribute
{
	public string Name { get; }
	public Type Type { get; }
    public object? DefaultValue { get; }

    public AttachedDependencyPropertyAttribute(
        string name,
        Type type,
        object? defaultValue = null)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Type = type ?? throw new ArgumentNullException(nameof(type));
        DefaultValue = defaultValue;
    }
}