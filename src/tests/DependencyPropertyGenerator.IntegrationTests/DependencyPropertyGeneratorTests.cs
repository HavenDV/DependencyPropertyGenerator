namespace H.Generators.IntegrationTests;

[TestClass]
public class DependencyPropertyGeneratorTests
{
    [TestMethod]
    public void GeneratesCorrectly()
    {
        var value = false;

        var thread = new Thread(() =>
        {
            var window = new MainWindow();
            window.SetValue(MainWindow.IsSpinningProperty, true);
            value = (bool)window.GetValue(MainWindow.IsSpinningProperty);
        });
        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
        thread.Join();

        value.Should().BeTrue();
    }
}