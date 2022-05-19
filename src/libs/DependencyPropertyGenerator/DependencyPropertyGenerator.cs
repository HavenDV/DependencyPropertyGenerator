using Microsoft.CodeAnalysis;

namespace H.Generators;

[Generator]
public class DependencyPropertyGenerator : IIncrementalGenerator
{
    #region Methods

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterSourceOutput(
            context.CompilationProvider,
            static (context, _) => Execute(context));
    }

    private static void Execute(
        SourceProductionContext context)
    {
    }

    #endregion
}
