namespace DependencyPropertyGenerator;

/// <summary>
/// Will generates attached dependency property using DependencyProperty.Register.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class DependencyPropertyAttribute : Attribute
{
    /// <summary>
    /// Name of this dependency property.
    /// </summary>
	public string Name { get; }

    /// <summary>
    /// Type of this dependency property.
    /// </summary>
    public Type Type { get; }

    /// <summary>
    /// Default value of this dependency property. Default - <see langword="default(type)"/>.
    /// </summary>
    public object? DefaultValue { get; set; }

    /// <summary>
    /// The dependency property xml documentation. Default - "&lt;summary&gt;&lt;/summary&gt;".
    /// </summary>
    public string XmlDoc { get; set; } = string.Empty;

    /// <summary>
    /// The property getter xml documentation. Default - "&lt;summary&gt;&lt;/summary&gt;".
    /// </summary>
    public string PropertyGetterXmlDoc { get; set; } = string.Empty;

    /// <summary>
    /// The property setter xml documentation. Default - "&lt;summary&gt;&lt;/summary&gt;".
    /// </summary>
    public string PropertySetterXmlDoc { get; set; } = string.Empty;

    /// <summary>
    /// WPF: The measure pass of layout compositions is affected by value changes to this dependency property.
    /// </summary>
    public bool AffectsMeasure { get; set; }

    /// <summary>
    /// WPF: The arrange pass of layout composition is affected by value changes to this dependency property.
    /// </summary>
    public bool AffectsArrange { get; set; }

    /// <summary>
    /// WPF: The measure pass on the parent element is affected by value changes to this dependency property.
    /// </summary>
    public bool AffectsParentMeasure { get; set; }

    /// <summary>
    /// WPF: The arrange pass on the parent element is affected by value changes to this dependency property.
    /// </summary>
    public bool AffectsParentArrange { get; set; }

    /// <summary>
    /// WPF: Some aspect of rendering or layout composition (other than measure or arrange) is affected by value changes to this dependency property.
    /// </summary>
    public bool AffectsRender { get; set; }

    /// <summary>
    /// WPF: The values of this dependency property are inherited by child elements.
    /// </summary>
    public bool Inherits { get; set; }

    /// <summary>
    /// WPF: The values of this dependency property span separated trees for purposes of property value inheritance.
    /// </summary>
    public bool OverridesInheritanceBehavior { get; set; }

    /// <summary>
    /// WPF: Data binding to this dependency property is not allowed.
    /// </summary>
    public bool NotDataBindable { get; set; }

    /// <summary>
    /// WPF: The System.Windows.Data.BindingMode for data bindings on this dependency property defaults to System.Windows.Data.BindingMode.TwoWay.
    /// </summary>
    public bool BindsTwoWayByDefault { get; set; }

    /// <summary>
    /// WPF: The values of this dependency property should be saved or restored by journaling processes, or when navigating by Uniform resource identifiers (URIs).
    /// </summary>
    public bool Journal { get; set; }

    /// <summary>
    /// WPF: The subproperties on the value of this dependency property do not affect any aspect of rendering.
    /// </summary>
    public bool SubPropertiesDoNotAffectRender { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="type"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public DependencyPropertyAttribute(
        string name,
        Type type)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Type = type ?? throw new ArgumentNullException(nameof(type));
    }
}

/// <summary>
/// Will generates attached dependency property using DependencyProperty.Register.
/// </summary>
/// <typeparam name="T">Type of this dependency property.</typeparam>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class DependencyPropertyAttribute<T> : Attribute
{
    /// <summary>
    /// Name of this dependency property.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Type of this dependency property.
    /// </summary>
    public Type Type { get; }

    /// <summary>
    /// Default value of this dependency property. Default - <see langword="default(type)"/>.
    /// </summary>
    public T? DefaultValue { get; set; }

    /// <summary>
    /// The dependency property xml documentation. Default - "&lt;summary&gt;&lt;/summary&gt;".
    /// </summary>
    public string XmlDoc { get; set; } = string.Empty;

    /// <summary>
    /// The property getter xml documentation. Default - "&lt;summary&gt;&lt;/summary&gt;".
    /// </summary>
    public string PropertyGetterXmlDoc { get; set; } = string.Empty;

    /// <summary>
    /// The property setter xml documentation. Default - "&lt;summary&gt;&lt;/summary&gt;".
    /// </summary>
    public string PropertySetterXmlDoc { get; set; } = string.Empty;

    /// <summary>
    /// WPF: The measure pass of layout compositions is affected by value changes to this dependency property.
    /// </summary>
    public bool AffectsMeasure { get; set; }

    /// <summary>
    /// WPF: The arrange pass of layout composition is affected by value changes to this dependency property.
    /// </summary>
    public bool AffectsArrange { get; set; }

    /// <summary>
    /// WPF: The measure pass on the parent element is affected by value changes to this dependency property.
    /// </summary>
    public bool AffectsParentMeasure { get; set; }

    /// <summary>
    /// WPF: The arrange pass on the parent element is affected by value changes to this dependency property.
    /// </summary>
    public bool AffectsParentArrange { get; set; }

    /// <summary>
    /// WPF: Some aspect of rendering or layout composition (other than measure or arrange) is affected by value changes to this dependency property.
    /// </summary>
    public bool AffectsRender { get; set; }

    /// <summary>
    /// WPF: The values of this dependency property are inherited by child elements.
    /// </summary>
    public bool Inherits { get; set; }

    /// <summary>
    /// WPF: The values of this dependency property span separated trees for purposes of property value inheritance.
    /// </summary>
    public bool OverridesInheritanceBehavior { get; set; }

    /// <summary>
    /// WPF: Data binding to this dependency property is not allowed.
    /// </summary>
    public bool NotDataBindable { get; set; }

    /// <summary>
    /// WPF: The System.Windows.Data.BindingMode for data bindings on this dependency property defaults to System.Windows.Data.BindingMode.TwoWay.
    /// </summary>
    public bool BindsTwoWayByDefault { get; set; }

    /// <summary>
    /// WPF: The values of this dependency property should be saved or restored by journaling processes, or when navigating by Uniform resource identifiers (URIs).
    /// </summary>
    public bool Journal { get; set; }

    /// <summary>
    /// WPF: The subproperties on the value of this dependency property do not affect any aspect of rendering.
    /// </summary>
    public bool SubPropertiesDoNotAffectRender { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public DependencyPropertyAttribute(
        string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Type = typeof(T);
    }
}