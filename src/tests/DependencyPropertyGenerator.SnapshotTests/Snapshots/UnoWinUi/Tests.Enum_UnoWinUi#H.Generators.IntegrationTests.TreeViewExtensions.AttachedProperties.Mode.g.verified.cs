//HintName: H.Generators.IntegrationTests.TreeViewExtensions.AttachedProperties.Mode.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public static partial class TreeViewExtensions
    {
        /// <summary>
        /// Identifies the Mode dependency property.<br/>
        /// Default value: Mode2
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        public static readonly global::Microsoft.UI.Xaml.DependencyProperty ModeProperty =
            global::Microsoft.UI.Xaml.DependencyProperty.RegisterAttached(
                name: "Mode",
                propertyType: typeof(global::H.Generators.IntegrationTests.Mode),
                ownerType: typeof(global::H.Generators.IntegrationTests.TreeViewExtensions),
                typeMetadata: new global::Microsoft.UI.Xaml.PropertyMetadata(
                    defaultValue: (global::H.Generators.IntegrationTests.Mode)1,
                    propertyChangedCallback: static (sender, args) =>
                    {
                        OnModeChanged(
                            (global::Microsoft.UI.Xaml.Controls.TreeView)sender,
                            (global::H.Generators.IntegrationTests.Mode)args.OldValue,
                            (global::H.Generators.IntegrationTests.Mode)args.NewValue);
                    }));

        /// <summary>
        /// Default value: Mode2
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static void SetMode(global::Microsoft.UI.Xaml.DependencyObject element, global::H.Generators.IntegrationTests.Mode value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(ModeProperty, value);
        }

        /// <summary>
        /// Default value: Mode2
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static global::H.Generators.IntegrationTests.Mode GetMode(global::Microsoft.UI.Xaml.DependencyObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (global::H.Generators.IntegrationTests.Mode)element.GetValue(ModeProperty);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        static partial void OnModeChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        static partial void OnModeChanged(global::Microsoft.UI.Xaml.Controls.TreeView treeView);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        static partial void OnModeChanged(global::Microsoft.UI.Xaml.Controls.TreeView treeView, global::H.Generators.IntegrationTests.Mode newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        static partial void OnModeChanged(global::Microsoft.UI.Xaml.Controls.TreeView treeView, global::H.Generators.IntegrationTests.Mode oldValue, global::H.Generators.IntegrationTests.Mode newValue);
    }
}