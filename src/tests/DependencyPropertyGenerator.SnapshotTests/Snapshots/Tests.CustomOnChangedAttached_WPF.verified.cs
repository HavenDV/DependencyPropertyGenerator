//HintName: GridHelpers.AttachedProperties.RowCount.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public static partial class GridHelpers
    {
        /// <summary>
        /// Identifies the <see cref="RowCount"/> dependency property.<br/>
        /// Default value: -1
        /// </summary>
        public static readonly global::System.Windows.DependencyProperty RowCountProperty =
            global::System.Windows.DependencyProperty.RegisterAttached(
                name: "RowCount",
                propertyType: typeof(int),
                ownerType: typeof(global::H.Generators.IntegrationTests.GridHelpers),
                defaultMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: (int)-1,
                    flags: global::System.Windows.FrameworkPropertyMetadataOptions.None,
                    propertyChangedCallback: static (sender, args) =>
                    {
                        OnRowCountChanged(
                            (global::System.Windows.Controls.Grid)sender,
                            (int)args.NewValue);
                    },
                    coerceValueCallback: null,
                    isAnimationProhibited: false),
                validateValueCallback: null);

        /// <summary>
        /// Default value: -1
        /// </summary>
        public static void SetRowCount(global::System.Windows.DependencyObject element, int value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(RowCountProperty, value);
        }

        /// <summary>
        /// Default value: -1
        /// </summary>
        [global::System.Windows.AttachedPropertyBrowsableForType(typeof(global::System.Windows.Controls.Grid))]
        public static int GetRowCount(global::System.Windows.DependencyObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (int)element.GetValue(RowCountProperty);
        }

    }
}