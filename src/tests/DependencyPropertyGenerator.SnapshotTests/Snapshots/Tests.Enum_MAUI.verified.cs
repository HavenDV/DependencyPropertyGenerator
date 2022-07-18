//HintName: GridExtensions.AttachedProperties.Mode.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public static partial class GridExtensions
    {
        /// <summary>
        /// Default value: Mode2
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindableProperty ModeProperty =
            global::Microsoft.Maui.Controls.BindableProperty.CreateAttached(
            propertyName: "Mode",
            returnType: typeof(global::H.Generators.IntegrationTests.Mode),
            declaringType: typeof(global::H.Generators.IntegrationTests.GridExtensions),
            defaultValue: (global::H.Generators.IntegrationTests.Mode)1,
            defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
            validateValue: null,
            propertyChanged: static (sender, oldValue, newValue) =>
            {
                OnModeChanged();
                OnModeChanged(
                    (global::Microsoft.Maui.Controls.Grid)sender);
                OnModeChanged(
                    (global::Microsoft.Maui.Controls.Grid)sender,
                    (global::H.Generators.IntegrationTests.Mode)newValue);
                OnModeChanged(
                    (global::Microsoft.Maui.Controls.Grid)sender,
                    (global::H.Generators.IntegrationTests.Mode)oldValue,
                    (global::H.Generators.IntegrationTests.Mode)newValue);
            },
            propertyChanging: static (sender, oldValue, newValue) =>
            {
                OnModeChanging();
                OnModeChanging(
                    (global::Microsoft.Maui.Controls.Grid)sender);
                OnModeChanging(
                    (global::Microsoft.Maui.Controls.Grid)sender,
                    (global::H.Generators.IntegrationTests.Mode)newValue);
                OnModeChanging(
                    (global::Microsoft.Maui.Controls.Grid)sender,
                    (global::H.Generators.IntegrationTests.Mode)oldValue,
                    (global::H.Generators.IntegrationTests.Mode)newValue);
            },
            coerceValue: null,
            defaultValueCreator: null);

        /// <summary>
        /// Default value: Mode2
        /// </summary>
        public static void SetMode(global::Microsoft.Maui.Controls.BindableObject element, global::H.Generators.IntegrationTests.Mode value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(ModeProperty, value);
        }

        /// <summary>
        /// Default value: Mode2
        /// </summary>
        public static global::H.Generators.IntegrationTests.Mode GetMode(global::Microsoft.Maui.Controls.BindableObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (global::H.Generators.IntegrationTests.Mode)element.GetValue(ModeProperty);
        }

        static partial void OnModeChanged();
        static partial void OnModeChanged(global::Microsoft.Maui.Controls.Grid grid);
        static partial void OnModeChanged(global::Microsoft.Maui.Controls.Grid grid, global::H.Generators.IntegrationTests.Mode newValue);
        static partial void OnModeChanged(global::Microsoft.Maui.Controls.Grid grid, global::H.Generators.IntegrationTests.Mode oldValue, global::H.Generators.IntegrationTests.Mode newValue);
        static partial void OnModeChanging();
        static partial void OnModeChanging(global::Microsoft.Maui.Controls.Grid grid);
        static partial void OnModeChanging(global::Microsoft.Maui.Controls.Grid grid, global::H.Generators.IntegrationTests.Mode newValue);
        static partial void OnModeChanging(global::Microsoft.Maui.Controls.Grid grid, global::H.Generators.IntegrationTests.Mode oldValue, global::H.Generators.IntegrationTests.Mode newValue);
    }
}