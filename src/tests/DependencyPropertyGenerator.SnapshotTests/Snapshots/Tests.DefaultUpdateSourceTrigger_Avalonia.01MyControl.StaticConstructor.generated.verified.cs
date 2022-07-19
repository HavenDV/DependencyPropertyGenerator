//HintName: MyControl.StaticConstructor.generated.cs

using System;

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        static MyControl()
        {
            ExplicitUpdateSourceTriggerPropertyProperty.Changed.Subscribe(static x =>
            {
                ((global::H.Generators.IntegrationTests.MyControl)x.Sender).OnExplicitUpdateSourceTriggerPropertyChanged();
                ((global::H.Generators.IntegrationTests.MyControl)x.Sender).OnExplicitUpdateSourceTriggerPropertyChanged(
                    (bool)x.NewValue.GetValueOrDefault());
                ((global::H.Generators.IntegrationTests.MyControl)x.Sender).OnExplicitUpdateSourceTriggerPropertyChanged(
                    (bool)x.OldValue.GetValueOrDefault(),
                    (bool)x.NewValue.GetValueOrDefault());
            });
        }
    }
}