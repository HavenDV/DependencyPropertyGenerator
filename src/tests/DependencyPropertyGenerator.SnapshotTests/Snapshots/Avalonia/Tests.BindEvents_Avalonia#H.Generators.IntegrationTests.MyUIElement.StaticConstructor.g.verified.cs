//HintName: H.Generators.IntegrationTests.MyUIElement.StaticConstructor.g.cs
#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class MyUIElement
    {
        static MyUIElement()
        {
            BindEventsPropertyProperty.Changed.Subscribe(new global::Avalonia.Reactive.AnonymousObserver<global::Avalonia.AvaloniaPropertyChangedEventArgs<object?>>(static x =>
            {
                ((global::H.Generators.IntegrationTests.MyUIElement)x.Sender).OnBindEventsPropertyChanged(
                    (object?)x.OldValue.GetValueOrDefault(),
                    (object?)x.NewValue.GetValueOrDefault());
            }));
        }
    }
}