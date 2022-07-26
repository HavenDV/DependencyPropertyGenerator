//HintName: TreeViewExtensions.AttachedProperties.SelectedItem.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public static partial class TreeViewExtensions
    {
        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static readonly global::Microsoft.UI.Xaml.DependencyProperty SelectedItemProperty =
            global::Microsoft.UI.Xaml.DependencyProperty.RegisterAttached(
                name: "SelectedItem",
                propertyType: typeof(object),
                ownerType: typeof(global::H.Generators.IntegrationTests.TreeViewExtensions),
                typeMetadata: new global::Microsoft.UI.Xaml.PropertyMetadata(
                    defaultValue: default(object),
                    propertyChangedCallback: static (sender, args) =>
                    {
                        OnSelectedItemChanged();
                        OnSelectedItemChanged(
                            (global::Microsoft.UI.Xaml.Controls.TreeView)sender);
                        OnSelectedItemChanged(
                            (global::Microsoft.UI.Xaml.Controls.TreeView)sender,
                            (object?)args.NewValue);
                        OnSelectedItemChanged(
                            (global::Microsoft.UI.Xaml.Controls.TreeView)sender,
                            (object?)args.OldValue,
                            (object?)args.NewValue);
                    }));

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static void SetSelectedItem(global::Microsoft.UI.Xaml.DependencyObject element, object? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(SelectedItemProperty, value);
        }

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static object? GetSelectedItem(global::Microsoft.UI.Xaml.DependencyObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (object?)element.GetValue(SelectedItemProperty);
        }

        static partial void OnSelectedItemChanged();
        static partial void OnSelectedItemChanged(global::Microsoft.UI.Xaml.Controls.TreeView treeView);
        static partial void OnSelectedItemChanged(global::Microsoft.UI.Xaml.Controls.TreeView treeView, object? newValue);
        static partial void OnSelectedItemChanged(global::Microsoft.UI.Xaml.Controls.TreeView treeView, object? oldValue, object? newValue);
    }
}