//HintName: MyControl.StaticConstructor.generated.cs

using System;

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        static MyControl()
        {
            AttributedPropertyProperty.Changed.Subscribe(static x =>
            {
                ((global::H.Generators.IntegrationTests.MyControl)x.Sender).OnAttributedPropertyChanged();
                ((global::H.Generators.IntegrationTests.MyControl)x.Sender).OnAttributedPropertyChanged(
                    (string?)x.NewValue.GetValueOrDefault());
                ((global::H.Generators.IntegrationTests.MyControl)x.Sender).OnAttributedPropertyChanged(
                    (string?)x.OldValue.GetValueOrDefault(),
                    (string?)x.NewValue.GetValueOrDefault());
            });
        }
    }
}