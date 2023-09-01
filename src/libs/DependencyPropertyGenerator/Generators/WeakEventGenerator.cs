﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace H.Generators;

[Generator]
public class WeakEventGenerator : IIncrementalGenerator
{
    #region Constants

    private const string Id = "WEG";

    #endregion

    #region Methods

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(static context =>
        {
            context.AddSource(
                hintName: "WeakEventAttribute.g.cs",
                source: Resources.WeakEventAttribute_cs.AsString());
        });

        var framework = context.DetectFramework();

        context.SyntaxProvider
            .ForAttributeWithMetadataName("DependencyPropertyGenerator.WeakEventAttribute")
            .SelectManyAllAttributesOfCurrentClassSyntax()
            .Combine(framework)
            .SelectAndReportExceptions(PrepareData, context, Id)
            .WhereNotNull()
            .SelectAndReportExceptions(GetSourceCode, context, Id)
            .AddSource(context);
        context.SyntaxProvider
            .ForAttributeWithMetadataName("DependencyPropertyGenerator.WeakEventAttribute`1")
            .SelectManyAllAttributesOfCurrentClassSyntax()
            .Combine(framework)
            .SelectAndReportExceptions(PrepareData, context, Id)
            .WhereNotNull()
            .SelectAndReportExceptions(GetSourceCode, context, Id)
            .AddSource(context);
    }

    private static (ClassData Class, EventData Event)? PrepareData(
        Framework framework,
        (SemanticModel SemanticModel, AttributeData AttributeData, ClassDeclarationSyntax ClassSyntax, INamedTypeSymbol
            ClassSymbol) tuple)
    {
        if (framework is not (Framework.Maui or Framework.Wpf))
        {
            return null;
        }

        var (_, attribute, _, classSymbol) = tuple;
        var classData = classSymbol.GetClassData(framework);
        var eventData = attribute.GetEventData(isStaticClass: classData.IsStatic);

        return (classData, eventData);
    }

    private static FileWithName GetSourceCode((ClassData Class, EventData Event) data)
    {
        return new FileWithName(
            Name: $"{data.Class.FullName}.WeakEvents.{data.Event.Name}.g.cs",
            Text: Sources.GenerateWeakEvent(data.Class, data.Event));
    }

    #endregion
}