//HintName: GridExtensions.AttachedProperties.SomeProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public static partial class GridExtensions
    {
        /// <summary>
        /// Identifies the SomeProperty dependency property.<br/>
        /// Default value: default(object)
        /// </summary>
        public static readonly global::Microsoft.UI.Xaml.DependencyProperty SomePropertyProperty =
            global::Microsoft.UI.Xaml.DependencyProperty.RegisterAttached(
                name: "SomeProperty",
                propertyType: typeof(object),
                ownerType: typeof(global::H.Generators.IntegrationTests.GridExtensions),
                typeMetadata: new global::Microsoft.UI.Xaml.PropertyMetadata(
                    defaultValue: default(object),
                    propertyChangedCallback: null));

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static void SetSomeProperty(global::Microsoft.UI.Xaml.DependencyObject element, object? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(SomePropertyProperty, value);
        }

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static object? GetSomeProperty(global::Microsoft.UI.Xaml.DependencyObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (object?)element.GetValue(SomePropertyProperty);
        }

        static partial void OnSomePropertyChanged();
        static partial void OnSomePropertyChanged(global::Microsoft.UI.Xaml.DependencyObject dependencyObject);
        static partial void OnSomePropertyChanged(global::Microsoft.UI.Xaml.DependencyObject dependencyObject, object? newValue);
        static partial void OnSomePropertyChanged(global::Microsoft.UI.Xaml.DependencyObject dependencyObject, object? oldValue, object? newValue);
    }
}