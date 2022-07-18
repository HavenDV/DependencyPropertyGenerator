using H.Generators.Extensions;
using Microsoft.CodeAnalysis;

namespace H.Generators;

internal class SourceGenerationHelper
{
    public static string GenerateDependencyProperty(ClassData @class, DependencyPropertyData property)
    {
        return @$"
#nullable enable

namespace {@class.Namespace}
{{
    public{@class.Modifiers} partial class {@class.Name}
    {{
{GenerateXmlDocumentationFrom(property.XmlDocumentation, property)}
        {GeneratePropertyModifier(property)} static readonly {GeneratePropertyType(property)} {GenerateDependencyPropertyName(property)} =
            {GenerateDependencyPropertyCreateCall(@class, property)}

{GenerateAdditionalPropertyForReadOnlyProperties(property)}
{GenerateXmlDocumentationFrom(property.GetterXmlDocumentation, property)}
{GenerateCategoryAttribute(property.Category)}
{GenerateDescriptionAttribute(property.Description)}
{GenerateTypeConverterAttribute(property.TypeConverter)}
{GenerateBindableAttribute(property.Bindable)}
{GenerateBrowsableAttribute(property.Browsable)}
{GenerateDesignerSerializationVisibilityAttribute(property.DesignerSerializationVisibility)}
{GenerateCLSCompliantAttribute(property.CLSCompliant)}
{GenerateLocalizabilityAttribute(property.Localizability, @class.Platform)}
        public {GenerateType(property)} {property.Name}
        {{
            get => ({GenerateType(property)})GetValue({property.Name}Property);
            {GenerateAdditionalSetterModifier(property)}set => SetValue({GenerateDependencyPropertyName(property)}, value);
        }}

{GenerateOnChangedMethods(property)}
{GenerateCoercePartialMethod(property)}
{GenerateValidatePartialMethod(property)}
{GenerateCreateDefaultValueCallbackPartialMethod(property)}
{GenerateBindEventMethod(property)}
    }}
}}".RemoveBlankLinesWhereOnlyWhitespaces();
    }

    public static string GenerateDependencyPropertyCreateCall(ClassData @class, DependencyPropertyData property)
    {
        if (property.IsAddOwner)
        {
            if (@class.Platform == Platform.Avalonia)
            {
                return @$"
            {GenerateFromType(property)}.{property.Name}Property.AddOwner<{GenerateType(@class.FullName, false)}>();";
            }
            return @$"
            {GenerateFromType(property)}.{property.Name}Property.AddOwner(
                ownerType: typeof({GenerateType(@class.FullName, false)}),
                {GeneratePropertyMetadata(@class, property)});
 ".RemoveBlankLinesWhereOnlyWhitespaces();
        }

        return @$"
            {GenerateManagerType(@class)}.{GenerateRegisterMethod(@class, property)}(
                {GenerateRegisterMethodArguments(@class, property)});
 ".RemoveBlankLinesWhereOnlyWhitespaces();
    }

    public static string GenerateRegisterPropertyChangedCallbacksMethod(
        ClassData @class,
        IReadOnlyCollection<DependencyPropertyData> overrideMetadata)
    {
        return @$"#nullable enable

namespace {@class.Namespace}
{{
    public{GenerateModifiers(@class)} partial class {@class.Name}
    {{
        private void RegisterPropertyChangedCallbacks()
        {{
{overrideMetadata.Select(property => {
            var senderType = property.IsAttached
                ? GenerateBrowsableForType(property)
                : GenerateType(@class.FullName, false);

            return @$"
            _ = this.RegisterPropertyChangedCallback(
                dp: {property.Name}Property,
                callback: static (sender, dependencyProperty) =>
                {{
                    (({senderType})sender).On{property.Name}Changed();
                    (({senderType})sender).On{property.Name}Changed(
                        ({GenerateType(property)})sender.GetValue(dependencyProperty));
                    (({senderType})sender).On{property.Name}Changed(
                        ({GenerateType(property)})sender.GetValue(dependencyProperty),
                        ({GenerateType(property)})sender.GetValue(dependencyProperty));
                }});
";
        }).Inject()}
        }}

{overrideMetadata.Select(GenerateOnChangedMethods).Inject()}
    }}
}}".RemoveBlankLinesWhereOnlyWhitespaces();
    }

