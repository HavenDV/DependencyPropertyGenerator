//HintName: MyControl.Properties.FloatProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Default value: 42
        /// </summary>
        public static readonly global::Microsoft.UI.Xaml.DependencyProperty FloatPropertyProperty =
            global::Microsoft.UI.Xaml.DependencyProperty.Register(
                name: "FloatProperty",
                propertyType: typeof(float),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: new global::Microsoft.UI.Xaml.PropertyMetadata(
                    defaultValue: (float)42,
                    propertyChangedCallback: static (sender, args) =>
                        ((global::H.Generators.IntegrationTests.MyControl)sender).OnFloatPropertyChanged(
                            (float)args.OldValue,
                            (float)args.NewValue)));

        /// <summary>
        /// Default value: 42
        /// </summary>
        public float FloatProperty
        {
            get => (float)GetValue(FloatPropertyProperty);
            set => SetValue(FloatPropertyProperty, value);
        }

        partial void OnFloatPropertyChanged(float oldValue, float newValue);
    }
}