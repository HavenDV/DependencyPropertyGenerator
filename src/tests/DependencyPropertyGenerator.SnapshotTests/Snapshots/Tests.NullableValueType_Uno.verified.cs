//HintName: Generatable.Properties.Property.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class Generatable
    {
        /// <summary>
        /// Default value: default(int?)
        /// </summary>
        public static readonly global::Windows.UI.Xaml.DependencyProperty PropertyProperty =
            global::Windows.UI.Xaml.DependencyProperty.Register(
                name: "Property",
                propertyType: typeof(int?),
                ownerType: typeof(global::H.Generators.IntegrationTests.Generatable),
                typeMetadata: new global::Windows.UI.Xaml.PropertyMetadata(
                    defaultValue: default(int?),
                    propertyChangedCallback: null));

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
    }
}