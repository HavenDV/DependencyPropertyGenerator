//HintName: Generatable.StaticConstructor.generated.cs

using System;

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class Generatable
    {
        static Generatable()
        {
            TextProperty.Changed.Subscribe(static x =>
            {
                ((global::H.Generators.IntegrationTests.Generatable)x.Sender).OnTextChanged();
                ((global::H.Generators.IntegrationTests.Generatable)x.Sender).OnTextChanged(
                    (string?)x.NewValue.GetValueOrDefault());
                ((global::H.Generators.IntegrationTests.Generatable)x.Sender).OnTextChanged(
                    (string?)x.OldValue.GetValueOrDefault(),
                    (string?)x.NewValue.GetValueOrDefault());
            });
        }
    }
}