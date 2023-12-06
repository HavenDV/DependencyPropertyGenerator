//HintName: H.Generators.IntegrationTests.MyGrid.WeakEvents.Completed.g.cs
#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class MyGrid
    {
        private static global::Microsoft.Maui.WeakEventManager CompletedWeakEventManager { get; } = new global::Microsoft.Maui.WeakEventManager();
        /// <summary>
        /// </summary>
        public static event global::System.EventHandler? Completed
        {
            add => CompletedWeakEventManager.AddEventHandler(value);
            remove => CompletedWeakEventManager.RemoveEventHandler(value);
        }

        /// <summary>
        /// A helper method to raise the Completed event.
        /// </summary>
        internal static void RaiseCompletedEvent(object? sender)
        {
            CompletedWeakEventManager.HandleEvent(sender!, global::System.EventArgs.Empty!, eventName: nameof(Completed));
        }
    }
}