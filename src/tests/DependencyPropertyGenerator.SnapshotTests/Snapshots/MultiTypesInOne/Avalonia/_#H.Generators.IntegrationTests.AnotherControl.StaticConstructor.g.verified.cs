//HintName: H.Generators.IntegrationTests.AnotherControl.StaticConstructor.g.cs
#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class AnotherControl
    {
        static AnotherControl()
        {
            MyPropertyProperty.Changed.Subscribe(new global::Avalonia.Reactive.AnonymousObserver<global::Avalonia.AvaloniaPropertyChangedEventArgs<int>>(static x =>
            {
                ((global::H.Generators.IntegrationTests.AnotherControl)x.Sender).OnMyPropertyChanged();
            }));
        }
    }
}