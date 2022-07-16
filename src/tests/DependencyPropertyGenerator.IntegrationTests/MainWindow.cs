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
    static partial void OnSelectedItemChanged(TreeView treeView, object? oldValue, object? newValue)
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
    static partial void OnModeChanged(TreeView treeView, Mode oldValue, Mode newValue)
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

[AttachedDependencyProperty<object, Grid>("BindEventProperty", BindEvent = nameof(Grid.MouseWheel))]
public static partial class GridExtensions
{
    private static void OnBindEventPropertyChanged_MouseWheel(object? sender, System.Windows.Input.MouseWheelEventArgs args)
    {
    }
}

[DependencyProperty<object>("BindEventsProperty",
    BindEvents = new[] { nameof(Grid.MouseEnter), nameof(Grid.MouseLeave) })]
public partial class MyGrid : Grid
{
    private static void OnBindEventsPropertyChanged_MouseEnter(object? sender, System.Windows.Input.MouseEventArgs args)
    {
    }

    private static void OnBindEventsPropertyChanged_MouseLeave(object? sender, System.Windows.Input.MouseEventArgs args)
    {
    }
}

[DependencyProperty<string>("Text")]
[DesignTimeVisible(false)]
public partial class Generatable : FrameworkElement
{
    partial void OnTextChanged(string? oldValue, string? newValue)
    {
    }
}

[DependencyProperty<Uri>("AquariumGraphic", AffectsRender = true,
    DefaultValueExpression = "new System.Uri(\"http://www.contoso.com/aquarium-graphic.jpg\")")]
public partial class Aquarium : UIElement
{
}

[OverrideMetadata<Uri>("AquariumGraphic",
    DefaultValueExpression = "new System.Uri(\"http://www.contoso.com/tropical-aquarium-graphic.jpg\")")]
public partial class TropicalAquarium : Aquarium
{
}