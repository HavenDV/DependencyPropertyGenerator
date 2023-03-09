using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace H.Generators;

[Generator]
public class StaticConstructorGenerator : IIncrementalGenerator
{
    #region Constants

    private const string Name = nameof(StaticConstructorGenerator);
    private const string Id = "SCG";

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
                .PrepareData(static (x, y) => PrepareData(x, y, isAttached: false), context, Id)
                .Collect()
                .Select(GetSourceCode));
        context.RegisterSourceOutputOfFiles(
            context.SyntaxProvider
                .ForAttributeWithMetadataName("DependencyPropertyGenerator.DependencyPropertyAttribute`1")
                .SelectManyAllAttributesOfCurrentClassSyntax()
                .Combine(framework)
                .PrepareData(static (x, y) => PrepareData(x, y, isAttached: false), context, Id)
                .Collect()
                .Select(GetSourceCode));
        context.RegisterSourceOutputOfFiles(
            context.SyntaxProvider
                .ForAttributeWithMetadataName("DependencyPropertyGenerator.AttachedDependencyPropertyAttribute")
                .SelectManyAllAttributesOfCurrentClassSyntax()
                .Combine(framework)
                .PrepareData(static (x, y) => PrepareData(x, y, isAttached: true), context, Id)
                .Collect()
                .Select(GetSourceCode));
        context.RegisterSourceOutputOfFiles(
            context.SyntaxProvider
                .ForAttributeWithMetadataName("DependencyPropertyGenerator.AttachedDependencyPropertyAttribute`1")
                .SelectManyAllAttributesOfCurrentClassSyntax()
                .Combine(framework)
                .PrepareData(static (x, y) => PrepareData(x, y, isAttached: true), context, Id)
                .Collect()
                .Select(GetSourceCode));
        context.RegisterSourceOutputOfFiles(
            context.SyntaxProvider
                .ForAttributeWithMetadataName("DependencyPropertyGenerator.AttachedDependencyPropertyAttribute`2")
                .SelectManyAllAttributesOfCurrentClassSyntax()
                .Combine(framework)
                .PrepareData(static (x, y) => PrepareData(x, y, isAttached: true), context, Id)
                .Collect()
                .Select(GetSourceCode));
    }

    private static (ClassData Class, DependencyPropertyData DependencyProperty)? PrepareData(
        Framework framework,
        (SemanticModel SemanticModel, AttributeData AttributeData, ClassDeclarationSyntax ClassSyntax, INamedTypeSymbol ClassSymbol) tuple,
        bool isAttached)
    {
        var (_, attribute, _, classSymbol) = tuple;
        var classData = classSymbol.GetClassData(framework);
        var dependencyPropertyData = attribute.GetDependencyPropertyData(framework, isAttached: isAttached);
        
        return (classData, dependencyPropertyData);
    }
    
    private static FileWithName GetSourceCode(
        ImmutableArray<(ClassData Class, DependencyPropertyData DependencyProperty)> values,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        if (values.IsDefaultOrEmpty)
        {
            return FileWithName.Empty;
        }
        
        var @class = values.First().Class;
        if (@class.Framework is not Framework.Avalonia)
        {
            return FileWithName.Empty;
        }
        
        var dependencyProperties = values
            .Select(static x => x.DependencyProperty)
            .ToArray();
        if (dependencyProperties.Where(static property => !property.IsDirect).Any())
        {
            var text = SourceGenerationHelper.GenerateStaticConstructor(
                @class,
                dependencyProperties
                    .Where(static property => !property.IsDirect)
                    .ToArray());

            if (!string.IsNullOrWhiteSpace(text))
            {
                return new FileWithName(
                    Name: $"{@class.Name}.StaticConstructor.generated.cs",
                    Text: text);
            }
        }

        return FileWithName.Empty;
    }

    #endregion
}
