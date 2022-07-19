//HintName: MyGrid.StaticConstructor.generated.cs

using System;

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyGrid
    {
        static MyGrid()
        {
            SomePropertyProperty.Changed.Subscribe(static x =>
            {
                ((global::H.Generators.IntegrationTests.MyGrid)x.Sender).OnSomePropertyChanged();
                ((global::H.Generators.IntegrationTests.MyGrid)x.Sender).OnSomePropertyChanged(
                    (string?)x.NewValue.GetValueOrDefault());
                ((global::H.Generators.IntegrationTests.MyGrid)x.Sender).OnSomePropertyChanged(
                    (string?)x.OldValue.GetValueOrDefault(),
                    (string?)x.NewValue.GetValueOrDefault());
            });
        }
    }
}