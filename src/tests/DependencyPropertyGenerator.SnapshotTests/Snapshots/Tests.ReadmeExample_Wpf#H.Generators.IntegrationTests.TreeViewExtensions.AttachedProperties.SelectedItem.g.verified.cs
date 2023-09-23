//HintName: H.Generators.IntegrationTests.TreeViewExtensions.AttachedProperties.SelectedItem.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public static partial class TreeViewExtensions
    {
        /// <summary>
        /// Identifies the SelectedItem dependency property.<br/>
        /// Default value: default(object)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
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
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static void SetSelectedItem(global::System.Windows.DependencyObject element, object? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(SelectedItemProperty, value);
        }

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        [global::System.Windows.AttachedPropertyBrowsableForType(typeof(global::System.Windows.Controls.TreeView))]
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static object? GetSelectedItem(global::System.Windows.DependencyObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (object?)element.GetValue(SelectedItemProperty);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        static partial void OnSelectedItemChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        static partial void OnSelectedItemChanged(global::System.Windows.Controls.TreeView treeView);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        static partial void OnSelectedItemChanged(global::System.Windows.Controls.TreeView treeView, object? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        static partial void OnSelectedItemChanged(global::System.Windows.Controls.TreeView treeView, object? oldValue, object? newValue);
    }
}