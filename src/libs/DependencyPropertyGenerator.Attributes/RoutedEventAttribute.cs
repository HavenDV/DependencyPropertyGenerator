#nullable enable

namespace DependencyPropertyGenerator;

/// <summary>
/// Will generates routed event using EventManager.RegisterRoutedEvent.
/// </summary>
[global::System.AttributeUsage(global::System.AttributeTargets.Class, AllowMultiple = true)]
[global::System.Diagnostics.Conditional("DEPENDENCYPROPERTYGENERATOR_ATTRIBUTES")]
public sealed class RoutedEventAttribute : global::System.Attribute
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
    public global::System.Type? Type { get; set; }

    /// <summary>
    /// Will generates attached routed event. <br/>
    /// Default - <see langword="false"/>.
    /// </summary>
    public bool IsAttached { get; set; }

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
    /// WinRT events are disabled by default due to a series of issues with them in Windows 10:<br/>
    /// <see href="https://github.com/HavenDV/H.NotifyIcon/issues/36"/> <br/>
    /// <see href="https://github.com/HavenDV/H.NotifyIcon/issues/31"/> <br/>
    /// </summary>
    public bool WinRTEvents { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="strategy"></param>
    /// <exception cref="global::System.ArgumentNullException"></exception>
    public RoutedEventAttribute(
        string name,
        RoutedEventStrategy strategy)
    {
        Name = name ?? throw new global::System.ArgumentNullException(nameof(name));
        Strategy = strategy;
    }
}

/// <summary>
/// Will generates routed event using EventManager.RegisterRoutedEvent.
/// </summary>
/// <typeparam name="T">Type of this routed event.</typeparam>
[global::System.AttributeUsage(global::System.AttributeTargets.Class, AllowMultiple = true)]
[global::System.Diagnostics.Conditional("DEPENDENCYPROPERTYGENERATOR_ATTRIBUTES")]
public sealed class RoutedEventAttribute<T> : global::System.Attribute
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
    public global::System.Type? Type { get; set; }

    /// <summary>
    /// Will generates attached routed event. <br/>
    /// Default - <see langword="false"/>.
    /// </summary>
    public bool IsAttached { get; set; }

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
    /// WinRT events are disabled by default due to a series of issues with them in Windows 10:<br/>
    /// <see href="https://github.com/HavenDV/H.NotifyIcon/issues/36"/> <br/>
    /// <see href="https://github.com/HavenDV/H.NotifyIcon/issues/31"/> <br/>
    /// </summary>
    public bool WinRTEvents { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="strategy"></param>
    /// <exception cref="global::System.ArgumentNullException"></exception>
    public RoutedEventAttribute(
        string name,
        RoutedEventStrategy strategy)
    {
        Name = name ?? throw new global::System.ArgumentNullException(nameof(name));
        Strategy = strategy;
        Type = typeof(T);
    }
}