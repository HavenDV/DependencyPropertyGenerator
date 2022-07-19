//HintName: MyControl.StaticConstructor.generated.cs

using System;

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        static MyControl()
        {
            IsSpinning5Property.Changed.Subscribe(static x =>
            {
                ((global::H.Generators.IntegrationTests.MyControl)x.Sender).OnIsSpinning5Changed();
                ((global::H.Generators.IntegrationTests.MyControl)x.Sender).OnIsSpinning5Changed(
                    (bool)x.NewValue.GetValueOrDefault());
                ((global::H.Generators.IntegrationTests.MyControl)x.Sender).OnIsSpinning5Changed(
                    (bool)x.OldValue.GetValueOrDefault(),
                    (bool)x.NewValue.GetValueOrDefault());
            });
        }
    }
}