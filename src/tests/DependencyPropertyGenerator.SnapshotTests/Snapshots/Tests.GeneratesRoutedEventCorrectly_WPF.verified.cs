//HintName: MyControl_RoutedEvents.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// </summary>
        public static readonly global::System.Windows.RoutedEvent TrayLeftMouseDownEvent =
            global::System.Windows.EventManager.RegisterRoutedEvent(
                name: "TrayLeftMouseDown",
                routingStrategy: (global::System.Windows.RoutingStrategy)1,
                handlerType: typeof(global::System.Windows.RoutedEventHandler),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl));

        /// <summary>
        /// </summary>
        public event global::System.Windows.RoutedEventHandler TrayLeftMouseDown
        {
            add => AddHandler(TrayLeftMouseDownEvent, value);
            remove => RemoveHandler(TrayLeftMouseDownEvent, value);
        }

        /// <summary>
        /// A helper method to raise the TrayLeftMouseDown event.
        /// </summary>
        protected global::System.Windows.RoutedEventArgs RaiseTrayLeftMouseDownEvent()
        {
            var args = new global::System.Windows.RoutedEventArgs(TrayLeftMouseDownEvent);
            this.RaiseEvent(args);

            return args;
        }
    }
}