//HintName: Generatable.Properties.Text.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class Generatable
    {
        /// <summary>
        /// Default value: default(string)
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindableProperty TextProperty =
            global::Microsoft.Maui.Controls.BindableProperty.Create(
            propertyName: "Text",
            returnType: typeof(string),
            declaringType: typeof(global::H.Generators.IntegrationTests.Generatable),
            defaultValue: default(string),
            defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
            validateValue: null,
            propertyChanged: static (sender, oldValue, newValue) =>
            {
                ((global::H.Generators.IntegrationTests.Generatable)sender).OnMyTextChanged(
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

        partial void OnTextChanging();
        partial void OnTextChanging(string? newValue);
        partial void OnTextChanging(string? oldValue, string? newValue);
    }
}