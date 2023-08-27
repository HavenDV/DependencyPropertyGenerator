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
        public static readonly global::System.Windows.DependencyProperty ValuesProperty =
            global::System.Windows.DependencyProperty.Register(
                name: "Values",
                propertyType: typeof(double[]),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: default(double[]),
                    flags: global::System.Windows.FrameworkPropertyMetadataOptions.None,
                    propertyChangedCallback: null,
                    coerceValueCallback: null,
                    isAnimationProhibited: false),
                validateValueCallback: null);

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