//HintName: H.Generators.IntegrationTests.MyGrid.Properties.Values.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyGrid
    {
        /// <summary>
        /// Identifies the <see cref="Values"/> dependency property.<br/>
        /// Default value: default(double[])
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindableProperty ValuesProperty =
            global::Microsoft.Maui.Controls.BindableProperty.Create(
                propertyName: "Values",
                returnType: typeof(double[]),
                declaringType: typeof(global::H.Generators.IntegrationTests.MyGrid),
                defaultValue: default(double[]),
                defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
                validateValue: null,
                propertyChanged: null,
                propertyChanging: null,
                coerceValue: null,
                defaultValueCreator: null);

        /// <summary>
        /// Default value: default(double[])
        /// </summary>
        public double[]? Values
        {
            get => (double[]?)GetValue(ValuesProperty);
            set => SetValue(ValuesProperty, value);
        }

        partial void OnValuesChanged();
        partial void OnValuesChanged(double[]? newValue);
        partial void OnValuesChanged(double[]? oldValue, double[]? newValue);
        partial void OnValuesChanging();
        partial void OnValuesChanging(double[]? newValue);
        partial void OnValuesChanging(double[]? oldValue, double[]? newValue);
    }
}