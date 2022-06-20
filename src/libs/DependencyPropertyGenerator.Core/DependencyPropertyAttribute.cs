namespace DependencyPropertyGenerator;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class DependencyPropertyAttribute : Attribute
{
	public string Name { get; }
	public Type Type { get; }

    public object? DefaultValue { get; set; }
    public bool BindsTwoWayByDefault { get; set; }

    public DependencyPropertyAttribute(
        string name,
        Type type)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Type = type ?? throw new ArgumentNullException(nameof(type));
    }
}