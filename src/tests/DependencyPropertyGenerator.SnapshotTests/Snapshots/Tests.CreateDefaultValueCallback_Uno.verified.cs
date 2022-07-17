//HintName: MyGrid.Properties.SomeProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyGrid
    {
        /// <summary>
        /// Default value: default(string)
        /// </summary>
        public static readonly global::Windows.UI.Xaml.DependencyProperty SomePropertyProperty =
            global::Windows.UI.Xaml.DependencyProperty.Register(
                name: "SomeProperty",
                propertyType: typeof(string),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyGrid),
                typeMetadata: global::Windows.UI.Xaml.PropertyMetadata.Create(
                    createDefaultValueCallback: static () => GetSomePropertyDefaultValue(),
                    propertyChangedCallback: static (sender, args) =>
                    {
                        ((global::H.Generators.IntegrationTests.MyGrid)sender).OnSomePropertyChanged();
                        ((global::H.Generators.IntegrationTests.MyGrid)sender).OnSomePropertyChanged(
                            (string?)args.NewValue);
                        ((global::H.Generators.IntegrationTests.MyGrid)sender).OnSomePropertyChanged(
                            (string?)args.OldValue,
                            (string?)args.NewValue);
                    }));

        /// <summary>
        /// Default value: default(string)
        /// </summary>
        public string? SomeProperty
        {
            get => (string?)GetValue(SomePropertyProperty);
            set => SetValue(SomePropertyProperty, value);
        }

        partial void OnSomePropertyChanged();
        partial void OnSomePropertyChanged(string? newValue);
        partial void OnSomePropertyChanged(string? oldValue, string? newValue);
        private static partial string? GetSomePropertyDefaultValue();
    }
}