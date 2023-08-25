//HintName: H.Generators.IntegrationTests.Generatable.Properties.Property.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class Generatable
    {
        /// <summary>
        /// Identifies the <see cref="Property"/> dependency property.<br/>
        /// Default value: default(int?)
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindableProperty PropertyProperty =
            global::Microsoft.Maui.Controls.BindableProperty.Create(
                propertyName: "Property",
                returnType: typeof(int?),
                declaringType: typeof(global::H.Generators.IntegrationTests.Generatable),
                defaultValue: default(int?),
                defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
                validateValue: null,
                propertyChanged: null,
                propertyChanging: null,
                coerceValue: null,
                defaultValueCreator: null);

        /// <summary>
        /// Default value: default(int?)
        /// </summary>
        public int? Property
        {
            get => (int?)GetValue(PropertyProperty);
            set => SetValue(PropertyProperty, value);
        }

        partial void OnPropertyChanged();
        partial void OnPropertyChanged(int? newValue);
        partial void OnPropertyChanged(int? oldValue, int? newValue);
        partial void OnPropertyChanging();
        partial void OnPropertyChanging(int? newValue);
        partial void OnPropertyChanging(int? oldValue, int? newValue);
    }
}