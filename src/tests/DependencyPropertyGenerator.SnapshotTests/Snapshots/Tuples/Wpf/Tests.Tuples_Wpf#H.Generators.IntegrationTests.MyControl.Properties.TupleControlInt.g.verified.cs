//HintName: H.Generators.IntegrationTests.MyControl.Properties.TupleControlInt.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class MyControl
    {
        /// <summary>
        /// Identifies the <see cref="TupleControlInt"/> dependency property.<br/>
        /// Default value: default(Tuple&lt;FrameworkElement, int&gt;)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        public static readonly global::System.Windows.DependencyProperty TupleControlIntProperty =
            global::System.Windows.DependencyProperty.Register(
                name: "TupleControlInt",
                propertyType: typeof(global::System.Tuple<global::System.Windows.FrameworkElement, int>),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: default(global::System.Tuple<global::System.Windows.FrameworkElement, int>),
                    flags: global::System.Windows.FrameworkPropertyMetadataOptions.None,
                    propertyChangedCallback: null,
                    coerceValueCallback: null,
                    isAnimationProhibited: false),
                validateValueCallback: null);

        /// <summary>
        /// Default value: default(Tuple&lt;FrameworkElement, int&gt;)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::System.Tuple<global::System.Windows.FrameworkElement, int>? TupleControlInt
        {
            get => (global::System.Tuple<global::System.Windows.FrameworkElement, int>?)GetValue(TupleControlIntProperty);
            set => SetValue(TupleControlIntProperty, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        partial void OnTupleControlIntChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        partial void OnTupleControlIntChanged(global::System.Tuple<global::System.Windows.FrameworkElement, int>? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        partial void OnTupleControlIntChanged(global::System.Tuple<global::System.Windows.FrameworkElement, int>? oldValue, global::System.Tuple<global::System.Windows.FrameworkElement, int>? newValue);
    }
}