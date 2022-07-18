//HintName: Aquarium.Properties.AquariumGraphic.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class Aquarium
    {
        /// <summary>
        /// Default value: jpg")
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindablePropertyKey AquariumGraphicPropertyKey =
            global::Microsoft.Maui.Controls.BindableProperty.CreateReadOnly(
            propertyName: "AquariumGraphic",
            returnType: typeof(global::System.Uri),
            declaringType: typeof(global::H.Generators.IntegrationTests.Aquarium),
            defaultValue: (global::System.Uri)new System.Uri("http://www.contoso.com/aquarium-graphic.jpg"),
            defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWayToSource,
            validateValue: null,
            propertyChanged: static (sender, oldValue, newValue) =>
            {
                ((global::H.Generators.IntegrationTests.Aquarium)sender).OnAquariumGraphicChanged();
                ((global::H.Generators.IntegrationTests.Aquarium)sender).OnAquariumGraphicChanged(
                    (global::System.Uri?)newValue);
                ((global::H.Generators.IntegrationTests.Aquarium)sender).OnAquariumGraphicChanged(
                    (global::System.Uri?)oldValue,
                    (global::System.Uri?)newValue);
            },
            propertyChanging: static (sender, oldValue, newValue) =>
            {
                ((global::H.Generators.IntegrationTests.Aquarium)sender).OnAquariumGraphicChanging();
                ((global::H.Generators.IntegrationTests.Aquarium)sender).OnAquariumGraphicChanging(
                    (global::System.Uri?)newValue);
                ((global::H.Generators.IntegrationTests.Aquarium)sender).OnAquariumGraphicChanging(
                    (global::System.Uri?)oldValue,
                    (global::System.Uri?)newValue);
            },
            coerceValue: null,
            defaultValueCreator: null);

        /// <summary>
        /// Default value: jpg")
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindableProperty AquariumGraphicProperty
            = AquariumGraphicPropertyKey.BindableProperty;

        /// <summary>
        /// Default value: jpg")
        /// </summary>
        public global::System.Uri? AquariumGraphic
        {
            get => (global::System.Uri?)GetValue(AquariumGraphicProperty);
            protected set => SetValue(AquariumGraphicPropertyKey, value);
        }

        partial void OnAquariumGraphicChanged();
        partial void OnAquariumGraphicChanged(global::System.Uri? newValue);
        partial void OnAquariumGraphicChanged(global::System.Uri? oldValue, global::System.Uri? newValue);
        partial void OnAquariumGraphicChanging();
        partial void OnAquariumGraphicChanging(global::System.Uri? newValue);
        partial void OnAquariumGraphicChanging(global::System.Uri? oldValue, global::System.Uri? newValue);
    }
}