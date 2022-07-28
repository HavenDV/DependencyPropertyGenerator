//HintName: UIElementExtensions.StaticConstructor.generated.cs

using System;

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class UIElementExtensions
    {
        static UIElementExtensions()
        {
            BindEventPropertyProperty.Changed.Subscribe(static x =>
            {
                OnBindEventPropertyChanged(
                    (global::Avalonia.Input.InputElement)x.Sender,
                    (object?)x.OldValue.GetValueOrDefault(),
                    (object?)x.NewValue.GetValueOrDefault());
            });
        }
    }
}