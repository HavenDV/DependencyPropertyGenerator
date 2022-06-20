﻿//HintName: TreeViewExtensions_AttachedDependencyProperties.generated.cs

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
                defaultMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    default(object),
                    global::System.Windows.FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    static (sender, args) => OnSelectedItemChanged((System.Windows.Controls.TreeView)sender, (object?)args.OldValue, (object?)args.NewValue)));
  
        public static void SetSelectedItem(global::System.Windows.DependencyObject element, object? value)
        {
            element.SetValue(SelectedItemProperty, value);
        }

        [global::System.Windows.AttachedPropertyBrowsableForType(typeof(System.Windows.Controls.TreeView))]
        public static object? GetSelectedItem(global::System.Windows.DependencyObject element)
        {
            return (object?)element.GetValue(SelectedItemProperty);
        }

        static partial void OnSelectedItemChanged(System.Windows.Controls.TreeView sender, object? oldValue, object? newValue);
    }
}