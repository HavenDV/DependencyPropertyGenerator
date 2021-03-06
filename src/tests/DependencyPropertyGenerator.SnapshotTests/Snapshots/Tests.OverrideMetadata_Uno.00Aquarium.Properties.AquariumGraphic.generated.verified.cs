//HintName: Aquarium.Properties.AquariumGraphic.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class Aquarium
    {
        /// <summary>
        /// Default value: jpg")
        /// </summary>
        public static readonly global::Windows.UI.Xaml.DependencyProperty AquariumGraphicProperty =
            global::Windows.UI.Xaml.DependencyProperty.Register(
                name: "AquariumGraphic",
                propertyType: typeof(global::System.Uri),
                ownerType: typeof(global::H.Generators.IntegrationTests.Aquarium),
                typeMetadata: new global::Windows.UI.Xaml.PropertyMetadata(
                    defaultValue: (global::System.Uri)new System.Uri("http://www.contoso.com/aquarium-graphic.jpg"),
                    propertyChangedCallback: null));

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
    }
}