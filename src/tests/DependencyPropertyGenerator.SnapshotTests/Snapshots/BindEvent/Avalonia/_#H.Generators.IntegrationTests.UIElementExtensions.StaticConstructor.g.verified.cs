//HintName: H.Generators.IntegrationTests.UIElementExtensions.StaticConstructor.g.cs
#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class UIElementExtensions
    {
        static UIElementExtensions()
        {
            BindEventPropertyProperty.Changed.Subscribe(new global::Avalonia.Reactive.AnonymousObserver<global::Avalonia.AvaloniaPropertyChangedEventArgs<object?>>(static x =>
            {
                OnBindEventPropertyChanged(
                    (global::Avalonia.Input.InputElement)x.Sender,
                    (object?)x.OldValue.GetValueOrDefault(),
                    (object?)x.NewValue.GetValueOrDefault());
            }));
        }
    }
}