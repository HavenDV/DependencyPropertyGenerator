//HintName: TreeViewExtensions.StaticConstructor.generated.cs

using System;

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class TreeViewExtensions
    {
        static TreeViewExtensions()
        {
            ModeProperty.Changed.Subscribe(static x => OnModeChanged(
                (global::Avalonia.Controls.TreeView)x.Sender,
                (global::H.Generators.IntegrationTests.Mode)x.OldValue.GetValueOrDefault(),
                (global::H.Generators.IntegrationTests.Mode)x.NewValue.GetValueOrDefault()));
        }
    }
}