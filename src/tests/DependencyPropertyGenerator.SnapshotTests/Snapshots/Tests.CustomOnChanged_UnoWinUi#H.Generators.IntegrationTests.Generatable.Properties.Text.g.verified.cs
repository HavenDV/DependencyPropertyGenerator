//HintName: H.Generators.IntegrationTests.Generatable.Properties.Text.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class Generatable
    {
        /// <summary>
        /// Identifies the <see cref="Text"/> dependency property.<br/>
        /// Default value: default(string)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
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
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public string? Text
        {
            get => (string?)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

    }
}