//HintName: TropicalAquarium.StaticConstructor.generated.cs
#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class TropicalAquarium
    {
        static TropicalAquarium()
        {
            AquariumGraphicProperty.OverrideMetadata(
                forType: typeof(global::H.Generators.IntegrationTests.TropicalAquarium),
                typeMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: (global::System.Uri)new System.Uri("http://www.contoso.com/tropical-aquarium-graphic.jpg"),
                    flags: global::System.Windows.FrameworkPropertyMetadataOptions.None,
                    propertyChangedCallback: null,
                    coerceValueCallback: null,
                    isAnimationProhibited: false));
        }

        partial void OnAquariumGraphicChanged();
        partial void OnAquariumGraphicChanged(global::System.Uri? newValue);
        partial void OnAquariumGraphicChanged(global::System.Uri? oldValue, global::System.Uri? newValue);
    }
}