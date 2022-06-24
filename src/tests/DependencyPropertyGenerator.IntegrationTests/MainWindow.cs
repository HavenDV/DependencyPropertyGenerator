using DependencyPropertyGenerator;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

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
    TypeConverter = typeof(BooleanToVisibilityConverter),
    Bindable = true,
    DesignerSerializationVisibility = DesignerSerializationVisibility.Hidden,
    CLSCompliant = false,
    Localizability = Localizability.Text)]
public partial class MyControl : UserControl
{
}

[DependencyProperty<float>("FloatProperty", DefaultValue = 42)]
public partial class MyControl : UserControl
{
}

[DependencyProperty<double>("DoubleProperty", DefaultValue = 42)]
public partial class MyControl : UserControl
{
}

[DependencyProperty<decimal>("DecimalProperty", DefaultValueExpression = "42")]
public partial class MyControl : UserControl
{
}

[DependencyProperty<uint>("UnsignedIntProperty", DefaultValue = 42)]
public partial class MyControl : UserControl
{
}

[DependencyProperty<long>("LongProperty", DefaultValue = 42)]
public partial class MyControl : UserControl
{
}

[DependencyProperty<ulong>("UnsignedLongProperty", DefaultValue = 42)]
public partial class MyControl : UserControl
{
}

[DependencyProperty<string>("NotNullStringProperty", DefaultValue = "", Validate = true, Coerce = true)]
public partial class MyControl : UserControl
{
    private partial string? CoerceNotNullStringProperty(string? value)
    {
        return value ?? string.Empty;
    }

    private static partial bool IsNotNullStringPropertyValid(string? value)
    {
        return value != null;
    }
}

[DependencyProperty<bool>("ExplicitUpdateSourceTriggerProperty", DefaultUpdateSourceTrigger = SourceTrigger.Explicit)]
public partial class MyControl : UserControl
{
}

[DependencyProperty<bool>("ReadOnlyProperty", IsReadOnly = true)]
public partial class MyControl : UserControl
{
}

[AttachedDependencyProperty<object, Grid>("AttachedReadOnlyProperty", IsReadOnly = true)]
public static partial class GridExtensions
{
}