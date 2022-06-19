//HintName: MainWindow_AttachedDependencyProperties.generated.cs

#nullable enable

namespace H.Ipc.Apps.Wpf
{
    public partial class MainWindow
    {
        public static readonly global::System.Windows.DependencyProperty IsBubbleSourceProperty =
            global::System.Windows.DependencyProperty.RegisterAttached(
                name: "IsBubbleSource",
                propertyType: typeof(bool),
                ownerType: typeof(MainWindow),
                defaultMetadata: new global::System.Windows.PropertyMetadata(
                    true,
                    static (sender, args) => OnIsBubbleSourceChanged((System.Windows.Controls.TreeView)sender, args)));
  
        public static void SetIsBubbleSource(global::System.Windows.DependencyObject element, bool value)
        {
            element.SetValue(IsBubbleSourceProperty, value);
        }

        [global::System.Windows.AttachedPropertyBrowsableForType(typeof(System.Windows.Controls.TreeView))]
        public static bool GetIsBubbleSource(global::System.Windows.DependencyObject element)
        {
            return (bool)element.GetValue(IsBubbleSourceProperty);
        }

        static partial void OnIsBubbleSourceChanged(System.Windows.Controls.TreeView sender, global::System.Windows.DependencyPropertyChangedEventArgs args);
    }
}