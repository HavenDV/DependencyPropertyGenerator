//HintName: VisualElementExtensions.AttachedProperties.BindEventProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public static partial class VisualElementExtensions
    {
        /// <summary>
        /// Identifies the <see cref="BindEventProperty"/> dependency property.<br/>
        /// Default value: default(object)
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindableProperty BindEventPropertyProperty =
            global::Microsoft.Maui.Controls.BindableProperty.CreateAttached(
            propertyName: "BindEventProperty",
            returnType: typeof(object),
            declaringType: typeof(global::H.Generators.IntegrationTests.VisualElementExtensions),
            defaultValue: default(object),
            defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
            validateValue: null,
            propertyChanged: static (sender, oldValue, newValue) =>
            {
                OnBindEventPropertyChanged(
                    (global::Microsoft.Maui.Controls.VisualElement)sender,
                    (object?)oldValue,
                    (object?)newValue);
            },
            propertyChanging: null,
            coerceValue: null,
            defaultValueCreator: null);

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static void SetBindEventProperty(global::Microsoft.Maui.Controls.BindableObject element, object? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(BindEventPropertyProperty, value);
        }

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static object? GetBindEventProperty(global::Microsoft.Maui.Controls.BindableObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (object?)element.GetValue(BindEventPropertyProperty);
        }

        static partial void OnBindEventPropertyChanged();
        static partial void OnBindEventPropertyChanged(global::Microsoft.Maui.Controls.VisualElement visualElement);
        static partial void OnBindEventPropertyChanged(global::Microsoft.Maui.Controls.VisualElement visualElement, object? newValue);
        static partial void OnBindEventPropertyChanged(global::Microsoft.Maui.Controls.VisualElement visualElement, object? oldValue, object? newValue);
        static partial void OnBindEventPropertyChanging();
        static partial void OnBindEventPropertyChanging(global::Microsoft.Maui.Controls.VisualElement visualElement);
        static partial void OnBindEventPropertyChanging(global::Microsoft.Maui.Controls.VisualElement visualElement, object? newValue);
        static partial void OnBindEventPropertyChanging(global::Microsoft.Maui.Controls.VisualElement visualElement, object? oldValue, object? newValue);

        static partial void OnBindEventPropertyChanged_BeforeBind(
            global::Microsoft.Maui.Controls.VisualElement visualElement,
            object? oldValue,
            object? newValue);
        static partial void OnBindEventPropertyChanged_AfterBind(
            global::Microsoft.Maui.Controls.VisualElement visualElement,
            object? oldValue,
            object? newValue);

        static partial void OnBindEventPropertyChanged(
            global::Microsoft.Maui.Controls.VisualElement visualElement,
            object? oldValue,
            object? newValue)
        {
            OnBindEventPropertyChanged_BeforeBind(
                visualElement,
                oldValue,
                newValue);

            if (oldValue is not default(object))
            {
                visualElement.SizeChanged -= OnBindEventPropertyChanged_SizeChanged;
            }
            if (newValue is not default(object))
            {
                visualElement.SizeChanged += OnBindEventPropertyChanged_SizeChanged;
            }

            OnBindEventPropertyChanged_AfterBind(
                visualElement,
                oldValue,
                newValue);
        }
    }
}