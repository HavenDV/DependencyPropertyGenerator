namespace H.Generators.SnapshotTests;

public partial class Tests
{
    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    [DataRow(Platform.MAUI)]
    [DataRow(Platform.Avalonia)]
    public Task AddOwner(Platform platform)
    {
        return CheckSourceAsync<DependencyPropertyGenerator>(GetHeader(platform, string.Empty, "Media", "Controls") + @"
[AddOwner<Brush, Border>(nameof(Border.Background))]
public partial class UnrelatedStateControl : UIElement
{
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    [DataRow(Platform.MAUI)]
    [DataRow(Platform.Avalonia)]
    public Task AddOwnerDirect(Platform platform)
    {
        return CheckSourceAsync<DependencyPropertyGenerator>(GetHeader(platform, string.Empty, "Controls") + @"
[AddOwner<string, TextBox>(nameof(TextBox.Text), IsDirect = true)]
public partial class UnrelatedStateControl : UIElement
{
}", platform);
    }
}