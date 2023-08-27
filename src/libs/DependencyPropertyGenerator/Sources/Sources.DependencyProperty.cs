﻿using H.Generators.Extensions;
using System.Globalization;

namespace H.Generators;

internal static partial class Sources
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

        return
            @$"{GenerateAdditionalSetterModifier(property)}set => SetValue({GenerateDependencyPropertyName(property)}, value);";
    }
    
    private static string GenerateDependencyPropertyCreateCall(ClassData @class, DependencyPropertyData property)
    {
        if (property.IsAddOwner)
        {
            return GenerateAddOwnerCreateCall(@class, property);
        }

        return @$"
            {GenerateManagerType(@class)}.{GenerateRegisterMethod(@class, property)}(
                {GenerateRegisterMethodArguments(@class, property)});
 ".RemoveBlankLinesWhereOnlyWhitespaces();
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
}