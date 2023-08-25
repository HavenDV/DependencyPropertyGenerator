//HintName: H.Generators.IntegrationTests.Test.StaticConstructor.g.cs

using System;

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class Test
    {
        static Test()
        {
            TestPropProperty.Changed.Subscribe(static x =>
            {
                TestChanged(
                    (global::Avalonia.Controls.Grid)x.Sender,
                    (global::H.Generators.IntegrationTests.Test?)x.NewValue.GetValueOrDefault());
            });
        }
    }
}