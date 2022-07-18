//HintName: GridExtensions.StaticConstructor.generated.cs

using System;

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class GridExtensions
    {
        static GridExtensions()
        {
            SomePropertyProperty.Changed.Subscribe(static x => OnSomePropertyChanged(
                (global::Avalonia.IAvaloniaObject)x.Sender,
                (object?)x.OldValue.GetValueOrDefault(),
                (object?)x.NewValue.GetValueOrDefault()));
        }
    }
}