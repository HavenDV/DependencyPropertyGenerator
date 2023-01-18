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
        public static readonly global::System.Windows.DependencyProperty SomePropertyProperty =
            global::System.Windows.DependencyProperty.RegisterAttached(
                name: "SomeProperty",
                propertyType: typeof(object),
                ownerType: typeof(global::H.Generators.IntegrationTests.GridExtensions),
                defaultMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: default(object),
                    flags: global::System.Windows.FrameworkPropertyMetadataOptions.None,
                    propertyChangedCallback: null,
                    coerceValueCallback: null,
                    isAnimationProhibited: false),
                validateValueCallback: null);

        /// <summary>
        /// first line.
        /// second line.<br/>
        /// Default value: default(object)
        /// </summary>
        [global::System.ComponentModel.Description("first line.
second line.")]
        public static void SetSomeProperty(global::System.Windows.DependencyObject element, object? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(SomePropertyProperty, value);
        }

        /// <summary>
        /// first line.
        /// second line.<br/>
        /// Default value: default(object)
        /// </summary>
        [global::System.ComponentModel.Description("first line.
second line.")]
        [global::System.Windows.AttachedPropertyBrowsableForType(typeof(global::System.Windows.DependencyObject))]
        public static object? GetSomeProperty(global::System.Windows.DependencyObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (object?)element.GetValue(SomePropertyProperty);
        }

        static partial void OnSomePropertyChanged();
        static partial void OnSomePropertyChanged(global::System.Windows.DependencyObject dependencyObject);
        static partial void OnSomePropertyChanged(global::System.Windows.DependencyObject dependencyObject, object? newValue);
        static partial void OnSomePropertyChanged(global::System.Windows.DependencyObject dependencyObject, object? oldValue, object? newValue);
    }
}