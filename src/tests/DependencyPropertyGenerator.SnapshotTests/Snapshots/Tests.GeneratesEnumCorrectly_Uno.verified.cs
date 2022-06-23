//HintName: TreeViewExtensions_Mode.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public static partial class TreeViewExtensions
    {
        /// <summary>
        /// Default value: Mode2
        /// </summary>
        public static readonly global::Windows.UI.Xaml.DependencyProperty ModeProperty =
            global::Windows.UI.Xaml.DependencyProperty.RegisterAttached(
                name: "Mode",
                propertyType: typeof(global::H.Generators.IntegrationTests.Mode),
                ownerType: typeof(global::H.Generators.IntegrationTests.TreeViewExtensions),
                typeMetadata: new global::Windows.UI.Xaml.PropertyMetadata(
                    defaultValue: (global::H.Generators.IntegrationTests.Mode)1,
                    propertyChangedCallback: static (sender, args) =>
                        OnModeChanged(
                            (global::Windows.UI.Xaml.Controls.TreeView)sender,
                            (global::H.Generators.IntegrationTests.Mode)args.OldValue,
                            (global::H.Generators.IntegrationTests.Mode)args.NewValue)));

        /// <summary>
        /// Default value: Mode2
        /// </summary>
        public static void SetMode(global::Windows.UI.Xaml.DependencyObject element, global::H.Generators.IntegrationTests.Mode value)
        {
            element.SetValue(ModeProperty, value);
        }

        /// <summary>
        /// Default value: Mode2
        /// </summary>
        public static global::H.Generators.IntegrationTests.Mode GetMode(global::Windows.UI.Xaml.DependencyObject element)
        {
            return (global::H.Generators.IntegrationTests.Mode)element.GetValue(ModeProperty);
        }

        static partial void OnModeChanged(global::Windows.UI.Xaml.Controls.TreeView sender, global::H.Generators.IntegrationTests.Mode oldValue, global::H.Generators.IntegrationTests.Mode newValue);
    }
}