//HintName: GridExtensions.AttachedProperties.AttachedPropertyWithoutSecondType.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public static partial class GridExtensions
    {
        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static readonly global::System.Windows.DependencyProperty AttachedPropertyWithoutSecondTypeProperty =
            global::System.Windows.DependencyProperty.RegisterAttached(
                name: "AttachedPropertyWithoutSecondType",
                propertyType: typeof(object),
                ownerType: typeof(global::H.Generators.IntegrationTests.GridExtensions),
                defaultMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: default(object),
                    flags: global::System.Windows.FrameworkPropertyMetadataOptions.None,
                    propertyChangedCallback: static (sender, args) =>
                    {
                        OnAttachedPropertyWithoutSecondTypeChanged();
                        OnAttachedPropertyWithoutSecondTypeChanged(
                            (global::System.Windows.DependencyObject)sender);
                        OnAttachedPropertyWithoutSecondTypeChanged(
                            (global::System.Windows.DependencyObject)sender,
                            (object?)args.NewValue);
                        OnAttachedPropertyWithoutSecondTypeChanged(
                            (global::System.Windows.DependencyObject)sender,
                            (object?)args.OldValue,
                            (object?)args.NewValue);
                    },
                    coerceValueCallback: null,
                    isAnimationProhibited: false),
                validateValueCallback: null);

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static void SetAttachedPropertyWithoutSecondType(global::System.Windows.DependencyObject element, object? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(AttachedPropertyWithoutSecondTypeProperty, value);
        }

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        [global::System.Windows.AttachedPropertyBrowsableForType(typeof(global::System.Windows.DependencyObject))]
        public static object? GetAttachedPropertyWithoutSecondType(global::System.Windows.DependencyObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (object?)element.GetValue(AttachedPropertyWithoutSecondTypeProperty);
        }

        static partial void OnAttachedPropertyWithoutSecondTypeChanged();
        static partial void OnAttachedPropertyWithoutSecondTypeChanged(global::System.Windows.DependencyObject dependencyObject);
        static partial void OnAttachedPropertyWithoutSecondTypeChanged(global::System.Windows.DependencyObject dependencyObject, object? newValue);
        static partial void OnAttachedPropertyWithoutSecondTypeChanged(global::System.Windows.DependencyObject dependencyObject, object? oldValue, object? newValue);
    }
}