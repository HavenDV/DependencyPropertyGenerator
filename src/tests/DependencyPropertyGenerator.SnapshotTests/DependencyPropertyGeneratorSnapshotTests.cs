namespace H.Generators.SnapshotTests;

[TestClass]
public class DependencyPropertyGeneratorSnapshotTests : VerifyBase
{
    [TestMethod]
    public Task GeneratesCorrectly()
    {
        return this.CheckSourceAsync(@"
using DependencyPropertyGenerator;

namespace H.Ipc.Apps.Wpf;

[DependencyProperty(""IsSpinning"", typeof(bool))]
[AttachedDependencyProperty(""IsBubbleSource"", typeof(bool))]
public partial class MainWindow : global::System.Windows.Window
{
}");
    }
}