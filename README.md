# DependencyPropertyGenerator
Dependency property source generator for WPF/UWP/WinUI/Uno/Avalonia platforms. 
For the WPF platform, RoutedEvents are also supported.

## Install
```
Install-Package DependencyPropertyGenerator // Generator
Install-Package DependencyPropertyGenerator.Core // Attributes
```

## Usage
```cs
using DependencyPropertyGenerator;
using System.Windows;
using System.Windows.Controls;

#nullable enable

namespace H.Generators.IntegrationTests;

[DependencyProperty<bool>("IsSpinning", DefaultValue = true, Category = "Category", Description = "Description")]
public partial class MainWindow : Window
{
    // Optional
    partial void OnIsSpinningChanged(bool oldValue, bool newValue)
    {
    }
}

[AttachedDependencyProperty<object, TreeView>("SelectedItem", BindsTwoWayByDefault = true)]
public static partial class TreeViewExtensions
{
    // Optional
    static partial void OnSelectedItemChanged(TreeView sender, object? oldValue, object? newValue)
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
        /// <summary>
        /// Description<br/>
        /// Default value: true
        /// </summary>
        public static readonly global::System.Windows.DependencyProperty IsSpinningProperty =
            global::System.Windows.DependencyProperty.Register(
                name: "IsSpinning",
                propertyType: typeof(bool),
                ownerType: typeof(global::H.Generators.IntegrationTests.MainWindow),
                typeMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: true,
                    flags: global::System.Windows.FrameworkPropertyMetadataOptions.None,
                    propertyChangedCallback: static (sender, args) =>
                        ((global::H.Generators.IntegrationTests.MainWindow)sender).OnIsSpinningChanged(
                            (bool)args.OldValue,
                            (bool)args.NewValue)));

        /// <summary>
        /// Description<br/>
        /// Default value: true
        /// </summary>
        [global::System.ComponentModel.Category("Category")]
        [global::System.ComponentModel.Description("Description")]
        public bool IsSpinning
        {
            get => (bool)GetValue(IsSpinningProperty);
            set => SetValue(IsSpinningProperty, value);
        }

        partial void OnIsSpinningChanged(bool oldValue, bool newValue);
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
        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static readonly global::System.Windows.DependencyProperty SelectedItemProperty =
            global::System.Windows.DependencyProperty.RegisterAttached(
                name: "SelectedItem",
                propertyType: typeof(object),
                ownerType: typeof(global::H.Generators.IntegrationTests.TreeViewExtensions),
                defaultMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: default(object),
                    flags: global::System.Windows.FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    propertyChangedCallback: static (sender, args) =>
                        OnSelectedItemChanged(
                            (global::System.Windows.Controls.TreeView)sender,
                            (object?)args.OldValue,
                            (object?)args.NewValue)));

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static void SetSelectedItem(global::System.Windows.DependencyObject element, object? value)
        {
            element.SetValue(SelectedItemProperty, value);
        }

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        [global::System.Windows.AttachedPropertyBrowsableForType(typeof(global::System.Windows.Controls.TreeView))]
        public static object? GetSelectedItem(global::System.Windows.DependencyObject element)
        {
            return (object?)element.GetValue(SelectedItemProperty);
        }

        static partial void OnSelectedItemChanged(global::System.Windows.Controls.TreeView sender, object? oldValue, object? newValue);
    }
}
```

## Advanced usage
### new object/struct() expressions in DefaultValue
While it's [generally not recommended](https://discord.com/channels/372137812037730304/669640275500466197/988522411274158131) 
to use new expressions in properties, a generator provides this capability:
```cs
public readonly record struct Data();

[AttachedDependencyProperty<object, TreeView>(""SelectedItem"", DefaultValueExpression = ""new Data()"")]
```
If your type is declared outside the namespace of an attribute declaration, you will need to specify the full name of the type, including the namespace.

### XML documentation
If for some reason you need to save xml documentation for your properties, 
there is an option to specify xml text for both DependencyProperty and getter/setter 
via XmlDoc/PropertyXmlDoc attribute properties.

## Notes
To use generic attributes, you need to set up `LangVersion` in your .csproj:
```xml
<LangVersion>preview</LangVersion>
```
There are also non-Generic attributes here.

## Support
Priority place for bugs: https://github.com/HavenDV/DependencyPropertyGenerator/issues
Priority place for ideas and general questions: https://github.com/HavenDV/DependencyPropertyGenerator/discussions
I also have a Discord support channel:  
https://discord.gg/g8u2t9dKgE