    public static string GenerateStaticConstructor(ClassData @class, IReadOnlyCollection<DependencyPropertyData> properties)
    {
        if (@class.Platform == Platform.Avalonia)
        {
            return @$"
using System;

#nullable enable

namespace {@class.Namespace}
{{
    public{GenerateModifiers(@class)} partial class {@class.Name}
    {{
        static {@class.Name}()
        {{
{properties.Select(property => @$"
            {property.Name}Property.Changed.Subscribe(static x => On{property.Name}Changed(
                ({GenerateBrowsableForType(property)})x.Sender,
                ({GenerateType(property)})x.OldValue.GetValueOrDefault(),
                ({GenerateType(property)})x.NewValue.GetValueOrDefault()));
").Inject()}
        }}
    }}
}}".RemoveBlankLinesWhereOnlyWhitespaces();
        }
        if (@class.Platform == Platform.WPF)
        {
            return @$" 
#nullable enable

namespace {@class.Namespace}
{{
    public{GenerateModifiers(@class)} partial class {@class.Name}
    {{
        static {@class.Name}()
        {{
{properties.Where(static property => property.IsReadOnly).Select(property => @$"
            {property.Name}Property.OverrideMetadata(
                forType: typeof({GenerateType(@class.FullName, false)}),
                {GeneratePropertyMetadata(@class, property)},
                key: {property.Name}PropertyKey);
").Inject()}
{properties.Where(static property => !property.IsReadOnly).Select(property => @$"
            {property.Name}Property.OverrideMetadata(
                forType: typeof({GenerateType(@class.FullName, false)}),
                {GeneratePropertyMetadata(@class, property)});
").Inject()}
        }}

{properties.Select(GenerateOnChangedMethods).Inject()}
    }}
}}".RemoveBlankLinesWhereOnlyWhitespaces();
        }

        return string.Empty;
    }

    public static string GenerateAttachedDependencyProperty(ClassData @class, DependencyPropertyData property)
    {
        return @$"
#nullable enable

namespace {@class.Namespace}
{{
    public{GenerateModifiers(@class)} partial class {@class.Name}{GenerateBaseType(@class)}
    {{
{GenerateXmlDocumentationFrom(property.XmlDocumentation, property)}
        {GeneratePropertyModifier(property)} static readonly {GeneratePropertyType(property)} {GenerateDependencyPropertyName(property)} =
            {GenerateManagerType(@class)}.{GenerateRegisterMethod(@class, property)}(
                {GenerateRegisterAttachedMethodArguments(@class, property)});

{GenerateAdditionalPropertyForReadOnlyProperties(property)}
{GenerateXmlDocumentationFrom(property.SetterXmlDocumentation, property)}
{GenerateCategoryAttribute(property.Category)}
{GenerateDescriptionAttribute(property.Description)}
{GenerateTypeConverterAttribute(property.TypeConverter)}
{GenerateBindableAttribute(property.Bindable)}
{GenerateBrowsableAttribute(property.Browsable)}
{GenerateDesignerSerializationVisibilityAttribute(property.DesignerSerializationVisibility)}
{GenerateCLSCompliantAttribute(property.CLSCompliant)}
{GenerateLocalizabilityAttribute(property.Localizability, @class.Platform)}
        {(property.IsReadOnly ? "internal" : "public")} static void Set{property.Name}({GenerateDependencyObjectType(@class.Platform)} element, {GenerateType(property)} value)
        {{
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue({GenerateDependencyPropertyName(property)}, value);
        }}

{GenerateXmlDocumentationFrom(property.GetterXmlDocumentation, property)}
{GenerateCategoryAttribute(property.Category)}
{GenerateDescriptionAttribute(property.Description)}
{GenerateTypeConverterAttribute(property.TypeConverter)}
{GenerateBindableAttribute(property.Bindable)}
{GenerateBrowsableAttribute(property.Browsable)}
{GenerateDesignerSerializationVisibilityAttribute(property.DesignerSerializationVisibility)}
{GenerateBrowsableForTypeAttribute(property)}
{GenerateCLSCompliantAttribute(property.CLSCompliant)}
{GenerateLocalizabilityAttribute(property.Localizability, @class.Platform)}
        public static {GenerateType(property)} Get{property.Name}({GenerateDependencyObjectType(@class.Platform)} element)
        {{
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return ({GenerateType(property)})element.GetValue({property.Name}Property);
        }}

{GenerateOnChangedMethods(property)}
{GenerateCoercePartialMethod(property)}
{GenerateValidatePartialMethod(property)}
{GenerateCreateDefaultValueCallbackPartialMethod(property)}
{GenerateBindEventMethod(property)}
    }}
}}".RemoveBlankLinesWhereOnlyWhitespaces();
    }
    
    public static string GenerateRoutedEvent(ClassData @class, RoutedEventData @event)
    {
        // https://docs.avaloniaui.net/docs/input/routed-events
        if (@class.Platform == Platform.WPF || @class.Platform == Platform.Avalonia)
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
        public event {GenerateRouterEventType(@class, @event)} {@event.Name}
        {{
            add => AddHandler({@event.Name}Event, value);
            remove => RemoveHandler({@event.Name}Event, value);
        }}

        /// <summary>
        /// A helper method to raise the {@event.Name} event.
        /// </summary>
        protected {GenerateRoutedEventArgsType(@class)} On{@event.Name}()
        {{
            var args = new {GenerateRoutedEventArgsType(@class)}({@event.Name}Event);
            this.RaiseEvent(args);

            return args;
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

    public static string GenerateAttachedRoutedEvent(ClassData @class, RoutedEventData @event)
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
        public static void Add{@event.Name}Handler({GenerateDependencyObjectType(@class.Platform)} element, {GenerateRoutedEventHandlerType(@class)} handler)
        {{
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            if (element is {GenerateTypeByPlatform(@class.Platform, "UIElement")} uiElement)
            {{
                uiElement.AddHandler({@event.Name}Event, handler);
            }}
            else if (element is {GenerateTypeByPlatform(@class.Platform, "ContentElement")} contentElement)
            {{
                contentElement.AddHandler({@event.Name}Event, handler);
            }}
        }}

{GenerateXmlDocumentationFrom(@event.EventXmlDocumentation, @event)}
{GenerateCategoryAttribute(@event.Category)}
{GenerateDescriptionAttribute(@event.Description)}
        public static void Remove{@event.Name}Handler({GenerateDependencyObjectType(@class.Platform)} element, {GenerateRoutedEventHandlerType(@class)} handler)
        {{
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            if (element is {GenerateTypeByPlatform(@class.Platform, "UIElement")} uiElement)
            {{
                uiElement.RemoveHandler({@event.Name}Event, handler);
            }}
            else if (element is {GenerateTypeByPlatform(@class.Platform, "ContentElement")} contentElement)
            {{
                contentElement.RemoveHandler({@event.Name}Event, handler);
            }}
        }}
    }}
}}".RemoveBlankLinesWhereOnlyWhitespaces();
    }

    public static string GenerateBaseType(ClassData @class)
    {
        if (@class.Platform == Platform.Avalonia)
        {
            return $" : {GenerateTypeByPlatform(@class.Platform, "AvaloniaObject")}";
        }

        return string.Empty;
    }

    public static string GenerateModifiers(ClassData @class)
    {
        if (@class.Platform == Platform.Avalonia)
        {
            return string.Empty;
        }

        return @class.Modifiers;
    }

    public static string GeneratePropertyChangedCallback(ClassData @class, DependencyPropertyData property)
    {
        var senderType = property.IsAttached
            ? GenerateBrowsableForType(property)
            : GenerateType(@class.FullName, false);
        if (property.Platform == Platform.MAUI)
        {
            return property.IsAttached
                ? $@"static (sender, oldValue, newValue) =>
            {{
                On{property.Name}Changed();
                On{property.Name}Changed(
                    ({senderType})sender);
                On{property.Name}Changed(
                    ({senderType})sender,
                    ({GenerateType(property)})newValue);
                On{property.Name}Changed(
                    ({senderType})sender,
                    ({GenerateType(property)})oldValue,
                    ({GenerateType(property)})newValue);
            }}"
                : $@"static (sender, oldValue, newValue) =>
            {{
                (({senderType})sender).On{property.Name}Changed();
                (({senderType})sender).On{property.Name}Changed(
                    ({GenerateType(property)})newValue);
                (({senderType})sender).On{property.Name}Changed(
                    ({GenerateType(property)})oldValue,
                    ({GenerateType(property)})newValue);
            }}";
        }

        return property.IsAttached
            ? $@"static (sender, args) =>
                    {{
                        On{property.Name}Changed();
                        On{property.Name}Changed(
                            ({senderType})sender);
                        On{property.Name}Changed(
                            ({senderType})sender,
                            ({GenerateType(property)})args.NewValue);
                        On{property.Name}Changed(
                            ({senderType})sender,
                            ({GenerateType(property)})args.OldValue,
                            ({GenerateType(property)})args.NewValue);
                    }}"
            : $@"static (sender, args) =>
                    {{
                        (({senderType})sender).On{property.Name}Changed();
                        (({senderType})sender).On{property.Name}Changed(
                            ({GenerateType(property)})args.NewValue);
                        (({senderType})sender).On{property.Name}Changed(
                            ({GenerateType(property)})args.OldValue,
                            ({GenerateType(property)})args.NewValue);
                    }}";
    }

    public static string GenerateCoerceValueCallback(ClassData @class, DependencyPropertyData property)
    {
        if (!property.Coerce)
        {
            return "null";
        }

        var senderType = property.IsAttached
            ? GenerateBrowsableForType(property)
            : GenerateType(@class.FullName, false);

        if (property.Platform == Platform.MAUI)
        {
            return property.IsAttached
                ? $@"static (sender, value) =>
                        Coerce{property.Name}(
                            ({senderType})sender,
                            ({GenerateType(property)})value)"
                : $@"static (sender, value) =>
                        (({senderType})sender).Coerce{property.Name}(
                            ({GenerateType(property)})value)";
        }

        return property.IsAttached
            ? $@"static (sender, args) =>
                        Coerce{property.Name}(
                            ({senderType})sender,
                            ({GenerateType(property)})args.Value)"
            : $@"static (sender, value) =>
                        (({senderType})sender).Coerce{property.Name}(
                            ({GenerateType(property)})value)";
    }

    public static string GenerateValidateValueCallback(DependencyPropertyData property)
    {
        if (!property.Validate)
        {
            return "null";
        }

        if (property.Platform == Platform.MAUI)
        {
            return $@"static (_, value) =>
                    Is{property.Name}Valid(
                        ({GenerateType(property)})value)";
        }

        return $@"static value =>
                    Is{property.Name}Valid(
                        ({GenerateType(property)})value)";
    }

    public static string GenerateCreateDefaultValueCallbackValueCallback(DependencyPropertyData property)
    {
        if (!property.CreateDefaultValueCallback)
        {
            return "null";
        }

        if (property.Platform == Platform.MAUI)
        {
            return $@"static _ => Get{property.Name}DefaultValue()";
        }

        return $@"static () => Get{property.Name}DefaultValue()";
    }

    public static string GeneratePropertyMetadata(ClassData @class, DependencyPropertyData property)
    {
        if (property.IsAddOwner &&
            property.DefaultValue == null)
        {
            return "null";
        }

        var parameterName = (@class.Platform, property.IsAttached) switch
        {
            (Platform.WPF, true) or (Platform.UWP, true) or (Platform.WinUI, true) => "defaultMetadata",
            _ => "typeMetadata",
        };
        switch (@class.Platform)
        {
            case Platform.WPF:
                if (property.DefaultUpdateSourceTrigger == null)
                {
                    return $@"{parameterName}: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: {GenerateDefaultValue(property)},
                    flags: {GenerateOptions(property)},
                    propertyChangedCallback: {GeneratePropertyChangedCallback(@class, property)},
                    coerceValueCallback: {GenerateCoerceValueCallback(@class, property)},
                    isAnimationProhibited: {property.IsAnimationProhibited.ToString().ToLower()})";
                }

                return $@"{parameterName}: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: {GenerateDefaultValue(property)},
                    flags: {GenerateOptions(property)},
                    propertyChangedCallback: {GeneratePropertyChangedCallback(@class, property)},
                    coerceValueCallback: {GenerateCoerceValueCallback(@class, property)},
                    isAnimationProhibited: {property.IsAnimationProhibited.ToString().ToLower()},
                    defaultUpdateSourceTrigger: global::System.Windows.Data.UpdateSourceTrigger.{property.DefaultUpdateSourceTrigger})";

            case Platform.UWP:
            case Platform.WinUI:
            case Platform.Uno:
            case Platform.UnoWinUI:
                var type = GenerateTypeByPlatform(@class.Platform, "PropertyMetadata");
                if (property.CreateDefaultValueCallback)
                {
                    return $@"{parameterName}: {type}.Create(
                    createDefaultValueCallback: {GenerateCreateDefaultValueCallbackValueCallback(property)},
                    propertyChangedCallback: {GeneratePropertyChangedCallback(@class, property)})";
                }

                return $@"{parameterName}: {type}.Create(
                    defaultValue: {GenerateDefaultValue(property)},
                    propertyChangedCallback: {GeneratePropertyChangedCallback(@class, property)})";
        }

        throw new InvalidOperationException("Platform is not supported.");
    }

