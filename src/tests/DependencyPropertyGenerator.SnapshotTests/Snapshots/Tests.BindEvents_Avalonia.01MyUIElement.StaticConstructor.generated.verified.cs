//HintName: MyUIElement.StaticConstructor.generated.cs

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
                ((global::H.Generators.IntegrationTests.MyUIElement)x.Sender).OnBindEventsPropertyChanged();
                ((global::H.Generators.IntegrationTests.MyUIElement)x.Sender).OnBindEventsPropertyChanged(
                    (object?)x.NewValue.GetValueOrDefault());
                ((global::H.Generators.IntegrationTests.MyUIElement)x.Sender).OnBindEventsPropertyChanged(
                    (object?)x.OldValue.GetValueOrDefault(),
                    (object?)x.NewValue.GetValueOrDefault());
            });
        }
    }
}