//HintName: UIElementExtensions.AttachedProperties.BindEventProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class UIElementExtensions : global::Avalonia.AvaloniaObject
    {
        /// <summary>
        /// Identifies the <see cref="BindEventProperty"/> dependency property.<br/>
        /// Default value: default(object)
        /// </summary>
        public static readonly global::Avalonia.AttachedProperty<object?> BindEventPropertyProperty =
            global::Avalonia.AvaloniaProperty.RegisterAttached<global::H.Generators.IntegrationTests.UIElementExtensions, global::Avalonia.Input.InputElement, object?>(
                name: "BindEventProperty",
                defaultValue: default(object),
                inherits: false,
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                validate: null,
                coerce: null);

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static void SetBindEventProperty(global::Avalonia.IAvaloniaObject element, object? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(BindEventPropertyProperty, value);
        }

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static object? GetBindEventProperty(global::Avalonia.IAvaloniaObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (object?)element.GetValue(BindEventPropertyProperty);
        }

        static partial void OnBindEventPropertyChanged();
        static partial void OnBindEventPropertyChanged(global::Avalonia.Input.InputElement inputElement);
        static partial void OnBindEventPropertyChanged(global::Avalonia.Input.InputElement inputElement, object? newValue);
        static partial void OnBindEventPropertyChanged(global::Avalonia.Input.InputElement inputElement, object? oldValue, object? newValue);

        static partial void OnBindEventPropertyChanged_BeforeBind(
            global::Avalonia.Input.InputElement inputElement,
            object? oldValue,
            object? newValue);
        static partial void OnBindEventPropertyChanged_AfterBind(
            global::Avalonia.Input.InputElement inputElement,
            object? oldValue,
            object? newValue);

        static partial void OnBindEventPropertyChanged(
            global::Avalonia.Input.InputElement inputElement,
            object? oldValue,
            object? newValue)
        {
            OnBindEventPropertyChanged_BeforeBind(
                inputElement,
                oldValue,
                newValue);

            if (oldValue is not default(object))
            {
                inputElement.KeyUp -= OnBindEventPropertyChanged_KeyUp;
            }
            if (newValue is not default(object))
            {
                inputElement.KeyUp += OnBindEventPropertyChanged_KeyUp;
            }

            OnBindEventPropertyChanged_AfterBind(
                inputElement,
                oldValue,
                newValue);
        }
    }
}