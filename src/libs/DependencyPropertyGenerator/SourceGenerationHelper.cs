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
        public static readonly {GenerateDependencyPropertyType(@class)} {property.Name}Property =
            {GenerateDependencyPropertyType(@class)}.Register(
                name: ""{property.Name}"",
                propertyType: typeof({GenerateType(property.Type, property.IsSpecialType)}),
                ownerType: typeof({GenerateType(@class.FullName, false)}),
                {GeneratePropertyMetadata(@class, property, false)});

{GenerateXmlDocumentationFrom(property.GetterXmlDocumentation, property)}
{GenerateCategoryAttribute(property.Category)}
{GenerateDescriptionAttribute(property.Description)}
{GenerateTypeConverterAttribute(property.TypeConverter)}
{GenerateBindableAttribute(property.Bindable)}
{GenerateDesignerSerializationVisibilityAttribute(property.DesignerSerializationVisibility)}
{GenerateCLSCompliantAttribute(property.CLSCompliant)}
{GenerateLocalizabilityAttribute(property.Localizability, @class.Platform)}
        public {GenerateType(property)} {property.Name}
        {{
            get => ({GenerateType(property)})GetValue({property.Name}Property);
            set => SetValue({property.Name}Property, value);
        }}

        partial void On{property.Name}Changed({GenerateType(property)} oldValue, {GenerateType(property)} newValue);
    }}
}}".RemoveBlankLinesWhereOnlyWhitespaces();
    }

    public static string GenerateStaticConstructor(ClassData @class, IReadOnlyCollection<DependencyPropertyData> properties)
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
                ({GenerateBrowsableForType(@class, property)})x.Sender,
                ({GenerateType(property)})x.OldValue.GetValueOrDefault(),
                ({GenerateType(property)})x.NewValue.GetValueOrDefault()));
").Inject()}
        }}
    }}
}}".RemoveBlankLinesWhereOnlyWhitespaces();
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
        public static readonly {GenerateAttachedPropertyType(@class, property)} {property.Name}Property =
            {GenerateManagerType(@class)}.{GenerateRegisterAttachedMethod(@class, property)}(
                {GenerateRegisterAttachedMethodArguments(@class, property)});

{GenerateXmlDocumentationFrom(property.SetterXmlDocumentation, property)}
{GenerateCategoryAttribute(property.Category)}
{GenerateDescriptionAttribute(property.Description)}
{GenerateTypeConverterAttribute(property.TypeConverter)}
{GenerateBindableAttribute(property.Bindable)}
{GenerateDesignerSerializationVisibilityAttribute(property.DesignerSerializationVisibility)}
{GenerateCLSCompliantAttribute(property.CLSCompliant)}
{GenerateLocalizabilityAttribute(property.Localizability, @class.Platform)}
        public static void Set{property.Name}({GenerateDependencyObjectType(@class)} element, {GenerateType(property)} value)
        {{
            element.SetValue({property.Name}Property, value);
        }}