    public static string GenerateTypeByPlatform(Platform platform, string name)
    {
        return (platform switch
        {
            Platform.WPF => $"System.Windows.{name}",
            Platform.UWP or Platform.Uno => $"Windows.UI.Xaml.{name}",
            Platform.WinUI or Platform.UnoWinUI => $"Microsoft.UI.Xaml.{name}",
            Platform.Avalonia => $"Avalonia.{name}",
            Platform.MAUI => $"Microsoft.Maui.Controls.{name}",
            _ => throw new InvalidOperationException("Platform is not supported."),
        }).WithGlobalPrefix();
    }

    public static string GenerateType(string fullTypeName, bool isSpecialType)
    {
        if (isSpecialType)
        {
            return fullTypeName;
        }

        return fullTypeName switch
        {
            _ => fullTypeName.WithGlobalPrefix(),
        };
    }

    public static string GenerateRoutedEventType(ClassData @class)
    {
        if (@class.Platform == Platform.Avalonia)
        {
            return $"{GenerateTypeByPlatform(@class.Platform, "Interactivity.RoutedEvent")}<{GenerateRoutedEventArgsType(@class)}>";
        }

        return GenerateTypeByPlatform(@class.Platform, "RoutedEvent");
    }

    public static string GenerateRoutedEventArgsType(ClassData @class)
    {
        if (@class.Platform == Platform.Avalonia)
        {
            return GenerateTypeByPlatform(@class.Platform, "Interactivity.RoutedEventArgs");
        }

        return GenerateTypeByPlatform(@class.Platform, "RoutedEventArgs");
    }

