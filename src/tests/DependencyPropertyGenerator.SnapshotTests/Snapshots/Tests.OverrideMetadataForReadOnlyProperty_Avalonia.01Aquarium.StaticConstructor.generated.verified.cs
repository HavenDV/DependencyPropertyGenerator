//HintName: Aquarium.StaticConstructor.generated.cs

using System;

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class Aquarium
    {
        static Aquarium()
        {
            AquariumGraphicProperty.Changed.Subscribe(static x =>
            {
                ((global::H.Generators.IntegrationTests.Aquarium)x.Sender).OnAquariumGraphicChanged();
                ((global::H.Generators.IntegrationTests.Aquarium)x.Sender).OnAquariumGraphicChanged(
                    (global::System.Uri?)x.NewValue.GetValueOrDefault());
                ((global::H.Generators.IntegrationTests.Aquarium)x.Sender).OnAquariumGraphicChanged(
                    (global::System.Uri?)x.OldValue.GetValueOrDefault(),
                    (global::System.Uri?)x.NewValue.GetValueOrDefault());
            });
        }
    }
}