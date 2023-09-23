//HintName: H.Generators.IntegrationTests.MyControl.StaticConstructor.g.cs
#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        static MyControl()
        {
            IsSpinningProperty.Changed.Subscribe(new global::Avalonia.Reactive.AnonymousObserver<global::Avalonia.AvaloniaPropertyChangedEventArgs<bool>>(static x =>
            {
                ((global::H.Generators.IntegrationTests.MyControl)x.Sender).OnIsSpinningChanged();
            }));

            IsSpinning2Property.Changed.Subscribe(new global::Avalonia.Reactive.AnonymousObserver<global::Avalonia.AvaloniaPropertyChangedEventArgs<bool>>(static x =>
            {
                ((global::H.Generators.IntegrationTests.MyControl)x.Sender).OnIsSpinning2Changed(
                    (bool)x.NewValue.GetValueOrDefault());
            }));
        }
    }
}