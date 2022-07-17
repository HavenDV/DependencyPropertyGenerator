namespace H.Generators.SnapshotTests;

public partial class Tests : VerifyBase
{
    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    public Task GeneratesRoutedEventCorrectly(Platform platform)
    {
        return CheckSourceAsync(GetHeader(platform, "Controls") + @"
[RoutedEvent(""TrayLeftMouseDown"", RoutedEventStrategy.Bubble)]
public partial class MyControl : UserControl
{
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    public Task GeneratesAttachedRoutedEventCorrectly(Platform platform)
    {
        return CheckSourceAsync(GetHeader(platform, "Controls") + @"
[RoutedEvent(""TrayLeftMouseDown"", RoutedEventStrategy.Bubble, IsAttached = true)]
public partial class MyControl : UserControl
{
}", platform);
    }
}