    public static string GenerateRoutedEventHandlerType(ClassData @class)
    {
        if (@class.Platform == Platform.Avalonia)
        {
            return $"global::System.EventHandler<{GenerateRoutedEventArgsType(@class)}>";
        }

        return GenerateTypeByPlatform(@class.Platform, "RoutedEventHandler");
    }

    public static string GenerateEventManagerType(ClassData @class)
    {
        if (@class.Platform == Platform.Avalonia)
        {
            return GenerateTypeByPlatform(@class.Platform, "Interactivity.RoutedEvent");
        }

        return GenerateTypeByPlatform(@class.Platform, "EventManager");
    }

    public static string GenerateRoutingStrategyType(ClassData @class)
    {
        if (@class.Platform == Platform.Avalonia)
        {
            return GenerateTypeByPlatform(@class.Platform, $"Interactivity.RoutingStrategies");
        }

        return GenerateTypeByPlatform(@class.Platform, "RoutingStrategy");
    }

    public static string GeneratePropertyType(DependencyPropertyData property)
    {
        if (property.Platform == Platform.MAUI)
        {
            return GenerateTypeByPlatform(
                property.Platform,
                property.IsReadOnly
                    ? "BindablePropertyKey"
                    : "BindableProperty");
        }
        if (property.Platform == Platform.Avalonia)
        {
            return property.IsAttached
                ? GenerateTypeByPlatform(
                    property.Platform,
                    $"AttachedProperty<{GenerateType(property)}>")
                : GenerateTypeByPlatform(
                    property.Platform,
                    $"StyledProperty<{GenerateType(property)}>");
        }
        if (property.IsReadOnly && property.Platform == Platform.WPF)
        {
            return GenerateTypeByPlatform(property.Platform, "DependencyPropertyKey");
        }

        return GenerateTypeByPlatform(property.Platform, "DependencyProperty");
    }

