//HintName: H.Generators.IntegrationTests.AnotherControl.StaticConstructor.g.cs
#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class AnotherControl
    {
        static AnotherControl()
        {
            MyProperty3Property.Changed.Subscribe(new global::Avalonia.Reactive.AnonymousObserver<global::Avalonia.AvaloniaPropertyChangedEventArgs<int>>(static x =>
            {
                ((global::H.Generators.IntegrationTests.AnotherControl)x.Sender).OnMyProperty3Changed();
            }));

            MyPropertyProperty.Changed.Subscribe(new global::Avalonia.Reactive.AnonymousObserver<global::Avalonia.AvaloniaPropertyChangedEventArgs<int>>(static x =>
            {
                ((global::H.Generators.IntegrationTests.AnotherControl)x.Sender).OnMyPropertyChanged();
            }));

            MyProperty2Property.Changed.Subscribe(new global::Avalonia.Reactive.AnonymousObserver<global::Avalonia.AvaloniaPropertyChangedEventArgs<(int, string)>>(static x =>
            {
                ((global::H.Generators.IntegrationTests.AnotherControl)x.Sender).OnMyProperty2Changed();
            }));
        }
    }
}