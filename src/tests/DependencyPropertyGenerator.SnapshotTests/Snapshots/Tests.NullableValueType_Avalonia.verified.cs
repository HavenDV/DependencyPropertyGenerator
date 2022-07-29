//HintName: Generatable.Properties.Property.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class Generatable
    {
        /// <summary>
        /// Default value: default(int?)
        /// </summary>
        public static readonly global::Avalonia.StyledProperty<int?> PropertyProperty =
            global::Avalonia.AvaloniaProperty.Register<global::H.Generators.IntegrationTests.Generatable, int?>(
                name: "Property",
                defaultValue: default(int?),
                inherits: false,
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                validate: null,
                coerce: null,
                notifying: null);

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