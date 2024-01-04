namespace H.Generators.SnapshotTests;

public partial class Tests
{
    [DataTestMethod]
    [DataRow(Framework.None)]
    public Task NoneFramework(Framework framework)
    {
        return CheckSourceAsync<WeakEventGenerator>(GetHeader(framework, "Controls") + @"
[WeakEvent<string>(""UrlChanged"", IsStatic = true)]
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
    public Task DescriptionWithCref(Framework framework)
    {
        return CheckSourceAsync<DependencyPropertyGenerator>(GetHeader(framework, "Controls") + @"
[DependencyProperty<bool>(""IsSpinning"", Description = ""<see cref=\""Style.TargetType\""/> must be Label."")]
public partial class MyControl : UserControl
{
}
", framework);
    }
}