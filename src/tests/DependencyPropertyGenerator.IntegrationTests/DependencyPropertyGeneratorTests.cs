namespace H.Generators.IntegrationTests;

[TestClass]
public class DependencyPropertyGeneratorTests
{
    [TestMethod]
    public void GeneratesCorrectly()
    {
        var isSpinningValue = false;
        var isBubbleSourceValue = false;

        var thread = new Thread(() =>
        {
            var window = new MainWindow();
            window.SetValue(MainWindow.IsSpinningProperty, true);
            isSpinningValue = (bool)window.GetValue(MainWindow.IsSpinningProperty);

            MainWindow.SetIsBubbleSource(window, true);
            isBubbleSourceValue = (bool)MainWindow.GetIsBubbleSource(window);
        });
        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
        thread.Join();

        isSpinningValue.Should().BeTrue();
        isBubbleSourceValue.Should().BeTrue();
    }
}