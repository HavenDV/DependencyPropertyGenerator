﻿using H.Generators.Extensions;
using System.Net;

namespace H.Generators;

internal static partial class Sources
{
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

    private static string GenerateDependencyPropertyName(DependencyPropertyData property)
    {
        if (property is { IsReadOnly: true, Framework: Framework.Wpf or Framework.Maui })
        {
            return $"{property.Name}PropertyKey";
        }

        return $"{property.Name}Property";
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
    
    private static string GenerateEventArgsType(EventData @event)
    {
        if (string.IsNullOrWhiteSpace(@event.Type))
        {
            return "global::System.EventArgs";
        }

        return GenerateType(@event);
    }
}