{GenerateXmlDocumentationFrom(property.GetterXmlDocumentation, property)}
{GenerateCategoryAttribute(property.Category)}
{GenerateDescriptionAttribute(property.Description)}
{GenerateTypeConverterAttribute(property.TypeConverter)}
{GenerateBindableAttribute(property.Bindable)}
{GenerateDesignerSerializationVisibilityAttribute(property.DesignerSerializationVisibility)}
{GenerateBrowsableForTypeAttribute(@class, property)}
{GenerateCLSCompliantAttribute(property.CLSCompliant)}
{GenerateLocalizabilityAttribute(property.Localizability, @class.Platform)}
        public static {GenerateType(property)} Get{property.Name}({GenerateDependencyObjectType(@class)} element)
        {{
            return ({GenerateType(property)})element.GetValue({property.Name}Property);
        }}

        static partial void On{property.Name}Changed({GenerateBrowsableForType(@class, property)} sender, {GenerateType(property)} oldValue, {GenerateType(property)} newValue);
    }}
}}".RemoveBlankLinesWhereOnlyWhitespaces();
    }
    
    public static string GenerateRoutedEvent(ClassData @class, RoutedEventData @event)
    {
        return @$"
#nullable enable

namespace {@class.Namespace}
{{
    public{@class.Modifiers} partial class {@class.Name}
    {{
{GenerateXmlDocumentationFrom(@event.XmlDocumentation, @event)}
        public static readonly {GenerateRoutedEventType(@class)} {@event.Name}Event =
            {GenerateEventManagerType(@class)}.RegisterRoutedEvent(
                name: ""{@event.Name}"",
                routingStrategy: ({GenerateRoutingStrategyType(@class)}){@event.Strategy},
                handlerType: typeof({GenerateRouterEventType(@class, @event)}),
                ownerType: typeof({GenerateType(@class.FullName, false)}));

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
        protected {GenerateRoutedEventArgsType(@class)} Raise{@event.Name}Event()
        {{
            var args = new {GenerateRoutedEventArgsType(@class)}({@event.Name}Event);
            this.RaiseEvent(args);

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
            {GenerateEventManagerType(@class)}.RegisterRoutedEvent(
                name: ""{@event.Name}"",
                routingStrategy: ({GenerateRoutingStrategyType(@class)}){@event.Strategy},
                handlerType: typeof({GenerateRouterEventType(@class, @event)}),
                ownerType: typeof({GenerateType(@class.FullName, false)}));

{GenerateXmlDocumentationFrom(@event.EventXmlDocumentation, @event)}
{GenerateCategoryAttribute(@event.Category)}
{GenerateDescriptionAttribute(@event.Description)}
        public static void Add{@event.Name}Handler({GenerateDependencyObjectType(@class)} element, {GenerateRoutedEventHandlerType(@class)} handler)
        {{
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
        public static void Remove{@event.Name}Handler({GenerateDependencyObjectType(@class)} element, {GenerateRoutedEventHandlerType(@class)} handler)
        {{
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

    public static string GeneratePropertyChangedCallback(ClassData @class, DependencyPropertyData property, bool isAttached)
    {
        var senderType = isAttached
            ? GenerateBrowsableForType(@class, property)
            : GenerateType(@class.FullName, false);

        return isAttached
            ? $@"propertyChangedCallback: static (sender, args) =>
                        On{property.Name}Changed(
                            ({senderType})sender,
                            ({GenerateType(property)})args.OldValue,
                            ({GenerateType(property)})args.NewValue)"
            : $@"propertyChangedCallback: static (sender, args) =>
                        (({senderType})sender).On{property.Name}Changed(
                            ({GenerateType(property)})args.OldValue,
                            ({GenerateType(property)})args.NewValue)";
    }

    public static string GeneratePropertyMetadata(ClassData @class, DependencyPropertyData property, bool isAttached)
    {
        var parameterName = (@class.Platform, isAttached) switch
        {
            (Platform.WPF, true) or (Platform.UWP, true) or (Platform.WinUI, true) => "defaultMetadata",
            _ => "typeMetadata",
        };
        switch (@class.Platform)
        {
            case Platform.WPF:
                return $@"{parameterName}: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: {GenerateDefaultValue(property)},
                    flags: {GenerateOptions(property)},
                    {GeneratePropertyChangedCallback(@class, property, isAttached)})";

            case Platform.UWP:
            case Platform.WinUI:
            case Platform.Uno:
            case Platform.UnoWinUI:
                var type = GenerateTypeByPlatform(@class.Platform, "PropertyMetadata");
                return $@"{parameterName}: new {type}(
                    defaultValue: {GenerateDefaultValue(property)},
                    {GeneratePropertyChangedCallback(@class, property, isAttached)})";
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
        return GenerateTypeByPlatform(@class.Platform, "RoutedEvent");
    }

    public static string GenerateRoutedEventArgsType(ClassData @class)
    {
        return GenerateTypeByPlatform(@class.Platform, "RoutedEventArgs");
    }

    public static string GenerateRoutedEventHandlerType(ClassData @class)
    {
        return GenerateTypeByPlatform(@class.Platform, "RoutedEventHandler");
    }

    public static string GenerateEventManagerType(ClassData @class)
    {
        return GenerateTypeByPlatform(@class.Platform, "EventManager");
    }

    public static string GenerateRoutingStrategyType(ClassData @class)
    {
        return GenerateTypeByPlatform(@class.Platform, "RoutingStrategy");
    }

    public static string GenerateAttachedPropertyType(ClassData @class, DependencyPropertyData property)
    {
        if (@class.Platform == Platform.Avalonia)
        {
            return GenerateTypeByPlatform(
                @class.Platform,
                $"AttachedProperty<{GenerateType(property)}>");
        }
        
        return GenerateDependencyPropertyType(@class);
    }

    public static string GenerateManagerType(ClassData @class)
    {
        if (@class.Platform == Platform.Avalonia)
        {
            return GenerateTypeByPlatform(
                @class.Platform,
                $"AvaloniaProperty");
        }

        return GenerateDependencyPropertyType(@class);
    }

    public static string GenerateRegisterAttachedMethod(ClassData @class, DependencyPropertyData property)
    {
        if (@class.Platform == Platform.Avalonia)
        {
            return $"RegisterAttached<{GenerateType(@class.FullName, false)}, {GenerateBrowsableForType(@class, property)}, {GenerateType(property)}>";
        }

        return "RegisterAttached";
    }

    public static string GenerateRegisterAttachedMethodArguments(ClassData @class, DependencyPropertyData property)
    {
        if (@class.Platform == Platform.Avalonia)
        {
            return $@"
                name: ""{property.Name}"",
                defaultValue: {GenerateDefaultValue(property)}";
        }

        return @$"
                name: ""{property.Name}"",
                propertyType: typeof({GenerateType(property.Type, property.IsSpecialType)}),
                ownerType: typeof({GenerateType(@class.FullName, false)}),
                {GeneratePropertyMetadata(@class, property, true)}";
    }

    public static string GenerateDependencyPropertyType(ClassData @class)
    {
        return GenerateTypeByPlatform(@class.Platform, "DependencyProperty");
    }

    public static string GenerateDependencyObjectType(ClassData @class)
    {
        if (@class.Platform == Platform.Avalonia)
        {
            return GenerateTypeByPlatform(@class.Platform, "IAvaloniaObject");
        }

        return GenerateTypeByPlatform(@class.Platform, "DependencyObject");
    }

    public static string GenerateDefaultValue(DependencyPropertyData property)
    {
        if (property.IsSpecialType && property.DefaultValueDocumentation != null)
        {
            return property.DefaultValueDocumentation;
        }

        var type = GenerateType(property.Type, property.IsSpecialType);
        return property.DefaultValue != null 
            ? $"({type}){property.DefaultValue}"
            : $"default({type})";
    }

    public static string GenerateBrowsableForType(ClassData @class, DependencyPropertyData property)
    {
        return property.BrowsableForType?.WithGlobalPrefix() ?? GenerateDependencyObjectType(@class);
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
    
    public static string GenerateBrowsableForTypeAttribute(ClassData @class, DependencyPropertyData property)
    {
        if (@class.Platform != Platform.WPF)
        {
            return " ";
        }

        return GenerateAttribute(
            "System.Windows.AttachedPropertyBrowsableForType",
            $"typeof({GenerateBrowsableForType(@class, property)})");
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