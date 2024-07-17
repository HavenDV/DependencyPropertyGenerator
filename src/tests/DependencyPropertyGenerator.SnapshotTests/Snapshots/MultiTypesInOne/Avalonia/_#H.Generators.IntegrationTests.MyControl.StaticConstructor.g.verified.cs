//HintName: H.Generators.IntegrationTests.MyControl.StaticConstructor.g.cs
#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class MyControl
    {
        static MyControl()
        {
            MyPropertyProperty.Changed.Subscribe(new global::Avalonia.Reactive.AnonymousObserver<global::Avalonia.AvaloniaPropertyChangedEventArgs<int>>(static x =>
            {
                ((global::H.Generators.IntegrationTests.MyControl)x.Sender).OnMyPropertyChanged();
            }));
        }
    }
}