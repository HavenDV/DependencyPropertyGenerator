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
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
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
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::System.Tuple<int, global::System.Windows.FrameworkElement>? TupleIntControl
        {
            get => (global::System.Tuple<int, global::System.Windows.FrameworkElement>?)GetValue(TupleIntControlProperty);
            set => SetValue(TupleIntControlProperty, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnTupleIntControlChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnTupleIntControlChanged(global::System.Tuple<int, global::System.Windows.FrameworkElement>? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnTupleIntControlChanged(global::System.Tuple<int, global::System.Windows.FrameworkElement>? oldValue, global::System.Tuple<int, global::System.Windows.FrameworkElement>? newValue);
    }
}