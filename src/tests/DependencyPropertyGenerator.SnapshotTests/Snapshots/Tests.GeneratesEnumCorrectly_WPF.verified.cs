//HintName: TreeViewExtensions_Mode.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public static partial class TreeViewExtensions
    {
        /// <summary>
        /// Default value: Mode2
        /// </summary>
        public static readonly global::System.Windows.DependencyProperty ModeProperty =
            global::System.Windows.DependencyProperty.RegisterAttached(
                name: "Mode",
                propertyType: typeof(global::H.Generators.IntegrationTests.Mode),
                ownerType: typeof(global::H.Generators.IntegrationTests.TreeViewExtensions),
                defaultMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: (global::H.Generators.IntegrationTests.Mode)1,
                    flags: global::System.Windows.FrameworkPropertyMetadataOptions.None,
                    propertyChangedCallback: static (sender, args) =>
                        OnModeChanged(
                            (global::System.Windows.Controls.TreeView)sender,
                            (global::H.Generators.IntegrationTests.Mode)args.OldValue,
                            (global::H.Generators.IntegrationTests.Mode)args.NewValue)));

        /// <summary>
        /// Default value: Mode2
        /// </summary>
        public static void SetMode(global::System.Windows.DependencyObject element, global::H.Generators.IntegrationTests.Mode value)
        {
            element.SetValue(ModeProperty, value);
        }

        /// <summary>
        /// Default value: Mode2
        /// </summary>
        [global::System.Windows.AttachedPropertyBrowsableForType(typeof(global::System.Windows.Controls.TreeView))]
        public static global::H.Generators.IntegrationTests.Mode GetMode(global::System.Windows.DependencyObject element)
        {
            return (global::H.Generators.IntegrationTests.Mode)element.GetValue(ModeProperty);
        }

        static partial void OnModeChanged(global::System.Windows.Controls.TreeView sender, global::H.Generators.IntegrationTests.Mode oldValue, global::H.Generators.IntegrationTests.Mode newValue);
    }
}