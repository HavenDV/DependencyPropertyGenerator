//HintName: MyControl.WeakEvents.Changed.generated.cs
#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        private class ChangedWeakEventManager : global::System.Windows.WeakEventManager
        {
            private ChangedWeakEventManager()
            {
            }

            public static void AddHandler(object? source, global::System.EventHandler<global::System.EventArgs?>? handler)
            {
                if (source == null)
                    throw new global::System.ArgumentNullException(nameof(source));
                if (handler == null)
                    throw new global::System.ArgumentNullException(nameof(handler));

                CurrentManager.ProtectedAddHandler(source, handler);
            }

            public static void RemoveHandler(object? source, global::System.EventHandler<global::System.EventArgs?>? handler)
            {
                if (source == null)
                    throw new global::System.ArgumentNullException(nameof(source));
                if (handler == null)
                    throw new global::System.ArgumentNullException(nameof(handler));

                CurrentManager.ProtectedRemoveHandler(source, handler);
            }

            internal static ChangedWeakEventManager CurrentManager
            {
                get
                {
                    var managerType = typeof(ChangedWeakEventManager);
                    var manager = (ChangedWeakEventManager)GetCurrentManager(managerType);
                    if (manager == null)
                    {
                        manager = new ChangedWeakEventManager();
                        SetCurrentManager(managerType, manager);
                    }

                    return manager;
                }
            }

            protected override void StartListening(object? source)
            {
                (source as MyControl)!.Changed += OnChanged;
            }

            protected override void StopListening(object? source)
            {
                (source as MyControl)!.Changed -= OnChanged;
            }

            internal void OnChanged(object? sender, global::System.EventArgs? args)
            {
                DeliverEvent(sender, args);
            }
        }

        /// <summary>
        /// </summary>
        public event global::System.EventHandler<global::System.EventArgs?>? Changed
        {
            add => ChangedWeakEventManager.AddHandler(null, value);
            remove => ChangedWeakEventManager.RemoveHandler(null, value);
        }

        /// <summary>
        /// A helper method to raise the Changed event.
        /// </summary>
        internal void RaiseChangedEvent(object? sender, global::System.EventArgs? args)
        {
            ChangedWeakEventManager.CurrentManager.OnChanged(sender, args);
        }
    }
}