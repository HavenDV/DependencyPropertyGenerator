//HintName: MyControl.Events.TrayLeftMouseDown.generated.cs
#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// </summary>
        public event global::Windows.UI.Xaml.RoutedEventHandler? TrayLeftMouseDown;

        /// <summary>
        /// A helper method to raise the TrayLeftMouseDown event.
        /// </summary>
        protected global::Windows.UI.Xaml.RoutedEventArgs OnTrayLeftMouseDown()
        {
            var args = new global::Windows.UI.Xaml.RoutedEventArgs();
            TrayLeftMouseDown?.Invoke(this, args);

            return args;
        }
    }
}