using DependencyPropertyGenerator;
using System.Windows;
using System.Windows.Controls;

namespace H.Generators.IntegrationTests;

[DependencyProperty("IsSpinning", typeof(bool))]
[AttachedDependencyProperty("IsBubbleSource", typeof(bool), defaultValue: true, browsableForType: typeof(System.Windows.Controls.TreeView))]
public partial class MainWindow : Window
{
    static partial void OnIsSpinningChanged(MainWindow sender, DependencyPropertyChangedEventArgs args)
    {
    }

    static partial void OnIsBubbleSourceChanged(TreeView sender, DependencyPropertyChangedEventArgs args)
    {
    }
}