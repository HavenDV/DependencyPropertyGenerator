//HintName: Generatable.Properties.Text.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class Generatable
    {
        /// <summary>
        /// Default value: default(string)
        /// </summary>
        public static readonly global::Avalonia.StyledProperty<string?> TextProperty =
            global::Avalonia.AvaloniaProperty.Register<global::H.Generators.IntegrationTests.Generatable, string?>(
                name: "Text",
                defaultValue: default(string),
                inherits: false,
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                validate: null,
                coerce: null,
                notifying: null);

        /// <summary>
        /// Default value: default(string)
        /// </summary>
        public string? Text
        {
            get => (string?)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

    }
}