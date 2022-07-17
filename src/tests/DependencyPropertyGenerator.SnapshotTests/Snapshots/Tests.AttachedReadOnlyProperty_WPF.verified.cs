//HintName: GridExtensions.AttachedProperties.AttachedReadOnlyProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public static partial class GridExtensions
    {
        /// <summary>
        /// Default value: default(object)
        /// </summary>
        internal static readonly global::System.Windows.DependencyPropertyKey AttachedReadOnlyPropertyPropertyKey =
            global::System.Windows.DependencyProperty.RegisterAttachedReadOnly(
                name: "AttachedReadOnlyProperty",
                propertyType: typeof(object),
                ownerType: typeof(global::H.Generators.IntegrationTests.GridExtensions),
                defaultMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: default(object),
                    flags: global::System.Windows.FrameworkPropertyMetadataOptions.None,
                    propertyChangedCallback: static (sender, args) =>
                    {
                        OnAttachedReadOnlyPropertyChanged();
                        OnAttachedReadOnlyPropertyChanged(
                            (global::System.Windows.Controls.Grid)sender);
                        OnAttachedReadOnlyPropertyChanged(
                            (global::System.Windows.Controls.Grid)sender,
                            (object?)args.NewValue);
                        OnAttachedReadOnlyPropertyChanged(
                            (global::System.Windows.Controls.Grid)sender,
                            (object?)args.OldValue,
                            (object?)args.NewValue);
                    },
                    coerceValueCallback: null,
                    isAnimationProhibited: false),
                validateValueCallback: null);

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static readonly global::System.Windows.DependencyProperty AttachedReadOnlyPropertyProperty
            = AttachedReadOnlyPropertyPropertyKey.DependencyProperty;

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        internal static void SetAttachedReadOnlyProperty(global::System.Windows.DependencyObject element, object? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(AttachedReadOnlyPropertyPropertyKey, value);
        }

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        [global::System.Windows.AttachedPropertyBrowsableForType(typeof(global::System.Windows.Controls.Grid))]
        public static object? GetAttachedReadOnlyProperty(global::System.Windows.DependencyObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (object?)element.GetValue(AttachedReadOnlyPropertyProperty);
        }

        static partial void OnAttachedReadOnlyPropertyChanged();
        static partial void OnAttachedReadOnlyPropertyChanged(global::System.Windows.Controls.Grid grid);
        static partial void OnAttachedReadOnlyPropertyChanged(global::System.Windows.Controls.Grid grid, object? newValue);
        static partial void OnAttachedReadOnlyPropertyChanged(global::System.Windows.Controls.Grid grid, object? oldValue, object? newValue);
    }
}