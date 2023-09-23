//HintName: H.Generators.IntegrationTests.TreeViewExtensions.AttachedProperties.SelectedItem.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class TreeViewExtensions : global::Avalonia.AvaloniaObject
    {
        /// <summary>
        /// Identifies the SelectedItem dependency property.<br/>
        /// Default value: default(object)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
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
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static void SetSelectedItem(global::Avalonia.AvaloniaObject element, object? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(SelectedItemProperty, value);
        }

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static object? GetSelectedItem(global::Avalonia.AvaloniaObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (object?)element.GetValue(SelectedItemProperty);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        static partial void OnSelectedItemChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        static partial void OnSelectedItemChanged(global::Avalonia.Controls.TreeView treeView);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        static partial void OnSelectedItemChanged(global::Avalonia.Controls.TreeView treeView, object? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        static partial void OnSelectedItemChanged(global::Avalonia.Controls.TreeView treeView, object? oldValue, object? newValue);
    }
}