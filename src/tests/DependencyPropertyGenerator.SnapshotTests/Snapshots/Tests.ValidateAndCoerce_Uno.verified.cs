//HintName: MyControl.Properties.NotNullStringProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Default value: ""
        /// </summary>
        public static readonly global::Windows.UI.Xaml.DependencyProperty NotNullStringPropertyProperty =
            global::Windows.UI.Xaml.DependencyProperty.Register(
                name: "NotNullStringProperty",
                propertyType: typeof(string),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: new global::Windows.UI.Xaml.PropertyMetadata(
                    defaultValue: (string)"",
                    propertyChangedCallback: null));

        /// <summary>
        /// Default value: ""
        /// </summary>
        public string? NotNullStringProperty
        {
            get => (string?)GetValue(NotNullStringPropertyProperty);
            set => SetValue(NotNullStringPropertyProperty, value);
        }

        partial void OnNotNullStringPropertyChanged();
        partial void OnNotNullStringPropertyChanged(string? newValue);
        partial void OnNotNullStringPropertyChanged(string? oldValue, string? newValue);
        private partial string? CoerceNotNullStringProperty(string? value);
        private static partial bool IsNotNullStringPropertyValid(string? value);
    }
}