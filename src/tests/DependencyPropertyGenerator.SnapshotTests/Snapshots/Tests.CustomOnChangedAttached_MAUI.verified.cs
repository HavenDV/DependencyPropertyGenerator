//HintName: GridHelpers.AttachedProperties.RowCount.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public static partial class GridHelpers
    {
        /// <summary>
        /// Default value: -1
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindableProperty RowCountProperty =
            global::Microsoft.Maui.Controls.BindableProperty.CreateAttached(
            propertyName: "RowCount",
            returnType: typeof(int),
            declaringType: typeof(global::H.Generators.IntegrationTests.GridHelpers),
            defaultValue: (int)-1,
            defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
            validateValue: null,
            propertyChanged: static (sender, oldValue, newValue) =>
            {
                OnRowCountChanged(
                    (global::Microsoft.Maui.Controls.Grid)sender,
                    (int)newValue);
            },
            propertyChanging: null,
            coerceValue: null,
            defaultValueCreator: null);

        /// <summary>
        /// Default value: -1
        /// </summary>
        public static void SetRowCount(global::Microsoft.Maui.Controls.BindableObject element, int value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(RowCountProperty, value);
        }

        /// <summary>
        /// Default value: -1
        /// </summary>
        public static int GetRowCount(global::Microsoft.Maui.Controls.BindableObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (int)element.GetValue(RowCountProperty);
        }

        static partial void OnRowCountChanging();
        static partial void OnRowCountChanging(global::Microsoft.Maui.Controls.Grid grid);
        static partial void OnRowCountChanging(global::Microsoft.Maui.Controls.Grid grid, int newValue);
        static partial void OnRowCountChanging(global::Microsoft.Maui.Controls.Grid grid, int oldValue, int newValue);
    }
}