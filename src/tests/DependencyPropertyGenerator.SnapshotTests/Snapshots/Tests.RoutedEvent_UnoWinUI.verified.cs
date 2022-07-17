//HintName: MyControl.Events.TrayLeftMouseDown.generated.cs
#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// </summary>
        public event global::Microsoft.UI.Xaml.RoutedEventHandler? TrayLeftMouseDown;

        /// <summary>
        /// A helper method to raise the TrayLeftMouseDown event.
        /// </summary>
        protected global::Microsoft.UI.Xaml.RoutedEventArgs OnTrayLeftMouseDown()
        {
            var args = new global::Microsoft.UI.Xaml.RoutedEventArgs();
            TrayLeftMouseDown?.Invoke(this, args);

            return args;
        }
    }
}