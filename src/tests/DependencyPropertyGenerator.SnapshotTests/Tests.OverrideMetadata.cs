namespace H.Generators.SnapshotTests;

public partial class Tests : VerifyBase
{
    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    [DataRow(Platform.MAUI)]
    [DataRow(Platform.Avalonia)]
    public Task OverrideMetadata(Platform platform)
    {
        return CheckSourceAsync(GetHeader(platform, string.Empty, "System") + @"
[DependencyProperty<Uri>(""AquariumGraphic"", AffectsRender = true,
    DefaultValueExpression = ""new System.Uri(\""http://www.contoso.com/aquarium-graphic.jpg\"")"")]
public partial class Aquarium : UIElement
{
}

[OverrideMetadata<Uri>(""AquariumGraphic"",
    DefaultValueExpression = ""new System.Uri(\""http://www.contoso.com/tropical-aquarium-graphic.jpg\"")"")]
public partial class TropicalAquarium : Aquarium
{
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    [DataRow(Platform.MAUI)]
    [DataRow(Platform.Avalonia)]
    public Task OverrideMetadataForReadOnlyProperty(Platform platform)
    {
        return CheckSourceAsync(GetHeader(platform, string.Empty, "System") + @"
[DependencyProperty<Uri>(""AquariumGraphic"", IsReadOnly = true,
    DefaultValueExpression = ""new System.Uri(\""http://www.contoso.com/aquarium-graphic.jpg\"")"")]
public partial class Aquarium : UIElement
{
}

[OverrideMetadata<Uri>(""AquariumGraphic"", IsReadOnly = true,
    DefaultValueExpression = ""new System.Uri(\""http://www.contoso.com/tropical-aquarium-graphic.jpg\"")"")]
public partial class TropicalAquarium : Aquarium
{
}", platform);
    }
}