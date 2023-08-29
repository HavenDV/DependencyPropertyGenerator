//HintName: H.Generators.IntegrationTests.MyGrid.Properties.TypeIntControl.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyGrid
    {
        /// <summary>
        /// Identifies the <see cref="TypeIntControl"/> dependency property.<br/>
        /// Default value: default((int, VisualElement))
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindableProperty TypeIntControlProperty =
            global::Microsoft.Maui.Controls.BindableProperty.Create(
                propertyName: "TypeIntControl",
                returnType: typeof((int, global::Microsoft.Maui.Controls.VisualElement)),
                declaringType: typeof(global::H.Generators.IntegrationTests.MyGrid),
                defaultValue: default((int, global::Microsoft.Maui.Controls.VisualElement)),
                defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
                validateValue: null,
                propertyChanged: null,
                propertyChanging: null,
                coerceValue: null,
                defaultValueCreator: null);

        /// <summary>
        /// Default value: default((int, VisualElement))
        /// </summary>
        public (int, global::Microsoft.Maui.Controls.VisualElement) TypeIntControl
        {
            get => ((int, global::Microsoft.Maui.Controls.VisualElement))GetValue(TypeIntControlProperty);
            set => SetValue(TypeIntControlProperty, value);
        }

        partial void OnTypeIntControlChanged();
        partial void OnTypeIntControlChanged((int, global::Microsoft.Maui.Controls.VisualElement) newValue);
        partial void OnTypeIntControlChanged((int, global::Microsoft.Maui.Controls.VisualElement) oldValue, (int, global::Microsoft.Maui.Controls.VisualElement) newValue);
        partial void OnTypeIntControlChanging();
        partial void OnTypeIntControlChanging((int, global::Microsoft.Maui.Controls.VisualElement) newValue);
        partial void OnTypeIntControlChanging((int, global::Microsoft.Maui.Controls.VisualElement) oldValue, (int, global::Microsoft.Maui.Controls.VisualElement) newValue);
    }
}