namespace H.Generators.SnapshotTests;

public partial class Tests
{
    [DataTestMethod]
    [DataRow(Framework.Wpf)]
    [DataRow(Framework.Uno)]
    [DataRow(Framework.UnoWinUi)]
    [DataRow(Framework.Maui)]
    [DataRow(Framework.Avalonia)]
    public Task RoutedEvent(Framework framework)
    {
        return CheckSourceAsync<RoutedEventGenerator>(GetHeader(framework, "Controls") + @"
[RoutedEvent(""TrayLeftMouseDown"", RoutedEventStrategy.Bubble, WinRtEvents = true)]
public partial class MyControl : UserControl
{
}", framework);
    }

    [DataTestMethod]
    [DataRow(Framework.Wpf)]
    [DataRow(Framework.Uno)]
    [DataRow(Framework.UnoWinUi)]
    [DataRow(Framework.Maui)]
    [DataRow(Framework.Avalonia)]
    public Task AttachedRoutedEvent(Framework framework)
    {
        return CheckSourceAsync<RoutedEventGenerator>(GetHeader(framework, "Controls") + @"
[RoutedEvent(""TrayLeftMouseDown"", RoutedEventStrategy.Bubble, IsAttached = true)]
public partial class MyControl : UserControl
{
}", framework);
    }

    [DataTestMethod]
    [DataRow(Framework.Wpf)]
    [DataRow(Framework.Uno)]
    [DataRow(Framework.UnoWinUi)]
    [DataRow(Framework.Avalonia)]
    public async Task RoutedEvent_WithGenericHandlerType_DoesNotProduceDuplicateGlobalPrefix(Framework framework)
    {
        var source = GetHeader(framework, "Controls") + @"
public delegate void MyRoutedEventHandler(object sender, global::System.EventArgs e);

[RoutedEvent<MyRoutedEventHandler>(""TrayLeftMouseDown"", RoutedEventStrategy.Bubble, WinRtEvents = true)]
public partial class MyControl : UserControl
{
}";
        var generated = await GenerateSourceAsync<RoutedEventGenerator>(source, framework);

        generated.Should().NotContain("global::global::");
        generated.Should().Contain("global::H.Generators.IntegrationTests.MyRoutedEventHandler");
    }

    [DataTestMethod]
    [DataRow(Framework.Wpf)]
    [DataRow(Framework.Uno)]
    [DataRow(Framework.UnoWinUi)]
    [DataRow(Framework.Avalonia)]
    public async Task RoutedEvent_WithTypeNamedArgument_DoesNotProduceDuplicateGlobalPrefix(Framework framework)
    {
        var source = GetHeader(framework, "Controls") + @"
public delegate void MyRoutedEventHandler(object sender, global::System.EventArgs e);

[RoutedEvent(""TrayLeftMouseDown"", RoutedEventStrategy.Bubble, Type = typeof(MyRoutedEventHandler), WinRtEvents = true)]
public partial class MyControl : UserControl
{
}";
        var generated = await GenerateSourceAsync<RoutedEventGenerator>(source, framework);

        generated.Should().NotContain("global::global::");
        generated.Should().Contain("global::H.Generators.IntegrationTests.MyRoutedEventHandler");
    }
}