using System.ComponentModel;

namespace DependencyPropertyGenerator;

/// <summary>
/// Will generates attached dependency property using DependencyProperty.RegisterAttached.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class AttachedDependencyPropertyAttribute : Attribute
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
    /// Default value of this dependency property. <br/>
    /// If you need to pass a new() expression, use <see cref="DefaultValueExpression"/>. <br/>
    /// Default - <see langword="default(type)"/>.
    /// </summary>
    public object? DefaultValue { get; set; }

    /// <summary>
    /// Default value expression of this dependency property. <br/>
    /// Used to pass a new() expression to an initializer. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public string? DefaultValueExpression { get; set; }

    /// <summary>
    /// Description of this dependency property. <br/>
    /// The property will contain a <see cref="DescriptionAttribute"/> with this value. <br/>
    /// This will also be used in the xml documentation if not explicitly specified. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Category of this dependency property. <br/>
    /// The property will contain a <see cref="CategoryAttribute"/> with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public string? Category { get; set; }

    /// <summary>
    /// Type converter of this dependency property. <br/>
    /// The property will contain a <see cref="TypeConverterAttribute"/> with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public Type? TypeConverter { get; set; }

    /// <summary>
    /// The property will contain a <see cref="BindableAttribute"/> with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public bool Bindable { get; set; }

    /// <summary>
    /// The property will contain a <see cref="DesignerSerializationVisibilityAttribute"/> with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public DesignerSerializationVisibility DesignerSerializationVisibility { get; set; }

    /// <summary>
    /// The property will contain a <see cref="CLSCompliantAttribute"/> with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public bool CLSCompliant { get; set; }

    /// <summary>
    /// The property will contain a System.Windows.LocalizabilityAttribute with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public Localizability Localizability { get; set; }

    /// <summary>
    /// The type for which the extension is intended. <br/>
    /// Default - DependencyObject.
    /// </summary>
    public Type? BrowsableForType { get; set; }

    /// <summary>
    /// The dependency property xml documentation. <br/>
    /// Default - "&lt;summary&gt;&lt;/summary&gt;".
    /// </summary>
    public string XmlDocumentation { get; set; } = string.Empty;

    /// <summary>
    /// The property getter xml documentation. <br/>
    /// Default - "&lt;summary&gt;&lt;/summary&gt;".
    /// </summary>
    public string GetterXmlDocumentation { get; set; } = string.Empty;

    /// <summary>
    /// The property setter xml documentation. <br/>
    /// Default - "&lt;summary&gt;&lt;/summary&gt;".
    /// </summary>
    public string SetterXmlDocumentation { get; set; } = string.Empty;

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
    /// WPF: true to prevent the property system from animating the property that this metadata
    /// is applied to. Such properties will raise a run-time exception originating from
    /// the property system if animations of them are attempted. The default is false.
    /// </summary>
    public bool IsAnimationProhibited { get; set; }

    /// <summary>
    /// WPF: The System.Windows.Data.UpdateSourceTrigger to use when bindings for this property
    /// are applied that have their System.Windows.Data.UpdateSourceTrigger set to 
    /// System.Windows.Data.UpdateSourceTrigger.Default.
    /// </summary>
    public SourceTrigger DefaultUpdateSourceTrigger { get; set; }

    /// <summary>
    /// WPF: partial method for coerceValueCallback will be created.
    /// </summary>
    public bool Coerce { get; set; }

    /// <summary>
    /// WPF: partial method for validateValueCallback will be created.
    /// </summary>
    public bool Validate { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="type"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public AttachedDependencyPropertyAttribute(
        string name,
        Type type)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Type = type ?? throw new ArgumentNullException(nameof(type));
    }
}

/// <summary>
/// Will generates attached dependency property using DependencyProperty.RegisterAttached.
/// </summary>
/// <typeparam name="T">Type of this dependency property.</typeparam>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class AttachedDependencyPropertyAttribute<T> : Attribute
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
    /// Default value of this dependency property. <br/>
    /// If you need to pass a new() expression, use <see cref="DefaultValueExpression"/>. <br/>
    /// Default - <see langword="default(type)"/>.
    /// </summary>
    public T? DefaultValue { get; set; }

    /// <summary>
    /// Default value expression of this dependency property. <br/>
    /// Used to pass a new() expression to an initializer. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public string? DefaultValueExpression { get; set; }

    /// <summary>
    /// Description of this dependency property. <br/>
    /// The property will contain a <see cref="DescriptionAttribute"/> with this value. <br/>
    /// This will also be used in the xml documentation if not explicitly specified. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Category of this dependency property. <br/>
    /// The property will contain a <see cref="CategoryAttribute"/> with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public string? Category { get; set; }

    /// <summary>
    /// Type converter of this dependency property. <br/>
    /// The property will contain a <see cref="TypeConverterAttribute"/> with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public Type? TypeConverter { get; set; }

    /// <summary>
    /// The property will contain a <see cref="BindableAttribute"/> with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public bool Bindable { get; set; }

    /// <summary>
    /// The property will contain a <see cref="DesignerSerializationVisibilityAttribute"/> with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public DesignerSerializationVisibility DesignerSerializationVisibility { get; set; }

    /// <summary>
    /// The property will contain a <see cref="CLSCompliantAttribute"/> with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public bool CLSCompliant { get; set; }

    /// <summary>
    /// The property will contain a System.Windows.LocalizabilityAttribute with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public Localizability Localizability { get; set; }

    /// <summary>
    /// The type for which the extension is intended. <br/>
    /// Default - DependencyObject.
    /// </summary>
    public Type? BrowsableForType { get; set; }

    /// <summary>
    /// The dependency property xml documentation. <br/>
    /// Default - "&lt;summary&gt;&lt;/summary&gt;".
    /// </summary>
    public string XmlDocumentation { get; set; } = string.Empty;

    /// <summary>
    /// The property getter xml documentation. <br/>
    /// Default - "&lt;summary&gt;&lt;/summary&gt;".
    /// </summary>
    public string GetterXmlDocumentation { get; set; } = string.Empty;

    /// <summary>
    /// The property setter xml documentation. <br/>
    /// Default - "&lt;summary&gt;&lt;/summary&gt;".
    /// </summary>
    public string SetterXmlDocumentation { get; set; } = string.Empty;

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
    /// WPF: true to prevent the property system from animating the property that this metadata
    /// is applied to. Such properties will raise a run-time exception originating from
    /// the property system if animations of them are attempted. The default is false.
    /// </summary>
    public bool IsAnimationProhibited { get; set; }

    /// <summary>
    /// WPF: The System.Windows.Data.UpdateSourceTrigger to use when bindings for this property
    /// are applied that have their System.Windows.Data.UpdateSourceTrigger set to 
    /// System.Windows.Data.UpdateSourceTrigger.Default.
    /// </summary>
    public SourceTrigger DefaultUpdateSourceTrigger { get; set; }

    /// <summary>
    /// WPF: partial method for coerceValueCallback will be created.
    /// </summary>
    public bool Coerce { get; set; }

    /// <summary>
    /// WPF: partial method for validateValueCallback will be created.
    /// </summary>
    public bool Validate { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public AttachedDependencyPropertyAttribute(
        string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Type = typeof(T);
    }
}

