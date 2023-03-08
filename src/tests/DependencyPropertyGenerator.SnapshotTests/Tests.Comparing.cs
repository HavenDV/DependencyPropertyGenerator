using System.Collections.Immutable;
using DependencyPropertyGenerator.Helpers;

namespace H.Generators.SnapshotTests;

public partial class Tests
{
    [TestMethod]
    public void CompareFileWithNamesImmutableArrays()
    {
        var first = ImmutableArray.Create(new FileWithName(Name: "test.txt", Text: "Hello World!")).AsEquatableArray();
        var second = ImmutableArray.Create(new FileWithName(Name: "test.txt", Text: "Hello World!")).AsEquatableArray();
        var comparison = first == second;
        comparison.Should().BeTrue();
    }
}