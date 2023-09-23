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
        public static readonly global::Avalonia.StyledProperty<global::System.Uri?> AquariumGraphicProperty =
            global::Avalonia.AvaloniaProperty.Register<global::H.Generators.IntegrationTests.Aquarium, global::System.Uri?>(
                name: "AquariumGraphic",
                defaultValue: (global::System.Uri)new System.Uri("http://www.contoso.com/aquarium-graphic.jpg"),
                inherits: false,
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                validate: null,
                coerce: null);

        /// <summary>
        /// Default value: jpg")
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::System.Uri? AquariumGraphic
        {
            get => (global::System.Uri?)GetValue(AquariumGraphicProperty);
            protected set => SetValue(AquariumGraphicProperty, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnAquariumGraphicChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnAquariumGraphicChanged(global::System.Uri? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnAquariumGraphicChanged(global::System.Uri? oldValue, global::System.Uri? newValue);
    }
}