//HintName: H.Generators.IntegrationTests.MyGrid.Properties.FloatProperty.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyGrid
    {
        /// <summary>
        /// Identifies the <see cref="FloatProperty"/> dependency property.<br/>
        /// Default value: 42
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindableProperty FloatPropertyProperty =
            global::Microsoft.Maui.Controls.BindableProperty.Create(
                propertyName: "FloatProperty",
                returnType: typeof(float),
                declaringType: typeof(global::H.Generators.IntegrationTests.MyGrid),
                defaultValue: (float)42,
                defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
                validateValue: null,
                propertyChanged: null,
                propertyChanging: null,
                coerceValue: null,
                defaultValueCreator: null);

        /// <summary>
        /// Default value: 42
        /// </summary>
        public float FloatProperty
        {
            get => (float)GetValue(FloatPropertyProperty);
            set => SetValue(FloatPropertyProperty, value);
        }

        partial void OnFloatPropertyChanged();
        partial void OnFloatPropertyChanged(float newValue);
        partial void OnFloatPropertyChanged(float oldValue, float newValue);
        partial void OnFloatPropertyChanging();
        partial void OnFloatPropertyChanging(float newValue);
        partial void OnFloatPropertyChanging(float oldValue, float newValue);
    }
}