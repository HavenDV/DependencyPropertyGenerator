namespace H.Generators.SnapshotTests;

[TestClass]
public partial class Tests : VerifyBase
{
    [DataTestMethod]
    [DataRow(Platform.WPF)]
    public Task GeneratesNonGenericAttributesCorrectly(Platform platform)
    {
        return CheckSourceAsync(GetHeader(platform, "Controls") + @"
[DependencyProperty(""Text"", typeof(string))]
public partial class MyControl : UserControl
{
}

[AttachedDependencyProperty(""AttachedProperty"", typeof(object), BrowsableForType = typeof(Grid))]
public static partial class GridExtensions
{
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    public Task GeneratesMultipleClassDeclarationsCorrectly(Platform platform)
    {
        return CheckSourceAsync(GetHeader(platform, "Controls") + @"
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
    public Task GeneratesAttributesCorrectly(Platform platform)
    {
        return CheckSourceAsync(GetHeader(platform, "Controls", "System.ComponentModel") + @"
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

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    public Task GeneratesCorrectlyWithOtherAttributes(Platform platform)
    {
        return CheckSourceAsync(GetHeader(platform, "Controls", "System") + @"
[CLSCompliant(false)]
public partial class MyControl : UserControl
{
}

[DependencyProperty<bool>(""IsSpinning5"")]
public partial class MyControl : UserControl
{   
    partial void OnIsSpinning5Changed(bool oldValue, bool newValue)
    {
    }
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    public Task GeneratesCorrectlyWithOtherAttributes2(Platform platform)
    {
        return CheckSourceAsync(GetHeader(platform) + @"
[DependencyProperty<string>(""Text"")]
[System.ComponentModel.DesignTimeVisible(false)]
public partial class Generatable : System.Windows.FrameworkElement
{
    partial void OnTextChanged(string? oldValue, string? newValue)
    {
    }
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    public Task GeneratesFloatLiteralsCorrectly(Platform platform)
    {
        return CheckSourceAsync(GetHeader(platform, "Controls") + @"
[DependencyProperty<float>(""FloatProperty"", DefaultValue = 42)]
public partial class MyControl : UserControl
{
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    [DataRow(Platform.MAUI)]
    public Task GeneratesValidateAndCoerceCorrectly(Platform platform)
    {
        return CheckSourceAsync(GetHeader(platform, "Controls") + @"
[DependencyProperty<string>(""NotNullStringProperty"", DefaultValue = """", Validate = true, Coerce = true)]
public partial class MyControl : UserControl
{
    private partial string? CoerceNotNullStringProperty(string? value)
    {
        return value ?? string.Empty;
    }

    private static partial bool IsNotNullStringPropertyValid(string? value)
    {
        return value != null;
    }
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    public Task GeneratesDefaultUpdateSourceTriggerCorrectly(Platform platform)
    {
        return CheckSourceAsync(GetHeader(platform, "Controls") + @"
[DependencyProperty<bool>(""ExplicitUpdateSourceTriggerProperty"", DefaultUpdateSourceTrigger = SourceTrigger.Explicit)]
public partial class MyControl : UserControl
{
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    public Task GeneratesReadOnlyPropertyCorrectly(Platform platform)
    {
        return CheckSourceAsync(GetHeader(platform, "Controls") + @"
[DependencyProperty<bool>(""ReadOnlyProperty"", IsReadOnly = true)]
public partial class MyControl : UserControl
{
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    public Task GeneratesBindEventsCorrectly(Platform platform)
    {
        return CheckSourceAsync(GetHeader(platform, "Controls") + @"
[DependencyProperty<object>(""BindEventsProperty"",
    BindEvents = new[] { nameof(Grid.MouseEnter), nameof(Grid.MouseLeave) })]
public partial class MyGrid : Grid
{
    private static void OnBindEventsPropertyChanged_MouseEnter(object? sender, System.Windows.Input.MouseEventArgs args)
    {
    }

    private static void OnBindEventsPropertyChanged_MouseLeave(object? sender, System.Windows.Input.MouseEventArgs args)
    {
    }
}", platform);
    }
}