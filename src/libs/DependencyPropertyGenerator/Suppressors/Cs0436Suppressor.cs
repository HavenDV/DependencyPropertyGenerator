using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace H.Generators.Suppressors;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class Cs0436Suppressor : DiagnosticSuppressor
{
    private static readonly SuppressionDescriptor Descriptor = new(
        id: "DPG0436",
        suppressedDiagnosticId: "CS0436",
        justification: "DependencyPropertyGenerator emits internal attribute helper types into each compilation; duplicate friend-assembly copies are expected.");

    public override ImmutableArray<SuppressionDescriptor> SupportedSuppressions { get; } = ImmutableArray.Create(Descriptor);

    public override void ReportSuppressions(SuppressionAnalysisContext context)
    {
        foreach (var diagnostic in context.ReportedDiagnostics)
        {
            if (ShouldSuppress(diagnostic))
            {
                context.ReportSuppression(Suppression.Create(Descriptor, diagnostic));
            }
        }
    }

    private static bool ShouldSuppress(Diagnostic diagnostic)
    {
        if (diagnostic.Id != "CS0436")
        {
            return false;
        }

        var message = diagnostic.GetMessage(System.Globalization.CultureInfo.InvariantCulture);

        return message.Contains(@"DependencyPropertyGenerator\H.Generators.", StringComparison.Ordinal) ||
               message.Contains("DependencyPropertyGenerator/H.Generators.", StringComparison.Ordinal);
    }
}
