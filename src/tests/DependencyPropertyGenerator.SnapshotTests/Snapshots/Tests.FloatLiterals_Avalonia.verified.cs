//HintName: MyControl.Properties.FloatProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Identifies the <see cref="FloatProperty"/> dependency property.<br/>
        /// Default value: 42
        /// </summary>
        public static readonly global::Avalonia.StyledProperty<float> FloatPropertyProperty =
            global::Avalonia.AvaloniaProperty.Register<global::H.Generators.IntegrationTests.MyControl, float>(
                name: "FloatProperty",
                defaultValue: (float)42,
                inherits: false,
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                validate: null,
                coerce: null,
                notifying: null);

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