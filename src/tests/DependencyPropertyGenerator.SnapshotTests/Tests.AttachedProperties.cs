namespace H.Generators.SnapshotTests;

public partial class Tests : VerifyBase
{
    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    [DataRow(Platform.Avalonia)]
    public Task GeneratesEnumCorrectly(Platform platform)
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
    public Task GeneratesAttachedReadOnlyPropertyCorrectly(Platform platform)
    {
        return CheckSourceAsync(GetHeader(platform, "Controls") + @"
[AttachedDependencyProperty<object, Grid>(""AttachedReadOnlyProperty"", IsReadOnly = true)]
public static partial class GridExtensions
{
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    public Task GeneratesBindEventCorrectly(Platform platform)
    {
        return CheckSourceAsync(GetHeader(platform, "Controls") + @"
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
    public Task AttachedPropertyWithoutSecondType(Platform platform)
    {
        return CheckSourceAsync(GetHeader(platform) + @"
[AttachedDependencyProperty<object>(""AttachedPropertyWithoutSecondType"")]
public static partial class GridExtensions
{
}", platform);
    }
}