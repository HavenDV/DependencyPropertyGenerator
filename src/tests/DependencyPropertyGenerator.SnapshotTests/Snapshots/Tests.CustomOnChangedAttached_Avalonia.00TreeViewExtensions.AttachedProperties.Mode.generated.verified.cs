//HintName: TreeViewExtensions.AttachedProperties.Mode.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class TreeViewExtensions : global::Avalonia.AvaloniaObject
    {
        /// <summary>
        /// Default value: default(Mode)
        /// </summary>
        public static readonly global::Avalonia.AttachedProperty<global::H.Generators.IntegrationTests.Mode> ModeProperty =
            global::Avalonia.AvaloniaProperty.RegisterAttached<global::H.Generators.IntegrationTests.TreeViewExtensions, global::Avalonia.Controls.TreeView, global::H.Generators.IntegrationTests.Mode>(
                name: "Mode",
                defaultValue: default(global::H.Generators.IntegrationTests.Mode),
                inherits: false,
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                validate: null,
                coerce: null);

        /// <summary>
        /// Default value: default(Mode)
        /// </summary>
        public static void SetMode(global::Avalonia.IAvaloniaObject element, global::H.Generators.IntegrationTests.Mode value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(ModeProperty, value);
        }

        /// <summary>
        /// Default value: default(Mode)
        /// </summary>
        public static global::H.Generators.IntegrationTests.Mode GetMode(global::Avalonia.IAvaloniaObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (global::H.Generators.IntegrationTests.Mode)element.GetValue(ModeProperty);
        }

    }
}