namespace H.Generators.SnapshotTests;

public partial class Tests : VerifyBase
{
    [DataTestMethod]
    [DataRow(Platform.WPF)]
    //[DataRow(Platform.UWP)]
    //[DataRow(Platform.WinUI)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    [DataRow(Platform.MAUI)]
    public Task GeneratesReadmeExampleCorrectly(Platform platform)
    {
        return CheckSourceAsync(GetHeader(platform, "Controls") + @"
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
}