//HintName: DependencyPropertyAttribute.g.cs
// ReSharper disable RedundantNameQualifier
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
#nullable enable

namespace DependencyPropertyGenerator;

/// <summary>
/// Generates attached dependency property using DependencyProperty.Register.
/// </summary>
[global::System.AttributeUsage(global::System.AttributeTargets.Class, AllowMultiple = true)]
[global::System.Diagnostics.Conditional("DEPENDENCY_PROPERTY_GENERATOR_ATTRIBUTES")]
internal sealed class DependencyPropertyAttribute : global::System.Attribute
{
    /// <summary>
    /// Name of this dependency property.
    /// </summary>
	public string Name { get; }

    /// <summary>
    /// Type of this dependency property.
    /// </summary>
    public global::System.Type Type { get; }

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
    /// The property will create through RegisterReadOnly (if the platform supports it) and 
    /// the property setter will contain the protected modifier. <br/>
    /// Default - <see langword="false"/>.
    /// </summary>
    public bool IsReadOnly { get; set; }

    /// <summary>
    /// Avalonia: Direct properties are a lightweight version of styled properties. <br/>
    /// Default - <see langword="false"/>.
    /// </summary>
    public bool IsDirect { get; set; }

    /// <summary>
    /// Description of this dependency property. <br/>
    /// The property will contain a <see cref="global::System.ComponentModel.DescriptionAttribute"/> with this value. <br/>
    /// This will also be used in the xml documentation if not explicitly specified. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Category of this dependency property. <br/>
    /// The property will contain a <see cref="global::System.ComponentModel.CategoryAttribute"/> with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public string? Category { get; set; }

    /// <summary>
    /// Type converter of this dependency property. <br/>
    /// The property will contain a <see cref="global::System.ComponentModel.TypeConverterAttribute"/> with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public global::System.Type? TypeConverter { get; set; }

    /// <summary>
    /// The property will contain a <see cref="global::System.ComponentModel.BindableAttribute"/> with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public bool Bindable { get; set; }

    /// <summary>
    /// The property will contain a <see cref="global::System.ComponentModel.BrowsableAttribute"/> with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public bool Browsable { get; set; }

    /// <summary>
    /// The property will contain a <see cref="global::System.ComponentModel.DesignerSerializationVisibilityAttribute"/> with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public global::System.ComponentModel.DesignerSerializationVisibility DesignerSerializationVisibility { get; set; }

    /// <summary>
    /// The property will contain a <see cref="global::System.CLSCompliantAttribute"/> with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public bool ClsCompliant { get; set; }

    /// <summary>
    /// The property will contain a System.Windows.LocalizabilityAttribute with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public Localizability Localizability { get; set; }

    /// <summary>
    /// The dependency property xml documentation. <br/>
    /// Default - "&lt;summary&gt;&lt;/summary&gt;".
    /// </summary>
    public string XmlDocumentation { get; set; } = string.Empty;

    /// <summary>
    /// The property getter/setter xml documentation. <br/>
    /// Default - "&lt;summary&gt;&lt;/summary&gt;".
    /// </summary>
    public string PropertyXmlDocumentation { get; set; } = string.Empty;

    /// <summary>
    /// For values other than default(type), will bind/rebind/remove the 
    /// On{Name}Changed_{EventName}(object sender, Args args) handler for the specified event. <br/>
    /// It is recommended to specify as nameof(UIElement.Drop). <br/>
    /// Default - string.Empty.
    /// </summary>
    public string BindEvent { get; set; } = string.Empty;

    /// <summary>
    /// For values other than default(type), will bind/rebind/remove the 
    /// On{Name}Changed_{EventName}(object sender, Args args) handler for the specified event. <br/>
    /// It is recommended to specify as nameof(UIElement.Drop). <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public string[]? BindEvents { get; set; }

    /// <summary>
    /// Allows to set a custom name for the OnChanged method call, allowing this method to be non-partial.
    /// </summary>
    public string OnChanged { get; set; } = string.Empty;

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
    /// WPF: The values of this dependency property should be saved or restored by journaling processes, or when navigating by Uniform resource identifiers (URIs).
    /// </summary>
    public bool Journal { get; set; }

    /// <summary>
    /// WPF: The sub properties on the value of this dependency property do not affect any aspect of rendering.
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
    /// Avalonia/MAUI: Default BindingMode. <br/>
    /// WPF: Only Default/TwoWay is supported. <br/>
    /// Default - <see cref="DefaultBindingMode.Default"/>.
    /// </summary>
    public DefaultBindingMode DefaultBindingMode { get; set; } = DefaultBindingMode.Default;

    /// <summary>
    /// Avalonia-DirectProperty: Whether the property is interested in data validation. <br/>
    /// Default - <see langword="false"/>.
    /// </summary>
    public bool EnableDataValidation { get; set; }

    /// <summary>
    /// WPF: partial method for coerceValueCallback will be created.
    /// </summary>
    public bool Coerce { get; set; }

    /// <summary>
    /// WPF: partial method for validateValueCallback will be created. <br/>
    /// Default - <see langword="false"/>.
    /// </summary>
    public bool Validate { get; set; }

