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
}