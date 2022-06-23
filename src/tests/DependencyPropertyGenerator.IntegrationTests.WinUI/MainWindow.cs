using DependencyPropertyGenerator;
using System.ComponentModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

#nullable enable

namespace H.Generators.IntegrationTests;

[DependencyProperty<bool>("IsSpinning", DefaultValue = true, Category = "Category", Description = "Description")]
public partial class MyControl : UserControl
{
    // Optional
    partial void OnIsSpinningChanged(bool oldValue, bool newValue)
    {
    }
}

[AttachedDependencyProperty<object, TreeView>("SelectedItem", BindsTwoWayByDefault = true)]
public static partial class TreeViewExtensions
{
    // Optional
    static partial void OnSelectedItemChanged(TreeView sender, object? oldValue, object? newValue)
    {
    }
}

public enum Mode
{
    Mode1,
    Mode2,
}

[AttachedDependencyProperty<Mode, TreeView>("Mode", DefaultValue = Mode.Mode2)]
public static partial class TreeViewExtensions
{
    static partial void OnModeChanged(TreeView sender, Mode oldValue, Mode newValue)
    {
    }
}

[RoutedEvent("TrayLeftMouseDown", RoutedEventStrategy.Bubble)]
public partial class MyControl : UserControl
{
}

[DependencyProperty<string>("AttributedProperty",
    Category = "Category",
    Description = "Description",
    TypeConverter = typeof(EnumConverter),
    Bindable = true,
    DesignerSerializationVisibility = DesignerSerializationVisibility.Hidden,
    CLSCompliant = false,
    Localizability = Localizability.Text)]
public partial class MyControl : UserControl
{
}
