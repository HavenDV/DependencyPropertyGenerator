# DependencyPropertyGenerator
Dependency property source generator for WPF/UWP/WinUI/Uno platforms.

### Usage
```cs
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
```
will generate:
```cs
//HintName: MainWindow_AttachedDependencyProperties.generated.cs

#nullable enable

namespace H.Ipc.Apps.Wpf
{
    public partial class MainWindow
    {
        public static readonly global::System.Windows.DependencyProperty IsBubbleSourceProperty =
            global::System.Windows.DependencyProperty.RegisterAttached(
                name: "IsBubbleSource",
                propertyType: typeof(bool),
                ownerType: typeof(MainWindow),
                defaultMetadata: new global::System.Windows.PropertyMetadata(
                    true,
                    static (sender, args) => OnIsBubbleSourceChanged((System.Windows.Controls.TreeView)sender, args)));
  
        public static void SetIsBubbleSource(global::System.Windows.DependencyObject element, bool value)
        {
            element.SetValue(IsBubbleSourceProperty, value);
        }

        [global::System.Windows.AttachedPropertyBrowsableForType(typeof(System.Windows.Controls.TreeView))]
        public static bool GetIsBubbleSource(global::System.Windows.DependencyObject element)
        {
            return (bool)element.GetValue(IsBubbleSourceProperty);
        }

        static partial void OnIsBubbleSourceChanged(System.Windows.Controls.TreeView sender, global::System.Windows.DependencyPropertyChangedEventArgs args);
    }
}
```
```cs
//HintName: MainWindow_DependencyProperties.generated.cs

#nullable enable

namespace H.Ipc.Apps.Wpf
{
    public partial class MainWindow
    {
        public static readonly global::System.Windows.DependencyProperty IsSpinningProperty =
            global::System.Windows.DependencyProperty.Register(
                name: "IsSpinning",
                propertyType: typeof(bool),
                ownerType: typeof(MainWindow),
                typeMetadata: new global::System.Windows.PropertyMetadata(
                    default(bool),
                    static (sender, args) => OnIsSpinningChanged((MainWindow)sender, args)));

        public bool IsSpinning
        {
            get => (bool)GetValue(IsSpinningProperty);
            set => SetValue(IsSpinningProperty, value);
        }

        static partial void OnIsSpinningChanged(MainWindow sender, global::System.Windows.DependencyPropertyChangedEventArgs args);
    }
}
```