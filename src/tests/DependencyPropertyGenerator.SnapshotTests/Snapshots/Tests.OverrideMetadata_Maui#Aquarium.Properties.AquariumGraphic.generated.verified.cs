//HintName: Aquarium.Properties.AquariumGraphic.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class Aquarium
    {
        /// <summary>
        /// Identifies the <see cref="AquariumGraphic"/> dependency property.<br/>
        /// Default value: jpg")
        /// </summary>
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
        public global::System.Uri? AquariumGraphic
        {
            get => (global::System.Uri?)GetValue(AquariumGraphicProperty);
            set => SetValue(AquariumGraphicProperty, value);
        }

        partial void OnAquariumGraphicChanged();
        partial void OnAquariumGraphicChanged(global::System.Uri? newValue);
        partial void OnAquariumGraphicChanged(global::System.Uri? oldValue, global::System.Uri? newValue);
        partial void OnAquariumGraphicChanging();
        partial void OnAquariumGraphicChanging(global::System.Uri? newValue);
        partial void OnAquariumGraphicChanging(global::System.Uri? oldValue, global::System.Uri? newValue);
    }
}