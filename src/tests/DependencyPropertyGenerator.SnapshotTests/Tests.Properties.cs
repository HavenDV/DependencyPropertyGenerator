namespace H.Generators.SnapshotTests;

[TestClass]
public partial class Tests
{
    [DataTestMethod]
    [DataRow(Framework.Wpf)]
    [DataRow(Framework.Uno)]
    [DataRow(Framework.UnoWinUi)]
    [DataRow(Framework.Maui)]
    [DataRow(Framework.Avalonia)]
    public Task NonGenericAttributes(Framework framework)
    {
        return CheckSourceAsync<DependencyPropertyGenerator>(GetHeader(framework, "Controls") + @"
[DependencyProperty(""Text"", typeof(string))]
public partial class MyControl : UserControl
{
}

[AttachedDependencyProperty(""AttachedProperty"", typeof(object), BrowsableForType = typeof(Grid))]
public static partial class GridExtensions
{
}", framework, additionalGenerators: new AttachedDependencyPropertyGenerator());
    }

    [DataTestMethod]
    [DataRow(Framework.Wpf)]
    [DataRow(Framework.Uno)]
    [DataRow(Framework.UnoWinUi)]
    [DataRow(Framework.Maui)]
    [DataRow(Framework.Avalonia)]
    public Task MultipleClassDeclarations(Framework framework)
    {
        return CheckSourceAsync<DependencyPropertyGenerator>(GetHeader(framework, "Controls") + @"
[DependencyProperty<bool>(""IsSpinning"")]
public partial class MyControl : UserControl
{
    // Optional
    partial void OnIsSpinningChanged()
    {
    }
}

[DependencyProperty<bool>(""IsSpinning2"")]
public partial class MyControl : UserControl
{
    // Optional
    partial void OnIsSpinning2Changed(bool newValue)
    {
    }
}", framework, additionalGenerators: new StaticConstructorGenerator());
    }

    [DataTestMethod]
    [DataRow(Framework.Wpf)]
    [DataRow(Framework.Uno)]
    [DataRow(Framework.UnoWinUi)]
    [DataRow(Framework.Maui)]
    [DataRow(Framework.Avalonia)]
    public Task Attributes(Framework framework)
    {
        return CheckSourceAsync<DependencyPropertyGenerator>(GetHeader(framework, "Controls", "System.ComponentModel") +
                                                             @"
[DependencyProperty<string>(""AttributedProperty"",
    Category = ""Category"",
    Description = ""Description"",
    TypeConverter = typeof(EnumConverter),
    Bindable = true,
    DesignerSerializationVisibility = DesignerSerializationVisibility.Hidden,
    ClsCompliant = false,
    Localizability = Localizability.Text)]
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
    public Task WithOtherAttributes(Framework framework)
    {
        return CheckSourceAsync<DependencyPropertyGenerator>(GetHeader(framework, "Controls", "System") + @"
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
}", framework, additionalGenerators: new StaticConstructorGenerator());
    }

    [DataTestMethod]
    [DataRow(Framework.Wpf)]
    [DataRow(Framework.Uno)]
    [DataRow(Framework.UnoWinUi)]
    [DataRow(Framework.Maui)]
    [DataRow(Framework.Avalonia)]
    public Task WithOtherAttributes2(Framework framework)
    {
        return CheckSourceAsync<DependencyPropertyGenerator>(GetHeader(framework, string.Empty) + @"
[DependencyProperty<string>(""Text"")]
[System.ComponentModel.DesignTimeVisible(false)]
public partial class Generatable : FrameworkElement
{
    partial void OnTextChanged(string? oldValue, string? newValue)
    {
    }
}", framework, additionalGenerators: new StaticConstructorGenerator());
    }

    [DataTestMethod]
    [DataRow(Framework.Wpf)]
    [DataRow(Framework.Uno)]
    [DataRow(Framework.UnoWinUi)]
    [DataRow(Framework.Maui)]
    [DataRow(Framework.Avalonia)]
    public Task NullableDisable(Framework framework)
    {
        return CheckSourceAsync<DependencyPropertyGenerator>(GetHeader(framework, nullable: false, @namespace: true, string.Empty) + @"
[DependencyProperty<string>(""Text"")]
public partial class Generatable : FrameworkElement
{
    partial void OnTextChanged(string oldValue, string newValue)
    {
    }
}", framework, additionalGenerators: new StaticConstructorGenerator());
    }

    [DataTestMethod]
    [DataRow(Framework.Wpf)]
    [DataRow(Framework.Uno)]
    [DataRow(Framework.UnoWinUi)]
    [DataRow(Framework.Maui)]
    [DataRow(Framework.Avalonia)]
    public Task FloatLiterals(Framework framework)
    {
        return CheckSourceAsync<DependencyPropertyGenerator>(GetHeader(framework, "Controls") + @"
[DependencyProperty<float>(""FloatProperty"", DefaultValue = 42)]
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
    public Task ValidateAndCoerce(Framework framework)
    {
        return CheckSourceAsync<DependencyPropertyGenerator>(GetHeader(framework, "Controls") + $@"
[DependencyProperty<string>(""NotNullStringProperty"", DefaultValue = """", Validate = true, Coerce = true)]
public partial class MyControl : UserControl
{{
    private partial string? CoerceNotNullStringProperty(string? value)
    {{
        return value ?? string.Empty;
    }}

{(framework == Framework.Maui ? @"
    private static partial bool IsNotNullStringPropertyValid(MyControl sender, string? value)
    {
        return value != null;
    }" : @"
    private static partial bool IsNotNullStringPropertyValid(string? value)
    {
        return value != null;
    }")}
}}", framework);
    }

    [DataTestMethod]
    [DataRow(Framework.Wpf)]
    [DataRow(Framework.Uno)]
    [DataRow(Framework.UnoWinUi)]
    [DataRow(Framework.Maui)]
    [DataRow(Framework.Avalonia)]
    public Task CreateDefaultValueCallback(Framework framework)
    {
        return CheckSourceAsync<DependencyPropertyGenerator>(GetHeader(framework, "Controls") + @"
[DependencyProperty<string>(""SomeProperty"", CreateDefaultValueCallback = true)]
public partial class MyGrid : Grid
{
    private static partial string GetSomePropertyDefaultValue()
    {
        return ""Hello, world"";
    }
}", framework);
    }

    [DataTestMethod]
    [DataRow(Framework.Wpf)]
    [DataRow(Framework.Uno)]
    [DataRow(Framework.UnoWinUi)]
    [DataRow(Framework.Maui)]
    [DataRow(Framework.Avalonia)]
    public Task DefaultUpdateSourceTrigger(Framework framework)
    {
        return CheckSourceAsync<DependencyPropertyGenerator>(GetHeader(framework, "Controls") + @"
[DependencyProperty<bool>(""ExplicitUpdateSourceTriggerProperty"", DefaultUpdateSourceTrigger = SourceTrigger.Explicit)]
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
    public Task ReadOnlyProperty(Framework framework)
    {
        return CheckSourceAsync<DependencyPropertyGenerator>(GetHeader(framework, "Controls") + @"
[DependencyProperty<bool>(""ReadOnlyProperty"", IsReadOnly = true)]
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
    public Task DefaultBindingMode(Framework framework)
    {
        return CheckSourceAsync<DependencyPropertyGenerator>(GetHeader(framework, "Controls") + @"
[DependencyProperty<bool>(""IsSpinning"", DefaultBindingMode = DefaultBindingMode.OneTime)]
public partial class MyGrid : Grid
{
}", framework);
    }

    [DataTestMethod]
    [DataRow(Framework.Wpf)]
    [DataRow(Framework.Uno)]
    [DataRow(Framework.UnoWinUi)]
    [DataRow(Framework.Maui)]
    [DataRow(Framework.Avalonia)]
    public Task Direct(Framework framework)
    {
        return CheckSourceAsync<DependencyPropertyGenerator>(GetHeader(framework, "Controls") + @"
[DependencyProperty<bool>(""IsSpinning"", IsDirect = true)]
public partial class MyGrid : Grid
{
}", framework);
    }

    [DataTestMethod]
    [DataRow(Framework.Wpf)]
    [DataRow(Framework.Uno)]
    [DataRow(Framework.UnoWinUi)]
    [DataRow(Framework.Maui)]
    [DataRow(Framework.Avalonia)]
    public Task DirectReadOnly(Framework framework)
    {
        return CheckSourceAsync<DependencyPropertyGenerator>(GetHeader(framework, "Controls") + @"
[DependencyProperty<bool>(""IsSpinning"", IsDirect = true, IsReadOnly = true, EnableDataValidation = true)]
public partial class MyGrid : Grid
{
}", framework);
    }

    [DataTestMethod]
    [DataRow(Framework.Wpf)]
    [DataRow(Framework.Uno)]
    [DataRow(Framework.UnoWinUi)]
    [DataRow(Framework.Maui)]
    [DataRow(Framework.Avalonia)]
    public Task BindEvents(Framework framework)
    {
        return CheckSourceAsync<DependencyPropertyGenerator>(GetHeader(framework, string.Empty, "Input") + @"
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
}", framework, additionalGenerators: new StaticConstructorGenerator());
    }

    [DataTestMethod]
    [DataRow(Framework.Wpf)]
    [DataRow(Framework.Uno)]
    [DataRow(Framework.UnoWinUi)]
    [DataRow(Framework.Maui)]
    [DataRow(Framework.Avalonia)]
    public Task CustomOnChanged(Framework framework)
    {
        return CheckSourceAsync<DependencyPropertyGenerator>(GetHeader(framework, string.Empty) + @"
[DependencyProperty<string>(""Text"", OnChanged = nameof(OnMyTextChanged))]
public partial class Generatable : FrameworkElement
{
    protected virtual void OnMyTextChanged(string? value)
    {
    }
}", framework, additionalGenerators: new StaticConstructorGenerator());
    }

    [DataTestMethod]
    [DataRow(Framework.Wpf)]
    [DataRow(Framework.Uno)]
    [DataRow(Framework.UnoWinUi)]
    [DataRow(Framework.Maui)]
    [DataRow(Framework.Avalonia)]
    public Task NullableValueType(Framework framework)
    {
        return CheckSourceAsync<DependencyPropertyGenerator>(GetHeader(framework, string.Empty) + @"
[DependencyProperty<int?>(""Property"")]
public partial class Generatable : FrameworkElement
{
}", framework);
    }

    [DataTestMethod]
    [DataRow(Framework.Wpf)]
    [DataRow(Framework.Uno)]
    [DataRow(Framework.UnoWinUi)]
    [DataRow(Framework.Maui)]
    [DataRow(Framework.Avalonia)]
    public Task Dictionary(Framework framework)
    {
        return CheckSourceAsync<DependencyPropertyGenerator>(GetHeader(framework, string.Empty) + @"
[DependencyProperty<System.Collections.Generic.Dictionary<string, string>>(""Headers"", DefaultBindingMode = DefaultBindingMode.TwoWay)]
public partial class Generatable : FrameworkElement
{
}", framework);
    }

    [DataTestMethod]
    [DataRow(Framework.Wpf)]
    [DataRow(Framework.Uno)]
    [DataRow(Framework.UnoWinUi)]
    [DataRow(Framework.Maui)]
    [DataRow(Framework.Avalonia)]
    public Task SameNameDifferentNamespaces(Framework framework)
    {
        return CheckSourceAsync<DependencyPropertyGenerator>(GetHeader(framework, nullable: true, @namespace: false, string.Empty) + @"
namespace Namespace1
{
    [DependencyProperty<int>(""MyProperty"")]
    public partial class MyControl : FrameworkElement
    {
        public int MyPropertySqrt => MyProperty * MyProperty;
    }
}

namespace Namespace2
{
    [DependencyProperty<int>(""MyProperty"")]
    public partial class MyControl : FrameworkElement
    {
        public int MyPropertySqrt => MyProperty * MyProperty;
    }
}", framework);
    }

    [DataTestMethod]
    [DataRow(Framework.Wpf)]
    [DataRow(Framework.Uno)]
    [DataRow(Framework.UnoWinUi)]
    [DataRow(Framework.Maui)]
    [DataRow(Framework.Avalonia)]
    public Task PrimitiveTypeArray(Framework framework)
    {
        return CheckSourceAsync<DependencyPropertyGenerator>(GetHeader(framework, string.Empty) + @"
[DependencyProperty<double[]>(""Values"")]
public partial class MyControl : FrameworkElement
{
}", framework);
    }

    [DataTestMethod]
    [DataRow(Framework.Wpf)]
    [DataRow(Framework.Uno)]
    [DataRow(Framework.UnoWinUi)]
    [DataRow(Framework.Maui)]
    [DataRow(Framework.Avalonia)]
    public Task MultidimensionalArray(Framework framework)
    {
        return CheckSourceAsync<DependencyPropertyGenerator>(GetHeader(framework, string.Empty) + @"
[DependencyProperty<int[,,]>(""Values3"")]
public partial class MyControl : FrameworkElement
{
}", framework);
    }

    [DataTestMethod]
    [DataRow(Framework.Wpf)]
    [DataRow(Framework.Uno)]
    [DataRow(Framework.UnoWinUi)]
    [DataRow(Framework.Maui)]
    [DataRow(Framework.Avalonia)]
    public Task Tuples(Framework framework)
    {
        return CheckSourceAsync<DependencyPropertyGenerator>(GetHeader(framework, string.Empty) + @"
[DependencyProperty<(int, string)>(""TypeIntString"")]
[DependencyProperty<(FrameworkElement, int)>(""TypeControlInt"")]
[DependencyProperty<(int, FrameworkElement)>(""TypeIntControl"")]
[DependencyProperty<System.Tuple<int, string>>(""TupleIntString"")]
[DependencyProperty<System.Tuple<FrameworkElement, int>>(""TupleControlInt"")]
[DependencyProperty<System.Tuple<int, FrameworkElement>>(""TupleIntControl"")]
public partial class MyControl : FrameworkElement
{
}", framework);
    }
}