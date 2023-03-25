using H.Generators.Extensions;

namespace H.Generators;

internal static partial class SourceGenerationHelper
{
    public static string GenerateWeakEvent(ClassData @class, EventData @event)
    {
        var additionalParameters = string.IsNullOrWhiteSpace(@event.Type)
            ? string.Empty
            : $", {GenerateEventArgsType(@event)} args";
        var args = string.IsNullOrWhiteSpace(@event.Type)
            ? "System.EventArgs.Empty".WithGlobalPrefix()
            : "args";
        var modifiers = @event.IsAttached
            ? " static"
            : string.Empty;

        switch (@class.Framework)
        {
            // https://learn.microsoft.com/en-us/dotnet/desktop/wpf/events/weak-event-patterns
            case Framework.Wpf:
            {
                var source = @event.IsAttached
                    ? @class.Name
                    : $"(source as {@class.Name})!";

                return @$" 
#nullable enable

namespace {@class.Namespace}
{{
    public{@class.Modifiers} partial class {@class.Name}
    {{
        private class {@event.Name}WeakEventManager : global::System.Windows.WeakEventManager
        {{
            private {@event.Name}WeakEventManager()
            {{
            }}

            public static void AddHandler(object? source, {GenerateEventHandlerType(@event)} handler)
            {{
                if (source == null)
                    throw new global::System.ArgumentNullException(nameof(source));
                if (handler == null)
                    throw new global::System.ArgumentNullException(nameof(handler));

                CurrentManager.ProtectedAddHandler(source, handler);
            }}

            public static void RemoveHandler(object? source, {GenerateEventHandlerType(@event)} handler)
            {{
                if (source == null)
                    throw new global::System.ArgumentNullException(nameof(source));
                if (handler == null)
                    throw new global::System.ArgumentNullException(nameof(handler));

                CurrentManager.ProtectedRemoveHandler(source, handler);
            }}

            internal static {@event.Name}WeakEventManager CurrentManager
            {{
                get
                {{
                    var managerType = typeof({@event.Name}WeakEventManager);
                    var manager = ({@event.Name}WeakEventManager)GetCurrentManager(managerType);
                    if (manager == null)
                    {{
                        manager = new {@event.Name}WeakEventManager();
                        SetCurrentManager(managerType, manager);
                    }}

                    return manager;
                }}
            }}

            protected override void StartListening(object? source)
            {{
                {source}.{@event.Name} += On{@event.Name};
            }}

            protected override void StopListening(object? source)
            {{
                {source}.{@event.Name} -= On{@event.Name};
            }}

            internal void On{@event.Name}(object? sender, {GenerateEventArgsType(@event)} args)
            {{
                DeliverEvent(sender, args);
            }}
        }}

{GenerateXmlDocumentationFrom(@event.EventXmlDocumentation, @event)}
        public{modifiers} event {GenerateEventHandlerType(@event)} {@event.Name}
        {{
            add => {@event.Name}WeakEventManager.AddHandler(null, value);
            remove => {@event.Name}WeakEventManager.RemoveHandler(null, value);
        }}

        /// <summary>
        /// A helper method to raise the {@event.Name} event.
        /// </summary>
        internal{modifiers} void Raise{@event.Name}Event(object? sender{additionalParameters})
        {{
            {@event.Name}WeakEventManager.CurrentManager.On{@event.Name}(sender, {args});
        }}
    }}
}}".RemoveBlankLinesWhereOnlyWhitespaces();
            }

            // https://github.com/dotnet/maui/issues/2703
            // https://github.com/dotnet/maui/pull/12950
            case Framework.Maui:
            {
                var nullable = !@event.Type.Contains("EventArgs");

                return @$" 
#nullable enable

namespace {@class.Namespace}
{{
    public{@class.Modifiers} partial class {@class.Name}
    {{
        private{modifiers} global::Microsoft.Maui.WeakEventManager {@event.Name}WeakEventManager {{ get; }} = new global::Microsoft.Maui.WeakEventManager();
        
{GenerateXmlDocumentationFrom(@event.EventXmlDocumentation, @event)}
        public{modifiers} event {GenerateEventHandlerType(@event, nullable: nullable, nullableType: nullable)} {@event.Name}
        {{
            add => {@event.Name}WeakEventManager.AddEventHandler(value);
            remove => {@event.Name}WeakEventManager.RemoveEventHandler(value);
        }}

        /// <summary>
        /// A helper method to raise the {@event.Name} event.
        /// </summary>
        internal{modifiers} void Raise{@event.Name}Event(object? sender{additionalParameters})
        {{
            {@event.Name}WeakEventManager.HandleEvent(sender!, {args}!, eventName: nameof({@event.Name}));
        }}
    }}
}}".RemoveBlankLinesWhereOnlyWhitespaces();
            }

            case Framework.Uwp:
            case Framework.WinUi:
            case Framework.Uno:
            case Framework.UnoWinUi:
            case Framework.Avalonia:
            default:
                return string.Empty;
        }
    }

    private static string GenerateEventHandlerType(EventData @event, bool nullable = true, bool nullableType = true)
    {
        var eventHandler = (string.IsNullOrWhiteSpace(@event.Type)
            ? "System.EventHandler"
            : $"System.EventHandler<{GenerateType(@event, nullable: nullableType)}>").WithGlobalPrefix();
        if (nullable)
        {
            eventHandler += "?";
        }

        return eventHandler;
    }
}