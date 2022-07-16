//HintName: MyControl.Properties.NotNullStringProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Default value: ""
        /// </summary>
        public static readonly global::Microsoft.UI.Xaml.DependencyProperty NotNullStringPropertyProperty =
            global::Microsoft.UI.Xaml.DependencyProperty.Register(
                name: "NotNullStringProperty",
                propertyType: typeof(string),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: global::Microsoft.UI.Xaml.PropertyMetadata.Create(
                    defaultValue: (string)"",
                    propertyChangedCallback: static (sender, args) =>
                    {
                        ((global::H.Generators.IntegrationTests.MyControl)sender).OnNotNullStringPropertyChanged();
                        ((global::H.Generators.IntegrationTests.MyControl)sender).OnNotNullStringPropertyChanged(
                            (string?)args.NewValue);
                        ((global::H.Generators.IntegrationTests.MyControl)sender).OnNotNullStringPropertyChanged(
                            (string?)args.OldValue,
                            (string?)args.NewValue);
                    }));

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