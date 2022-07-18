//HintName: TreeViewExtensions.AttachedProperties.Mode.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class TreeViewExtensions : global::Avalonia.AvaloniaObject
    {
        /// <summary>
        /// Default value: Mode2
        /// </summary>
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
        public static void SetMode(global::Avalonia.IAvaloniaObject element, global::H.Generators.IntegrationTests.Mode value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(ModeProperty, value);
        }

        /// <summary>
        /// Default value: Mode2
        /// </summary>
        public static global::H.Generators.IntegrationTests.Mode GetMode(global::Avalonia.IAvaloniaObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (global::H.Generators.IntegrationTests.Mode)element.GetValue(ModeProperty);
        }

        static partial void OnModeChanged();
        static partial void OnModeChanged(global::Avalonia.Controls.TreeView treeView);
        static partial void OnModeChanged(global::Avalonia.Controls.TreeView treeView, global::H.Generators.IntegrationTests.Mode newValue);
        static partial void OnModeChanged(global::Avalonia.Controls.TreeView treeView, global::H.Generators.IntegrationTests.Mode oldValue, global::H.Generators.IntegrationTests.Mode newValue);
    }
}