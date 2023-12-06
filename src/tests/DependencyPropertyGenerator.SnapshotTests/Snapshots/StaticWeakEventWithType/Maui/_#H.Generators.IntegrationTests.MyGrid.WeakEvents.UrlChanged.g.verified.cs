//HintName: H.Generators.IntegrationTests.MyGrid.WeakEvents.UrlChanged.g.cs
#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class MyGrid
    {
        private static global::Microsoft.Maui.WeakEventManager UrlChangedWeakEventManager { get; } = new global::Microsoft.Maui.WeakEventManager();
        /// <summary>
        /// </summary>
        public static event global::System.EventHandler<string?>? UrlChanged
        {
            add => UrlChangedWeakEventManager.AddEventHandler(value);
            remove => UrlChangedWeakEventManager.RemoveEventHandler(value);
        }

        /// <summary>
        /// A helper method to raise the UrlChanged event.
        /// </summary>
        internal static void RaiseUrlChangedEvent(object? sender, string? args)
        {
            UrlChangedWeakEventManager.HandleEvent(sender!, args!, eventName: nameof(UrlChanged));
        }
    }
}