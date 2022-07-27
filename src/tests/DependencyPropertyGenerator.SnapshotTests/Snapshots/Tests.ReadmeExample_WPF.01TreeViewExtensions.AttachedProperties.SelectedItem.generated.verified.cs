//HintName: TreeViewExtensions.AttachedProperties.SelectedItem.generated.cs

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
                    {
                        OnSelectedItemChanged(
                            (global::System.Windows.Controls.TreeView)sender,
                            (object?)args.OldValue,
                            (object?)args.NewValue);
                    },
                    coerceValueCallback: null,
                    isAnimationProhibited: false),
                validateValueCallback: null);

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static void SetSelectedItem(global::System.Windows.DependencyObject element, object? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(SelectedItemProperty, value);
        }

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        [global::System.Windows.AttachedPropertyBrowsableForType(typeof(global::System.Windows.Controls.TreeView))]
        public static object? GetSelectedItem(global::System.Windows.DependencyObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (object?)element.GetValue(SelectedItemProperty);
        }

        static partial void OnSelectedItemChanged();
        static partial void OnSelectedItemChanged(global::System.Windows.Controls.TreeView treeView);
        static partial void OnSelectedItemChanged(global::System.Windows.Controls.TreeView treeView, object? newValue);
        static partial void OnSelectedItemChanged(global::System.Windows.Controls.TreeView treeView, object? oldValue, object? newValue);
    }
}