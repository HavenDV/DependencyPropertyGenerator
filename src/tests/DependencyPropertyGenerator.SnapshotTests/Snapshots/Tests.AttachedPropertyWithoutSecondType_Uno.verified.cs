//HintName: GridExtensions.AttachedProperties.SomeProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public static partial class GridExtensions
    {
        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static readonly global::Windows.UI.Xaml.DependencyProperty SomePropertyProperty =
            global::Windows.UI.Xaml.DependencyProperty.RegisterAttached(
                name: "SomeProperty",
                propertyType: typeof(object),
                ownerType: typeof(global::H.Generators.IntegrationTests.GridExtensions),
                typeMetadata: new global::Windows.UI.Xaml.PropertyMetadata(
                    defaultValue: default(object),
                    propertyChangedCallback: static (sender, args) =>
                    {
                        OnSomePropertyChanged();
                        OnSomePropertyChanged(
                            (global::Windows.UI.Xaml.DependencyObject)sender);
                        OnSomePropertyChanged(
                            (global::Windows.UI.Xaml.DependencyObject)sender,
                            (object?)args.NewValue);
                        OnSomePropertyChanged(
                            (global::Windows.UI.Xaml.DependencyObject)sender,
                            (object?)args.OldValue,
                            (object?)args.NewValue);
                    }));

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static void SetSomeProperty(global::Windows.UI.Xaml.DependencyObject element, object? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(SomePropertyProperty, value);
        }

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static object? GetSomeProperty(global::Windows.UI.Xaml.DependencyObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (object?)element.GetValue(SomePropertyProperty);
        }

        static partial void OnSomePropertyChanged();
        static partial void OnSomePropertyChanged(global::Windows.UI.Xaml.DependencyObject dependencyObject);
        static partial void OnSomePropertyChanged(global::Windows.UI.Xaml.DependencyObject dependencyObject, object? newValue);
        static partial void OnSomePropertyChanged(global::Windows.UI.Xaml.DependencyObject dependencyObject, object? oldValue, object? newValue);
    }
}