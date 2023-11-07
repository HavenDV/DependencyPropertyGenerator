//HintName: H.Generators.IntegrationTests.MyGrid.WeakEvents.Changed.g.cs
#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class MyGrid
    {
        private global::Microsoft.Maui.WeakEventManager ChangedWeakEventManager { get; } = new global::Microsoft.Maui.WeakEventManager();
        /// <summary>
        /// </summary>
        public event global::System.EventHandler<global::System.EventArgs> Changed
        {
            add => ChangedWeakEventManager.AddEventHandler(value);
            remove => ChangedWeakEventManager.RemoveEventHandler(value);
        }

        /// <summary>
        /// A helper method to raise the Changed event.
        /// </summary>
        internal void RaiseChangedEvent(object? sender, global::System.EventArgs? args)
        {
            ChangedWeakEventManager.HandleEvent(sender!, args!, eventName: nameof(Changed));
        }
    }
}