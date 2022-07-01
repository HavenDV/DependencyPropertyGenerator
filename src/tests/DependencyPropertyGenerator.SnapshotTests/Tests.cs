using Microsoft.CodeAnalysis;

namespace H.Generators.SnapshotTests;

[TestClass]
public class Tests : VerifyBase
{
    private static string GetHeader(Platform platform, params string[] values)
    {
        var prefix = platform switch
        {
            Platform.WinUI or Platform.UnoWinUI => @"Microsoft.UI.Xaml",
            Platform.UWP or Platform.Uno => @"Windows.UI.Xaml",
            Platform.Avalonia => @"Avalonia",
            _ => @"System.Windows",
        };
        var usings = string.Join(
            Environment.NewLine,
            values.Select(value => value.StartsWith("System")
                ? $"using {value};"
                : $"using {prefix}.{value};"));

        return @$"{usings}
using DependencyPropertyGenerator;

#nullable enable

namespace H.Generators.IntegrationTests;
";
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    //[DataRow(Platform.UWP)]
    //[DataRow(Platform.WinUI)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    public Task GeneratesReadmeExampleCorrectly(Platform platform)
    {
        
        return this.CheckSourceAsync(GetHeader(platform, "Controls") + @"
[DependencyProperty<bool>(""IsSpinning"", DefaultValue = true, Category = ""Category"", Description = ""Description"")]
public partial class MyControl : UserControl
{
    // Optional
    partial void OnIsSpinningChanged(bool oldValue, bool newValue)
    {
    }
}

[AttachedDependencyProperty<object, TreeView>(""SelectedItem"", BindsTwoWayByDefault = true)]
public static partial class TreeViewExtensions
{
    // Optional
    static partial void OnSelectedItemChanged(TreeView sender, object? oldValue, object? newValue)
    {
    }
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    public Task GeneratesNonGenericAttributesCorrectly(Platform platform)
    {
        return this.CheckSourceAsync(GetHeader(platform, "Controls") + @"
[DependencyProperty(""Text"", typeof(string))]
public partial class MyControl : UserControl
{
}

[AttachedDependencyProperty(""AttachedProperty"", typeof(object), BrowsableForType = typeof(Grid))]
public static partial class GridExtensions
{
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    public Task GeneratesMultipleClassDeclarationsCorrectly(Platform platform)
    {
        return this.CheckSourceAsync(GetHeader(platform, "Controls") + @"
[DependencyProperty<bool>(""IsSpinning"")]
public partial class MyControl : UserControl
{
    // Optional
    partial void OnIsSpinningChanged(bool oldValue, bool newValue)
    {
    }
}

[DependencyProperty<bool>(""IsSpinning2"")]
public partial class MyControl : UserControl
{
    // Optional
    partial void OnIsSpinning2Changed(bool oldValue, bool newValue)
    {
    }
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    [DataRow(Platform.Avalonia)]
    public Task GeneratesEnumCorrectly(Platform platform)
    {
        return this.CheckSourceAsync(GetHeader(platform, "Controls") + @"
public enum Mode
{
    Mode1,
    Mode2,
}

[AttachedDependencyProperty<Mode, TreeView>(""Mode"", DefaultValue = Mode.Mode2)]
public static partial class TreeViewExtensions
{
    static partial void OnModeChanged(TreeView sender, Mode oldValue, Mode newValue)
    {
    }
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    public Task GeneratesRoutedEventCorrectly(Platform platform)
    {
        return this.CheckSourceAsync(GetHeader(platform, "Controls") + @"
[RoutedEvent(""TrayLeftMouseDown"", RoutedEventStrategy.Bubble)]
public partial class MyControl : UserControl
{
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    public Task GeneratesAttachedRoutedEventCorrectly(Platform platform)
    {
        return this.CheckSourceAsync(GetHeader(platform, "Controls") + @"
[RoutedEvent(""TrayLeftMouseDown"", RoutedEventStrategy.Bubble, IsAttached = true)]
public partial class MyControl : UserControl
{
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    public Task GeneratesAttributesCorrectly(Platform platform)
    {
        return this.CheckSourceAsync(GetHeader(platform, "Controls", "System.ComponentModel") + @"
[DependencyProperty<string>(""AttributedProperty"",
    Category = ""Category"",
    Description = ""Description"",
    TypeConverter = typeof(EnumConverter),
    Bindable = true,
    DesignerSerializationVisibility = DesignerSerializationVisibility.Hidden,
    CLSCompliant = false,
    Localizability = Localizability.Text)]
public partial class MyControl : UserControl
{
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    public Task GeneratesCorrectlyWithOtherAttributes(Platform platform)
    {
        return this.CheckSourceAsync(GetHeader(platform, "Controls", "System") + @"
[CLSCompliant(false)]
public partial class MyControl : UserControl
{
}

[DependencyProperty<bool>(""IsSpinning5"")]
public partial class MyControl : UserControl
{   
    partial void OnIsSpinning5Changed(bool oldValue, bool newValue)
    {
    }
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    public Task GeneratesCorrectlyWithOtherAttributes2(Platform platform)
    {
        return this.CheckSourceAsync(GetHeader(platform) + @"
[DependencyProperty<string>(""Text"")]
[System.ComponentModel.DesignTimeVisible(false)]
public partial class Generatable : System.Windows.FrameworkElement
{
    partial void OnTextChanged(string? oldValue, string? newValue)
    {
    }
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    public Task GeneratesFloatLiteralsCorrectly(Platform platform)
    {
        return this.CheckSourceAsync(GetHeader(platform, "Controls") + @"
[DependencyProperty<float>(""FloatProperty"", DefaultValue = 42)]
public partial class MyControl : UserControl
{
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    public Task GeneratesValidateAndCoerceCorrectly(Platform platform)
    {
        return this.CheckSourceAsync(GetHeader(platform, "Controls") + @"
[DependencyProperty<string>(""NotNullStringProperty"", DefaultValue = """", Validate = true, Coerce = true)]
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
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    public Task GeneratesDefaultUpdateSourceTriggerCorrectly(Platform platform)
    {
        return this.CheckSourceAsync(GetHeader(platform, "Controls") + @"
[DependencyProperty<bool>(""ExplicitUpdateSourceTriggerProperty"", DefaultUpdateSourceTrigger = SourceTrigger.Explicit)]
public partial class MyControl : UserControl
{
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    public Task GeneratesReadOnlyPropertyCorrectly(Platform platform)
    {
        return this.CheckSourceAsync(GetHeader(platform, "Controls") + @"
[DependencyProperty<bool>(""ReadOnlyProperty"", IsReadOnly = true)]
public partial class MyControl : UserControl
{
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    public Task GeneratesAttachedReadOnlyPropertyCorrectly(Platform platform)
    {
        return this.CheckSourceAsync(GetHeader(platform, "Controls") + @"
[AttachedDependencyProperty<object, Grid>(""AttachedReadOnlyProperty"", IsReadOnly = true)]
public static partial class GridExtensions
{
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    public Task GeneratesBindEventCorrectly(Platform platform)
    {
        return this.CheckSourceAsync(GetHeader(platform, "Controls") + @"
[AttachedDependencyProperty<object, Grid>(""BindEventProperty"", BindEvent = nameof(Grid.MouseWheel))]
public static partial class GridExtensions
{
    private static void OnBindEventPropertyChanged_MouseWheel(object? sender, System.Windows.Input.MouseWheelEventArgs args)
    {
    }
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    public Task GeneratesBindEventsCorrectly(Platform platform)
    {
        return this.CheckSourceAsync(GetHeader(platform, "Controls") + @"
[DependencyProperty<object>(""BindEventsProperty"",
    BindEvents = new[] { nameof(Grid.MouseEnter), nameof(Grid.MouseLeave) })]
public partial class MyGrid : Grid
{
    private static void OnBindEventsPropertyChanged_MouseEnter(object? sender, System.Windows.Input.MouseEventArgs args)
    {
    }

    private static void OnBindEventsPropertyChanged_MouseLeave(object? sender, System.Windows.Input.MouseEventArgs args)
    {
    }
}", platform);
    }
}