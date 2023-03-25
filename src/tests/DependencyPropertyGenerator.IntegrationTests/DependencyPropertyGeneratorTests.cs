using Avalonia.Controls;

namespace H.Generators.IntegrationTests;

[TestClass]
public class DependencyPropertyGeneratorTests
{
    [TestMethod]
    public void GeneratesCorrectly()
    {
        var isSpinningValue = false;
        var selectedItemValue = (object?)null;
        var exception = (Exception?)null;

        var thread = new Thread(() =>
        {
            try
            {
                var window = new MyControl();
                window.SetValue(MyControl.IsSpinningProperty, true);
                isSpinningValue = window.GetValue(MyControl.IsSpinningProperty);

                var treeView = new TreeView();
                TreeViewExtensions.SetSelectedItem(treeView, new object());
                selectedItemValue = TreeViewExtensions.GetSelectedItem(treeView);
            }
            catch (Exception e)
            {
                exception = e;
            }
        });
        //thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
        thread.Join();

        if (exception != null)
        {
            throw exception;
        }

        isSpinningValue.Should().BeTrue();
        selectedItemValue.Should().NotBeNull();
    }
}