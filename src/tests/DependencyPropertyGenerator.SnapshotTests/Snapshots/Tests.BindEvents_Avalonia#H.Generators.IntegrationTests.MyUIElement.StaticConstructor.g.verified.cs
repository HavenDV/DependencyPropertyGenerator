//HintName: H.Generators.IntegrationTests.MyUIElement.StaticConstructor.g.cs

using System;

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyUIElement
    {
        static MyUIElement()
        {
            BindEventsPropertyProperty.Changed.Subscribe(static x =>
            {
                ((global::H.Generators.IntegrationTests.MyUIElement)x.Sender).OnBindEventsPropertyChanged(
                    (object?)x.OldValue.GetValueOrDefault(),
                    (object?)x.NewValue.GetValueOrDefault());
            });
        }
    }
}