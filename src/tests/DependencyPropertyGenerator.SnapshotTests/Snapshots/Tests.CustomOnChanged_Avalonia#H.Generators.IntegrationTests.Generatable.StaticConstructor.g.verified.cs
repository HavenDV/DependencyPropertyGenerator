//HintName: H.Generators.IntegrationTests.Generatable.StaticConstructor.g.cs

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
                ((global::H.Generators.IntegrationTests.Generatable)x.Sender).OnMyTextChanged(
                    (string?)x.NewValue.GetValueOrDefault());
            });
        }
    }
}