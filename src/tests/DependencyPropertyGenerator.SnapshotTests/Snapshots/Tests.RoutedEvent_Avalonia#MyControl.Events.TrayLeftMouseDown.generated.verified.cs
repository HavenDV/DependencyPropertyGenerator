//HintName: MyControl.Events.TrayLeftMouseDown.generated.cs
#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// </summary>
        public static readonly global::Avalonia.Interactivity.RoutedEvent<global::Avalonia.Interactivity.RoutedEventArgs> TrayLeftMouseDownEvent =
            global::Avalonia.Interactivity.RoutedEvent.Register<global::H.Generators.IntegrationTests.MyControl, global::Avalonia.Interactivity.RoutedEventArgs>(
            name: "TrayLeftMouseDown",
            routingStrategy: global::Avalonia.Interactivity.RoutingStrategies.Bubble);

        /// <summary>
        /// </summary>
        public event global::System.EventHandler<global::Avalonia.Interactivity.RoutedEventArgs> TrayLeftMouseDown
        {
            add => AddHandler(TrayLeftMouseDownEvent, value);
            remove => RemoveHandler(TrayLeftMouseDownEvent, value);
        }

        /// <summary>
        /// A helper method to raise the TrayLeftMouseDown event.
        /// </summary>
        protected global::Avalonia.Interactivity.RoutedEventArgs OnTrayLeftMouseDown()
        {
            var args = new global::Avalonia.Interactivity.RoutedEventArgs(TrayLeftMouseDownEvent);
            this.RaiseEvent(args);

            return args;
        }
    }
}