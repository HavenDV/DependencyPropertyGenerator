//HintName: GridExtensions.AttachedProperties.AttachedProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public static partial class GridExtensions
    {
        /// <summary>
        /// Identifies the AttachedProperty dependency property.<br/>
        /// Default value: default(object)
        /// </summary>
        public static readonly global::Windows.UI.Xaml.DependencyProperty AttachedPropertyProperty =
            global::Windows.UI.Xaml.DependencyProperty.RegisterAttached(
                name: "AttachedProperty",
                propertyType: typeof(object),
                ownerType: typeof(global::H.Generators.IntegrationTests.GridExtensions),
                typeMetadata: new global::Windows.UI.Xaml.PropertyMetadata(
                    defaultValue: default(object),
                    propertyChangedCallback: null));

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static void SetAttachedProperty(global::Windows.UI.Xaml.DependencyObject element, object? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(AttachedPropertyProperty, value);
        }

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static object? GetAttachedProperty(global::Windows.UI.Xaml.DependencyObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (object?)element.GetValue(AttachedPropertyProperty);
        }

        static partial void OnAttachedPropertyChanged();
        static partial void OnAttachedPropertyChanged(global::Windows.UI.Xaml.Controls.Grid grid);
        static partial void OnAttachedPropertyChanged(global::Windows.UI.Xaml.Controls.Grid grid, object? newValue);
        static partial void OnAttachedPropertyChanged(global::Windows.UI.Xaml.Controls.Grid grid, object? oldValue, object? newValue);
    }
}