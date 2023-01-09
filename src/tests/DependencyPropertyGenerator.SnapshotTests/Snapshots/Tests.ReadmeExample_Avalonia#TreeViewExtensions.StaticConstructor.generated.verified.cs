//HintName: TreeViewExtensions.StaticConstructor.generated.cs

using System;

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class TreeViewExtensions
    {
        static TreeViewExtensions()
        {
            SelectedItemProperty.Changed.Subscribe(static x =>
            {
                OnSelectedItemChanged(
                    (global::Avalonia.Controls.TreeView)x.Sender,
                    (object?)x.OldValue.GetValueOrDefault(),
                    (object?)x.NewValue.GetValueOrDefault());
            });
        }
    }
}