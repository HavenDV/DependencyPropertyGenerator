﻿using H.Generators.Extensions;

namespace H.Generators;

public readonly record struct DependencyPropertyData(
    string Name,
    string Type,
    bool IsValueType,
    bool IsSpecialType,
    string? DefaultValue,
    string? DefaultValueDocumentation,
    bool IsReadOnly,
    bool IsDirect,
    bool IsAttached,
    bool IsAddOwner,
    Framework Framework,
    string? Description,
    string? Category,
    string? TypeConverter,
    bool? Bindable,
    bool? Browsable,
    string? DesignerSerializationVisibility,
    bool? ClsCompliant,
    string? Localizability,
    string? BrowsableForType,
    string? FromType,
    bool IsBrowsableForTypeSpecialType,
    string? XmlDocumentation,
    string? SetterXmlDocumentation,
    string? GetterXmlDocumentation,
    EquatableArray<string> BindEvents,
    string OnChanged,
    bool AffectsMeasure,
    bool AffectsArrange,
    bool AffectsParentMeasure,
    bool AffectsParentArrange,
    bool AffectsRender,
    bool Inherits,
    bool OverridesInheritanceBehavior,
    bool NotDataBindable,
    bool Journal,
    bool SubPropertiesDoNotAffectRender,
    bool IsAnimationProhibited,
    string? DefaultUpdateSourceTrigger,
    string? DefaultBindingMode,
    bool EnableDataValidation,
    bool Coerce,
    bool Validate,
    bool CreateDefaultValueCallback);