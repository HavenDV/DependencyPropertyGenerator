namespace H.Generators;

public readonly record struct DependencyPropertyData(
    string Name,
    string Type,
    bool IsValueType,
    string? DefaultValue = null,
    string? BrowsableForType = null,
    string XmlDoc = "<summary></summary>",
    string PropertySetterXmlDoc = "<summary></summary>",
    string PropertyGetterXmlDoc = "<summary></summary>",
    bool AffectsMeasure = false,
    bool AffectsArrange = false,
    bool AffectsParentMeasure = false,
    bool AffectsParentArrange = false,
    bool AffectsRender = false,
    bool Inherits = false,
    bool OverridesInheritanceBehavior = false,
    bool NotDataBindable = false,
    bool BindsTwoWayByDefault = false,
    bool Journal = false,
    bool SubPropertiesDoNotAffectRender = false);