    /// <summary>
    /// UWP/WinUI/Uno/MAUI: partial method for createDefaultValueCallback will be created.
    /// </summary>
    public bool CreateDefaultValueCallback { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="type"></param>
    /// <exception cref="global::System.ArgumentNullException"></exception>
    public DependencyPropertyAttribute(
        string name,
        global::System.Type type)
    {
        Name = name ?? throw new global::System.ArgumentNullException(nameof(name));
        Type = type ?? throw new global::System.ArgumentNullException(nameof(type));
    }
}

/// <summary>
/// Generates attached dependency property using DependencyProperty.Register.
/// </summary>
/// <typeparam name="T">Type of this dependency property.</typeparam>
[global::System.AttributeUsage(global::System.AttributeTargets.Class, AllowMultiple = true)]
[global::System.Diagnostics.Conditional("DEPENDENCY_PROPERTY_GENERATOR_ATTRIBUTES")]
internal sealed class DependencyPropertyAttribute<T> : global::System.Attribute
{
    /// <summary>
    /// Name of this dependency property.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Type of this dependency property.
    /// </summary>
    public global::System.Type Type { get; }

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
    /// The property will create through RegisterReadOnly (if the platform supports it) and 
    /// the property setter will contain the protected modifier. <br/>
    /// Default - <see langword="false"/>.
    /// </summary>
    public bool IsReadOnly { get; set; }

    /// <summary>
    /// Avalonia: Direct properties are a lightweight version of styled properties. <br/>
    /// Default - <see langword="false"/>.
    /// </summary>
    public bool IsDirect { get; set; }

    /// <summary>
    /// Description of this dependency property. <br/>
    /// The property will contain a <see cref="global::System.ComponentModel.DescriptionAttribute"/> with this value. <br/>
    /// This will also be used in the xml documentation if not explicitly specified. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Category of this dependency property. <br/>
    /// The property will contain a <see cref="global::System.ComponentModel.CategoryAttribute"/> with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public string? Category { get; set; }

    /// <summary>
    /// Type converter of this dependency property. <br/>
    /// The property will contain a <see cref="global::System.ComponentModel.TypeConverterAttribute"/> with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public global::System.Type? TypeConverter { get; set; }

    /// <summary>
    /// The property will contain a <see cref="global::System.ComponentModel.BindableAttribute"/> with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public bool Bindable { get; set; }

    /// <summary>
    /// The property will contain a <see cref="global::System.ComponentModel.BrowsableAttribute"/> with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public bool Browsable { get; set; }

    /// <summary>
    /// The property will contain a <see cref="global::System.ComponentModel.DesignerSerializationVisibilityAttribute"/> with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public global::System.ComponentModel.DesignerSerializationVisibility DesignerSerializationVisibility { get; set; }

    /// <summary>
    /// The property will contain a <see cref="global::System.CLSCompliantAttribute"/> with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public bool ClsCompliant { get; set; }

    /// <summary>
    /// The property will contain a System.Windows.LocalizabilityAttribute with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public Localizability Localizability { get; set; }

    /// <summary>
    /// The dependency property xml documentation. <br/>
    /// Default - "&lt;summary&gt;&lt;/summary&gt;".
    /// </summary>
    public string XmlDocumentation { get; set; } = string.Empty;

    /// <summary>
    /// The property getter/setter xml documentation. <br/>
    /// Default - "&lt;summary&gt;&lt;/summary&gt;".
    /// </summary>
    public string PropertyXmlDocumentation { get; set; } = string.Empty;

    /// <summary>
    /// For values other than default(type), will bind/rebind/remove the 
    /// On{Name}Changed_{EventName}(object sender, Args args) handler for the specified event. <br/>
    /// It is recommended to specify as nameof(UIElement.Drop). <br/>
    /// Default - string.Empty.
    /// </summary>
    public string BindEvent { get; set; } = string.Empty;

    /// <summary>
    /// For values other than default(type), will bind/rebind/remove the 
    /// On{Name}Changed_{EventName}(object sender, Args args) handler for the specified event. <br/>
    /// It is recommended to specify as nameof(UIElement.Drop). <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public string[]? BindEvents { get; set; }

    /// <summary>
    /// Allows to set a custom name for the OnChanged method call, allowing this method to be non-partial.
    /// </summary>
    public string OnChanged { get; set; } = string.Empty;

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
    /// WPF: The values of this dependency property should be saved or restored by journaling processes, or when navigating by Uniform resource identifiers (URIs).
    /// </summary>
    public bool Journal { get; set; }

    /// <summary>
    /// WPF: The sub properties on the value of this dependency property do not affect any aspect of rendering.
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
    /// Avalonia/MAUI: Default BindingMode. <br/>
    /// WPF: Only Default/TwoWay is supported. <br/>
    /// Default - <see cref="DefaultBindingMode.Default"/>.
    /// </summary>
    public DefaultBindingMode DefaultBindingMode { get; set; } = DefaultBindingMode.Default;

    /// <summary>
    /// Avalonia-DirectProperty: Whether the property is interested in data validation. <br/>
    /// Default - <see langword="false"/>.
    /// </summary>
    public bool EnableDataValidation { get; set; }

    /// <summary>
    /// WPF: partial method for coerceValueCallback will be created.
    /// </summary>
    public bool Coerce { get; set; }

    /// <summary>
    /// WPF: partial method for validateValueCallback will be created. <br/>
    /// Default - <see langword="false"/>.
    /// </summary>
    public bool Validate { get; set; }

    /// <summary>
    /// UWP/WinUI/Uno/MAUI: partial method for createDefaultValueCallback will be created.
    /// </summary>
    public bool CreateDefaultValueCallback { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <exception cref="global::System.ArgumentNullException"></exception>
    public DependencyPropertyAttribute(
        string name)
    {
        Name = name ?? throw new global::System.ArgumentNullException(nameof(name));
        Type = typeof(T);
    }
}
