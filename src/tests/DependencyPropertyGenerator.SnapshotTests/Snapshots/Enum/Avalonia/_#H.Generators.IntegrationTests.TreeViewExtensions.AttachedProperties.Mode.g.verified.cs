//HintName: H.Generators.IntegrationTests.TreeViewExtensions.AttachedProperties.Mode.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class TreeViewExtensions
    {
        /// <summary>
        /// Identifies the Mode dependency property.<br/>
        /// Default value: Mode2
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        public static readonly global::Avalonia.AttachedProperty<global::H.Generators.IntegrationTests.Mode> ModeProperty =
            global::Avalonia.AvaloniaProperty.RegisterAttached<global::H.Generators.IntegrationTests.TreeViewExtensions, global::Avalonia.Controls.TreeView, global::H.Generators.IntegrationTests.Mode>(
                name: "Mode",
                defaultValue: (global::H.Generators.IntegrationTests.Mode)1,
                inherits: false,
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                validate: null,
                coerce: null);

        /// <summary>
        /// Default value: Mode2
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static void SetMode(global::Avalonia.AvaloniaObject element, global::H.Generators.IntegrationTests.Mode value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(ModeProperty, value);
        }

        /// <summary>
        /// Default value: Mode2
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static global::H.Generators.IntegrationTests.Mode GetMode(global::Avalonia.AvaloniaObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (global::H.Generators.IntegrationTests.Mode)element.GetValue(ModeProperty);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnModeChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnModeChanged(global::Avalonia.Controls.TreeView treeView);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnModeChanged(global::Avalonia.Controls.TreeView treeView, global::H.Generators.IntegrationTests.Mode newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnModeChanged(global::Avalonia.Controls.TreeView treeView, global::H.Generators.IntegrationTests.Mode oldValue, global::H.Generators.IntegrationTests.Mode newValue);
    }
}