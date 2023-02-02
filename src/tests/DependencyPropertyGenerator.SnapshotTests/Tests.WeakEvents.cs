namespace H.Generators.SnapshotTests;

public partial class Tests
{
    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    [DataRow(Platform.MAUI)]
    [DataRow(Platform.Avalonia)]
    public Task WeakEvent(Platform platform)
    {
        return CheckSourceAsync<WeakEventGenerator>(GetHeader(platform, "Controls") + @"
[WeakEvent(""Completed"")]
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
    public Task WeakEventWithType(Platform platform)
    {
        return CheckSourceAsync<WeakEventGenerator>(GetHeader(platform, "Controls") + @"
[WeakEvent<string>(""UrlChanged"")]
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
    public Task StaticWeakEvent(Platform platform)
    {
        return CheckSourceAsync<WeakEventGenerator>(GetHeader(platform, "Controls") + @"
[WeakEvent(""Completed"", IsStatic = true)]
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
    public Task StaticWeakEventWithType(Platform platform)
    {
        return CheckSourceAsync<WeakEventGenerator>(GetHeader(platform, "Controls") + @"
[WeakEvent<string>(""UrlChanged"", IsStatic = true)]
public partial class MyControl : UserControl
{
}", platform);
    }
}