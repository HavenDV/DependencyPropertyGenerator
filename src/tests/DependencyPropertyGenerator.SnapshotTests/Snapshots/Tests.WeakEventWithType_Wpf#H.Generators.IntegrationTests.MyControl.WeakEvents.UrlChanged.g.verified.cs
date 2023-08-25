//HintName: H.Generators.IntegrationTests.MyControl.WeakEvents.UrlChanged.g.cs
#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        private class UrlChangedWeakEventManager : global::System.Windows.WeakEventManager
        {
            private UrlChangedWeakEventManager()
            {
            }

            public static void AddHandler(object? source, global::System.EventHandler<string?>? handler)
            {
                if (source == null)
                    throw new global::System.ArgumentNullException(nameof(source));
                if (handler == null)
                    throw new global::System.ArgumentNullException(nameof(handler));

                CurrentManager.ProtectedAddHandler(source, handler);
            }

            public static void RemoveHandler(object? source, global::System.EventHandler<string?>? handler)
            {
                if (source == null)
                    throw new global::System.ArgumentNullException(nameof(source));
                if (handler == null)
                    throw new global::System.ArgumentNullException(nameof(handler));

                CurrentManager.ProtectedRemoveHandler(source, handler);
            }

            internal static UrlChangedWeakEventManager CurrentManager
            {
                get
                {
                    var managerType = typeof(UrlChangedWeakEventManager);
                    var manager = (UrlChangedWeakEventManager)GetCurrentManager(managerType);
                    if (manager == null)
                    {
                        manager = new UrlChangedWeakEventManager();
                        SetCurrentManager(managerType, manager);
                    }

                    return manager;
                }
            }

            protected override void StartListening(object? source)
            {
                (source as MyControl)!.UrlChanged += OnUrlChanged;
            }

            protected override void StopListening(object? source)
            {
                (source as MyControl)!.UrlChanged -= OnUrlChanged;
            }

            internal void OnUrlChanged(object? sender, string? args)
            {
                DeliverEvent(sender, args);
            }
        }

        /// <summary>
        /// </summary>
        public event global::System.EventHandler<string?>? UrlChanged
        {
            add => UrlChangedWeakEventManager.AddHandler(null, value);
            remove => UrlChangedWeakEventManager.RemoveHandler(null, value);
        }

        /// <summary>
        /// A helper method to raise the UrlChanged event.
        /// </summary>
        internal void RaiseUrlChangedEvent(object? sender, string? args)
        {
            UrlChangedWeakEventManager.CurrentManager.OnUrlChanged(sender, args);
        }
    }
}