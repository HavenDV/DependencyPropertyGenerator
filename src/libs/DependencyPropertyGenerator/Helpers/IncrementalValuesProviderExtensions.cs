using H.Generators.Extensions;
using Microsoft.CodeAnalysis;

namespace H.Generators;

public static class IncrementalValuesProviderExtensions
{
    public static IncrementalValuesProvider<TResult> SafeSelect<TSource, TResult>(
        this IncrementalValuesProvider<TSource> source,
        Func<TSource, TResult> selector,
        IncrementalGeneratorInitializationContext initializationContext,
        string? prefix = null)
    {
        var outputWithErrors = source
            .Select<TSource, (TResult? Value, Exception? Exception)>((value, cancellationToken) =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                
                try
                {
                    return (Value: selector(value), Exception: null);
                }
                catch (Exception exception)
                {
                    return (Value: default, Exception: exception);
                }
            });

        initializationContext.RegisterSourceOutput(outputWithErrors
            .Where(static x => x.Exception is not null),
            (context, tuple) =>
            {
                context.ReportException(id: "001", exception: tuple.Exception!, prefix);
            });
        
        return outputWithErrors
            .Where(static x => x.Exception is null)
            .Select(static (x, _) => x.Value!);
    }
}
