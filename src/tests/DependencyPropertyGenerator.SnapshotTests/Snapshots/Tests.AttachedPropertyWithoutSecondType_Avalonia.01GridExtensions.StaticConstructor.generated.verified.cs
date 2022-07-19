//HintName: GridExtensions.StaticConstructor.generated.cs

using System;

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class GridExtensions
    {
        static GridExtensions()
        {
            SomePropertyProperty.Changed.Subscribe(static x =>
            {
                OnSomePropertyChanged();
                OnSomePropertyChanged(
                    (global::Avalonia.IAvaloniaObject)x.Sender);
                OnSomePropertyChanged(
                    (global::Avalonia.IAvaloniaObject)x.Sender,
                    (object?)x.NewValue.GetValueOrDefault());
                OnSomePropertyChanged(
                    (global::Avalonia.IAvaloniaObject)x.Sender,
                    (object?)x.OldValue.GetValueOrDefault(),
                    (object?)x.NewValue.GetValueOrDefault());
            });
        }
    }
}