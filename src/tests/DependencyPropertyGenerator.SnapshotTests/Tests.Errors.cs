namespace H.Generators.SnapshotTests;

public partial class Tests
{
    [TestMethod]
    public async Task FrameworkIsInferredFromReferencesWhenAnalyzerOptionsAreMissing()
    {
        var parseOptions = global::Microsoft.CodeAnalysis.CSharp.CSharpParseOptions.Default
            .WithLanguageVersion(global::Microsoft.CodeAnalysis.CSharp.LanguageVersion.Preview);
        var references = (await global::Microsoft.CodeAnalysis.Testing.ReferenceAssemblies.NetFramework.Net48.Wpf.ResolveAsync(null, CancellationToken.None))
            .ToArray();
        var compilation = CreateCompilation(
            assemblyName: "SelfContainedPublish",
            source: @"
using DependencyPropertyGenerator;
using System.Windows.Controls;

namespace SelfContainedPublish;

[DependencyProperty<int>(""Value"")]
internal partial class GeneratedControl : Control
{
}",
            references,
            parseOptions);

        global::Microsoft.CodeAnalysis.GeneratorDriver driver = global::Microsoft.CodeAnalysis.CSharp.CSharpGeneratorDriver.Create(
            generators: new global::Microsoft.CodeAnalysis.IIncrementalGenerator[]
            {
                new DependencyPropertyGenerator(),
                new StaticConstructorGenerator(),
            }.Select(global::Microsoft.CodeAnalysis.GeneratorExtensions.AsSourceGenerator),
            parseOptions: parseOptions);
        driver = driver.RunGeneratorsAndUpdateCompilation(compilation, out var updatedCompilation, out _);

        var diagnostics = updatedCompilation.GetDiagnostics();
        diagnostics.Should().NotContain(static diagnostic =>
            diagnostic.Id == "TRF001" || diagnostic.Id == "DPG" || diagnostic.Id == "ADPG");
        diagnostics.Where(static diagnostic => diagnostic.Severity == global::Microsoft.CodeAnalysis.DiagnosticSeverity.Error)
            .Should()
            .BeEmpty();
        driver.GetRunResult().GeneratedTrees
            .Should()
            .Contain(static tree => tree.FilePath.Contains("GeneratedControl.Properties.Value.g.cs", StringComparison.Ordinal));
    }

    [DataTestMethod]
    [DataRow(Framework.None)]
    public Task NoneFramework(Framework framework)
    {
        return CheckSourceAsync<WeakEventGenerator>(GetHeader(framework) + @"
[WeakEvent<string>(""UrlChanged"", IsStatic = true)]
public partial class MyControl
{
}", framework);
    }
    
    [DataTestMethod]
    [DataRow(Framework.Wpf)]
    [DataRow(Framework.Uno)]
    [DataRow(Framework.UnoWinUi)]
    [DataRow(Framework.Maui)]
    [DataRow(Framework.Avalonia)]
    public Task DescriptionWithCref(Framework framework)
    {
        return CheckSourceAsync<DependencyPropertyGenerator>(GetHeader(framework, "Controls") + @"
[DependencyProperty<bool>(""IsSpinning"", Description = ""<see cref=\""Style.TargetType\""/> must be Label."")]
public partial class MyControl : UserControl
{
}
", framework);
    }
}
