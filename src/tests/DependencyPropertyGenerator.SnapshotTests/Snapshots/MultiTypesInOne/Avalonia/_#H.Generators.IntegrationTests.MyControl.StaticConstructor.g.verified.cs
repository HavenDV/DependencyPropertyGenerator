//HintName: H.Generators.IntegrationTests.MyControl.StaticConstructor.g.cs
#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class MyControl
    {
        static MyControl()
        {
            MyProperty3Property.Changed.Subscribe(new global::Avalonia.Reactive.AnonymousObserver<global::Avalonia.AvaloniaPropertyChangedEventArgs<int>>(static x =>
            {
                ((global::H.Generators.IntegrationTests.MyControl)x.Sender).OnMyProperty3Changed();
            }));

            MyPropertyProperty.Changed.Subscribe(new global::Avalonia.Reactive.AnonymousObserver<global::Avalonia.AvaloniaPropertyChangedEventArgs<int>>(static x =>
            {
                ((global::H.Generators.IntegrationTests.MyControl)x.Sender).OnMyPropertyChanged();
            }));

            MyProperty2Property.Changed.Subscribe(new global::Avalonia.Reactive.AnonymousObserver<global::Avalonia.AvaloniaPropertyChangedEventArgs<int>>(static x =>
            {
                ((global::H.Generators.IntegrationTests.MyControl)x.Sender).OnMyProperty2Changed();
            }));
        }
    }
}