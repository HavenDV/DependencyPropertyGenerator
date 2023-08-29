//HintName: H.Generators.IntegrationTests.MyControl.Properties.TupleControlInt.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Identifies the <see cref="TupleControlInt"/> dependency property.<br/>
        /// Default value: default(Tuple&lt;FrameworkElement, int&gt;)
        /// </summary>
        public static readonly global::Microsoft.UI.Xaml.DependencyProperty TupleControlIntProperty =
            global::Microsoft.UI.Xaml.DependencyProperty.Register(
                name: "TupleControlInt",
                propertyType: typeof(global::System.Tuple<global::Microsoft.UI.Xaml.FrameworkElement, int>),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: new global::Microsoft.UI.Xaml.PropertyMetadata(
                    defaultValue: default(global::System.Tuple<global::Microsoft.UI.Xaml.FrameworkElement, int>),
                    propertyChangedCallback: null));

        /// <summary>
        /// Default value: default(Tuple&lt;FrameworkElement, int&gt;)
        /// </summary>
        public global::System.Tuple<global::Microsoft.UI.Xaml.FrameworkElement, int>? TupleControlInt
        {
            get => (global::System.Tuple<global::Microsoft.UI.Xaml.FrameworkElement, int>?)GetValue(TupleControlIntProperty);
            set => SetValue(TupleControlIntProperty, value);
        }

        partial void OnTupleControlIntChanged();
        partial void OnTupleControlIntChanged(global::System.Tuple<global::Microsoft.UI.Xaml.FrameworkElement, int>? newValue);
        partial void OnTupleControlIntChanged(global::System.Tuple<global::Microsoft.UI.Xaml.FrameworkElement, int>? oldValue, global::System.Tuple<global::Microsoft.UI.Xaml.FrameworkElement, int>? newValue);
    }
}