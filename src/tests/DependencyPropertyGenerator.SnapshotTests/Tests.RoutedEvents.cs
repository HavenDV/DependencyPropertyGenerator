namespace H.Generators.SnapshotTests;

public partial class Tests
{
    [DataTestMethod]
    [DataRow(Framework.Wpf)]
    [DataRow(Framework.Uno)]
    [DataRow(Framework.UnoWinUi)]
    [DataRow(Framework.Maui)]
    [DataRow(Framework.Avalonia)]
    public Task RoutedEvent(Framework framework)
    {
        return CheckSourceAsync<RoutedEventGenerator>(GetHeader(framework, "Controls") + @"
[RoutedEvent(""TrayLeftMouseDown"", RoutedEventStrategy.Bubble, WinRtEvents = true)]
public partial class MyControl : UserControl
{
}", framework);
    }

    [DataTestMethod]
    [DataRow(Framework.Wpf)]
    [DataRow(Framework.Uno)]
    [DataRow(Framework.UnoWinUi)]
    [DataRow(Framework.Maui)]
    [DataRow(Framework.Avalonia)]
    public Task AttachedRoutedEvent(Framework framework)
    {
        return CheckSourceAsync<RoutedEventGenerator>(GetHeader(framework, "Controls") + @"
[RoutedEvent(""TrayLeftMouseDown"", RoutedEventStrategy.Bubble, IsAttached = true)]
public partial class MyControl : UserControl
{
}", framework);
    }

    [TestMethod]
    public async Task AttachedRoutedEvent_StaticClass_DoesNotDuplicatePublicModifier()
    {
        const Framework framework = Framework.Wpf;
        var source = GetHeader(framework, "Controls") + @"
[RoutedEvent(""MouseDoubleClickEvent"", RoutedEventStrategy.Bubble, IsAttached = true)]
public static partial class ImageRoutedEvents
{
}";
        var generated = await GenerateSourceAsync<RoutedEventGenerator>(source, framework);

        generated.Should().NotContain("publicpublic");
        generated.Should().Contain("public static partial class ImageRoutedEvents");
    }

    [DataTestMethod]
    [DataRow(Framework.Wpf)]
    [DataRow(Framework.Uno)]
    [DataRow(Framework.UnoWinUi)]
    [DataRow(Framework.Avalonia)]
    public async Task RoutedEvent_WithGenericHandlerType_DoesNotProduceDuplicateGlobalPrefix(Framework framework)
    {
        var source = GetHeader(framework, "Controls") + @"
public delegate void MyRoutedEventHandler(object sender, global::System.EventArgs e);

[RoutedEvent<MyRoutedEventHandler>(""TrayLeftMouseDown"", RoutedEventStrategy.Bubble, WinRtEvents = true)]
public partial class MyControl : UserControl
{
}";
        var generated = await GenerateSourceAsync<RoutedEventGenerator>(source, framework);

        generated.Should().NotContain("global::global::");
        generated.Should().Contain("global::H.Generators.IntegrationTests.MyRoutedEventHandler");
    }

    [DataTestMethod]
    [DataRow(Framework.Wpf)]
    [DataRow(Framework.Uno)]
    [DataRow(Framework.UnoWinUi)]
    [DataRow(Framework.Avalonia)]
    public async Task RoutedEvent_WithTypeNamedArgument_DoesNotProduceDuplicateGlobalPrefix(Framework framework)
    {
        var source = GetHeader(framework, "Controls") + @"
public delegate void MyRoutedEventHandler(object sender, global::System.EventArgs e);

[RoutedEvent(""TrayLeftMouseDown"", RoutedEventStrategy.Bubble, Type = typeof(MyRoutedEventHandler), WinRtEvents = true)]
public partial class MyControl : UserControl
{
}";
        var generated = await GenerateSourceAsync<RoutedEventGenerator>(source, framework);

        generated.Should().NotContain("global::global::");
        generated.Should().Contain("global::H.Generators.IntegrationTests.MyRoutedEventHandler");
    }

    [TestMethod]
    public async Task Cs0436Suppressor_SuppressesOnlyGeneratedAttributeConflicts()
    {
        var parseOptions = global::Microsoft.CodeAnalysis.CSharp.CSharpParseOptions.Default
            .WithLanguageVersion(global::Microsoft.CodeAnalysis.CSharp.LanguageVersion.Preview);
        var references = (await global::Microsoft.CodeAnalysis.Testing.ReferenceAssemblies.NetFramework.Net48.Wpf.ResolveAsync(null, CancellationToken.None))
            .ToArray();

        var projectA = CreateCompilation(
            assemblyName: "ProjectA",
            source: @"
using System.Runtime.CompilerServices;
using DependencyPropertyGenerator;
using System.Windows.Controls;

[assembly: InternalsVisibleTo(""ProjectB"")]

namespace ProjectA;

internal sealed class SharedType
{
}

[RoutedEvent(""Opened"", RoutedEventStrategy.Bubble)]
internal partial class ProjectAControl : Control
{
}",
            references,
            parseOptions);
        projectA = RunRoutedEventGenerator(projectA, parseOptions);

        using var projectAAssembly = new MemoryStream();
        var projectAEmitResult = projectA.Emit(projectAAssembly);
        projectAEmitResult.Success.Should().BeTrue(string.Join(Environment.NewLine, projectAEmitResult.Diagnostics));
        projectAAssembly.Position = 0;

        var projectB = CreateCompilation(
            assemblyName: "ProjectB",
            source: @"
using DependencyPropertyGenerator;
using System.Windows.Controls;

namespace ProjectA
{
    internal sealed class SharedType
    {
    }
}

namespace ProjectB
{
    [RoutedEvent(""Closed"", RoutedEventStrategy.Bubble)]
    internal partial class ProjectBControl : Control
    {
        private ProjectA.SharedType? SharedType { get; set; }
    }
}",
            references.Concat(new[] { global::Microsoft.CodeAnalysis.MetadataReference.CreateFromStream(projectAAssembly) }).ToArray(),
            parseOptions);
        projectB = RunRoutedEventGenerator(projectB, parseOptions);

        var rawCs0436Diagnostics = projectB.GetDiagnostics()
            .Where(static diagnostic => diagnostic.Id == "CS0436")
            .ToArray();
        rawCs0436Diagnostics.Should().Contain(static diagnostic =>
            diagnostic.GetMessage().Contains("RoutedEventAttribute", StringComparison.Ordinal));
        rawCs0436Diagnostics.Should().Contain(static diagnostic =>
            diagnostic.GetMessage().Contains("SharedType", StringComparison.Ordinal));

        var diagnostics = await global::Microsoft.CodeAnalysis.Diagnostics.DiagnosticAnalyzerExtensions
            .WithAnalyzers(
                projectB,
                global::System.Collections.Immutable.ImmutableArray.Create<global::Microsoft.CodeAnalysis.Diagnostics.DiagnosticAnalyzer>(
                    new global::H.Generators.Suppressors.Cs0436Suppressor()),
                new global::Microsoft.CodeAnalysis.Diagnostics.AnalyzerOptions(
                    global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.AdditionalText>.Empty))
            .GetAllDiagnosticsAsync();

        diagnostics.Where(static diagnostic => diagnostic.Id == "CS0436")
            .Should()
            .ContainSingle(static diagnostic => diagnostic.GetMessage().Contains("SharedType", StringComparison.Ordinal));
        diagnostics.Where(static diagnostic => diagnostic.Severity == global::Microsoft.CodeAnalysis.DiagnosticSeverity.Error)
            .Should()
            .BeEmpty();
    }

    private static global::Microsoft.CodeAnalysis.Compilation CreateCompilation(
        string assemblyName,
        string source,
        global::Microsoft.CodeAnalysis.MetadataReference[] references,
        global::Microsoft.CodeAnalysis.CSharp.CSharpParseOptions parseOptions)
    {
        return global::Microsoft.CodeAnalysis.CSharp.CSharpCompilation.Create(
            assemblyName: assemblyName,
            syntaxTrees: new[]
            {
                global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxTree.ParseText(source, options: parseOptions),
            },
            references: references,
            options: new global::Microsoft.CodeAnalysis.CSharp.CSharpCompilationOptions(global::Microsoft.CodeAnalysis.OutputKind.DynamicallyLinkedLibrary));
    }

    private static global::Microsoft.CodeAnalysis.Compilation RunRoutedEventGenerator(
        global::Microsoft.CodeAnalysis.Compilation compilation,
        global::Microsoft.CodeAnalysis.CSharp.CSharpParseOptions parseOptions)
    {
        global::Microsoft.CodeAnalysis.GeneratorDriver driver = global::Microsoft.CodeAnalysis.CSharp.CSharpGeneratorDriver.Create(
            generators: new[] { global::Microsoft.CodeAnalysis.GeneratorExtensions.AsSourceGenerator(new RoutedEventGenerator()) },
            parseOptions: parseOptions);
        driver = driver
            .WithUpdatedAnalyzerConfigOptions(new global::H.Generators.Tests.Extensions.DictionaryAnalyzerConfigOptionsProvider(GetGlobalOptions(Framework.Wpf)))
            .RunGeneratorsAndUpdateCompilation(compilation, out var updatedCompilation, out _);

        return updatedCompilation;
    }
}
