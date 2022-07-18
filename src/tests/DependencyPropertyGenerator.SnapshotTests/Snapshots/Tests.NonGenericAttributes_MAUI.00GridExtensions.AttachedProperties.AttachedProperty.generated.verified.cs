//HintName: GridExtensions.AttachedProperties.AttachedProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public static partial class GridExtensions
    {
        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindableProperty AttachedPropertyProperty =
            global::Microsoft.Maui.Controls.BindableProperty.CreateAttached(
            propertyName: "AttachedProperty",
            returnType: typeof(object),
            declaringType: typeof(global::H.Generators.IntegrationTests.GridExtensions),
            defaultValue: default(object),
            defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
            validateValue: null,
            propertyChanged: static (sender, oldValue, newValue) =>
            {
                OnAttachedPropertyChanged();
                OnAttachedPropertyChanged(
                    (global::Microsoft.Maui.Controls.Grid)sender);
                OnAttachedPropertyChanged(
                    (global::Microsoft.Maui.Controls.Grid)sender,
                    (object?)newValue);
                OnAttachedPropertyChanged(
                    (global::Microsoft.Maui.Controls.Grid)sender,
                    (object?)oldValue,
                    (object?)newValue);
            },
            propertyChanging: static (sender, oldValue, newValue) =>
            {
                OnAttachedPropertyChanging();
                OnAttachedPropertyChanging(
                    (global::Microsoft.Maui.Controls.Grid)sender);
                OnAttachedPropertyChanging(
                    (global::Microsoft.Maui.Controls.Grid)sender,
                    (object?)newValue);
                OnAttachedPropertyChanging(
                    (global::Microsoft.Maui.Controls.Grid)sender,
                    (object?)oldValue,
                    (object?)newValue);
            },
            coerceValue: null,
            defaultValueCreator: null);

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static void SetAttachedProperty(global::Microsoft.Maui.Controls.BindableObject element, object? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(AttachedPropertyProperty, value);
        }

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static object? GetAttachedProperty(global::Microsoft.Maui.Controls.BindableObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (object?)element.GetValue(AttachedPropertyProperty);
        }

        static partial void OnAttachedPropertyChanged();
        static partial void OnAttachedPropertyChanged(global::Microsoft.Maui.Controls.Grid grid);
        static partial void OnAttachedPropertyChanged(global::Microsoft.Maui.Controls.Grid grid, object? newValue);
        static partial void OnAttachedPropertyChanged(global::Microsoft.Maui.Controls.Grid grid, object? oldValue, object? newValue);
        static partial void OnAttachedPropertyChanging();
        static partial void OnAttachedPropertyChanging(global::Microsoft.Maui.Controls.Grid grid);
        static partial void OnAttachedPropertyChanging(global::Microsoft.Maui.Controls.Grid grid, object? newValue);
        static partial void OnAttachedPropertyChanging(global::Microsoft.Maui.Controls.Grid grid, object? oldValue, object? newValue);
    }
}