# DPGenerator
Dependency property source generator for WPF/UWP/WinUI/Uno platforms.

```cs
[DependencyProperty("IsSpinning", typeof(bool))]
public partial MainWindow
{
}
```
will generate:
```cs
public static readonly DependencyProperty IsSpinningProperty = DependencyProperty.Register(
    "IsSpinning",
    typeof(bool),
    typeof(MainWindow));

public bool IsSpinning
{
    get => (bool)GetValue(IsSpinningProperty);
    set => SetValue(IsSpinningProperty, value);
}
```
