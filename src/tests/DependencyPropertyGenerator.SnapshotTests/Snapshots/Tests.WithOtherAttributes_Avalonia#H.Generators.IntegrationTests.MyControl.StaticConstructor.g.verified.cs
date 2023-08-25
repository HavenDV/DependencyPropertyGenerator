//HintName: H.Generators.IntegrationTests.MyControl.StaticConstructor.g.cs

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
                ((global::H.Generators.IntegrationTests.MyControl)x.Sender).OnIsSpinning5Changed(
                    (bool)x.OldValue.GetValueOrDefault(),
                    (bool)x.NewValue.GetValueOrDefault());
            });
        }
    }
}