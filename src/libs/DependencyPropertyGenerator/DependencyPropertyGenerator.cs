﻿using System.Collections.Immutable;
using H.Generators.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace H.Generators;

[Generator]
public class DependencyPropertyGenerator : IIncrementalGenerator
{
    #region Constants

    public const string Name = nameof(DependencyPropertyGenerator);
    public const string Id = "DPG";

    private const string AttachedDependencyPropertyAttribute = "DependencyPropertyGenerator.AttachedDependencyPropertyAttribute";
    private const string DependencyPropertyAttribute = "DependencyPropertyGenerator.DependencyPropertyAttribute";

    #endregion

    #region Methods

    private static ClassDeclarationSyntax? GetSemanticTargetForGeneration(GeneratorSyntaxContext context)
    {
        var syntax = (ClassDeclarationSyntax)context.Node;

        foreach (var attributeListSyntax in syntax.AttributeLists)
        {
            foreach (var attributeSyntax in attributeListSyntax.Attributes)
            {
                if (context.SemanticModel.GetSymbolInfo(attributeSyntax).Symbol is not IMethodSymbol attributeSymbol)
                {
                    continue;
                }

                var attributeContainingTypeSymbol = attributeSymbol.ContainingType;
                var fullName = attributeContainingTypeSymbol.ToDisplayString();
                if (fullName.StartsWith(AttachedDependencyPropertyAttribute) ||
                    fullName.StartsWith(DependencyPropertyAttribute))
                {
                    return syntax;
                }
            }
        }

        return null;
    }

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var classes = context.SyntaxProvider
            .CreateSyntaxProvider(
                predicate: static (node, _) => node is ClassDeclarationSyntax { AttributeLists.Count: > 0 },
                transform: static (context, _) => GetSemanticTargetForGeneration(context))
            .Where(static syntax => syntax is not null);

        var compilationAndClasses = context.CompilationProvider.Combine(classes.Collect());

        context.RegisterSourceOutput(
            compilationAndClasses,
            static (context, source) => Execute(source.Left, source.Right!, context));
    }

    private static void Execute(
        Compilation compilation,
        ImmutableArray<ClassDeclarationSyntax> classSyntaxes,
        SourceProductionContext context)
    {
        if (classSyntaxes.IsDefaultOrEmpty)
        {
            return;
        }

        try
        {
            var classes = GetTypesToGenerate(compilation, classSyntaxes, context.CancellationToken);
            foreach (var @class in classes)
            {
                context.AddTextSource(
                    hintName: $"{@class.Name}_DependencyProperties.generated.cs",
                    text: SourceGenerationHelper.GenerateDependencyProperty(@class));
                context.AddTextSource(
                    hintName: $"{@class.Name}_AttachedDependencyProperties.generated.cs",
                    text: SourceGenerationHelper.GenerateAttachedDependencyProperty(@class));
            }
        }
        catch (Exception exception)
        {
            context.ReportException(
                id: "001",
                exception: exception,
                prefix: Id);
        }
    }

    private static List<ClassData> GetTypesToGenerate(
        Compilation compilation,
        IEnumerable<ClassDeclarationSyntax> classes,
        CancellationToken cancellationToken)
    {
        var enumsToGenerate = new List<ClassData>();
        foreach (var @class in classes)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var semanticModel = compilation.GetSemanticModel(@class.SyntaxTree);
            if (semanticModel.GetDeclaredSymbol(
                @class, cancellationToken) is not INamedTypeSymbol classSymbol)
            {
                continue;
            }

            var fullClassName = classSymbol.ToString();
            var @namespace = fullClassName.Substring(0, fullClassName.LastIndexOf('.'));
            var className = fullClassName.Substring(fullClassName.LastIndexOf('.') + 1);
            var classModifiers = classSymbol.IsStatic ? " static" : string.Empty;

            var dependencyProperties = new List<DependencyPropertyData>();
            var attachedDependencyProperties = new List<DependencyPropertyData>();
            foreach (var (attributeSyntax, attribute) in @class.AttributeLists
                .SelectMany(static list => list.Attributes)
                .Zip(classSymbol.GetAttributes(), static (a, b) => (a, b)))
            {
                var name = attribute.ConstructorArguments[0].Value as string ?? string.Empty;
                var type =
                    GetGenericTypeArgumentFromAttributeData(attribute, 0)?.ToDisplayString() ??
                    attribute.ConstructorArguments.ElementAtOrDefault(1).Value?.ToString() ??
                    string.Empty;
                var isValueType =
                    GetGenericTypeArgumentFromAttributeData(attribute, 0)?.IsValueType ??
                    attribute.ConstructorArguments.ElementAtOrDefault(1).Type?.IsValueType ??
                    true;
                var defaultValue = GetPropertyFromAttributeSyntax(attributeSyntax, "DefaultValue");
                var bindsTwoWayByDefault = GetPropertyFromAttributeSyntax(attributeSyntax, "BindsTwoWayByDefault") ?? bool.FalseString;
                var browsableForType =
                    GetGenericTypeArgumentFromAttributeData(attribute, 1)?.ToDisplayString() ??
                    GetPropertyFromAttributeData(attribute, "BrowsableForType")?.Value?.ToString();
                var value = new DependencyPropertyData(
                    Name: name,
                    Type: type,
                    IsValueType: isValueType,
                    DefaultValue: defaultValue,
                    BindsTwoWayByDefault: bool.Parse(bindsTwoWayByDefault),
                    BrowsableForType: browsableForType);
                var attributeClass = attribute.AttributeClass?.ToDisplayString() ?? string.Empty;
                if (attributeClass.StartsWith(DependencyPropertyAttribute))
                {
                    dependencyProperties.Add(value);
                }
                else if (attributeClass.StartsWith(AttachedDependencyPropertyAttribute))
                {
                    attachedDependencyProperties.Add(value);
                }
            }

            enumsToGenerate.Add(new ClassData(@namespace, className, classModifiers, dependencyProperties, attachedDependencyProperties));
        }

        return enumsToGenerate;
    }

    private static ITypeSymbol? GetGenericTypeArgumentFromAttributeData(AttributeData data, int position)
{
        return data.AttributeClass?.TypeArguments.ElementAtOrDefault(position);
    }

    private static TypedConstant? GetPropertyFromAttributeData(AttributeData data, string name)
{
        return data.NamedArguments
            .FirstOrDefault(pair => pair.Key == name)
            .Value;
    }

    private static string? GetPropertyFromAttributeSyntax(AttributeSyntax syntax, string name)
    {
        return syntax.ArgumentList?.Arguments
            .FirstOrDefault(pair => pair.NameEquals?.ToFullString().StartsWith(name) == true)?
            .Expression
            .ToFullString();
    }

    #endregion
}