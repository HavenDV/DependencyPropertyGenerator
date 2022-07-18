//HintName: MyGrid.Properties.FloatProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyGrid
    {
        /// <summary>
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
            propertyChanged: static (sender, oldValue, newValue) =>
            {
                ((global::H.Generators.IntegrationTests.MyGrid)sender).OnFloatPropertyChanged();
                ((global::H.Generators.IntegrationTests.MyGrid)sender).OnFloatPropertyChanged(
                    (float)newValue);
                ((global::H.Generators.IntegrationTests.MyGrid)sender).OnFloatPropertyChanged(
                    (float)oldValue,
                    (float)newValue);
            },
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
    }
}