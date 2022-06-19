//HintName: MainWindow_AttachedDependencyProperties.generated.cs

#nullable enable

namespace H.Ipc.Apps.Wpf
{
    public partial class MainWindow
    {
        public static readonly global::System.Windows.DependencyProperty IsBubbleSourceProperty =
            global::System.Windows.DependencyProperty.RegisterAttached(
                "IsBubbleSource",
                typeof(bool),
                typeof(MainWindow));
  
        public static void SetIsBubbleSource(global::System.Windows.UIElement element, bool value)
        {
            element.SetValue(IsBubbleSourceProperty, value);
        }

        public static bool GetIsBubbleSource(global::System.Windows.UIElement element)
        {
            return (bool)element.GetValue(IsBubbleSourceProperty);
        }
    }
}