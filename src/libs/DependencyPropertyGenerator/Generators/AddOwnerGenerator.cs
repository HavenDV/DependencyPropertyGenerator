﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace H.Generators;

[Generator]
public class AddOwnerGenerator : IIncrementalGenerator
{
    #region Constants

    private const string Id = "AOG";

    #endregion

    #region Methods

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var framework = context.DetectFramework();

        context.SyntaxProvider
            .ForAttributeWithMetadataName("DependencyPropertyGenerator.AddOwnerAttribute")
            .SelectManyAllAttributesOfCurrentClassSyntax()
            .Combine(framework)
            .SelectAndReportExceptions(PrepareData, context, Id)
            .WhereNotNull()
            .SelectAndReportExceptions(GetSourceCode, context, Id)
            .AddSource(context);
        context.SyntaxProvider
            .ForAttributeWithMetadataName("DependencyPropertyGenerator.AddOwnerAttribute`2")
            .SelectManyAllAttributesOfCurrentClassSyntax()
            .Combine(framework)
            .SelectAndReportExceptions(PrepareData, context, Id)
            .WhereNotNull()
            .SelectAndReportExceptions(GetSourceCode, context, Id)
            .AddSource(context);
    }

    private static (ClassData Class, DependencyPropertyData DependencyProperty)? PrepareData(
        Framework framework,
        (SemanticModel SemanticModel, AttributeData AttributeData, ClassDeclarationSyntax ClassSyntax, INamedTypeSymbol ClassSymbol) tuple)
    {
        if (framework is not (Framework.Avalonia or Framework.Wpf))
        {
            return null;
        }

        var (_, attribute, _, classSymbol) = tuple;
        
        var classData = classSymbol.GetClassData(framework);
        var dependencyPropertyData = attribute.GetDependencyPropertyData(framework, isAddOwner: true);
        
        return (classData, dependencyPropertyData);
    }
    
    private static FileWithName GetSourceCode((ClassData Class, DependencyPropertyData DependencyProperty) data)
    {
        return new FileWithName(
            Name: $"{data.Class.Name}.AddOwner.{data.DependencyProperty.Name}.generated.cs",
            Text: SourceGenerationHelper.GenerateDependencyProperty(data.Class, data.DependencyProperty));
    }

    #endregion
}