//HintName: MyControl.StaticConstructor.generated.cs

using System;

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        static MyControl()
        {
            TextProperty.Changed.Subscribe(static x =>
            {
                ((global::H.Generators.IntegrationTests.MyControl)x.Sender).OnTextChanged();
                ((global::H.Generators.IntegrationTests.MyControl)x.Sender).OnTextChanged(
                    (string?)x.NewValue.GetValueOrDefault());
                ((global::H.Generators.IntegrationTests.MyControl)x.Sender).OnTextChanged(
                    (string?)x.OldValue.GetValueOrDefault(),
                    (string?)x.NewValue.GetValueOrDefault());
            });
        }
    }
}