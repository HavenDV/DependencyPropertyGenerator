//HintName: H.Generators.IntegrationTests.MyGrid.Properties.TypeControlInt.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyGrid
    {
        /// <summary>
        /// Identifies the <see cref="TypeControlInt"/> dependency property.<br/>
        /// Default value: default((VisualElement, int))
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindableProperty TypeControlIntProperty =
            global::Microsoft.Maui.Controls.BindableProperty.Create(
                propertyName: "TypeControlInt",
                returnType: typeof((global::Microsoft.Maui.Controls.VisualElement, int)),
                declaringType: typeof(global::H.Generators.IntegrationTests.MyGrid),
                defaultValue: default((global::Microsoft.Maui.Controls.VisualElement, int)),
                defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
                validateValue: null,
                propertyChanged: null,
                propertyChanging: null,
                coerceValue: null,
                defaultValueCreator: null);

        /// <summary>
        /// Default value: default((VisualElement, int))
        /// </summary>
        public (global::Microsoft.Maui.Controls.VisualElement, int) TypeControlInt
        {
            get => ((global::Microsoft.Maui.Controls.VisualElement, int))GetValue(TypeControlIntProperty);
            set => SetValue(TypeControlIntProperty, value);
        }

        partial void OnTypeControlIntChanged();
        partial void OnTypeControlIntChanged((global::Microsoft.Maui.Controls.VisualElement, int) newValue);
        partial void OnTypeControlIntChanged((global::Microsoft.Maui.Controls.VisualElement, int) oldValue, (global::Microsoft.Maui.Controls.VisualElement, int) newValue);
        partial void OnTypeControlIntChanging();
        partial void OnTypeControlIntChanging((global::Microsoft.Maui.Controls.VisualElement, int) newValue);
        partial void OnTypeControlIntChanging((global::Microsoft.Maui.Controls.VisualElement, int) oldValue, (global::Microsoft.Maui.Controls.VisualElement, int) newValue);
    }
}