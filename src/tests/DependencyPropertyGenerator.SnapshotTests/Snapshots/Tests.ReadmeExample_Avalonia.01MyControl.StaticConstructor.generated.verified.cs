//HintName: MyControl.StaticConstructor.generated.cs

using System;

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        static MyControl()
        {
            IsSpinningProperty.Changed.Subscribe(static x =>
            {
                ((global::H.Generators.IntegrationTests.MyControl)x.Sender).OnIsSpinningChanged();
                ((global::H.Generators.IntegrationTests.MyControl)x.Sender).OnIsSpinningChanged(
                    (bool)x.NewValue.GetValueOrDefault());
                ((global::H.Generators.IntegrationTests.MyControl)x.Sender).OnIsSpinningChanged(
                    (bool)x.OldValue.GetValueOrDefault(),
                    (bool)x.NewValue.GetValueOrDefault());
            });
        }
    }
}