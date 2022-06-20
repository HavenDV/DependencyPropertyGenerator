﻿namespace DependencyPropertyGenerator;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class AttachedDependencyPropertyAttribute : Attribute
{
	public string Name { get; }
	public Type Type { get; }

    public object? DefaultValue { get; set; }
    public Type? BrowsableForType { get; set; }

    public bool AffectsMeasure { get; set; }
    public bool AffectsArrange { get; set; }
    public bool AffectsParentMeasure { get; set; }
    public bool AffectsParentArrange { get; set; }
    public bool AffectsRender { get; set; }
    public bool Inherits { get; set; }
    public bool OverridesInheritanceBehavior { get; set; }
    public bool NotDataBindable { get; set; }
    public bool BindsTwoWayByDefault { get; set; }
    public bool Journal { get; set; }
    public bool SubPropertiesDoNotAffectRender { get; set; }

    public AttachedDependencyPropertyAttribute(
        string name,
        Type type)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Type = type ?? throw new ArgumentNullException(nameof(type));
    }
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class AttachedDependencyPropertyAttribute<T> : Attribute
{
    public string Name { get; }
    public Type Type { get; }

    public T? DefaultValue { get; set; }
    public Type? BrowsableForType { get; set; }

    public bool AffectsMeasure { get; set; }
    public bool AffectsArrange { get; set; }
    public bool AffectsParentMeasure { get; set; }
    public bool AffectsParentArrange { get; set; }
    public bool AffectsRender { get; set; }
    public bool Inherits { get; set; }
    public bool OverridesInheritanceBehavior { get; set; }
    public bool NotDataBindable { get; set; }
    public bool BindsTwoWayByDefault { get; set; }
    public bool Journal { get; set; }
    public bool SubPropertiesDoNotAffectRender { get; set; }

    public AttachedDependencyPropertyAttribute(
        string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Type = typeof(T);
    }
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class AttachedDependencyPropertyAttribute<T, TBrowsableForType> : Attribute
{
    public string Name { get; }
    public Type Type { get; }

    public T? DefaultValue { get; set; }
    public Type? BrowsableForType { get; set; }

    public bool AffectsMeasure { get; set; }
    public bool AffectsArrange { get; set; }
    public bool AffectsParentMeasure { get; set; }
    public bool AffectsParentArrange { get; set; }
    public bool AffectsRender { get; set; }
    public bool Inherits { get; set; }
    public bool OverridesInheritanceBehavior { get; set; }
    public bool NotDataBindable { get; set; }
    public bool BindsTwoWayByDefault { get; set; }
    public bool Journal { get; set; }
    public bool SubPropertiesDoNotAffectRender { get; set; }

    public AttachedDependencyPropertyAttribute(
        string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Type = typeof(T);
        BrowsableForType = typeof(TBrowsableForType);
    }
}