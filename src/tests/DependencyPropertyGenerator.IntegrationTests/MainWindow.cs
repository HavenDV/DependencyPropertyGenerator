using DependencyPropertyGenerator;
using System.Windows;
using System.Windows.Controls;

#nullable enable

namespace H.Generators.IntegrationTests;

[DependencyProperty<bool>("IsSpinning", DefaultValue = true)]
public partial class MainWindow : Window
{
    static partial void OnIsSpinningChanged(MainWindow sender, bool oldValue, bool newValue)
    {
    }
}

[AttachedDependencyProperty<object, TreeView>("SelectedItem", BindsTwoWayByDefault = true)]
public static partial class TreeViewExtensions
{
    static partial void OnSelectedItemChanged(TreeView sender, object? oldValue, object? newValue)
    {
    }
}