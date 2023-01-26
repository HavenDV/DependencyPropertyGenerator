namespace H.Generators.SnapshotTests;

public partial class Tests
{
    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    [DataRow(Platform.MAUI)]
    [DataRow(Platform.Avalonia)]
    public Task RoutedEvent(Platform platform)
    {
        return CheckSourceAsync(GetHeader(platform, "Controls") + @"
[RoutedEvent(""TrayLeftMouseDown"", RoutedEventStrategy.Bubble, WinRtEvents = true)]
public partial class MyControl : UserControl
{
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    [DataRow(Platform.MAUI)]
    [DataRow(Platform.Avalonia)]
    public Task AttachedRoutedEvent(Platform platform)
    {
        return CheckSourceAsync(GetHeader(platform, "Controls") + @"
[RoutedEvent(""TrayLeftMouseDown"", RoutedEventStrategy.Bubble, IsAttached = true)]
public partial class MyControl : UserControl
{
}", platform);
    }
}