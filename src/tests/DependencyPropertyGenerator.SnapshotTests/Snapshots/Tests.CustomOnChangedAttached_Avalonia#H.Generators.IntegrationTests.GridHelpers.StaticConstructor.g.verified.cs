//HintName: H.Generators.IntegrationTests.GridHelpers.StaticConstructor.g.cs

using System;

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class GridHelpers
    {
        static GridHelpers()
        {
            RowCountProperty.Changed.Subscribe(static x =>
            {
                OnRowCountChanged(
                    (global::Avalonia.Controls.Grid)x.Sender,
                    (int)x.NewValue.GetValueOrDefault());
            });
        }
    }
}