using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace H.Generators;

[Generator]
public class DependencyPropertyGenerator : IIncrementalGenerator
{
    #region Constants

    private const string Name = nameof(DependencyPropertyGenerator);
    private const string Id = "DPG";

    #endregion

    #region Methods

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var framework = context.DetectFramework(Name);

        context.RegisterSourceOutputOfFiles(
            context.SyntaxProvider
                .ForAttributeWithMetadataName("DependencyPropertyGenerator.DependencyPropertyAttribute")
                .SelectManyAllAttributesOfCurrentClassSyntax()
                .Combine(framework)
                .PrepareData(PrepareData, context, Id)
                .SafeSelect(GetSourceCode, context, Id));
        context.RegisterSourceOutputOfFiles(
            context.SyntaxProvider
                .ForAttributeWithMetadataName("DependencyPropertyGenerator.DependencyPropertyAttribute`1")
                .SelectManyAllAttributesOfCurrentClassSyntax()
                .Combine(framework)
                .PrepareData(PrepareData, context, Id)
                .SafeSelect(GetSourceCode, context, Id));
    }

    private static (ClassData Class, DependencyPropertyData DependencyProperty)? PrepareData(
        Framework framework,
        (SemanticModel SemanticModel, AttributeData AttributeData, ClassDeclarationSyntax ClassSyntax, INamedTypeSymbol ClassSymbol) tuple)
    {
        var (_, attribute, classSyntax, classSymbol) = tuple;
        var classData = classSymbol.GetClassData(framework);
        var dependencyPropertyData = attribute.GetDependencyPropertyData(framework, classSyntax.TryFindAttributeSyntax(attribute));
        
        return (classData, dependencyPropertyData);
    }

    private static FileWithName GetSourceCode((ClassData Class, DependencyPropertyData DependencyProperty) data)
    {
        return new FileWithName(
            Name: $"{data.Class.Name}.Properties.{data.DependencyProperty.Name}.generated.cs",
            Text: SourceGenerationHelper.GenerateDependencyProperty(data.Class, data.DependencyProperty));
    }

    #endregion
}