    public static string GenerateManagerType(ClassData @class)
    {
        if (@class.Platform == Platform.MAUI)
        {
            return GenerateTypeByPlatform(
                @class.Platform,
                "BindableProperty");
        }
        if (@class.Platform == Platform.Avalonia)
        {
            return GenerateTypeByPlatform(
                @class.Platform,
                "AvaloniaProperty");
        }

        return GenerateTypeByPlatform(@class.Platform, "DependencyProperty");
    }

    public static string GenerateRegisterMethod(ClassData @class)
    {
        if (@class.Platform == Platform.Avalonia)
        {
            return $"Register<{GenerateType(@class.FullName, false)}, {GenerateRoutedEventArgsType(@class)}>";
        }

        return "RegisterRoutedEvent";
    }

    public static string GenerateRegisterMethod(ClassData @class, DependencyPropertyData property)
    {
        if (property.Platform == Platform.MAUI)
        {
            return property.IsAttached
                ? property.IsReadOnly
                    ? "CreateAttachedReadOnly"
                    : "CreateAttached"
                : property.IsReadOnly
                    ? "CreateReadOnly"
                    : "Create";
        }
        if (property.Platform == Platform.Avalonia)
        {
            return property.IsAttached
                ? $"RegisterAttached<{GenerateType(@class.FullName, false)}, {GenerateBrowsableForType(property)}, {GenerateType(property)}>"
                : $"Register<{GenerateType(@class.FullName, false)}, {GenerateType(property)}>";
        }
        if (property.IsReadOnly && property.Platform == Platform.WPF)
        {
            return property.IsAttached
                ? "RegisterAttachedReadOnly"
                : "RegisterReadOnly";
        }

        return property.IsAttached
            ? "RegisterAttached"
            : "Register";
    }

    public static string GenerateMauiRegisterMethodArguments(ClassData @class, DependencyPropertyData property)
    {
        return @$"
            propertyName: ""{property.Name}"",
            returnType: typeof({GenerateType(property.Type, property.IsSpecialType)}),
            declaringType: typeof({GenerateType(@class.FullName, false)}),
            defaultValue: {GenerateDefaultValue(property)},
            defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.{(property.IsReadOnly ? "OneWayToSource" : "OneWay")},
            validateValue: {GenerateValidateValueCallback(property)},
            propertyChanged: {GeneratePropertyChangedCallback(@class, property)},
            propertyChanging: null,
            coerceValue: {GenerateCoerceValueCallback(@class, property)},
            defaultValueCreator: {GenerateCreateDefaultValueCallbackValueCallback(property)}";
    }

    // https://docs.avaloniaui.net/docs/authoring-controls/defining-properties
    public static string GenerateAvaloniaRegisterMethodArguments(ClassData @class, DependencyPropertyData property)
    {
        if (property.IsAttached)
        {
            return $@"
                name: ""{property.Name}"",
                defaultValue: {GenerateDefaultValue(property)},
                inherits: {(property.Inherits ? "true" : "false")},
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                validate: {GenerateValidateValueCallback(property)},
                coerce: {GenerateCoerceValueCallback(@class, property)}";
        }

        return @$"
                name: ""{property.Name}"",
                defaultValue: {GenerateDefaultValue(property)},
                inherits: {(property.Inherits ? "true" : "false")},
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                validate: {GenerateValidateValueCallback(property)},
                coerce: {GenerateCoerceValueCallback(@class, property)},
                notifying: null";
    }

