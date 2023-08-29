//HintName: H.Generators.IntegrationTests.MyControl.Properties.TupleIntControl.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Identifies the <see cref="TupleIntControl"/> dependency property.<br/>
        /// Default value: default(Tuple&lt;int, FrameworkElement&gt;)
        /// </summary>
        public static readonly global::System.Windows.DependencyProperty TupleIntControlProperty =
            global::System.Windows.DependencyProperty.Register(
                name: "TupleIntControl",
                propertyType: typeof(global::System.Tuple<int, global::System.Windows.FrameworkElement>),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: default(global::System.Tuple<int, global::System.Windows.FrameworkElement>),
                    flags: global::System.Windows.FrameworkPropertyMetadataOptions.None,
                    propertyChangedCallback: null,
                    coerceValueCallback: null,
                    isAnimationProhibited: false),
                validateValueCallback: null);

        /// <summary>
        /// Default value: default(Tuple&lt;int, FrameworkElement&gt;)
        /// </summary>
        public global::System.Tuple<int, global::System.Windows.FrameworkElement>? TupleIntControl
        {
            get => (global::System.Tuple<int, global::System.Windows.FrameworkElement>?)GetValue(TupleIntControlProperty);
            set => SetValue(TupleIntControlProperty, value);
        }

        partial void OnTupleIntControlChanged();
        partial void OnTupleIntControlChanged(global::System.Tuple<int, global::System.Windows.FrameworkElement>? newValue);
        partial void OnTupleIntControlChanged(global::System.Tuple<int, global::System.Windows.FrameworkElement>? oldValue, global::System.Tuple<int, global::System.Windows.FrameworkElement>? newValue);
    }
}