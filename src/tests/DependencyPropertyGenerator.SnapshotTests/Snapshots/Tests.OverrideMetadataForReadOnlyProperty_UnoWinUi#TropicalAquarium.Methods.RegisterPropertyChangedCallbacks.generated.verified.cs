//HintName: TropicalAquarium.Methods.RegisterPropertyChangedCallbacks.generated.cs
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

        partial void OnAquariumGraphicChanged();
        partial void OnAquariumGraphicChanged(global::System.Uri? newValue);
        partial void OnAquariumGraphicChanged(global::System.Uri? oldValue, global::System.Uri? newValue);
    }
}