    public static string GenerateRegisterMethodArguments(ClassData @class, DependencyPropertyData property)
    {
        if (@class.Platform == Platform.Avalonia)
        {
            return GenerateAvaloniaRegisterMethodArguments(@class, property);
        }
        if (@class.Platform == Platform.MAUI)
        {
            return GenerateMauiRegisterMethodArguments(@class, property);
        }
        if (@class.Platform == Platform.WPF)
        {
            return @$"
                name: ""{property.Name}"",
                propertyType: typeof({GenerateType(property.Type, property.IsSpecialType)}),
                ownerType: typeof({GenerateType(@class.FullName, false)}),
                {GeneratePropertyMetadata(@class, property)},
                validateValueCallback: {GenerateValidateValueCallback(property)}";
        }

        return @$"
                name: ""{property.Name}"",
                propertyType: typeof({GenerateType(property.Type, property.IsSpecialType)}),
                ownerType: typeof({GenerateType(@class.FullName, false)}),
                {GeneratePropertyMetadata(@class, property)}";
    }

    public static string GenerateRegisterAttachedMethodArguments(ClassData @class, DependencyPropertyData property)
    {
        if (@class.Platform == Platform.MAUI)
        {
            return GenerateMauiRegisterMethodArguments(@class, property);
        }
        if (@class.Platform == Platform.Avalonia)
        {
            return GenerateAvaloniaRegisterMethodArguments(@class, property);
        }
        if (@class.Platform == Platform.WPF)
        {
            return @$"
                name: ""{property.Name}"",
                propertyType: typeof({GenerateType(property.Type, property.IsSpecialType)}),
                ownerType: typeof({GenerateType(@class.FullName, false)}),
                {GeneratePropertyMetadata(@class, property)},
                validateValueCallback: {GenerateValidateValueCallback(property)}";
        }

        return @$"
                name: ""{property.Name}"",
                propertyType: typeof({GenerateType(property.Type, property.IsSpecialType)}),
                ownerType: typeof({GenerateType(@class.FullName, false)}),
                {GeneratePropertyMetadata(@class, property)}";
    }

    public static string GenerateRegisterRoutedEventMethodArguments(ClassData @class, RoutedEventData @event)
    {
        if (@class.Platform == Platform.Avalonia)
        {
            return @$"
            name: ""{@event.Name}"",
            routingStrategy: {GenerateRoutingStrategyType(@class)}.{@event.Strategy}";
        }

        return @$"
                name: ""{@event.Name}"",
                routingStrategy: {GenerateRoutingStrategyType(@class)}.{@event.Strategy},
                handlerType: typeof({GenerateRouterEventType(@class, @event)}),
                ownerType: typeof({GenerateType(@class.FullName, false)})";
    }

    public static string GenerateDependencyPropertyName(DependencyPropertyData property)
    {
        if (property.IsReadOnly &&
            (property.Platform == Platform.WPF ||
            property.Platform == Platform.MAUI))
        {
            return $"{property.Name}PropertyKey";
        }

        return $"{property.Name}Property";
    }

    public static string GenerateDependencyObjectType(Platform platform)
    {
        if (platform == Platform.MAUI)
        {
            return GenerateTypeByPlatform(platform, "BindableObject");
        }
        if (platform == Platform.Avalonia)
        {
            return GenerateTypeByPlatform(platform, "IAvaloniaObject");
        }

        return GenerateTypeByPlatform(platform, "DependencyObject");
    }
    
    public static string GenerateDefaultValue(DependencyPropertyData property)
    {
        var type = GenerateType(property.Type, property.IsSpecialType);
        if (property.IsSpecialType && property.DefaultValueDocumentation != null)
        {
            return $"({type}){property.DefaultValueDocumentation}";
        }
        
        return property.DefaultValue != null 
            ? $"({type}){property.DefaultValue}"
            : $"default({type})";
    }

    public static string? GenerateFromType(DependencyPropertyData property)
    {
        return property.FromType?.WithGlobalPrefix();
    }

    public static string GenerateBrowsableForType(DependencyPropertyData property)
    {
        return property.BrowsableForType?.WithGlobalPrefix() ?? GenerateDependencyObjectType(property.Platform);
    }

    public static string GenerateBrowsableForTypeParameterName(DependencyPropertyData property)
    {
        return (property.BrowsableForType ?? GenerateDependencyObjectType(property.Platform))
            .ExtractSimpleName()
            .ToParameterName();
    }

    public static string GenerateRouterEventType(ClassData @class, RoutedEventData @event)
    {
        return @event.Type?.WithGlobalPrefix() ?? GenerateRoutedEventHandlerType(@class);
    }

    public static string GenerateType(DependencyPropertyData property)
    {
        var value = GenerateType(property.Type, property.IsSpecialType);
        if (!property.IsValueType)
        {
            value += "?";
        }

        return value;
    }

    public static string GenerateXmlDocumentationFrom(string value)
    {
        var lines = value.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        return string.Join(Environment.NewLine, lines.Select(static line => $"        /// {line}"));
    }

    public static string GenerateXmlDocumentationFrom(string? value, DependencyPropertyData property)
    {
        value ??= @$"<summary>
{(property.Description != null ? $"{property.Description}<br/>" : " ")}
Default value: {property.DefaultValueDocumentation?.ExtractSimpleName() ?? $"default({property.Type?.ExtractSimpleName()})"}
</summary>".RemoveBlankLinesWhereOnlyWhitespaces();

        return GenerateXmlDocumentationFrom(value);
    }

