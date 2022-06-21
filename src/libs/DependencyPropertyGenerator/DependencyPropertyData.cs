namespace H.Generators;

public readonly record struct DependencyPropertyData(
    string Name,
    string Type,
    bool IsValueType,
    string? DefaultValue,
    string? Description,
    string? Category,
    string? BrowsableForType,
    string XmlDoc,
    string PropertySetterXmlDoc,
    string PropertyGetterXmlDoc,
    bool AffectsMeasure,
    bool AffectsArrange,
    bool AffectsParentMeasure,
    bool AffectsParentArrange,
    bool AffectsRender,
    bool Inherits,
    bool OverridesInheritanceBehavior,
    bool NotDataBindable,
    bool BindsTwoWayByDefault,
    bool Journal,
    bool SubPropertiesDoNotAffectRender);
