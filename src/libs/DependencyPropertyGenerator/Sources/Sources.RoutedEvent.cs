using H.Generators.Extensions;

namespace H.Generators;

internal static partial class Sources
{
    public static string GenerateRoutedEvent(ClassData @class, EventData @event)
    {
        if (@event.IsAttached)
        {
            return GenerateAttachedRoutedEvent(@class, @event);
        }

        // https://docs.avaloniaui.net/docs/input/routed-events
        if (@class.Framework == Framework.Wpf || @class.Framework == Framework.Avalonia)
        {
            return @$" 
#nullable enable

namespace {@class.Namespace}
{{
    public{@class.Modifiers} partial class {@class.Name}
    {{
{GenerateXmlDocumentationFrom(@event.XmlDocumentation, @event)}
{GenerateGeneratedCodeAttribute()}
        public static readonly {GenerateRoutedEventType(@class)} {@event.Name}Event =
            {GenerateEventManagerType(@class)}.{GenerateRegisterMethod(@class)}(
                {GenerateRegisterRoutedEventMethodArguments(@class, @event)});

{GenerateXmlDocumentationFrom(@event.EventXmlDocumentation, @event)}
{GenerateCategoryAttribute(@event.Category)}
{GenerateDescriptionAttribute(@event.Description)}
{GenerateGeneratedCodeAttribute()}
{GenerateExcludeFromCodeCoverageAttribute()}
        public event {GenerateRouterEventType(@class, @event)} {@event.Name}
        {{
            add => AddHandler({@event.Name}Event, value);
            remove => RemoveHandler({@event.Name}Event, value);
        }}

        /// <summary>
        /// A helper method to raise the {@event.Name} event.
        /// </summary>
{GenerateGeneratedCodeAttribute()}
{GenerateExcludeFromCodeCoverageAttribute()}
        protected {GenerateRoutedEventArgsType(@class)} On{@event.Name}()
        {{
            var args = new {GenerateRoutedEventArgsType(@class)}({@event.Name}Event);
            this.RaiseEvent(args);

            return args;
        }}
    }}
}}".RemoveBlankLinesWhereOnlyWhitespaces();
        }

        if (!@event.WinRtEvents)
        {
            return @$" 
#nullable enable

namespace {@class.Namespace}
{{
    public{@class.Modifiers} partial class {@class.Name}
    {{
        /// <summary>
        /// A helper method to raise the {@event.Name} event. <br/>
        /// WinRT events are disabled by default due to a series of issues with them in Windows 10:
        /// https://github.com/HavenDV/H.NotifyIcon/issues/36
        /// https://github.com/HavenDV/H.NotifyIcon/issues/31
        /// Use the WinRTEvents = true option to enable them.
        /// </summary>
        protected {GenerateRoutedEventArgsType(@class)}? On{@event.Name}()
        {{
            return null;
        }}
    }}
}}".RemoveBlankLinesWhereOnlyWhitespaces();
        }

        // https://docs.microsoft.com/en-us/previous-versions/windows/apps/hh972883(v=vs.140)
        return @$" 
#nullable enable

namespace {@class.Namespace}
{{
    public{@class.Modifiers} partial class {@class.Name}
    {{
{GenerateXmlDocumentationFrom(@event.EventXmlDocumentation, @event)}
{GenerateCategoryAttribute(@event.Category)}
{GenerateDescriptionAttribute(@event.Description)}
        public event {GenerateRouterEventType(@class, @event)}? {@event.Name};

        /// <summary>
        /// A helper method to raise the {@event.Name} event.
        /// </summary>
        protected {GenerateRoutedEventArgsType(@class)} On{@event.Name}()
        {{
            var args = new {GenerateRoutedEventArgsType(@class)}();
            {@event.Name}?.Invoke(this, args);

            return args;
        }}
    }}
}}".RemoveBlankLinesWhereOnlyWhitespaces();
    }
    
