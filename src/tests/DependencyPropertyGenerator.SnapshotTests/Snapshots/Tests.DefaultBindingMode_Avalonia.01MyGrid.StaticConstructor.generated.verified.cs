//HintName: MyGrid.StaticConstructor.generated.cs

using System;

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyGrid
    {
        static MyGrid()
        {
            IsSpinningProperty.Changed.Subscribe(static x =>
            {
                ((global::H.Generators.IntegrationTests.MyGrid)x.Sender).OnIsSpinningChanged();
                ((global::H.Generators.IntegrationTests.MyGrid)x.Sender).OnIsSpinningChanged(
                    (bool)x.NewValue.GetValueOrDefault());
                ((global::H.Generators.IntegrationTests.MyGrid)x.Sender).OnIsSpinningChanged(
                    (bool)x.OldValue.GetValueOrDefault(),
                    (bool)x.NewValue.GetValueOrDefault());
            });
        }
    }
}