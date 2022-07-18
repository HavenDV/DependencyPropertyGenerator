namespace H.Generators.SnapshotTests;

[TestClass]
public partial class Tests : VerifyBase
{
    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    [DataRow(Platform.MAUI)]
    [DataRow(Platform.Avalonia)]
    public Task NonGenericAttributes(Platform platform)
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
    [DataRow(Platform.MAUI)]
    [DataRow(Platform.Avalonia)]
    public Task MultipleClassDeclarations(Platform platform)
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
    [DataRow(Platform.MAUI)]
    [DataRow(Platform.Avalonia)]
    public Task Attributes(Platform platform)
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
    [DataRow(Platform.MAUI)]
    [DataRow(Platform.Avalonia)]
    public Task WithOtherAttributes(Platform platform)
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
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    //[DataRow(Platform.MAUI)]
    //[DataRow(Platform.Avalonia)]
    public Task WithOtherAttributes2(Platform platform)
    {
        return CheckSourceAsync(GetHeader(platform, string.Empty) + @"
[DependencyProperty<string>(""Text"")]
[System.ComponentModel.DesignTimeVisible(false)]
public partial class Generatable : FrameworkElement
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
    [DataRow(Platform.MAUI)]
    [DataRow(Platform.Avalonia)]
    public Task FloatLiterals(Platform platform)
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
    [DataRow(Platform.Avalonia)]
    public Task ValidateAndCoerce(Platform platform)
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
    [DataRow(Platform.MAUI)]
    [DataRow(Platform.Avalonia)]
    public Task CreateDefaultValueCallback(Platform platform)
    {
        return CheckSourceAsync(GetHeader(platform, "Controls") + @"
[DependencyProperty<string>(""SomeProperty"", CreateDefaultValueCallback = true)]
public partial class MyGrid : Grid
{
    private static partial string GetSomePropertyDefaultValue()
    {
        return ""Hello, world"";
    }
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    [DataRow(Platform.MAUI)]
    [DataRow(Platform.Avalonia)]
    public Task DefaultUpdateSourceTrigger(Platform platform)
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
    //[DataRow(Platform.MAUI)]
    [DataRow(Platform.Avalonia)]
    public Task ReadOnlyProperty(Platform platform)
    {
        return CheckSourceAsync(GetHeader(platform, "Controls") + @"
[DependencyProperty<bool>(""ReadOnlyProperty"", IsReadOnly = true)]
public partial class MyControl : UserControl
{
}", platform);
    }

    [DataTestMethod]
    [DataRow(Platform.WPF)]
    [DataRow(Platform.Uno)]
    [DataRow(Platform.UnoWinUI)]
    //[DataRow(Platform.MAUI)]
    [DataRow(Platform.Avalonia)]
    public Task BindEvents(Platform platform)
    {
        return CheckSourceAsync(GetHeader(platform, string.Empty, "Input") + @"
[DependencyProperty<object>(""BindEventsProperty"",
    BindEvents = new[] { nameof(UIElement.PointerEntered), nameof(UIElement.PointerExited) })]
public partial class MyUIElement : UIElement
{
    private static void OnBindEventsPropertyChanged_PointerEntered(object? sender, PointerRoutedEventArgs args)
    {
    }

    private static void OnBindEventsPropertyChanged_PointerExited(object? sender, PointerRoutedEventArgs args)
    {
    }
}", platform);
    }
}