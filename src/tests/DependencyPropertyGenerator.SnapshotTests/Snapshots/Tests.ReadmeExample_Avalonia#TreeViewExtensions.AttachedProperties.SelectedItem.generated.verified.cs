//HintName: TreeViewExtensions.AttachedProperties.SelectedItem.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class TreeViewExtensions : global::Avalonia.AvaloniaObject
    {
        /// <summary>
        /// Identifies the <see cref="SelectedItem"/> dependency property.<br/>
        /// Default value: default(object)
        /// </summary>
        public static readonly global::Avalonia.AttachedProperty<object?> SelectedItemProperty =
            global::Avalonia.AvaloniaProperty.RegisterAttached<global::H.Generators.IntegrationTests.TreeViewExtensions, global::Avalonia.Controls.TreeView, object?>(
                name: "SelectedItem",
                defaultValue: default(object),
                inherits: false,
                defaultBindingMode: global::Avalonia.Data.BindingMode.TwoWay,
                validate: null,
                coerce: null);

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static void SetSelectedItem(global::Avalonia.IAvaloniaObject element, object? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(SelectedItemProperty, value);
        }

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static object? GetSelectedItem(global::Avalonia.IAvaloniaObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (object?)element.GetValue(SelectedItemProperty);
        }

        static partial void OnSelectedItemChanged();
        static partial void OnSelectedItemChanged(global::Avalonia.Controls.TreeView treeView);
        static partial void OnSelectedItemChanged(global::Avalonia.Controls.TreeView treeView, object? newValue);
        static partial void OnSelectedItemChanged(global::Avalonia.Controls.TreeView treeView, object? oldValue, object? newValue);
    }
}