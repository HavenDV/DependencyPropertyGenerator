//HintName: MainWindow_DependencyProperties.generated.cs

#nullable enable

namespace H.Ipc.Apps.Wpf
{
    public partial class MainWindow
    {
        public static readonly global::System.Windows.DependencyProperty IsSpinningProperty =
            global::System.Windows.DependencyProperty.Register(
                "IsSpinning",
                 typeof(bool),
                 typeof(MainWindow));

        public bool IsSpinning
        {
            get => (bool)GetValue(IsSpinningProperty);
            set => SetValue(IsSpinningProperty, value);
        }
    }
}