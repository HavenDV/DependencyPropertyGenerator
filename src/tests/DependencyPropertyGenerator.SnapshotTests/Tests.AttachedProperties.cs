namespace H.Generators.SnapshotTests;

public partial class Tests : VerifyBase
{
    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    [DataRow(Platform.MAUI)]
    [DataRow(Platform.Avalonia)]
    public Task Enum(Platform platform)
    {
        return CheckSourceAsync(GetHeader(platform, "Controls") + @"
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
    [DataRow(Platform.MAUI)]
    [DataRow(Platform.Avalonia)]
    public Task AttachedReadOnlyProperty(Platform platform)
    {
        return CheckSourceAsync(GetHeader(platform, "Controls") + @"
[AttachedDependencyProperty<object, Grid>(""AttachedReadOnlyProperty"", IsReadOnly = true)]
public static partial class GridExtensions
{
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    [DataRow(Platform.MAUI)]
    [DataRow(Platform.Avalonia)]
    public Task BindEvent(Platform platform)
    {
        return CheckSourceAsync(GetHeader(platform, string.Empty, "Input") + @"
[AttachedDependencyProperty<object, UIElement>(""BindEventProperty"", BindEvent = nameof(UIElement.KeyUp))]
public static partial class UIElementExtensions
{
    private static void OnBindEventPropertyChanged_KeyUp(object? sender, KeyEventArgs args)
    {
    }
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    [DataRow(Platform.MAUI)]
    [DataRow(Platform.Avalonia)]
    public Task AttachedPropertyWithoutSecondType(Platform platform)
    {
        return CheckSourceAsync(GetHeader(platform) + @"
[AttachedDependencyProperty<object>(""SomeProperty"")]
public static partial class GridExtensions
{
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    [DataRow(Platform.MAUI)]
    [DataRow(Platform.Avalonia)]
    public Task CustomOnChangedAttached(Platform platform)
    {
        return CheckSourceAsync(GetHeader(platform, "Controls") + @"
[AttachedDependencyProperty<int, Grid>(""RowCount"", OnChanged = nameof(OnRowCountChanged), DefaultValue = -1)]
public static partial class GridHelpers
{
    static void OnRowCountChanged(Grid grid, int newValue)
    {
    }
}", platform);
    }
}