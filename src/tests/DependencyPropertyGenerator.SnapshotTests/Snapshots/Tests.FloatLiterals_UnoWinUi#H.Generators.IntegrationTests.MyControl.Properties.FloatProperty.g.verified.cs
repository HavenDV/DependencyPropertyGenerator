//HintName: H.Generators.IntegrationTests.MyControl.Properties.FloatProperty.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Identifies the <see cref="FloatProperty"/> dependency property.<br/>
        /// Default value: 42
        /// </summary>
        public static readonly global::Microsoft.UI.Xaml.DependencyProperty FloatPropertyProperty =
            global::Microsoft.UI.Xaml.DependencyProperty.Register(
                name: "FloatProperty",
                propertyType: typeof(float),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: new global::Microsoft.UI.Xaml.PropertyMetadata(
                    defaultValue: (float)42,
                    propertyChangedCallback: null));

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