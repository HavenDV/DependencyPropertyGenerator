//HintName: MyControl.StaticConstructor.generated.cs

using System;

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        static MyControl()
        {
            ReadOnlyPropertyProperty.Changed.Subscribe(static x =>
            {
                ((global::H.Generators.IntegrationTests.MyControl)x.Sender).OnReadOnlyPropertyChanged();
                ((global::H.Generators.IntegrationTests.MyControl)x.Sender).OnReadOnlyPropertyChanged(
                    (bool)x.NewValue.GetValueOrDefault());
                ((global::H.Generators.IntegrationTests.MyControl)x.Sender).OnReadOnlyPropertyChanged(
                    (bool)x.OldValue.GetValueOrDefault(),
                    (bool)x.NewValue.GetValueOrDefault());
            });
        }
    }
}