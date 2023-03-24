using System.ComponentModel;
using H.Generators.Extensions;
using System.Globalization;
using System.Net;

namespace H.Generators;

internal static partial class SourceGenerationHelper
{
    public static string GenerateDependencyProperty(ClassData @class, DependencyPropertyData property)
    {
        return @$"
#nullable enable

namespace {@class.Namespace}
{{
    public{@class.Modifiers} partial class {@class.Name}
    {{
{GenerateXmlDocumentationFrom(property.XmlDocumentation, property, isProperty: false)}
        {GeneratePropertyModifier(property)} static readonly {GeneratePropertyType(@class, property)} {GenerateDependencyPropertyName(property)} =
            {GenerateDependencyPropertyCreateCall(@class, property)}

{GenerateAdditionalFieldForDirectProperties(property)}
{GenerateAdditionalPropertyForReadOnlyProperties(property)}
{GenerateXmlDocumentationFrom(property.GetterXmlDocumentation, property, isProperty: true)}
{GenerateCategoryAttribute(property.Category)}
{GenerateDescriptionAttribute(property.Description)}
{GenerateTypeConverterAttribute(property.TypeConverter)}
{GenerateBindableAttribute(property.Bindable)}
{GenerateBrowsableAttribute(property.Browsable)}
{GenerateDesignerSerializationVisibilityAttribute(property.DesignerSerializationVisibility)}
{GenerateClsCompliantAttribute(property.ClsCompliant)}
{GenerateLocalizabilityAttribute(property.Localizability, @class.Framework)}
        public {GenerateType(property)} {property.Name}
        {{
            {GenerateGetter(property)}
            {GenerateSetter(property)}
        }}

{GenerateOnChangedMethods(property)}
{GenerateOnChangingMethods(property)}
{GenerateCoercePartialMethod(property)}
{GenerateValidatePartialMethod(property)}
{GenerateCreateDefaultValueCallbackPartialMethod(property)}
{GenerateBindEventMethod(property)}
    }}
}}".RemoveBlankLinesWhereOnlyWhitespaces();
    }

    private static string GenerateGetter(DependencyPropertyData property)
    {
        if (property is { IsDirect: true, Framework: Framework.Avalonia })
        {
            return @$"get => _{property.Name.ToParameterName()};";
        }

        return @$"get => ({GenerateType(property)})GetValue({property.Name}Property);";
    }

    private static string GenerateSetter(DependencyPropertyData property)
    {
        if (property is { IsDirect: true, Framework: Framework.Avalonia })
        {
            return @$"private set
            {{
                var oldValue = _{property.Name.ToParameterName()};
                SetAndRaise({property.Name}Property, ref _{property.Name.ToParameterName()}, value);
                On{property.Name}Changed();
                On{property.Name}Changed(
                    ({GenerateType(property)})value);
                On{property.Name}Changed(
                    ({GenerateType(property)})oldValue,
                    ({GenerateType(property)})value);
            }}";
        }

        return @$"{GenerateAdditionalSetterModifier(property)}set => SetValue({GenerateDependencyPropertyName(property)}, value);";
    }

