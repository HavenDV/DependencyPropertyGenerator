# DPGenerator
Dependency property source generator for WPF/UWP/WinUI/Uno platforms.

### Dependency property
```cs
[DependencyProperty("IsSpinning", typeof(bool))]
public partial class MainWindow
{
}
```
will generate:
```cs
public static readonly DependencyProperty IsSpinningProperty =
    DependencyProperty.Register(
        "IsSpinning",
         typeof(bool),
         typeof(MainWindow));

public bool IsSpinning
{
    get => (bool)GetValue(IsSpinningProperty);
    set => SetValue(IsSpinningProperty, value);
}
```

### Attached Dependency Property
```cs
[AttachedDependencyProperty("IsBubbleSource", typeof(bool))]
public partial static class AquariumObject2
{
}
```
will generate:
```cs
public static readonly DependencyProperty IsBubbleSourceProperty =
    DependencyProperty.RegisterAttached(
        "IsBubbleSource",
        typeof(bool),
        typeof(AquariumObject2));
  
public static void SetIsBubbleSource(UIElement element, bool value)
{
    element.SetValue(IsBubbleSourceProperty, value);
}

public static bool GetIsBubbleSource(UIElement element)
{
    return (bool)element.GetValue(IsBubbleSourceProperty);
}
```
