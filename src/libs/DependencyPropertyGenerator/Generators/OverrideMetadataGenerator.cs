using System.Collections.Immutable;
using H.Generators.Extensions;
using Microsoft.CodeAnalysis;

namespace H.Generators;

[Generator]
public class OverrideMetadataGenerator : IIncrementalGenerator
{
    #region Constants

    private const string Id = "OMG";

    #endregion

    #region Methods

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(static context =>
        {
            context.AddSource(
                hintName: "OverrideMetadataAttribute.g.cs",
                source: Resources.OverrideMetadataAttribute_cs.AsString());
        });

        var framework = context.DetectFramework();
        var version = context.DetectVersion();

        context.SyntaxProvider
            .ForAttributeWithMetadataNameOfClassesAndRecords("DependencyPropertyGenerator.OverrideMetadataAttribute")
            .SelectAllAttributes()
            .Combine(framework)
            .Combine(version)
            .SelectAndReportExceptions(PrepareData, context, Id)
            .WhereNotNull()
            .SelectAndReportExceptions(GetSourceCode, context, Id)
            .AddSource(context);
        context.SyntaxProvider
            .ForAttributeWithMetadataNameOfClassesAndRecords("DependencyPropertyGenerator.OverrideMetadataAttribute`1")
            .SelectAllAttributes()
            .Combine(framework)
            .Combine(version)
            .SelectAndReportExceptions(PrepareData, context, Id)
            .WhereNotNull()
            .SelectAndReportExceptions(GetSourceCode, context, Id)
            .AddSource(context);
    }

    private static (ClassData Class, EquatableArray<DependencyPropertyData> OverrideMetada)? PrepareData(
        ((ClassWithAttributesContext context,
            Framework framework) left,
            string version) tuple)
    {
        var (((_, attributes, _, classSymbol), framework), version) = tuple;
        if (framework is not (Framework.Wpf or Framework.Uwp or Framework.WinUi or Framework.Uno or Framework.UnoWinUi))
        {
            return null;
        }

        var classData = classSymbol.GetClassData(framework, version);
        var overrideMetadata = attributes
            .Select(attribute => attribute.GetDependencyPropertyData(framework, version))
            .ToImmutableArray()
            .AsEquatableArray();

        return (classData, overrideMetadata);
    }

    private static FileWithName GetSourceCode(
        (ClassData Class, EquatableArray<DependencyPropertyData> OverrideMetada) data)
    {
        var name = data.Class.Framework is Framework.Wpf
            ? $"{data.Class.FullName}.StaticConstructor.g.cs"
            : $"{data.Class.FullName}.Methods.RegisterPropertyChangedCallbacks.g.cs";
        var text = data.Class.Framework is Framework.Wpf
            ? Sources.GenerateStaticConstructor(data.Class, data.OverrideMetada.AsImmutableArray())
            : Sources.GenerateRegisterPropertyChangedCallbacksMethod(data.Class,
                data.OverrideMetada.AsImmutableArray());

        return new FileWithName(
            Name: name,
            Text: text);
    }

    #endregion
}