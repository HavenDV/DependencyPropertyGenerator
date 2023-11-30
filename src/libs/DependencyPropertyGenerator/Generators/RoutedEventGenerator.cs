using H.Generators.Extensions;
using Microsoft.CodeAnalysis;

namespace H.Generators;

[Generator]
public class RoutedEventGenerator : IIncrementalGenerator
{
    #region Constants

    private const string Id = "REG";

    #endregion

    #region Methods

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(static context =>
        {
            context.AddSource(
                hintName: "RoutedEventAttribute.g.cs",
                source: Resources.RoutedEventAttribute_cs.AsString());
            context.AddSource(
                hintName: "RoutedEventStrategy.g.cs",
                source: Resources.RoutedEventStrategy_cs.AsString());
        });

        var framework = context.DetectFramework();
        var version = context.DetectVersion();

        context.SyntaxProvider
            .ForAttributeWithMetadataNameOfClassesAndRecords("DependencyPropertyGenerator.RoutedEventAttribute")
            .SelectManyAllAttributesOfCurrentClassSyntax()
            .Combine(framework)
            .Combine(version)
            .SelectAndReportExceptions(PrepareData, context, Id)
            .WhereNotNull()
            .SelectAndReportExceptions(GetSourceCode, context, Id)
            .AddSource(context);
        context.SyntaxProvider
            .ForAttributeWithMetadataNameOfClassesAndRecords("DependencyPropertyGenerator.RoutedEventAttribute`1")
            .SelectManyAllAttributesOfCurrentClassSyntax()
            .Combine(framework)
            .Combine(version)
            .SelectAndReportExceptions(PrepareData, context, Id)
            .WhereNotNull()
            .SelectAndReportExceptions(GetSourceCode, context, Id)
            .AddSource(context);
    }

    private static (ClassData Class, EventData Event)? PrepareData(
        ((ClassWithAttributesContext context,
            Framework framework) left,
            string version) tuple)
    {
        var (((_, attributes, _, classSymbol), framework), version) = tuple;
        if (attributes.FirstOrDefault() is not { } attribute)
        {
            return null;
        }

        var eventData = attribute.GetEventData(isStaticClass: false);
        if (framework is Framework.Maui ||
            framework is not Framework.Wpf && eventData.IsAttached)
        {
            return null;
        }

        var classData = classSymbol.GetClassData(framework, version);

        return (classData, eventData);
    }

    private static FileWithName GetSourceCode((ClassData Class, EventData Event) data)
    {
        var category = data.Event.IsAttached
            ? "AttachedEvents"
            : "Events";

        return new FileWithName(
            Name: $"{data.Class.FullName}.{category}.{data.Event.Name}.g.cs",
            Text: Sources.GenerateRoutedEvent(data.Class, data.Event));
    }

    #endregion
}