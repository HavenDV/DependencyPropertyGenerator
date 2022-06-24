//HintName: MyControl_FloatProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Default value: 42
        /// </summary>
        public static readonly global::System.Windows.DependencyProperty FloatPropertyProperty =
            global::System.Windows.DependencyProperty.Register(
                name: "FloatProperty",
                propertyType: typeof(float),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: (float)42,
                    flags: global::System.Windows.FrameworkPropertyMetadataOptions.None,
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