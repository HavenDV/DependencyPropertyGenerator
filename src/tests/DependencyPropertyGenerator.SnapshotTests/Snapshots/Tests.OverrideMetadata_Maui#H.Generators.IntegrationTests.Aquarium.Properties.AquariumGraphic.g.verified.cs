//HintName: H.Generators.IntegrationTests.Aquarium.Properties.AquariumGraphic.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class Aquarium
    {
        /// <summary>
        /// Identifies the <see cref="AquariumGraphic"/> dependency property.<br/>
        /// Default value: jpg")
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        public static readonly global::Microsoft.Maui.Controls.BindableProperty AquariumGraphicProperty =
            global::Microsoft.Maui.Controls.BindableProperty.Create(
                propertyName: "AquariumGraphic",
                returnType: typeof(global::System.Uri),
                declaringType: typeof(global::H.Generators.IntegrationTests.Aquarium),
                defaultValue: (global::System.Uri)new System.Uri("http://www.contoso.com/aquarium-graphic.jpg"),
                defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
                validateValue: null,
                propertyChanged: null,
                propertyChanging: null,
                coerceValue: null,
                defaultValueCreator: null);

        /// <summary>
        /// Default value: jpg")
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::System.Uri? AquariumGraphic
        {
            get => (global::System.Uri?)GetValue(AquariumGraphicProperty);
            set => SetValue(AquariumGraphicProperty, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnAquariumGraphicChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnAquariumGraphicChanged(global::System.Uri? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnAquariumGraphicChanged(global::System.Uri? oldValue, global::System.Uri? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnAquariumGraphicChanging();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnAquariumGraphicChanging(global::System.Uri? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnAquariumGraphicChanging(global::System.Uri? oldValue, global::System.Uri? newValue);
    }
}