using Microsoft.CodeAnalysis;

namespace H.Generators.SnapshotTests;

[TestClass]
public class Tests : VerifyBase
{
    private static string GetUsings(Platform platform, params string[] values)
    {
        var prefix = platform switch
        {
            Platform.WinUI or Platform.UnoWinUI => @"Microsoft.UI.Xaml",
            Platform.UWP or Platform.Uno => @"Windows.UI.Xaml",
            _ => @"System.Windows",
        };
        
        return string.Join(
            Environment.NewLine,
            values.Select(value => $"using {prefix}.{value};"));
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    //[DataRow(Platform.UWP)]
    //[DataRow(Platform.WinUI)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    public Task GeneratesCorrectly(Platform platform)
    {
        
        return this.CheckSourceAsync(GetUsings(platform, "Controls") + @"
using DependencyPropertyGenerator;

#nullable enable

namespace H.Generators.IntegrationTests;

[DependencyProperty<bool>(""IsSpinning"", DefaultValue = true, Category = ""Category"", Description = ""Description"")]
public partial class MyControl : UserControl
{
    // Optional
    partial void OnIsSpinningChanged(bool oldValue, bool newValue)
    {
    }
}

[AttachedDependencyProperty<object, TreeView>(""SelectedItem"", BindsTwoWayByDefault = true)]
public static partial class TreeViewExtensions
{
    // Optional
    static partial void OnSelectedItemChanged(TreeView sender, object? oldValue, object? newValue)
    {
    }
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    public Task GeneratesMultipleClassDeclarationsCorrectly(Platform platform)
    {
        return this.CheckSourceAsync(GetUsings(platform, "Controls") + @"
using DependencyPropertyGenerator;

#nullable enable

namespace H.Generators.IntegrationTests;

[DependencyProperty<bool>(""IsSpinning"")]
public partial class MyControl : UserControl
{
    // Optional
    partial void OnIsSpinningChanged(bool oldValue, bool newValue)
    {
    }
}

[DependencyProperty<bool>(""IsSpinning2"")]
public partial class MyControl : UserControl
{
    // Optional
    partial void OnIsSpinning2Changed(bool oldValue, bool newValue)
    {
    }
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    public Task GeneratesEnumCorrectly(Platform platform)
    {
        return this.CheckSourceAsync(GetUsings(platform, "Controls") + @"
using DependencyPropertyGenerator;

#nullable enable

namespace H.Generators.IntegrationTests;

public enum Mode
{
    Mode1,
    Mode2,
}

[AttachedDependencyProperty<Mode, TreeView>(""Mode"", DefaultValue = Mode.Mode2)]
public static partial class TreeViewExtensions
{
    static partial void OnModeChanged(TreeView sender, Mode oldValue, Mode newValue)
    {
    }
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    public Task GeneratesRoutedEventCorrectly(Platform platform)
    {
        return this.CheckSourceAsync(GetUsings(platform, "Controls") + @"
using DependencyPropertyGenerator;

#nullable enable

namespace H.Generators.IntegrationTests;

[RoutedEvent(""TrayLeftMouseDown"", RoutedEventStrategy.Bubble)]
public partial class MyControl : UserControl
{
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    public Task GeneratesAttachedRoutedEventCorrectly(Platform platform)
    {
        return this.CheckSourceAsync(GetUsings(platform, "Controls") + @"
using DependencyPropertyGenerator;

#nullable enable

namespace H.Generators.IntegrationTests;

[RoutedEvent(""TrayLeftMouseDown"", RoutedEventStrategy.Bubble, IsAttached = true)]
public partial class MyControl : UserControl
{
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    public Task GeneratesAttributesCorrectly(Platform platform)
    {
        return this.CheckSourceAsync(GetUsings(platform, "Controls") + @"
using DependencyPropertyGenerator;
using System.ComponentModel;

#nullable enable

namespace H.Generators.IntegrationTests;

[DependencyProperty<string>(""AttributedProperty"",
    Category = ""Category"",
    Description = ""Description"",
    TypeConverter = typeof(EnumConverter),
    Bindable = true,
    DesignerSerializationVisibility = DesignerSerializationVisibility.Hidden,
    CLSCompliant = false,
    Localizability = Localizability.Text)]
public partial class MyControl : UserControl
{
}", platform);
    }
}