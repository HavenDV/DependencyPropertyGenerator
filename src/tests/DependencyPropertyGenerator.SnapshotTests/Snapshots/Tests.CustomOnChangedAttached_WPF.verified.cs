//HintName: TreeViewExtensions.AttachedProperties.Mode.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public static partial class TreeViewExtensions
    {
        /// <summary>
        /// Default value: default(Mode)
        /// </summary>
        public static readonly global::System.Windows.DependencyProperty ModeProperty =
            global::System.Windows.DependencyProperty.RegisterAttached(
                name: "Mode",
                propertyType: typeof(global::H.Generators.IntegrationTests.Mode),
                ownerType: typeof(global::H.Generators.IntegrationTests.TreeViewExtensions),
                defaultMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: default(global::H.Generators.IntegrationTests.Mode),
                    flags: global::System.Windows.FrameworkPropertyMetadataOptions.None,
                    propertyChangedCallback: static (sender, args) =>
                    {
                        OnModeChanged(
                            (global::System.Windows.Controls.TreeView)sender,
                            (global::H.Generators.IntegrationTests.Mode)args.OldValue,
                            (global::H.Generators.IntegrationTests.Mode)args.NewValue);
                    },
                    coerceValueCallback: null,
                    isAnimationProhibited: false),
                validateValueCallback: null);

        /// <summary>
        /// Default value: default(Mode)
        /// </summary>
        public static void SetMode(global::System.Windows.DependencyObject element, global::H.Generators.IntegrationTests.Mode value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(ModeProperty, value);
        }

        /// <summary>
        /// Default value: default(Mode)
        /// </summary>
        [global::System.Windows.AttachedPropertyBrowsableForType(typeof(global::System.Windows.Controls.TreeView))]
        public static global::H.Generators.IntegrationTests.Mode GetMode(global::System.Windows.DependencyObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (global::H.Generators.IntegrationTests.Mode)element.GetValue(ModeProperty);
        }

    }
}