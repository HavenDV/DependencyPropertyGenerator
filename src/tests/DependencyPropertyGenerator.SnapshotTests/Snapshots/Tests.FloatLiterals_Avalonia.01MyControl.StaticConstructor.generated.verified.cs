//HintName: MyControl.StaticConstructor.generated.cs

using System;

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        static MyControl()
        {
            FloatPropertyProperty.Changed.Subscribe(static x =>
            {
                ((global::H.Generators.IntegrationTests.MyControl)x.Sender).OnFloatPropertyChanged();
                ((global::H.Generators.IntegrationTests.MyControl)x.Sender).OnFloatPropertyChanged(
                    (float)x.NewValue.GetValueOrDefault());
                ((global::H.Generators.IntegrationTests.MyControl)x.Sender).OnFloatPropertyChanged(
                    (float)x.OldValue.GetValueOrDefault(),
                    (float)x.NewValue.GetValueOrDefault());
            });
        }
    }
}