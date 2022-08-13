//HintName: GridExtensions.AttachedProperties.SomeProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public static partial class GridExtensions
    {
        /// <summary>
        /// Identifies the <see cref="SomeProperty"/> dependency property.<br/>
        /// Default value: default(object)
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindableProperty SomePropertyProperty =
            global::Microsoft.Maui.Controls.BindableProperty.CreateAttached(
            propertyName: "SomeProperty",
            returnType: typeof(object),
            declaringType: typeof(global::H.Generators.IntegrationTests.GridExtensions),
            defaultValue: default(object),
            defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
            validateValue: null,
            propertyChanged: null,
            propertyChanging: null,
            coerceValue: null,
            defaultValueCreator: null);

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static void SetSomeProperty(global::Microsoft.Maui.Controls.BindableObject element, object? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(SomePropertyProperty, value);
        }

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static object? GetSomeProperty(global::Microsoft.Maui.Controls.BindableObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (object?)element.GetValue(SomePropertyProperty);
        }

        static partial void OnSomePropertyChanged();
        static partial void OnSomePropertyChanged(global::Microsoft.Maui.Controls.BindableObject bindableObject);
        static partial void OnSomePropertyChanged(global::Microsoft.Maui.Controls.BindableObject bindableObject, object? newValue);
        static partial void OnSomePropertyChanged(global::Microsoft.Maui.Controls.BindableObject bindableObject, object? oldValue, object? newValue);
        static partial void OnSomePropertyChanging();
        static partial void OnSomePropertyChanging(global::Microsoft.Maui.Controls.BindableObject bindableObject);
        static partial void OnSomePropertyChanging(global::Microsoft.Maui.Controls.BindableObject bindableObject, object? newValue);
        static partial void OnSomePropertyChanging(global::Microsoft.Maui.Controls.BindableObject bindableObject, object? oldValue, object? newValue);
    }
}