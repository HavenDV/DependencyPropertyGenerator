//HintName: H.Generators.IntegrationTests.MyControl.StaticConstructor.g.cs
#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class MyControl
    {
        static MyControl()
        {
            IsSpinning5Property.Changed.Subscribe(new global::Avalonia.Reactive.AnonymousObserver<global::Avalonia.AvaloniaPropertyChangedEventArgs<bool>>(static x =>
            {
                ((global::H.Generators.IntegrationTests.MyControl)x.Sender).OnIsSpinning5Changed(
                    (bool)x.OldValue.GetValueOrDefault(),
                    (bool)x.NewValue.GetValueOrDefault());
            }));
        }
    }
}