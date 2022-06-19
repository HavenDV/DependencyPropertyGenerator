# DependencyPropertyGenerator
Dependency property source generator for WPF/UWP/WinUI/Uno platforms.

### Install
```
Install-Package DependencyPropertyGenerator // Generator
Install-Package DependencyPropertyGenerator.Core // Attributes
```

### Usage
```cs
using DependencyPropertyGenerator;
using System.Windows;
using System.Windows.Controls;

namespace H.Generators.IntegrationTests;

[DependencyProperty("IsSpinning", typeof(bool))]
public partial class MainWindow : Window
{
    static partial void OnIsSpinningChanged(MainWindow sender, DependencyPropertyChangedEventArgs args)
    {
    }
}

[AttachedDependencyProperty("SelectedItem", typeof(object), browsableForType: typeof(System.Windows.Controls.TreeView))]
public static partial class TreeViewExtensions
{
    static partial void OnSelectedItemChanged(TreeView sender, DependencyPropertyChangedEventArgs args)
    {
    }
}
```
will generate:
```cs
//HintName: MainWindow_DependencyProperties.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
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
```cs
//HintName: TreeViewExtensions_AttachedDependencyProperties.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public static partial class TreeViewExtensions
    {
        public static readonly global::System.Windows.DependencyProperty SelectedItemProperty =
            global::System.Windows.DependencyProperty.RegisterAttached(
                name: "SelectedItem",
                propertyType: typeof(object),
                ownerType: typeof(TreeViewExtensions),
                defaultMetadata: new global::System.Windows.PropertyMetadata(
                    typeof(System.Windows.Controls.TreeView),
                    static (sender, args) => OnSelectedItemChanged((System.Windows.Controls.TreeView)sender, args)));
  
        public static void SetSelectedItem(global::System.Windows.DependencyObject element, object value)
        {
            element.SetValue(SelectedItemProperty, value);
        }

        [global::System.Windows.AttachedPropertyBrowsableForType(typeof(System.Windows.Controls.TreeView))]
        public static object GetSelectedItem(global::System.Windows.DependencyObject element)
        {
            return (object)element.GetValue(SelectedItemProperty);
        }

        static partial void OnSelectedItemChanged(System.Windows.Controls.TreeView sender, global::System.Windows.DependencyPropertyChangedEventArgs args);
    }
}
```