//HintName: TreeViewExtensions.AttachedProperties.Mode.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public static partial class TreeViewExtensions
    {
        /// <summary>
        /// Default value: Mode2
        /// </summary>
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
        public static void SetMode(global::Microsoft.UI.Xaml.DependencyObject element, global::H.Generators.IntegrationTests.Mode value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(ModeProperty, value);
        }

        /// <summary>
        /// Default value: Mode2
        /// </summary>
        public static global::H.Generators.IntegrationTests.Mode GetMode(global::Microsoft.UI.Xaml.DependencyObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (global::H.Generators.IntegrationTests.Mode)element.GetValue(ModeProperty);
        }

        static partial void OnModeChanged();
        static partial void OnModeChanged(global::Microsoft.UI.Xaml.Controls.TreeView treeView);
        static partial void OnModeChanged(global::Microsoft.UI.Xaml.Controls.TreeView treeView, global::H.Generators.IntegrationTests.Mode newValue);
        static partial void OnModeChanged(global::Microsoft.UI.Xaml.Controls.TreeView treeView, global::H.Generators.IntegrationTests.Mode oldValue, global::H.Generators.IntegrationTests.Mode newValue);
    }
}