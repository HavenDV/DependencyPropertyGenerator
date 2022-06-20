using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Immutable;

namespace H.Generators.SnapshotTests;

internal static class GeneratorDriverExteniosns
{
    public static GeneratorDriver RunGeneratorsAndUpdateCompilation(
        this GeneratorDriver driver,
        LanguageVersion version,
        Compilation compilation,
        out Compilation outputCompilation,
        out ImmutableArray<Diagnostic> diagnostics,
        CancellationToken cancellationToken = default)
    {
        driver = driver.RunGenerators(compilation, cancellationToken);
        var result = driver.GetRunResult();
        
        outputCompilation = compilation
            .AddSyntaxTrees(result.GeneratedTrees
                .Select(tree => tree.WithRootAndOptions(tree.GetRoot(cancellationToken), CSharpParseOptions.Default.WithLanguageVersion(version))));
        diagnostics = result.Diagnostics;

        return driver;
    }
}