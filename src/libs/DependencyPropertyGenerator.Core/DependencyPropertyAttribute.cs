namespace DependencyPropertyGenerator;

[AttributeUsage(AttributeTargets.Class)]
public sealed class DependencyPropertyAttribute : Attribute
{
	public string Name { get; }
	public Type Type { get; }

    public DependencyPropertyAttribute(
        string name,
        Type type)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Type = type ?? throw new ArgumentNullException(nameof(type));
    }
}