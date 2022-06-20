using DependencyPropertyGenerator;
using System.Windows;
using System.Windows.Controls;

namespace H.Generators.IntegrationTests;

[DependencyProperty("IsSpinning", typeof(bool), DefaultValue = true)]
public partial class MainWindow : Window
{
    static partial void OnIsSpinningChanged(MainWindow sender, DependencyPropertyChangedEventArgs args)
    {
    }
}

[AttachedDependencyProperty("SelectedItem", typeof(object), BrowsableForType = typeof(TreeView))]
public static partial class TreeViewExtensions
{
    static partial void OnSelectedItemChanged(TreeView sender, DependencyPropertyChangedEventArgs args)
    {
    }
}