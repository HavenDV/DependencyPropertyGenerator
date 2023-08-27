using System.Collections.Immutable;
using H.Generators.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
        var framework = context.DetectFramework();

        context.SyntaxProvider
            .ForAttributeWithMetadataName("DependencyPropertyGenerator.OverrideMetadataAttribute")
            .SelectAllAttributes()
            .Combine(framework)
            .SelectAndReportExceptions(PrepareData, context, Id)
            .WhereNotNull()
            .SelectAndReportExceptions(GetSourceCode, context, Id)
            .AddSource(context);
        context.SyntaxProvider
            .ForAttributeWithMetadataName("DependencyPropertyGenerator.OverrideMetadataAttribute`1")
            .SelectAllAttributes()
            .Combine(framework)
            .SelectAndReportExceptions(PrepareData, context, Id)
            .WhereNotNull()
            .SelectAndReportExceptions(GetSourceCode, context, Id)
            .AddSource(context);
    }

    private static (ClassData Class, EquatableArray<DependencyPropertyData> OverrideMetada)? PrepareData(
        Framework framework,
        (SemanticModel SemanticModel, ImmutableArray<AttributeData> Attributes, ClassDeclarationSyntax ClassSyntax,
            INamedTypeSymbol ClassSymbol) tuple)
    {
        if (framework is not (Framework.Wpf or Framework.Uwp or Framework.WinUi or Framework.Uno or Framework.UnoWinUi))
        {
            return null;
        }

        var (_, attributes, _, classSymbol) = tuple;

        var classData = classSymbol.GetClassData(framework);
        var overrideMetadata = attributes
            .Select(attribute => attribute.GetDependencyPropertyData(framework))
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