    public static string GenerateAttachedRoutedEvent(ClassData @class, EventData @event)
    {
        return @$"
#nullable enable

namespace {@class.Namespace}
{{
    public{@class.Modifiers} partial class {@class.Name}
    {{
{GenerateXmlDocumentationFrom(@event.XmlDocumentation, @event)}
        public static readonly {GenerateRoutedEventType(@class)} {@event.Name}Event =
            {GenerateEventManagerType(@class)}.{GenerateRegisterMethod(@class)}(
                {GenerateRegisterRoutedEventMethodArguments(@class, @event)});

{GenerateXmlDocumentationFrom(@event.EventXmlDocumentation, @event)}
{GenerateCategoryAttribute(@event.Category)}
{GenerateDescriptionAttribute(@event.Description)}
        public static void Add{@event.Name}Handler({GenerateDependencyObjectType(@class.Framework)} element, {GenerateRoutedEventHandlerType(@class)} handler)
        {{
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            if (element is {GenerateTypeByPlatform(@class.Framework, "UIElement")} uiElement)
            {{
                uiElement.AddHandler({@event.Name}Event, handler);
            }}
            else if (element is {GenerateTypeByPlatform(@class.Framework, "ContentElement")} contentElement)
            {{
                contentElement.AddHandler({@event.Name}Event, handler);
            }}
        }}

{GenerateXmlDocumentationFrom(@event.EventXmlDocumentation, @event)}
{GenerateCategoryAttribute(@event.Category)}
{GenerateDescriptionAttribute(@event.Description)}
        public static void Remove{@event.Name}Handler({GenerateDependencyObjectType(@class.Framework)} element, {GenerateRoutedEventHandlerType(@class)} handler)
        {{
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            if (element is {GenerateTypeByPlatform(@class.Framework, "UIElement")} uiElement)
            {{
                uiElement.RemoveHandler({@event.Name}Event, handler);
            }}
            else if (element is {GenerateTypeByPlatform(@class.Framework, "ContentElement")} contentElement)
            {{
                contentElement.RemoveHandler({@event.Name}Event, handler);
            }}
        }}
    }}
}}".RemoveBlankLinesWhereOnlyWhitespaces();
    }

    private static string GenerateRouterEventType(ClassData @class, EventData @event)
    {
        if (string.IsNullOrWhiteSpace(@event.Type))
        {
            return GenerateRoutedEventHandlerType(@class);
        }

        return @event.Type.WithGlobalPrefix();
    }

    private static string GenerateRoutedEventType(ClassData @class)
    {
        if (@class.Framework == Framework.Avalonia)
        {
            return
                $"{GenerateTypeByPlatform(@class.Framework, "Interactivity.RoutedEvent")}<{GenerateRoutedEventArgsType(@class)}>";
        }

        return GenerateTypeByPlatform(@class.Framework, "RoutedEvent");
    }

    private static string GenerateRoutedEventArgsType(ClassData @class)
    {
        if (@class.Framework == Framework.Avalonia)
        {
            return GenerateTypeByPlatform(@class.Framework, "Interactivity.RoutedEventArgs");
        }

        return GenerateTypeByPlatform(@class.Framework, "RoutedEventArgs");
    }

    private static string GenerateRoutedEventHandlerType(ClassData @class)
    {
        if (@class.Framework == Framework.Avalonia)
        {
            return $"global::System.EventHandler<{GenerateRoutedEventArgsType(@class)}>";
        }

        return GenerateTypeByPlatform(@class.Framework, "RoutedEventHandler");
    }
    
    private static string GenerateRegisterRoutedEventMethodArguments(ClassData @class, EventData @event)
    {
        if (@class.Framework == Framework.Avalonia)
        {
            return @$"
                name: ""{@event.Name}"",
                routingStrategy: {GenerateRoutingStrategyType(@class)}.{@event.Strategy}";
        }

        return @$"
                name: ""{@event.Name}"",
                routingStrategy: {GenerateRoutingStrategyType(@class)}.{@event.Strategy},
                handlerType: typeof({GenerateRouterEventType(@class, @event)}),
                ownerType: typeof({@class.Type})";
    }

    private static string GenerateRoutingStrategyType(ClassData @class)
    {
        if (@class.Framework == Framework.Avalonia)
        {
            return GenerateTypeByPlatform(@class.Framework, $"Interactivity.RoutingStrategies");
        }

        return GenerateTypeByPlatform(@class.Framework, "RoutingStrategy");
    }

    private static string GenerateEventManagerType(ClassData @class)
    {
        if (@class.Framework == Framework.Avalonia)
        {
            return GenerateTypeByPlatform(@class.Framework, "Interactivity.RoutedEvent");
        }

        return GenerateTypeByPlatform(@class.Framework, "EventManager");
    }

    private static string GenerateRegisterMethod(ClassData @class)
    {
        if (@class.Framework == Framework.Avalonia)
        {
            return $"Register<{@class.Type}, {GenerateRoutedEventArgsType(@class)}>";
        }

        return "RegisterRoutedEvent";
    }
}