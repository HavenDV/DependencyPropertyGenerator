//HintName: H.Generators.IntegrationTests.MyGrid.Properties.NotNullStringProperty.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyGrid
    {
        /// <summary>
        /// Identifies the <see cref="NotNullStringProperty"/> dependency property.<br/>
        /// Default value: ""
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindableProperty NotNullStringPropertyProperty =
            global::Microsoft.Maui.Controls.BindableProperty.Create(
                propertyName: "NotNullStringProperty",
                returnType: typeof(string),
                declaringType: typeof(global::H.Generators.IntegrationTests.MyGrid),
                defaultValue: (string)"",
                defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
                validateValue: static (_, value) =>
                    IsNotNullStringPropertyValid(
                        (string?)value),
                propertyChanged: null,
                propertyChanging: null,
                coerceValue: static (sender, value) =>
                        ((global::H.Generators.IntegrationTests.MyGrid)sender).CoerceNotNullStringProperty(
                            (string?)value),
                defaultValueCreator: null);

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
        partial void OnNotNullStringPropertyChanging();
        partial void OnNotNullStringPropertyChanging(string? newValue);
        partial void OnNotNullStringPropertyChanging(string? oldValue, string? newValue);
        private partial string? CoerceNotNullStringProperty(string? value);
        private static partial bool IsNotNullStringPropertyValid(string? value);
    }
}