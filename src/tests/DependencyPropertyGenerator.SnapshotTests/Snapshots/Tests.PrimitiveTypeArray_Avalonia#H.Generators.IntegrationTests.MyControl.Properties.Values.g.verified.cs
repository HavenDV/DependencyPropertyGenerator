//HintName: H.Generators.IntegrationTests.MyControl.Properties.Values.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Identifies the <see cref="Values"/> dependency property.<br/>
        /// Default value: default(double[])
        /// </summary>
        public static readonly global::Avalonia.StyledProperty<double[]?> ValuesProperty =
            global::Avalonia.AvaloniaProperty.Register<global::H.Generators.IntegrationTests.MyControl, double[]?>(
                name: "Values",
                defaultValue: default(double[]),
                inherits: false,
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                validate: null,
                coerce: null);

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
    }
}