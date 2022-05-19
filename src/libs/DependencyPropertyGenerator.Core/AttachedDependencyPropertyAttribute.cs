namespace DependencyPropertyGenerator;

[AttributeUsage(AttributeTargets.Class)]
public sealed class AttachedDependencyPropertyAttribute : Attribute
{
	public string Name { get; }
	public Type Type { get; }

    public AttachedDependencyPropertyAttribute(
        string name,
        Type type)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Type = type ?? throw new ArgumentNullException(nameof(type));
    }
}