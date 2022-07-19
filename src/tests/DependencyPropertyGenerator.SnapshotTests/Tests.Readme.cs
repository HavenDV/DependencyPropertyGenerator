namespace H.Generators.SnapshotTests;

public partial class Tests : VerifyBase
{
    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    [DataRow(Platform.MAUI)]
    [DataRow(Platform.Avalonia)]
    public Task ReadmeExample(Platform platform)
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

[AttachedDependencyProperty<object, TreeView>(""SelectedItem"", DefaultBindingMode = DefaultBindingMode.TwoWay)]
public static partial class TreeViewExtensions
{
    // Optional
    static partial void OnSelectedItemChanged(TreeView sender, object? oldValue, object? newValue)
    {
    }
}", platform);
    }
}