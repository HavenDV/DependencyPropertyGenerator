#nullable enable

namespace DependencyPropertyGenerator;

/// <summary>
/// Specifies the category value of a System.Windows.LocalizabilityAttribute 
/// for a binary XAML (BAML) class or class member.
/// </summary>
public enum Localizability
{
    /// <summary>
    /// Resource does not belong to a standard category.
    /// </summary>
    None,
    
    /// <summary>
    /// For a lengthy piece of text.
    /// </summary>
    Text,
    
    /// <summary>
    /// For a single line of text, such as text used for a title.
    /// </summary>
    Title,
    
    /// <summary>
    /// A System.Windows.Controls.Label or related control.
    /// </summary>
    Label,
    
    /// <summary>
    /// A System.Windows.Controls.Button or related control.
    /// </summary>
    Button,
    
    /// <summary>
    /// A System.Windows.Controls.CheckBox or related control.
    /// </summary>
    CheckBox,
    
    /// <summary>
    /// A System.Windows.Controls.ComboBox or related control such as System.Windows.Controls.ComboBoxItem.
    /// </summary>
    ComboBox,
    
    /// <summary>
    /// A System.Windows.Controls.ListBox or related control such as System.Windows.Controls.ListBoxItem.
    /// </summary>
    ListBox,
    
    /// <summary>
    /// A System.Windows.Controls.Menu or related control such as System.Windows.Controls.MenuItem.
    /// </summary>
    Menu,
    
    /// <summary>
    /// A System.Windows.Controls.RadioButton or related control.
    /// </summary>
    RadioButton,
    
    /// <summary>
    /// A System.Windows.Controls.ToolTip or related control.
    /// </summary>
    ToolTip,
    
    /// <summary>
    /// A System.Windows.Documents.Hyperlink or related control.
    /// </summary>
    Hyperlink,
    
    /// <summary>
    /// For panels that can contain text.
    /// </summary>
    TextFlow,
    
    /// <summary>
    /// XML data.
    /// </summary>
    XmlData,
    
    /// <summary>
    /// Font-related data such as font name, style, or size.
    /// </summary>
    Font,
    
    /// <summary>
    /// Inherits its category from a parent node.
    /// </summary>
    Inherit,
    
    /// <summary>
    /// Do not localize this resource. This does not apply to any child nodes that might exist.
    /// </summary>
    Ignore,
    
    /// <summary>
    /// Do not localize this resource, or any child nodes whose category is set to Inherit.
    /// </summary>
    NeverLocalize,
}