//HintName: MyControl.StaticConstructor.generated.cs

using System;

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        static MyControl()
        {
            NotNullStringPropertyProperty.Changed.Subscribe(static x =>
            {
                ((global::H.Generators.IntegrationTests.MyControl)x.Sender).OnNotNullStringPropertyChanged();
                ((global::H.Generators.IntegrationTests.MyControl)x.Sender).OnNotNullStringPropertyChanged(
                    (string?)x.NewValue.GetValueOrDefault());
                ((global::H.Generators.IntegrationTests.MyControl)x.Sender).OnNotNullStringPropertyChanged(
                    (string?)x.OldValue.GetValueOrDefault(),
                    (string?)x.NewValue.GetValueOrDefault());
            });
        }
    }
}