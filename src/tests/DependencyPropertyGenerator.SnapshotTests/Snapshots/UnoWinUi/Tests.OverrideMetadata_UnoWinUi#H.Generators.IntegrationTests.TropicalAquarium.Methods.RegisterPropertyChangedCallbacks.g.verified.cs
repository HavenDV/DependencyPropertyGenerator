﻿//HintName: H.Generators.IntegrationTests.TropicalAquarium.Methods.RegisterPropertyChangedCallbacks.g.cs
#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class TropicalAquarium
    {
        private void RegisterPropertyChangedCallbacks()
        {
            _ = this.RegisterPropertyChangedCallback(
                dp: AquariumGraphicProperty,
                callback: static (sender, dependencyProperty) =>
                {
                    ((global::H.Generators.IntegrationTests.TropicalAquarium)sender).OnAquariumGraphicChanged();
                });
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnAquariumGraphicChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnAquariumGraphicChanged(global::System.Uri? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnAquariumGraphicChanged(global::System.Uri? oldValue, global::System.Uri? newValue);
    }
}