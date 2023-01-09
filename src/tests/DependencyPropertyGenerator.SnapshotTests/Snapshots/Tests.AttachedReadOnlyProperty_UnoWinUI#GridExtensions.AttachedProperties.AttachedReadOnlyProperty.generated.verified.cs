//HintName: GridExtensions.AttachedProperties.AttachedReadOnlyProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public static partial class GridExtensions
    {
        /// <summary>
        /// Identifies the AttachedReadOnlyProperty dependency property.<br/>
        /// Default value: default(object)
        /// </summary>
        public static readonly global::Microsoft.UI.Xaml.DependencyProperty AttachedReadOnlyPropertyProperty =
            global::Microsoft.UI.Xaml.DependencyProperty.RegisterAttached(
                name: "AttachedReadOnlyProperty",
                propertyType: typeof(object),
                ownerType: typeof(global::H.Generators.IntegrationTests.GridExtensions),
                typeMetadata: new global::Microsoft.UI.Xaml.PropertyMetadata(
                    defaultValue: default(object),
                    propertyChangedCallback: null));

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        internal static void SetAttachedReadOnlyProperty(global::Microsoft.UI.Xaml.DependencyObject element, object? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(AttachedReadOnlyPropertyProperty, value);
        }

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static object? GetAttachedReadOnlyProperty(global::Microsoft.UI.Xaml.DependencyObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (object?)element.GetValue(AttachedReadOnlyPropertyProperty);
        }

        static partial void OnAttachedReadOnlyPropertyChanged();
        static partial void OnAttachedReadOnlyPropertyChanged(global::Microsoft.UI.Xaml.Controls.Grid grid);
        static partial void OnAttachedReadOnlyPropertyChanged(global::Microsoft.UI.Xaml.Controls.Grid grid, object? newValue);
        static partial void OnAttachedReadOnlyPropertyChanged(global::Microsoft.UI.Xaml.Controls.Grid grid, object? oldValue, object? newValue);
    }
}