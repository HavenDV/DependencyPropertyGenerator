//HintName: H.Generators.IntegrationTests.TreeViewExtensions.StaticConstructor.g.cs
#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class TreeViewExtensions
    {
        static TreeViewExtensions()
        {
            ModeProperty.Changed.Subscribe(new global::Avalonia.Reactive.AnonymousObserver<global::Avalonia.AvaloniaPropertyChangedEventArgs<global::H.Generators.IntegrationTests.Mode>>(static x =>
            {
                OnModeChanged(
                    (global::Avalonia.Controls.TreeView)x.Sender,
                    (global::H.Generators.IntegrationTests.Mode)x.OldValue.GetValueOrDefault(),
                    (global::H.Generators.IntegrationTests.Mode)x.NewValue.GetValueOrDefault());
            }));
        }
    }
}