    private static string GenerateDependencyPropertyCreateCall(ClassData @class, DependencyPropertyData property)
    {
        if (property.IsAddOwner)
        {
            if (@class.Framework == Framework.Avalonia)
            {
                if (property.IsDirect)
                {
                    return @$"
            {GenerateFromType(property)}.{property.Name}Property.AddOwner<{GenerateType(@class.FullName, false)}>(
                {GenerateAvaloniaRegisterMethodArguments(@class, property)});";
                }

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

            var (name, isChanged0, isChanged1, isChanged2, isChanged3) = CheckOnChangedMethods(@class, property);
            if (!isChanged0 &&
                !isChanged1 &&
                !isChanged2 &&
                !isChanged3)
            {
                return " ";
            }

            return @$"
            _ = this.RegisterPropertyChangedCallback(
                dp: {property.Name}Property,
                callback: static (sender, dependencyProperty) =>
                {{
                    {(isChanged0 ? @$"(({senderType})sender).{name}();" : "")}
                    {(isChanged1 ? @$"(({senderType})sender).{name}(
                        ({GenerateType(property)})sender.GetValue(dependencyProperty));" : "")}
                    {(isChanged2 ? @$"(({senderType})sender).{name}(
                        ({GenerateType(property)})sender.GetValue(dependencyProperty),
                        ({GenerateType(property)})sender.GetValue(dependencyProperty));" : "")}
                }});
";
        }).Inject()}
        }}

{overrideMetadata.Select(GenerateOnChangedMethods).Inject()}
    }}
}}".RemoveBlankLinesWhereOnlyWhitespaces();
    }

    private static (bool IsChanged0, bool IsChanged1, bool IsChanged2, bool IsChanged3) CheckMethods(
        string name,
        ClassData @class,
        DependencyPropertyData property)
    {
        var type = GenerateType(property)
            .Replace("global::", string.Empty)
            .Replace("?", string.Empty);
        var senderType = (property.IsAttached
            ? GenerateBrowsableForType(property)
            : GenerateType(@class.FullName, false))
            .Replace("global::", string.Empty);

        var isChanged0 =
            IsMethodExists(@class, $"{name}()");
        var isChanged1 =
            IsMethodExists(@class, $"{name}({type})") ||
            IsMethodExists(@class, $"{name}({senderType})");
        var isChanged2 =
            IsMethodExists(@class, $"{name}({type}, {type})") ||
            IsMethodExists(@class, $"{name}({senderType}, {type})");
        var isChanged3 =
            IsMethodExists(@class, $"{name}({senderType}, {type}, {type})");

        return (isChanged0, isChanged1, isChanged2, isChanged3);
    }

    private static (string Name, bool IsChanged0, bool IsChanged1, bool IsChanged2, bool IsChanged3) CheckOnChangedMethods(
        ClassData @class,
        DependencyPropertyData property)
    {
        var isCustom = !string.IsNullOrWhiteSpace(property.OnChanged);
        var name = isCustom
            ? property.OnChanged
            : $"On{property.Name}Changed";

        var (isChanged0, isChanged1, isChanged2, isChanged3) = CheckMethods(name, @class, property);
        isChanged2 |= !isCustom && !property.IsAttached && property.BindEvents.Any();
        isChanged3 |= !isCustom && property.IsAttached && property.BindEvents.Any();

        return (name, isChanged0, isChanged1, isChanged2, isChanged3);
    }

    private static string GenerateAvaloniaStaticConstructorPropertyChanged(
        ClassData @class,
        DependencyPropertyData property)
    {
        var (name, isChanged0, isChanged1, isChanged2, isChanged3) = CheckOnChangedMethods(@class, property);
        if (!isChanged0 &&
            !isChanged1 &&
            !isChanged2 &&
            !isChanged3)
        {
            return string.Empty;
        }

        return property.IsAttached
            ? @$"
            {property.Name}Property.Changed.Subscribe(static x =>
            {{
                {(isChanged0 ? @$"{name}();" : "")}
                {(isChanged1 ? @$"{name}(
                    ({GenerateBrowsableForType(property)})x.Sender);" : "")}
                {(isChanged2 ? @$"{name}(
                    ({GenerateBrowsableForType(property)})x.Sender,
                    ({GenerateType(property)})x.NewValue.GetValueOrDefault());" : "")}
                {(isChanged3 ? @$"{name}(
                    ({GenerateBrowsableForType(property)})x.Sender,
                    ({GenerateType(property)})x.OldValue.GetValueOrDefault(),
                    ({GenerateType(property)})x.NewValue.GetValueOrDefault());" : "")}
            }});
".RemoveBlankLinesWhereOnlyWhitespaces()
            : @$"
            {property.Name}Property.Changed.Subscribe(static x =>
            {{
                {(isChanged0 ? @$"(({GenerateType(@class.FullName, false)})x.Sender).{name}();" : "")}
                {(isChanged1 ? @$"(({GenerateType(@class.FullName, false)})x.Sender).{name}(
                    ({GenerateType(property)})x.NewValue.GetValueOrDefault());" : "")}
                {(isChanged2 ? @$"(({GenerateType(@class.FullName, false)})x.Sender).{name}(
                    ({GenerateType(property)})x.OldValue.GetValueOrDefault(),
                    ({GenerateType(property)})x.NewValue.GetValueOrDefault());" : "")}
            }});
".RemoveBlankLinesWhereOnlyWhitespaces();
    }

    public static string GenerateStaticConstructor(
        ClassData @class,
        IReadOnlyCollection<DependencyPropertyData> properties)
    {
        if (@class.Framework == Framework.Avalonia)
        {
            var generatedProperties = properties
                .Where(static property => !property.IsAttached)
                .Select(property => GenerateAvaloniaStaticConstructorPropertyChanged(@class, property))
                .Inject();
            var generatedAttachedProperties = properties
                .Where(static property => property.IsAttached)
                .Select(property => GenerateAvaloniaStaticConstructorPropertyChanged(@class, property))
                .Inject();
            if (string.IsNullOrWhiteSpace(generatedProperties) &&
                string.IsNullOrWhiteSpace(generatedAttachedProperties))
            {
                return string.Empty;
            }

            return @$"
using System;

#nullable enable

namespace {@class.Namespace}
{{
    public{GenerateModifiers(@class)} partial class {@class.Name}
    {{
        static {@class.Name}()
        {{
{generatedProperties}
{generatedAttachedProperties}
        }}
    }}
}}".RemoveBlankLinesWhereOnlyWhitespaces();
        }

        if (@class.Framework == Framework.Wpf)
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
{GenerateXmlDocumentationFrom(property.XmlDocumentation, property, isProperty: false)}
        {GeneratePropertyModifier(property)} static readonly {GeneratePropertyType(@class, property)} {GenerateDependencyPropertyName(property)} =
            {GenerateManagerType(@class)}.{GenerateRegisterMethod(@class, property)}(
                {GenerateRegisterAttachedMethodArguments(@class, property)});

{GenerateAdditionalPropertyForReadOnlyProperties(property)}
{GenerateXmlDocumentationFrom(property.SetterXmlDocumentation, property, isProperty: true)}
{GenerateCategoryAttribute(property.Category)}
{GenerateDescriptionAttribute(property.Description)}
{GenerateTypeConverterAttribute(property.TypeConverter)}
{GenerateBindableAttribute(property.Bindable)}
{GenerateBrowsableAttribute(property.Browsable)}
{GenerateDesignerSerializationVisibilityAttribute(property.DesignerSerializationVisibility)}
{GenerateClsCompliantAttribute(property.ClsCompliant)}
{GenerateLocalizabilityAttribute(property.Localizability, @class.Framework)}
        {(property.IsReadOnly ? "internal" : "public")} static void Set{property.Name}({GenerateDependencyObjectType(@class.Framework)} element, {GenerateType(property)} value)
        {{
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue({GenerateDependencyPropertyName(property)}, value);
        }}

{GenerateXmlDocumentationFrom(property.GetterXmlDocumentation, property, isProperty: true)}
{GenerateCategoryAttribute(property.Category)}
{GenerateDescriptionAttribute(property.Description)}
{GenerateTypeConverterAttribute(property.TypeConverter)}
{GenerateBindableAttribute(property.Bindable)}
{GenerateBrowsableAttribute(property.Browsable)}
{GenerateDesignerSerializationVisibilityAttribute(property.DesignerSerializationVisibility)}
{GenerateBrowsableForTypeAttribute(property)}
{GenerateClsCompliantAttribute(property.ClsCompliant)}
{GenerateLocalizabilityAttribute(property.Localizability, @class.Framework)}
        public static {GenerateType(property)} Get{property.Name}({GenerateDependencyObjectType(@class.Framework)} element)
        {{
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return ({GenerateType(property)})element.GetValue({property.Name}Property);
        }}

{GenerateOnChangedMethods(property)}
{GenerateOnChangingMethods(property)}
{GenerateCoercePartialMethod(property)}
{GenerateValidatePartialMethod(property)}
{GenerateCreateDefaultValueCallbackPartialMethod(property)}
{GenerateBindEventMethod(property)}
    }}
}}".RemoveBlankLinesWhereOnlyWhitespaces();
    }
    
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

    private static string GenerateBaseType(ClassData @class)
    {
        if (@class.Framework == Framework.Avalonia)
        {
            return $" : {GenerateTypeByPlatform(@class.Framework, "AvaloniaObject")}";
        }

        return string.Empty;
    }

    private static string GenerateModifiers(ClassData @class)
    {
        if (@class.Framework == Framework.Avalonia)
        {
            return string.Empty;
        }

        return @class.Modifiers;
    }

    private static bool IsMethodExists(ClassData @class, string signature)
    {
        return @class.Methods.Contains($"{@class.FullName}.{signature}");
    }

    private static string GeneratePropertyChangedCallback(ClassData @class, DependencyPropertyData property)
    {
        var (name, isChanged0, isChanged1, isChanged2, isChanged3) = CheckOnChangedMethods(@class, property);
        if (!isChanged0 &&
            !isChanged1 &&
            !isChanged2 &&
            !isChanged3)
        {
            return "null";
        }

        var senderType = property.IsAttached
            ? GenerateBrowsableForType(property)
            : GenerateType(@class.FullName, false);
        if (property.Framework == Framework.Maui)
        {
            return property.IsAttached
                ? $@"static (sender, oldValue, newValue) =>
            {{
                {(isChanged0 ? @$"{name}();" : "")}
                {(isChanged1 ? @$"{name}(
                    ({senderType})sender);" : "")}
                {(isChanged2 ? @$"{name}(
                    ({senderType})sender,
                    ({GenerateType(property)})newValue);" : "")}
                {(isChanged3 ? @$"{name}(
                    ({senderType})sender,
                    ({GenerateType(property)})oldValue,
                    ({GenerateType(property)})newValue);" : "")}
            }}"
                : $@"static (sender, oldValue, newValue) =>
            {{
                {(isChanged0 ? @$"(({senderType})sender).{name}();" : "")}
                {(isChanged1 ? @$"(({senderType})sender).{name}(
                    ({GenerateType(property)})newValue);" : "")}
                {(isChanged2 ? @$"(({senderType})sender).{name}(
                    ({GenerateType(property)})oldValue,
                    ({GenerateType(property)})newValue);" : "")}
            }}";
        }

        return property.IsAttached
            ? $@"static (sender, args) =>
                    {{
                        {(isChanged0 ? @$"{name}();" : "")}
                        {(isChanged1 ? @$"{name}(
                            ({senderType})sender);" : "")}
                        {(isChanged2 ? @$"{name}(
                            ({senderType})sender,
                            ({GenerateType(property)})args.NewValue);" : "")}
                        {(isChanged3 ? @$"{name}(
                            ({senderType})sender,
                            ({GenerateType(property)})args.OldValue,
                            ({GenerateType(property)})args.NewValue);" : "")}
                    }}"
            : $@"static (sender, args) =>
                    {{
                        {(isChanged0 ? @$"(({senderType})sender).{name}();" : "")}
                        {(isChanged1 ? @$"(({senderType})sender).{name}(
                            ({GenerateType(property)})args.NewValue);" : "")}
                        {(isChanged2 ? @$"(({senderType})sender).{name}(
                            ({GenerateType(property)})args.OldValue,
                            ({GenerateType(property)})args.NewValue);" : "")}
                    }}";
    }

    private static string GeneratePropertyChangingCallback(ClassData @class, DependencyPropertyData property)
    {
        var (isChanging0, isChanging1, isChanging2, isChanging3) = CheckMethods($"On{property.Name}Changing", @class, property);
        if (!isChanging0 &&
            !isChanging1 &&
            !isChanging2 &&
            !isChanging3)
        {
            return "null";
        }

        var senderType = property.IsAttached
            ? GenerateBrowsableForType(property)
            : GenerateType(@class.FullName, false);
        if (property.Framework == Framework.Maui)
        {
            return property.IsAttached
                ? $@"static (sender, oldValue, newValue) =>
            {{
                {(isChanging0 ? @$"On{property.Name}Changing();" : "")}
                {(isChanging1 ? @$"On{property.Name}Changing(
                    ({senderType})sender);" : "")}
                {(isChanging2 ? @$"On{property.Name}Changing(
                    ({senderType})sender,
                    ({GenerateType(property)})newValue);" : "")}
                {(isChanging3 ? @$"On{property.Name}Changing(
                    ({senderType})sender,
                    ({GenerateType(property)})oldValue,
                    ({GenerateType(property)})newValue);" : "")}
            }}"
                : $@"static (sender, oldValue, newValue) =>
            {{
                {(isChanging0 ? @$"(({senderType})sender).On{property.Name}Changing();" : "")}
                {(isChanging1 ? @$"(({senderType})sender).On{property.Name}Changing(
                    ({GenerateType(property)})newValue);" : "")}
                {(isChanging2 ? @$"(({senderType})sender).On{property.Name}Changing(
                    ({GenerateType(property)})oldValue,
                    ({GenerateType(property)})newValue);" : "")}
            }}";
        }

        return property.IsAttached
            ? $@"static (sender, args) =>
                    {{
                        {(isChanging0 ? @$"On{property.Name}Changing();" : "")}
                        {(isChanging1 ? @$"On{property.Name}Changing(
                            ({senderType})sender);" : "")}
                        {(isChanging2 ? @$"On{property.Name}Changing(
                            ({senderType})sender,
                            ({GenerateType(property)})args.NewValue);" : "")}
                        {(isChanging3 ? @$"On{property.Name}Changing(
                            ({senderType})sender,
                            ({GenerateType(property)})args.OldValue,
                            ({GenerateType(property)})args.NewValue);" : "")}
                    }}"
            : $@"static (sender, args) =>
                    {{
                        {(isChanging0 ? @$"(({senderType})sender).On{property.Name}Changing();" : "")}
                        {(isChanging1 ? @$"(({senderType})sender).On{property.Name}Changing(
                            ({GenerateType(property)})args.NewValue);" : "")}
                        {(isChanging2 ? @$"(({senderType})sender).On{property.Name}Changing(
                            ({GenerateType(property)})args.OldValue,
                            ({GenerateType(property)})args.NewValue);" : "")}
                    }}";
    }

    private static string GenerateCoerceValueCallback(ClassData @class, DependencyPropertyData property)
    {
        if (!property.Coerce)
        {
            return "null";
        }

        var senderType = property.IsAttached
            ? GenerateBrowsableForType(property)
            : GenerateType(@class.FullName, false);

        if (property.Framework == Framework.Maui)
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

    private static string GenerateValidateValueCallback(DependencyPropertyData property)
    {
        if (!property.Validate)
        {
            return "null";
        }

        if (property.Framework == Framework.Maui)
        {
            return $@"static (_, value) =>
                    Is{property.Name}Valid(
                        ({GenerateType(property)})value)";
        }

        return $@"static value =>
                    Is{property.Name}Valid(
                        ({GenerateType(property)})value)";
    }

    private static string GenerateCreateDefaultValueCallbackValueCallback(DependencyPropertyData property)
    {
        if (!property.CreateDefaultValueCallback)
        {
            return "null";
        }

        if (property.Framework == Framework.Maui)
        {
            return $@"static _ => Get{property.Name}DefaultValue()";
        }

        return $@"static () => Get{property.Name}DefaultValue()";
    }

    private static string GeneratePropertyMetadata(ClassData @class, DependencyPropertyData property)
    {
        if (property is { IsAddOwner: true, DefaultValue: null })
        {
            return "null";
        }

        var parameterName = (@class.Framework, property.IsAttached) switch
        {
            (Framework.Wpf, true) or (Framework.Uwp, true) or (Framework.WinUi, true) => "defaultMetadata",
            _ => "typeMetadata",
        };
        switch (@class.Framework)
        {
            case Framework.Wpf:
                if (property.DefaultUpdateSourceTrigger == null)
                {
                    return $@"{parameterName}: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: {GenerateDefaultValue(property)},
                    flags: {GenerateOptions(property)},
                    propertyChangedCallback: {GeneratePropertyChangedCallback(@class, property)},
                    coerceValueCallback: {GenerateCoerceValueCallback(@class, property)},
                    isAnimationProhibited: {property.IsAnimationProhibited.ToString().ToLower(CultureInfo.InvariantCulture)})";
                }

                return $@"{parameterName}: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: {GenerateDefaultValue(property)},
                    flags: {GenerateOptions(property)},
                    propertyChangedCallback: {GeneratePropertyChangedCallback(@class, property)},
                    coerceValueCallback: {GenerateCoerceValueCallback(@class, property)},
                    isAnimationProhibited: {property.IsAnimationProhibited.ToString().ToLower(CultureInfo.InvariantCulture)},
                    defaultUpdateSourceTrigger: global::System.Windows.Data.UpdateSourceTrigger.{property.DefaultUpdateSourceTrigger})";

            case Framework.Uwp:
            case Framework.WinUi:
            case Framework.Uno:
            case Framework.UnoWinUi:
                var type = GenerateTypeByPlatform(@class.Framework, "PropertyMetadata");
                if (property.CreateDefaultValueCallback)
                {
                    return $@"{parameterName}: {type}.Create(
                    createDefaultValueCallback: {GenerateCreateDefaultValueCallbackValueCallback(property)},
                    propertyChangedCallback: {GeneratePropertyChangedCallback(@class, property)})";
                }

                // fix for NotImplementedException: The member PropertyMetadata PropertyMetadata.Create(object defaultValue, PropertyChangedCallback propertyChangedCallback) is not implemented in Uno.
                var create = property.Framework switch
                {
                    Framework.Uno or Framework.UnoWinUi => $"new {type}",
                    _ => $"{type}.Create",
                };
                return $@"{parameterName}: {create}(
                    defaultValue: {GenerateDefaultValue(property)},
                    propertyChangedCallback: {GeneratePropertyChangedCallback(@class, property)})";
        }

        throw new InvalidOperationException("Platform is not supported.");
    }

    private static string GenerateTypeByPlatform(Framework framework, string name)
    {
        return (framework switch
        {
            Framework.Wpf => $"System.Windows.{name}",
            Framework.Uwp or Framework.Uno => $"Windows.UI.Xaml.{name}",
            Framework.WinUi or Framework.UnoWinUi => $"Microsoft.UI.Xaml.{name}",
            Framework.Avalonia => $"Avalonia.{name}",
            Framework.Maui => $"Microsoft.Maui.Controls.{name}",
            _ => throw new InvalidOperationException("Platform is not supported."),
        }).WithGlobalPrefix();
    }

    private static string GenerateType(string fullTypeName, bool isSpecialType)
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

    private static string GenerateType(DependencyPropertyData property)
    {
        var value = GenerateType(property.Type, property.IsSpecialType);
        if (!property.IsValueType)
        {
            value += "?";
        }

        return value;
    }

    private static string GenerateType(EventData @event, bool nullable = true)
    {
        var value = GenerateType(@event.Type, @event.IsSpecialType);
        if (nullable && !@event.IsValueType)
        {
            value += "?";
        }

        return value;
    }

    private static string GenerateRoutedEventType(ClassData @class)
    {
        if (@class.Framework == Framework.Avalonia)
        {
            return $"{GenerateTypeByPlatform(@class.Framework, "Interactivity.RoutedEvent")}<{GenerateRoutedEventArgsType(@class)}>";
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

    private static string GenerateEventArgsType(EventData @event)
    {
        if (string.IsNullOrWhiteSpace(@event.Type))
        {
            return "global::System.EventArgs";
        }
        
        return GenerateType(@event);
    }

    private static string GenerateEventManagerType(ClassData @class)
    {
        if (@class.Framework == Framework.Avalonia)
        {
            return GenerateTypeByPlatform(@class.Framework, "Interactivity.RoutedEvent");
        }

        return GenerateTypeByPlatform(@class.Framework, "EventManager");
    }

    private static string GenerateRoutingStrategyType(ClassData @class)
    {
        if (@class.Framework == Framework.Avalonia)
        {
            return GenerateTypeByPlatform(@class.Framework, $"Interactivity.RoutingStrategies");
        }

        return GenerateTypeByPlatform(@class.Framework, "RoutingStrategy");
    }

    private static string GeneratePropertyType(ClassData @class, DependencyPropertyData property)
    {
        if (property.Framework == Framework.Maui)
        {
            return GenerateTypeByPlatform(
                property.Framework,
                property.IsReadOnly
                    ? "BindablePropertyKey"
                    : "BindableProperty");
        }
        if (property.Framework == Framework.Avalonia)
        {
            return property.IsDirect
                ? GenerateTypeByPlatform(
                    property.Framework,
                    $"DirectProperty<{GenerateType(@class.FullName, false)}, {GenerateType(property)}>")
                : property.IsAttached
                    ? GenerateTypeByPlatform(
                        property.Framework,
                        $"AttachedProperty<{GenerateType(property)}>")
                    : GenerateTypeByPlatform(
                        property.Framework,
                        $"StyledProperty<{GenerateType(property)}>");
        }
        if (property is { IsReadOnly: true, Framework: Framework.Wpf })
        {
            return GenerateTypeByPlatform(property.Framework, "DependencyPropertyKey");
        }

        return GenerateTypeByPlatform(property.Framework, "DependencyProperty");
    }

    private static string GenerateManagerType(ClassData @class)
    {
        if (@class.Framework == Framework.Maui)
        {
            return GenerateTypeByPlatform(
                @class.Framework,
                "BindableProperty");
        }
        if (@class.Framework == Framework.Avalonia)
        {
            return GenerateTypeByPlatform(
                @class.Framework,
                "AvaloniaProperty");
        }

        return GenerateTypeByPlatform(@class.Framework, "DependencyProperty");
    }

    private static string GenerateRegisterMethod(ClassData @class)
    {
        if (@class.Framework == Framework.Avalonia)
        {
            return $"Register<{GenerateType(@class.FullName, false)}, {GenerateRoutedEventArgsType(@class)}>";
        }

        return "RegisterRoutedEvent";
    }

    private static string GenerateRegisterMethod(ClassData @class, DependencyPropertyData property)
    {
        if (property.Framework == Framework.Maui)
        {
            return property.IsAttached
                ? property.IsReadOnly
                    ? "CreateAttachedReadOnly"
                    : "CreateAttached"
                : property.IsReadOnly
                    ? "CreateReadOnly"
                    : "Create";
        }
        if (property.Framework == Framework.Avalonia)
        {
            return property.IsDirect
                ? $"RegisterDirect<{GenerateType(@class.FullName, false)}, {GenerateType(property)}>"
                : property.IsAttached
                    ? $"RegisterAttached<{GenerateType(@class.FullName, false)}, {GenerateBrowsableForType(property)}, {GenerateType(property)}>"
                    : $"Register<{GenerateType(@class.FullName, false)}, {GenerateType(property)}>";
        }
        if (property is { IsReadOnly: true, Framework: Framework.Wpf })
        {
            return property.IsAttached
                ? "RegisterAttachedReadOnly"
                : "RegisterReadOnly";
        }

        return property.IsAttached
            ? "RegisterAttached"
            : "Register";
    }

    private static string GenerateMauiRegisterMethodArguments(ClassData @class, DependencyPropertyData property)
    {
        var defaultBindingMode = property.DefaultBindingMode is null or "Default"
            ? property.IsReadOnly
                ? "OneWayToSource"
                : "OneWay"
            : property.DefaultBindingMode;

        return @$"
            propertyName: ""{property.Name}"",
            returnType: typeof({GenerateType(property.Type, property.IsSpecialType)}),
            declaringType: typeof({GenerateType(@class.FullName, false)}),
            defaultValue: {GenerateDefaultValue(property)},
            defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.{defaultBindingMode},
            validateValue: {GenerateValidateValueCallback(property)},
            propertyChanged: {GeneratePropertyChangedCallback(@class, property)},
            propertyChanging: {GeneratePropertyChangingCallback(@class, property)},
            coerceValue: {GenerateCoerceValueCallback(@class, property)},
            defaultValueCreator: {GenerateCreateDefaultValueCallbackValueCallback(property)}";
    }

    // https://docs.avaloniaui.net/docs/authoring-controls/defining-properties
    private static string GenerateAvaloniaRegisterMethodArguments(ClassData @class, DependencyPropertyData property)
    {
        var defaultBindingMode = property.DefaultBindingMode is null or "Default"
            ? "OneWay"
            : property.DefaultBindingMode;

        if (property is { IsDirect: true, IsAddOwner: true })
        {
            return $@"
                getter: static sender => sender.{property.Name},
                setter: {(property.IsReadOnly ? "null" : $"static (sender, value) => sender.{property.Name} = value")},
                unsetValue: {GenerateDefaultValue(property)},
                defaultBindingMode: global::Avalonia.Data.BindingMode.{defaultBindingMode},
                enableDataValidation: {(property.EnableDataValidation ? "true" : "false")}";
        }

        if (property.IsDirect)
        {
            return $@"
                name: ""{property.Name}"",
                getter: static sender => sender.{property.Name},
                setter: {(property.IsReadOnly ? "null" : $"static (sender, value) => sender.{property.Name} = value")},
                unsetValue: {GenerateDefaultValue(property)},
                defaultBindingMode: global::Avalonia.Data.BindingMode.{defaultBindingMode},
                enableDataValidation: {(property.EnableDataValidation ? "true" : "false")}";
        }

        if (property.IsAttached)
        {
            return $@"
                name: ""{property.Name}"",
                defaultValue: {GenerateDefaultValue(property)},
                inherits: {(property.Inherits ? "true" : "false")},
                defaultBindingMode: global::Avalonia.Data.BindingMode.{defaultBindingMode},
                validate: {GenerateValidateValueCallback(property)},
                coerce: {GenerateCoerceValueCallback(@class, property)}";
        }

        return @$"
                name: ""{property.Name}"",
                defaultValue: {GenerateDefaultValue(property)},
                inherits: {(property.Inherits ? "true" : "false")},
                defaultBindingMode: global::Avalonia.Data.BindingMode.{defaultBindingMode},
                validate: {GenerateValidateValueCallback(property)},
                coerce: {GenerateCoerceValueCallback(@class, property)}";
    }

    private static string GenerateRegisterMethodArguments(ClassData @class, DependencyPropertyData property)
    {
        if (@class.Framework == Framework.Avalonia)
        {
            return GenerateAvaloniaRegisterMethodArguments(@class, property);
        }
        if (@class.Framework == Framework.Maui)
        {
            return GenerateMauiRegisterMethodArguments(@class, property);
        }
        if (@class.Framework == Framework.Wpf)
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

    private static string GenerateRegisterAttachedMethodArguments(ClassData @class, DependencyPropertyData property)
    {
        if (@class.Framework == Framework.Maui)
        {
            return GenerateMauiRegisterMethodArguments(@class, property);
        }
        if (@class.Framework == Framework.Avalonia)
        {
            return GenerateAvaloniaRegisterMethodArguments(@class, property);
        }
        if (@class.Framework == Framework.Wpf)
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
                ownerType: typeof({GenerateType(@class.FullName, false)})";
    }

    private static string GenerateDependencyPropertyName(DependencyPropertyData property)
    {
        if (property is { IsReadOnly: true, Framework: Framework.Wpf or Framework.Maui })
        {
            return $"{property.Name}PropertyKey";
        }

        return $"{property.Name}Property";
    }

    private static string GenerateDependencyObjectType(Framework framework)
    {
        if (framework == Framework.Maui)
        {
            return GenerateTypeByPlatform(framework, "BindableObject");
        }
        if (framework == Framework.Avalonia)
        {
            return GenerateTypeByPlatform(framework, "IAvaloniaObject");
        }

        return GenerateTypeByPlatform(framework, "DependencyObject");
    }
    
    private static string GenerateDefaultValue(DependencyPropertyData property)
    {
        var type = GenerateType(property.Type, property.IsSpecialType);
        if (property is { IsSpecialType: true, DefaultValueDocumentation: { } })
        {
            return $"({type}){property.DefaultValueDocumentation}";
        }
        
        return property.DefaultValue != null 
            ? $"({type}){property.DefaultValue}"
            : $"default({type})";
    }

    private static string? GenerateFromType(DependencyPropertyData property)
    {
        return property.FromType?.WithGlobalPrefix();
    }

    private static string GenerateBrowsableForType(DependencyPropertyData property)
    {
        return property.BrowsableForType?.WithGlobalPrefix() ?? GenerateDependencyObjectType(property.Framework);
    }

    private static string GenerateBrowsableForTypeParameterName(DependencyPropertyData property)
    {
        return (property.BrowsableForType ?? GenerateDependencyObjectType(property.Framework))
            .ExtractSimpleName()
            .ToParameterName();
    }

    private static string GenerateRouterEventType(ClassData @class, EventData @event)
    {
        if (string.IsNullOrWhiteSpace(@event.Type))
        {
            return GenerateRoutedEventHandlerType(@class);
        }
        
        return @event.Type.WithGlobalPrefix();
    }

    private static string GenerateXmlDocumentationFrom(string value)
    {
        var lines = value.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        
        return string.Join(Environment.NewLine, lines.Select(static line => $"        /// {line}"));
    }

    private static string GenerateXmlDocumentationFrom(
        string? value,
        DependencyPropertyData property,
        bool isProperty)
    {
        var name = property.IsAttached
            ? property.Name
            : $"<see cref=\"{property.Name}\"/>";
        var body = isProperty
            ? property.Description != null ? $"{property.Description}<br/>" : " "
            : $"Identifies the {name} dependency property.<br/>";
        value ??= @$"<summary>
{body}
Default value: {property.DefaultValueDocumentation?.ExtractSimpleName() ?? $"default({WebUtility.HtmlEncode(property.Type.ExtractSimpleName())})"}
</summary>".RemoveBlankLinesWhereOnlyWhitespaces();

        return GenerateXmlDocumentationFrom(value);
    }

    private static string GenerateXmlDocumentationFrom(string? value, EventData @event)
    {
        value ??= @$"<summary>
{(@event.Description != null ? $"{@event.Description}" : " ")}
</summary>".RemoveBlankLinesWhereOnlyWhitespaces();

        return GenerateXmlDocumentationFrom(value);
    }

    private static string GenerateOnChangedMethods(DependencyPropertyData property)
    {
        if (!string.IsNullOrWhiteSpace(property.OnChanged))
        {
            return " ";
        }

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

    private static string GenerateOnChangingMethods(DependencyPropertyData property)
    {
        if (property.Framework != Framework.Maui)
        {
            return " ";
        }

        return property.IsAttached
            ? $@" 
        static partial void On{property.Name}Changing();
        static partial void On{property.Name}Changing({GenerateBrowsableForType(property)} {GenerateBrowsableForTypeParameterName(property)});
        static partial void On{property.Name}Changing({GenerateBrowsableForType(property)} {GenerateBrowsableForTypeParameterName(property)}, {GenerateType(property)} newValue);
        static partial void On{property.Name}Changing({GenerateBrowsableForType(property)} {GenerateBrowsableForTypeParameterName(property)}, {GenerateType(property)} oldValue, {GenerateType(property)} newValue);"
            : $@" 
        partial void On{property.Name}Changing();
        partial void On{property.Name}Changing({GenerateType(property)} newValue);
        partial void On{property.Name}Changing({GenerateType(property)} oldValue, {GenerateType(property)} newValue);";
    }

    private static string GenerateCoercePartialMethod(DependencyPropertyData property)
    {
        if (!property.Coerce)
        {
            return " ";
        }

        return property.IsAttached
            ? $"        private static partial {GenerateType(property)} Coerce{property.Name}({GenerateBrowsableForType(property)} {GenerateBrowsableForTypeParameterName(property)}, {GenerateType(property)} value);"
            : $"        private partial {GenerateType(property)} Coerce{property.Name}({GenerateType(property)} value);";
    }

    private static string GenerateAdditionalFieldForDirectProperties(DependencyPropertyData property)
    {
        if (!property.IsDirect)
        {
            return " ";
        }

        return property.Framework switch
        {
            Framework.Avalonia => $@" 
        private {GenerateType(property)} _{property.Name.ToParameterName()} = {GenerateDefaultValue(property)};
",
            _ => " ",
        };
    }

    private static string GenerateAdditionalPropertyForReadOnlyProperties(DependencyPropertyData property)
    {
        if (!property.IsReadOnly)
        {
            return " ";
        }
        
        return property.Framework switch
        {
            Framework.Maui => $@" 
{GenerateXmlDocumentationFrom(property.XmlDocumentation, property, isProperty: false)}
        public static readonly {GenerateTypeByPlatform(property.Framework, "BindableProperty")} {property.Name}Property
            = {GenerateDependencyPropertyName(property)}.BindableProperty;
",
            // https://docs.microsoft.com/en-us/dotnet/api/system.windows.dependencypropertykey?view=windowsdesktop-6.0#examples
            Framework.Wpf => $@" 
{GenerateXmlDocumentationFrom(property.XmlDocumentation, property, isProperty: false)}
        public static readonly {GenerateTypeByPlatform(property.Framework, "DependencyProperty")} {property.Name}Property
            = {GenerateDependencyPropertyName(property)}.DependencyProperty;
",
            _ => " ",
        };
    }

    private static string GenerateAdditionalSetterModifier(DependencyPropertyData property)
    {
        return property is { IsDirect: true, Framework: Framework.Avalonia }
            ? "private "
            : property.IsReadOnly
                ? "protected "
                : string.Empty;
    }

    private static string GeneratePropertyModifier(DependencyPropertyData property)
    {
        if (property is { IsReadOnly: true, Framework: Framework.Wpf })
        {
            return "internal";
        }

        return "public";
    }

    private static string GenerateValidatePartialMethod(DependencyPropertyData property)
    {
        if (!property.Validate)
        {
            return " ";
        }

        return $"        private static partial bool Is{property.Name}Valid({GenerateType(property)} value);";
    }

    private static string GenerateCreateDefaultValueCallbackPartialMethod(DependencyPropertyData property)
    {
        if (!property.CreateDefaultValueCallback)
        {
            return " ";
        }

        return $"        private static partial {GenerateType(property)} Get{property.Name}DefaultValue();";
    }

    private static string GenerateOnChangedMethodDeclaration(string name, DependencyPropertyData property)
    {
        var modifiers = property.IsAttached ? "static " : string.Empty;

        return $@" 
        {modifiers}partial void {name}(
{(property.IsAttached ? @$" 
            {GenerateBrowsableForType(property)} {GenerateBrowsableForTypeParameterName(property)}," : " ")}
            {GenerateType(property)} oldValue,
            {GenerateType(property)} newValue)".RemoveBlankLinesWhereOnlyWhitespaces();
    }

    private static string GenerateOnChangedMethodCall(string name, DependencyPropertyData property)
    {
        return $@" 
            {name}(
{(property.IsAttached ? @$" 
                {GenerateBrowsableForTypeParameterName(property)}," : " ")}
                oldValue,
                newValue);".RemoveBlankLinesWhereOnlyWhitespaces();
    }

    private static string GenerateBindEventMethod(DependencyPropertyData property)
    {
        if (!property.BindEvents.Any())
        {
            return " ";
        }

        var type = GenerateType(property.Type, property.IsSpecialType);
        var sender = property.IsAttached ? GenerateBrowsableForTypeParameterName(property) : "this";

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

    private static string GenerateAttribute(string name, string? value)
    {
        if (value == null)
        {
            return " ";
        }

        return $"        [global::{name}({value})]";
    }

    private static string GenerateComponentModelAttribute(string name, string? value)
    {
        return GenerateAttribute($"System.ComponentModel.{name}", value);
    }

    private static string GenerateCategoryAttribute(string? value)
    {
        if (value == null)
        {
            return " ";
        }

        return GenerateComponentModelAttribute(
            nameof(DependencyPropertyData.Category),
            $"\"{value}\"");
    }

    private static string GenerateDescriptionAttribute(string? value)
    {
        if (value == null)
        {
            return " ";
        }

        var isMultilineString =
            value.Contains('\r') ||
            value.Contains('\n');
        
        return GenerateComponentModelAttribute(
            nameof(DependencyPropertyData.Description),
            isMultilineString 
                    ? $"@\"{value}\""
                    : $"\"{value}\"");
    }

    private static string GenerateTypeConverterAttribute(string? value)
    {
        if (value == null)
        {
            return " ";
        }

        return GenerateComponentModelAttribute(
            nameof(DependencyPropertyData.TypeConverter),
            $"typeof({value.WithGlobalPrefix()})");
    }

    private static string ToBooleanKeyword(this bool value)
    {
        return value
            ? "true"
            : "false";
    }

    private static string GenerateBindableAttribute(bool? value)
    {
        return GenerateComponentModelAttribute(
            nameof(DependencyPropertyData.Bindable),
            value?.ToBooleanKeyword());
    }

    private static string GenerateBrowsableAttribute(bool? value)
    {
        return GenerateComponentModelAttribute(
            nameof(DependencyPropertyData.Browsable),
            value?.ToBooleanKeyword());
    }

    private static string GenerateDesignerSerializationVisibilityAttribute(string? value)
    {
        if (value == null)
        {
            return " ";
        }

        return GenerateComponentModelAttribute(
            nameof(DependencyPropertyData.DesignerSerializationVisibility),
            $"global::System.ComponentModel.{nameof(DesignerSerializationVisibility)}.{value}");
    }

    private static string GenerateClsCompliantAttribute(bool? value)
    {
        return GenerateAttribute("System.CLSCompliant", value?.ToBooleanKeyword());
    }

    private static string GenerateLocalizabilityAttribute(string? value, Framework framework)
    {
        if (value == null || framework != Framework.Wpf)
        {
            return " ";
        }

        return GenerateAttribute(
            "System.Windows.Localizability",
            $"global::System.Windows.LocalizationCategory.{value}");
    }
    
    private static string GenerateBrowsableForTypeAttribute(DependencyPropertyData property)
    {
        if (property.Framework != Framework.Wpf)
        {
            return " ";
        }

        return GenerateAttribute(
            "System.Windows.AttachedPropertyBrowsableForType",
            $"typeof({GenerateBrowsableForType(property)})");
    }

    private static string GenerateOptions(DependencyPropertyData property)
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
        if (property.DefaultBindingMode == "TwoWay")
        {
            values.Add("BindsTwoWayByDefault");
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