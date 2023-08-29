//HintName: H.Generators.IntegrationTests.Generatable.StaticConstructor.g.cs
#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class Generatable
    {
        static Generatable()
        {
            TextProperty.Changed.Subscribe(new global::Avalonia.Reactive.AnonymousObserver<global::Avalonia.AvaloniaPropertyChangedEventArgs<string?>>(static x =>
            {
                ((global::H.Generators.IntegrationTests.Generatable)x.Sender).OnTextChanged(
                    (string?)x.OldValue.GetValueOrDefault(),
                    (string?)x.NewValue.GetValueOrDefault());
            }));
        }
    }
}