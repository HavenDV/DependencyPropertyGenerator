﻿//HintName: Aquarium.Properties.AquariumGraphic.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class Aquarium
    {
        /// <summary>
        /// Identifies the <see cref="AquariumGraphic"/> dependency property.<br/>
        /// Default value: jpg")
        /// </summary>
        internal static readonly global::System.Windows.DependencyPropertyKey AquariumGraphicPropertyKey =
            global::System.Windows.DependencyProperty.RegisterReadOnly(
                name: "AquariumGraphic",
                propertyType: typeof(global::System.Uri),
                ownerType: typeof(global::H.Generators.IntegrationTests.Aquarium),
                typeMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: (global::System.Uri)new System.Uri("http://www.contoso.com/aquarium-graphic.jpg"),
                    flags: global::System.Windows.FrameworkPropertyMetadataOptions.None,
                    propertyChangedCallback: null,
                    coerceValueCallback: null,
                    isAnimationProhibited: false),
                validateValueCallback: null);

        /// <summary>
        /// Identifies the <see cref="AquariumGraphic"/> dependency property.<br/>
        /// Default value: jpg")
        /// </summary>
        public static readonly global::System.Windows.DependencyProperty AquariumGraphicProperty
            = AquariumGraphicPropertyKey.DependencyProperty;

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
    }
}