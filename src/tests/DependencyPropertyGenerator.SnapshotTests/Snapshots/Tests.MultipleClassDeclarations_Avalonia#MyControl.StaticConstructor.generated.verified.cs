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
            });

            IsSpinning2Property.Changed.Subscribe(static x =>
            {
                ((global::H.Generators.IntegrationTests.MyControl)x.Sender).OnIsSpinning2Changed(
                    (bool)x.NewValue.GetValueOrDefault());
            });
        }
    }
}