    public static string GenerateXmlDocumentationFrom(string? value, RoutedEventData @event)
    {
        value ??= @$"<summary>
{(@event.Description != null ? $"{@event.Description}" : " ")}
</summary>".RemoveBlankLinesWhereOnlyWhitespaces();

        return GenerateXmlDocumentationFrom(value);
    }

    public static string GenerateOnChangedMethods(DependencyPropertyData property)
    {
        return property.IsAttached
            ? $@" 
        static partial void On{property.Name}Changed();
        static partial void On{property.Name}Changed({GenerateBrowsableForType(property)} {GenerateBrowsableForTypeParameterName(property)});
        static partial void On{property.Name}Changed({GenerateBrowsableForType(property)} {GenerateBrowsableForTypeParameterName(property)}, {GenerateType(property)} newValue);
        static partial void On{property.Name}Changed({GenerateBrowsableForType(property)} {GenerateBrowsableForTypeParameterName(property)}, {GenerateType(property)} oldValue, {GenerateType(property)} newValue);"
            : $@" 
        partial void On{property.Name}Changed();
        partial void On{property.Name}Changed({GenerateType(property)} newValue);
        partial void On{property.Name}Changed({GenerateType(property)} oldValue, {GenerateType(property)} newValue);";
    }

    public static string GenerateCoercePartialMethod(DependencyPropertyData property)
    {
        if (!property.Coerce)
        {
            return " ";
        }

        return property.IsAttached
            ? $"        private static partial {GenerateType(property)} Coerce{property.Name}({GenerateBrowsableForType(property)} {GenerateBrowsableForTypeParameterName(property)}, {GenerateType(property)} value);"
            : $"        private partial {GenerateType(property)} Coerce{property.Name}({GenerateType(property)} value);";
    }

    public static string GenerateAdditionalPropertyForReadOnlyProperties(DependencyPropertyData property)
    {
        if (!property.IsReadOnly)
        {
            return " ";
        }
        
        return property.Platform switch
        {
            Platform.MAUI => $@" 
{GenerateXmlDocumentationFrom(property.XmlDocumentation, property)}
        public static readonly {GenerateTypeByPlatform(property.Platform, "BindableProperty")} {property.Name}Property
            = {GenerateDependencyPropertyName(property)}.BindableProperty;
",
            // https://docs.microsoft.com/en-us/dotnet/api/system.windows.dependencypropertykey?view=windowsdesktop-6.0#examples
            Platform.WPF => $@" 
{GenerateXmlDocumentationFrom(property.XmlDocumentation, property)}
        public static readonly {GenerateTypeByPlatform(property.Platform, "DependencyProperty")} {property.Name}Property
            = {GenerateDependencyPropertyName(property)}.DependencyProperty;
",
            _ => " ",
        };
    }

    public static string GenerateAdditionalSetterModifier(DependencyPropertyData property)
    {
        return property.IsReadOnly
            ? "protected "
            : string.Empty;
    }

    public static string GeneratePropertyModifier(DependencyPropertyData property)
    {
        if (property.IsReadOnly && property.Platform == Platform.WPF)
        {
            return "internal";
        }

        return "public";
    }

    public static string GenerateValidatePartialMethod(DependencyPropertyData property)
    {
        if (!property.Validate)
        {
            return " ";
        }

        return $"        private static partial bool Is{property.Name}Valid({GenerateType(property)} value);";
    }

    public static string GenerateCreateDefaultValueCallbackPartialMethod(DependencyPropertyData property)
    {
        if (!property.CreateDefaultValueCallback)
        {
            return " ";
        }

        return $"        private static partial {GenerateType(property)} Get{property.Name}DefaultValue();";
    }

