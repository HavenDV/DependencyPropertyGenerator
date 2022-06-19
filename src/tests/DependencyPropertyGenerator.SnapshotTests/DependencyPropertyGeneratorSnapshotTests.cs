namespace H.Generators.SnapshotTests;

[TestClass]
public class DependencyPropertyGeneratorSnapshotTests : VerifyBase
{
    [TestMethod]
    public Task GeneratesCorrectly()
    {
        return this.CheckSourceAsync(@"
using DependencyPropertyGenerator;
using System.Windows;

namespace H.Ipc.Apps.Wpf;

[DependencyProperty(""IsSpinning"", typeof(bool))]
[AttachedDependencyProperty(""IsBubbleSource"", typeof(bool), defaultValue: true)]
public partial class MainWindow : global::System.Windows.Window
{
    static partial void OnIsSpinningChanged(MainWindow sender, DependencyPropertyChangedEventArgs args)
    {
    }

    static partial void OnIsBubbleSourceChanged(MainWindow sender, DependencyPropertyChangedEventArgs args)
    {
    }
}");
    }
}