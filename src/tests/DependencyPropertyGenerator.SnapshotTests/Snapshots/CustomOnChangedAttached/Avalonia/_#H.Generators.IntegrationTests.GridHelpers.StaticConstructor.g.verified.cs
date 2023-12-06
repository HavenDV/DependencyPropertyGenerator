//HintName: H.Generators.IntegrationTests.GridHelpers.StaticConstructor.g.cs
#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class GridHelpers
    {
        static GridHelpers()
        {
            RowCountProperty.Changed.Subscribe(new global::Avalonia.Reactive.AnonymousObserver<global::Avalonia.AvaloniaPropertyChangedEventArgs<int>>(static x =>
            {
                OnRowCountChanged(
                    (global::Avalonia.Controls.Grid)x.Sender,
                    (int)x.NewValue.GetValueOrDefault());
            }));
        }
    }
}