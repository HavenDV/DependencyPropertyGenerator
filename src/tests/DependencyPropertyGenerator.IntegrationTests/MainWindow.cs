using DependencyPropertyGenerator;
using System.Windows;

namespace H.Generators.IntegrationTests;

[DependencyProperty("IsSpinning", typeof(bool))]
[AttachedDependencyProperty("IsBubbleSource", typeof(bool))]
public partial class MainWindow : Window
{
    static partial void OnIsSpinningChanged(MainWindow sender, DependencyPropertyChangedEventArgs args)
    {
    }

    static partial void OnIsBubbleSourceChanged(MainWindow sender, DependencyPropertyChangedEventArgs args)
    {
    }
}