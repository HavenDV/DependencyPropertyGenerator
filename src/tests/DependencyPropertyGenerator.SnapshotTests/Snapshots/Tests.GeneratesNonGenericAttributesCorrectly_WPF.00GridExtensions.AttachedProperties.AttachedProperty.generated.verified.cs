//HintName: GridExtensions.AttachedProperties.AttachedProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public static partial class GridExtensions
    {
        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static readonly global::System.Windows.DependencyProperty AttachedPropertyProperty =
            global::System.Windows.DependencyProperty.RegisterAttached(
                name: "AttachedProperty",
                propertyType: typeof(object),
                ownerType: typeof(global::H.Generators.IntegrationTests.GridExtensions),
                defaultMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: default(object),
                    flags: global::System.Windows.FrameworkPropertyMetadataOptions.None,
                    propertyChangedCallback: static (sender, args) =>
                        OnAttachedPropertyChanged(
                            (global::System.Windows.Controls.Grid)sender,
                            (object?)args.OldValue,
                            (object?)args.NewValue),
                    coerceValueCallback: null,
                    isAnimationProhibited: false),
                validateValueCallback: null);

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static void SetAttachedProperty(global::System.Windows.DependencyObject element, object? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(AttachedPropertyProperty, value);
        }

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        [global::System.Windows.AttachedPropertyBrowsableForType(typeof(global::System.Windows.Controls.Grid))]
        public static object? GetAttachedProperty(global::System.Windows.DependencyObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (object?)element.GetValue(AttachedPropertyProperty);
        }

        static partial void OnAttachedPropertyChanged(global::System.Windows.Controls.Grid sender, object? oldValue, object? newValue);
    }
}