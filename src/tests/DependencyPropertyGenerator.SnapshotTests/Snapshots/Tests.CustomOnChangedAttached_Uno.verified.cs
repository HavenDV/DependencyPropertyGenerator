//HintName: TreeViewExtensions.AttachedProperties.Mode.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public static partial class TreeViewExtensions
    {
        /// <summary>
        /// Default value: default(Mode)
        /// </summary>
        public static readonly global::Windows.UI.Xaml.DependencyProperty ModeProperty =
            global::Windows.UI.Xaml.DependencyProperty.RegisterAttached(
                name: "Mode",
                propertyType: typeof(global::H.Generators.IntegrationTests.Mode),
                ownerType: typeof(global::H.Generators.IntegrationTests.TreeViewExtensions),
                typeMetadata: new global::Windows.UI.Xaml.PropertyMetadata(
                    defaultValue: default(global::H.Generators.IntegrationTests.Mode),
                    propertyChangedCallback: static (sender, args) =>
                    {
                        OnModeChanged(
                            (global::Windows.UI.Xaml.Controls.TreeView)sender,
                            (global::H.Generators.IntegrationTests.Mode)args.OldValue,
                            (global::H.Generators.IntegrationTests.Mode)args.NewValue);
                    }));

        /// <summary>
        /// Default value: default(Mode)
        /// </summary>
        public static void SetMode(global::Windows.UI.Xaml.DependencyObject element, global::H.Generators.IntegrationTests.Mode value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(ModeProperty, value);
        }

        /// <summary>
        /// Default value: default(Mode)
        /// </summary>
        public static global::H.Generators.IntegrationTests.Mode GetMode(global::Windows.UI.Xaml.DependencyObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (global::H.Generators.IntegrationTests.Mode)element.GetValue(ModeProperty);
        }

    }
}