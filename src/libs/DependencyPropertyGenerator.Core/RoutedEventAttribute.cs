using System.ComponentModel;

namespace DependencyPropertyGenerator;

/// <summary>
/// Will generates routed event using EventManager.RegisterRoutedEvent.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class RoutedEventAttribute : Attribute
{
    /// <summary>
    /// Name of this routed event.
    /// </summary>
	public string Name { get; }

    /// <summary>
    /// Strategy of this routed event.
    /// </summary>
    public RoutedEventStrategy Strategy { get; }

    /// <summary>
    /// Type of this routed event. <br/>
    /// Default - typeof(RoutedEventHandler).
    /// </summary>
    public Type? Type { get; set; }

    /// <summary>
    /// Will generates attached routed event. <br/>
    /// Default - <see langword="false"/>.
    /// </summary>
    public bool IsAttached { get; set; }

    /// <summary>
    /// Description of this routed event. <br/>
    /// The event will contain a <see cref="DescriptionAttribute"/> with this value. <br/>
    /// This will also be used in the xml documentation if not explicitly specified. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Category of this routed event. <br/>
    /// The event will contain a <see cref="CategoryAttribute"/> with this value. <br/>
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
    /// <param name="strategy"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public RoutedEventAttribute(
        string name,
        RoutedEventStrategy strategy)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Strategy = strategy;
    }
}

/// <summary>
/// Will generates routed event using EventManager.RegisterRoutedEvent.
/// </summary>
/// <typeparam name="T">Type of this routed event.</typeparam>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class RoutedEventAttribute<T> : Attribute
{
    /// <summary>
    /// Name of this routed event.
    /// </summary>
	public string Name { get; }

    /// <summary>
    /// Strategy of this routed event.
    /// </summary>
    public RoutedEventStrategy Strategy { get; }

    /// <summary>
    /// Type of this routed event. <br/>
    /// Default - typeof(RoutedEventHandler).
    /// </summary>
    public Type? Type { get; set; }

    /// <summary>
    /// Will generates attached routed event. <br/>
    /// Default - <see langword="false"/>.
    /// </summary>
    public bool IsAttached { get; set; }

    /// <summary>
    /// Description of this routed event. <br/>
    /// The event will contain a <see cref="DescriptionAttribute"/> with this value. <br/>
    /// This will also be used in the xml documentation if not explicitly specified. <br/>
    /// Default - <see langword="null"/>.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Category of this routed event. <br/>
    /// The event will contain a <see cref="CategoryAttribute"/> with this value. <br/>
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
    /// <param name="strategy"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public RoutedEventAttribute(
        string name,
        RoutedEventStrategy strategy)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Strategy = strategy;
        Type = typeof(T);
    }
}