//HintName: Generatable.Properties.Text.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class Generatable
    {
        /// <summary>
        /// Default value: default(string)
        /// </summary>
        public static readonly global::Microsoft.UI.Xaml.DependencyProperty TextProperty =
            global::Microsoft.UI.Xaml.DependencyProperty.Register(
                name: "Text",
                propertyType: typeof(string),
                ownerType: typeof(global::H.Generators.IntegrationTests.Generatable),
                typeMetadata: new global::Microsoft.UI.Xaml.PropertyMetadata(
                    defaultValue: default(string),
                    propertyChangedCallback: static (sender, args) =>
                    {
                        ((global::H.Generators.IntegrationTests.Generatable)sender).OnMyTextChanged(
                            (string?)args.NewValue);
                    }));

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