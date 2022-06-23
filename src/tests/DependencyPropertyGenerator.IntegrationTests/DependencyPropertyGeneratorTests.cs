using System.Windows.Controls;

namespace H.Generators.IntegrationTests;

[TestClass]
public class DependencyPropertyGeneratorTests
{
    [TestMethod]
    public void GeneratesCorrectly()
    {
        var isSpinningValue = false;
        var selectedItemValue = (object?)null;

        var thread = new Thread(() =>
        {
            var window = new MyControl();
            window.SetValue(MyControl.IsSpinningProperty, true);
            isSpinningValue = (bool)window.GetValue(MyControl.IsSpinningProperty);

            var treeView = new TreeView();
            TreeViewExtensions.SetSelectedItem(treeView, new object());
            selectedItemValue = TreeViewExtensions.GetSelectedItem(treeView);
        });
        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
        thread.Join();

        isSpinningValue.Should().BeTrue();
        selectedItemValue.Should().NotBeNull();
    }
}