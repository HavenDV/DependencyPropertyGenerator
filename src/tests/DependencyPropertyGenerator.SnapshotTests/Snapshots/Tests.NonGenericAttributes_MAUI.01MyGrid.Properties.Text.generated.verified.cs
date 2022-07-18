//HintName: MyGrid.Properties.Text.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyGrid
    {
        /// <summary>
        /// Default value: default(string)
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindableProperty TextProperty =
            global::Microsoft.Maui.Controls.BindableProperty.Create(
            propertyName: "Text",
            returnType: typeof(string),
            declaringType: typeof(global::H.Generators.IntegrationTests.MyGrid),
            defaultValue: default(string),
            defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
            validateValue: null,
            propertyChanged: static (sender, oldValue, newValue) =>
            {
                ((global::H.Generators.IntegrationTests.MyGrid)sender).OnTextChanged();
                ((global::H.Generators.IntegrationTests.MyGrid)sender).OnTextChanged(
                    (string?)newValue);
                ((global::H.Generators.IntegrationTests.MyGrid)sender).OnTextChanged(
                    (string?)oldValue,
                    (string?)newValue);
            },
            propertyChanging: null,
            coerceValue: null,
            defaultValueCreator: null);

        /// <summary>
        /// Default value: default(string)
        /// </summary>
        public string? Text
        {
            get => (string?)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        partial void OnTextChanged();
        partial void OnTextChanged(string? newValue);
        partial void OnTextChanged(string? oldValue, string? newValue);
    }
}