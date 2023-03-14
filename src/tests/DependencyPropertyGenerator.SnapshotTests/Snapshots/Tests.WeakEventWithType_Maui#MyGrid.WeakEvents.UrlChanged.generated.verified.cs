//HintName: MyGrid.WeakEvents.UrlChanged.generated.cs
#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyGrid
    {
        private global::Microsoft.Maui.WeakEventManager UrlChangedWeakEventManager { get; } = new global::Microsoft.Maui.WeakEventManager();
        /// <summary>
        /// </summary>
        public event global::System.EventHandler<string?>? UrlChanged
        {
            add => UrlChangedWeakEventManager.AddEventHandler(value);
            remove => UrlChangedWeakEventManager.RemoveEventHandler(value);
        }

        /// <summary>
        /// A helper method to raise the UrlChanged event.
        /// </summary>
        internal void RaiseUrlChangedEvent(object? sender, string? args)
        {
            UrlChangedWeakEventManager.HandleEvent(sender!, args!, eventName: nameof(UrlChanged));
        }
    }
}