    public static string GenerateOnChangedMethodDeclaration(string name, DependencyPropertyData property)
    {
        var modifiers = property.IsAttached ? "static " : string.Empty;

        return $@" 
        {modifiers}partial void {name}(
{(property.IsAttached ? @$" 
            {GenerateBrowsableForType(property)} {GenerateBrowsableForTypeParameterName(property)}," : " ")}
            {GenerateType(property)} oldValue,
            {GenerateType(property)} newValue)".RemoveBlankLinesWhereOnlyWhitespaces();
    }

    public static string GenerateOnChangedMethodCall(string name, DependencyPropertyData property)
    {
        return $@" 
            {name}(
{(property.IsAttached ? @$" 
                {GenerateBrowsableForTypeParameterName(property)}," : " ")}
                oldValue,
                newValue);".RemoveBlankLinesWhereOnlyWhitespaces();
    }

    public static string GenerateBindEventMethod(DependencyPropertyData property)
    {
        if (!property.BindEvents.Any())
        {
            return " ";
        }

        var type = GenerateType(property.Type, property.IsSpecialType);
        var sender = property.IsAttached ? GenerateBrowsableForTypeParameterName(property) : "this";
        var modifiers = property.IsAttached ? "static " : string.Empty;

        return $@"
{GenerateOnChangedMethodDeclaration($"On{property.Name}Changed_BeforeBind", property)};
{GenerateOnChangedMethodDeclaration($"On{property.Name}Changed_AfterBind", property)};

{GenerateOnChangedMethodDeclaration($"On{property.Name}Changed", property)}
        {{
{GenerateOnChangedMethodCall($"On{property.Name}Changed_BeforeBind", property)}

            if (oldValue is not default({type}))
            {{
{property.BindEvents.Select(@event => $@" 
                {sender}.{@event} -= On{property.Name}Changed_{@event};
 ").Inject()}
            }}
            if (newValue is not default({type}))
            {{
{property.BindEvents.Select(@event => $@" 
                {sender}.{@event} += On{property.Name}Changed_{@event};
 ").Inject()}
            }}

{GenerateOnChangedMethodCall($"On{property.Name}Changed_AfterBind", property)}
        }}".RemoveBlankLinesWhereOnlyWhitespaces();
    }

    public static string GenerateAttribute(string name, string? value)
    {
        if (value == null)
        {
            return " ";
        }

        return $"        [global::{name}({value})]";
    }

    public static string GenerateComponentModelAttribute(string name, string? value)
    {
        return GenerateAttribute($"System.ComponentModel.{name}", value);
    }

    public static string GenerateCategoryAttribute(string? value)
    {
        if (value == null)
        {
            return " ";
        }

        return GenerateComponentModelAttribute(
            nameof(DependencyPropertyData.Category),
            $"\"{value}\"");
    }

    public static string GenerateDescriptionAttribute(string? value)
    {
        if (value == null)
        {
            return " ";
        }

        return GenerateComponentModelAttribute(
            nameof(DependencyPropertyData.Description),
            $"\"{value}\"");
    }

    public static string GenerateTypeConverterAttribute(string? value)
    {
        if (value == null)
        {
            return " ";
        }

        return GenerateComponentModelAttribute(
            nameof(DependencyPropertyData.TypeConverter),
            $"typeof({value.WithGlobalPrefix()})");
    }

    public static string GenerateBindableAttribute(string? value)
    {
        return GenerateComponentModelAttribute(
            nameof(DependencyPropertyData.Bindable),
            value);
    }

    public static string GenerateBrowsableAttribute(string? value)
    {
        return GenerateComponentModelAttribute(
            nameof(DependencyPropertyData.Browsable),
            value);
    }

    public static string GenerateDesignerSerializationVisibilityAttribute(string? value)
    {
        if (value == null)
        {
            return " ";
        }

        return GenerateComponentModelAttribute(
            nameof(DependencyPropertyData.DesignerSerializationVisibility),
            $"global::System.ComponentModel.{value}");
    }

    public static string GenerateCLSCompliantAttribute(string? value)
{
        return GenerateAttribute("System.CLSCompliant", value);
    }

    public static string GenerateLocalizabilityAttribute(string? value, Platform platform)
    {
        if (value == null || platform != Platform.WPF)
        {
            return " ";
        }

        return GenerateAttribute(
            "System.Windows.Localizability",
            $"global::System.Windows.LocalizationCategory.{value}");
    }
    
    public static string GenerateBrowsableForTypeAttribute(DependencyPropertyData property)
    {
        if (property.Platform != Platform.WPF)
        {
            return " ";
        }

        return GenerateAttribute(
            "System.Windows.AttachedPropertyBrowsableForType",
            $"typeof({GenerateBrowsableForType(property)})");
    }

    public static string GenerateOptions(DependencyPropertyData property)
    {
        var values = new List<string>();
        if (property.AffectsMeasure)
        {
            values.Add(nameof(property.AffectsMeasure));
        }
        if (property.AffectsArrange)
        {
            values.Add(nameof(property.AffectsArrange));
        }
        if (property.AffectsParentMeasure)
        {
            values.Add(nameof(property.AffectsParentMeasure));
        }
        if (property.AffectsParentArrange)
        {
            values.Add(nameof(property.AffectsParentArrange));
        }
        if (property.AffectsRender)
        {
            values.Add(nameof(property.AffectsRender));
        }
        if (property.Inherits)
        {
            values.Add(nameof(property.Inherits));
        }
        if (property.OverridesInheritanceBehavior)
        {
            values.Add(nameof(property.OverridesInheritanceBehavior));
        }
        if (property.NotDataBindable)
        {
            values.Add(nameof(property.NotDataBindable));
        }
        if (property.BindsTwoWayByDefault)
        {
            values.Add(nameof(property.BindsTwoWayByDefault));
        }
        if (property.Journal)
        {
            values.Add(nameof(property.Journal));
        }
        if (property.SubPropertiesDoNotAffectRender)
        {
            values.Add(nameof(property.SubPropertiesDoNotAffectRender));
        }
        if (!values.Any())
        {
            values.Add("None");
        }

        return string.Join(" | ", values
            .Select(static value => $"global::System.Windows.FrameworkPropertyMetadataOptions.{value}"));
    }
}