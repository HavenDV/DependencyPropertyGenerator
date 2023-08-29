namespace H.Generators.SnapshotTests;

public partial class Tests
{
    [DataTestMethod]
    [DataRow(Framework.Wpf)]
    [DataRow(Framework.Uno)]
    [DataRow(Framework.UnoWinUi)]
    [DataRow(Framework.Maui)]
    [DataRow(Framework.Avalonia)]
    public Task AddOwner(Framework framework)
    {
        return CheckSourceAsync<AddOwnerGenerator>(GetHeader(framework, string.Empty, "Media", "Controls") + @"
[AddOwner<Brush, Border>(nameof(Border.Background))]
public partial class UnrelatedStateControl : UIElement
{
}", framework);
    }

    [DataTestMethod]
    [DataRow(Framework.Wpf)]
    [DataRow(Framework.Uno)]
    [DataRow(Framework.UnoWinUi)]
    [DataRow(Framework.Maui)]
    [DataRow(Framework.Avalonia)]
    public Task AddOwner2(Framework framework)
    {
        return CheckSourceAsync<AddOwnerGenerator>(GetHeader(framework, string.Empty, "Controls") + @"
[AddOwner<string, TextBox>(nameof(TextBox.Text))]
public partial class UnrelatedStateControl : UIElement
{
}", framework);
    }
}