//HintName: GridExtensions.StaticConstructor.generated.cs

using System;

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class GridExtensions
    {
        static GridExtensions()
        {
            AttachedPropertyProperty.Changed.Subscribe(static x => OnAttachedPropertyChanged(
                (global::Avalonia.Controls.Grid)x.Sender,
                (object?)x.OldValue.GetValueOrDefault(),
                (object?)x.NewValue.GetValueOrDefault()));
        }
    }
}