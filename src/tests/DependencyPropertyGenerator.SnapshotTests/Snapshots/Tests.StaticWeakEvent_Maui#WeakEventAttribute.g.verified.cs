//HintName: WeakEventAttribute.g.cs
// ReSharper disable RedundantNameQualifier
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
#nullable enable

namespace DependencyPropertyGenerator;

/// <summary>
/// Generates routed event using EventManager.RegisterRoutedEvent.
/// </summary>
[global::System.AttributeUsage(global::System.AttributeTargets.Class, AllowMultiple = true)]
[global::System.Diagnostics.Conditional("DEPENDENCY_PROPERTY_GENERATOR_ATTRIBUTES")]
public sealed class WeakEventAttribute : global::System.Attribute
{
    /// <summary>
    /// Name of this routed event.
    /// </summary>
	public string Name { get; }

    /// <summary>
    /// Type of this routed event. <br/>
    /// Default - typeof(RoutedEventHandler).
    /// </summary>
    public global::System.Type? Type { get; set; }

    /// <summary>
    /// Will generates static event. <br/>
    /// Default - <see langword="false"/>.
    /// </summary>
    public bool IsStatic { get; set; }

    /// <summary>
    /// Description of this routed event. <br/>
    /// The event will contain a <see cref="global::System.ComponentModel.DescriptionAttribute"/> with this value. <br/>
    /// This will also be used in the xml documentation if not explicitly specified. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Category of this routed event. <br/>
    /// The event will contain a <see cref="global::System.ComponentModel.CategoryAttribute"/> with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public string? Category { get; set; }

    /// <summary>
    /// The routed event xml documentation. <br/>
    /// Default - "&lt;summary&gt;&lt;/summary&gt;".
    /// </summary>
    public string XmlDocumentation { get; set; } = string.Empty;

    /// <summary>
    /// The event add/remove xml documentation. <br/>
    /// Default - "&lt;summary&gt;&lt;/summary&gt;".
    /// </summary>
    public string EventXmlDocumentation { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <exception cref="global::System.ArgumentNullException"></exception>
    public WeakEventAttribute(
        string name)
    {
        Name = name ?? throw new global::System.ArgumentNullException(nameof(name));
    }
}

/// <summary>
/// Will generates routed event using EventManager.RegisterRoutedEvent.
/// </summary>
/// <typeparam name="T">Type of this routed event.</typeparam>
[global::System.AttributeUsage(global::System.AttributeTargets.Class, AllowMultiple = true)]
[global::System.Diagnostics.Conditional("DEPENDENCY_PROPERTY_GENERATOR_ATTRIBUTES")]
public sealed class WeakEventAttribute<T> : global::System.Attribute
{
    /// <summary>
    /// Name of this routed event.
    /// </summary>
	public string Name { get; }

    /// <summary>
    /// Type of this routed event. <br/>
    /// Default - typeof(RoutedEventHandler).
    /// </summary>
    public global::System.Type? Type { get; set; }

    /// <summary>
    /// Will generates static event. <br/>
    /// Default - <see langword="false"/>.
    /// </summary>
    public bool IsStatic { get; set; }

    /// <summary>
    /// Description of this routed event. <br/>
    /// The event will contain a <see cref="global::System.ComponentModel.DescriptionAttribute"/> with this value. <br/>
    /// This will also be used in the xml documentation if not explicitly specified. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Category of this routed event. <br/>
    /// The event will contain a <see cref="global::System.ComponentModel.CategoryAttribute"/> with this value. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public string? Category { get; set; }

    /// <summary>
    /// The routed event xml documentation. <br/>
    /// Default - "&lt;summary&gt;&lt;/summary&gt;".
    /// </summary>
    public string XmlDocumentation { get; set; } = string.Empty;

    /// <summary>
    /// The event add/remove xml documentation. <br/>
    /// Default - "&lt;summary&gt;&lt;/summary&gt;".
    /// </summary>
    public string EventXmlDocumentation { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <exception cref="global::System.ArgumentNullException"></exception>
    public WeakEventAttribute(
        string name)
    {
        Name = name ?? throw new global::System.ArgumentNullException(nameof(name));
        Type = typeof(T);
    }
}