/// <summary>
/// Will generates attached dependency property using DependencyProperty.RegisterAttached.
/// </summary>
/// <typeparam name="T">Type of this dependency property.</typeparam>
/// <typeparam name="TBrowsableForType">The type for which the extension is intended.</typeparam>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class AttachedDependencyPropertyAttribute<T, TBrowsableForType> : Attribute
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
    /// Default value of this dependency property. <br/>
    /// If you need to pass a new() expression, use <see cref="DefaultValueExpression"/>. <br/>
    /// Default - <see langword="default(type)"/>.
    /// </summary>
    public T? DefaultValue { get; set; }

    /// <summary>
    /// Default value expression of this dependency property. <br/>
    /// Used to pass a new() expression to an initializer. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public string? DefaultValueExpression { get; set; }

    /// <summary>
    /// Description of this dependency property. <br/>
    /// The property will contain a <see cref="DescriptionAttribute"/> with this value. <br/>
    /// This will also be used in the xml documentation if not explicitly specified. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Category of this dependency property. <br/>
    /// The property will contain a <see cref="CategoryAttribute"/> with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public string? Category { get; set; }

    /// <summary>
    /// Type converter of this dependency property. <br/>
    /// The property will contain a <see cref="TypeConverterAttribute"/> with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public Type? TypeConverter { get; set; }

    /// <summary>
    /// The property will contain a <see cref="BindableAttribute"/> with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public bool Bindable { get; set; }

    /// <summary>
    /// The property will contain a <see cref="DesignerSerializationVisibilityAttribute"/> with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public DesignerSerializationVisibility DesignerSerializationVisibility { get; set; }

    /// <summary>
    /// The property will contain a <see cref="CLSCompliantAttribute"/> with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public bool CLSCompliant { get; set; }

    /// <summary>
    /// The property will contain a System.Windows.LocalizabilityAttribute with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public Localizability Localizability { get; set; }

    /// <summary>
    /// The type for which the extension is intended. <br/>
    /// Default - DependencyObject.
    /// </summary>
    public Type? BrowsableForType { get; set; }

    /// <summary>
    /// The dependency property xml documentation. <br/>
    /// Default - "&lt;summary&gt;&lt;/summary&gt;".
    /// </summary>
    public string XmlDocumentation { get; set; } = string.Empty;

    /// <summary>
    /// The property getter xml documentation. <br/>
    /// Default - "&lt;summary&gt;&lt;/summary&gt;".
    /// </summary>
    public string GetterXmlDocumentation { get; set; } = string.Empty;

    /// <summary>
    /// The property setter xml documentation. <br/>
    /// Default - "&lt;summary&gt;&lt;/summary&gt;".
    /// </summary>
    public string SetterXmlDocumentation { get; set; } = string.Empty;

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
    /// WPF: true to prevent the property system from animating the property that this metadata
    /// is applied to. Such properties will raise a run-time exception originating from
    /// the property system if animations of them are attempted. The default is false.
    /// </summary>
    public bool IsAnimationProhibited { get; set; }

    /// <summary>
    /// WPF: The System.Windows.Data.UpdateSourceTrigger to use when bindings for this property
    /// are applied that have their System.Windows.Data.UpdateSourceTrigger set to 
    /// System.Windows.Data.UpdateSourceTrigger.Default.
    /// </summary>
    public SourceTrigger DefaultUpdateSourceTrigger { get; set; }

    /// <summary>
    /// WPF: partial method for coerceValueCallback will be created.
    /// </summary>
    public bool Coerce { get; set; }

    /// <summary>
    /// WPF: partial method for validateValueCallback will be created.
    /// </summary>
    public bool Validate { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public AttachedDependencyPropertyAttribute(
        string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Type = typeof(T);
        BrowsableForType = typeof(TBrowsableForType);
    }
}