﻿//HintName: Aquarium.Properties.AquariumGraphic.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class Aquarium
    {
        /// <summary>
        /// Default value: jpg")
        /// </summary>
        public static readonly global::Microsoft.UI.Xaml.DependencyProperty AquariumGraphicProperty =
            global::Microsoft.UI.Xaml.DependencyProperty.Register(
                name: "AquariumGraphic",
                propertyType: typeof(global::System.Uri),
                ownerType: typeof(global::H.Generators.IntegrationTests.Aquarium),
                typeMetadata: global::Microsoft.UI.Xaml.PropertyMetadata.Create(
                    defaultValue: (global::System.Uri)new System.Uri("http://www.contoso.com/aquarium-graphic.jpg"),
                    propertyChangedCallback: static (sender, args) =>
                    {
                        ((global::H.Generators.IntegrationTests.Aquarium)sender).OnAquariumGraphicChanged();
                        ((global::H.Generators.IntegrationTests.Aquarium)sender).OnAquariumGraphicChanged(
                            (global::System.Uri?)args.NewValue);
                        ((global::H.Generators.IntegrationTests.Aquarium)sender).OnAquariumGraphicChanged(
                            (global::System.Uri?)args.OldValue,
                            (global::System.Uri?)args.NewValue);
                    }));

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