namespace H.Generators.SnapshotTests;

public partial class Tests
{
    [DataTestMethod]
    [DataRow(Framework.Wpf)]
    [DataRow(Framework.Uno)]
    [DataRow(Framework.UnoWinUi)]
    [DataRow(Framework.Maui)]
    [DataRow(Framework.Avalonia)]
    public Task ReadmeExample(Framework framework)
    {
        return CheckSourceAsync<DependencyPropertyGenerator>(GetHeader(framework, "Controls") + @"
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
}", framework, default, new AttachedDependencyPropertyGenerator(), new StaticConstructorGenerator());
    }
}