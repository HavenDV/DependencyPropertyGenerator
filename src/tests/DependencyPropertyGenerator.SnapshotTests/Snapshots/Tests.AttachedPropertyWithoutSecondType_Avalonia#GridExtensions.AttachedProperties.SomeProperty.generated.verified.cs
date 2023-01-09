//HintName: GridExtensions.AttachedProperties.SomeProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class GridExtensions : global::Avalonia.AvaloniaObject
    {
        /// <summary>
        /// Identifies the <see cref="SomeProperty"/> dependency property.<br/>
        /// Default value: default(object)
        /// </summary>
        public static readonly global::Avalonia.AttachedProperty<object?> SomePropertyProperty =
            global::Avalonia.AvaloniaProperty.RegisterAttached<global::H.Generators.IntegrationTests.GridExtensions, global::Avalonia.IAvaloniaObject, object?>(
                name: "SomeProperty",
                defaultValue: default(object),
                inherits: false,
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                validate: null,
                coerce: null);

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static void SetSomeProperty(global::Avalonia.IAvaloniaObject element, object? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(SomePropertyProperty, value);
        }

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static object? GetSomeProperty(global::Avalonia.IAvaloniaObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (object?)element.GetValue(SomePropertyProperty);
        }

        static partial void OnSomePropertyChanged();
        static partial void OnSomePropertyChanged(global::Avalonia.IAvaloniaObject iAvaloniaObject);
        static partial void OnSomePropertyChanged(global::Avalonia.IAvaloniaObject iAvaloniaObject, object? newValue);
        static partial void OnSomePropertyChanged(global::Avalonia.IAvaloniaObject iAvaloniaObject, object? oldValue, object? newValue);
    }
}