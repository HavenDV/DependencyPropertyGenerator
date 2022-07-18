//HintName: GridExtensions.AttachedProperties.SelectedItem.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public static partial class GridExtensions
    {
        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindableProperty SelectedItemProperty =
            global::Microsoft.Maui.Controls.BindableProperty.CreateAttached(
            propertyName: "SelectedItem",
            returnType: typeof(object),
            declaringType: typeof(global::H.Generators.IntegrationTests.GridExtensions),
            defaultValue: default(object),
            defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
            validateValue: null,
            propertyChanged: static (sender, oldValue, newValue) =>
            {
                OnSelectedItemChanged();
                OnSelectedItemChanged(
                    (global::Microsoft.Maui.Controls.Grid)sender);
                OnSelectedItemChanged(
                    (global::Microsoft.Maui.Controls.Grid)sender,
                    (object?)newValue);
                OnSelectedItemChanged(
                    (global::Microsoft.Maui.Controls.Grid)sender,
                    (object?)oldValue,
                    (object?)newValue);
            },
            propertyChanging: static (sender, oldValue, newValue) =>
            {
                OnSelectedItemChanging();
                OnSelectedItemChanging(
                    (global::Microsoft.Maui.Controls.Grid)sender);
                OnSelectedItemChanging(
                    (global::Microsoft.Maui.Controls.Grid)sender,
                    (object?)newValue);
                OnSelectedItemChanging(
                    (global::Microsoft.Maui.Controls.Grid)sender,
                    (object?)oldValue,
                    (object?)newValue);
            },
            coerceValue: null,
            defaultValueCreator: null);

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static void SetSelectedItem(global::Microsoft.Maui.Controls.BindableObject element, object? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(SelectedItemProperty, value);
        }

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static object? GetSelectedItem(global::Microsoft.Maui.Controls.BindableObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (object?)element.GetValue(SelectedItemProperty);
        }

        static partial void OnSelectedItemChanged();
        static partial void OnSelectedItemChanged(global::Microsoft.Maui.Controls.Grid grid);
        static partial void OnSelectedItemChanged(global::Microsoft.Maui.Controls.Grid grid, object? newValue);
        static partial void OnSelectedItemChanged(global::Microsoft.Maui.Controls.Grid grid, object? oldValue, object? newValue);
        static partial void OnSelectedItemChanging();
        static partial void OnSelectedItemChanging(global::Microsoft.Maui.Controls.Grid grid);
        static partial void OnSelectedItemChanging(global::Microsoft.Maui.Controls.Grid grid, object? newValue);
        static partial void OnSelectedItemChanging(global::Microsoft.Maui.Controls.Grid grid, object? oldValue, object? newValue);
    }
}