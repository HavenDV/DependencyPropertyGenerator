//HintName: H.Generators.IntegrationTests.MyControl.Properties.TupleIntString.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Identifies the <see cref="TupleIntString"/> dependency property.<br/>
        /// Default value: default(Tuple&lt;int, string&gt;)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        public static readonly global::Windows.UI.Xaml.DependencyProperty TupleIntStringProperty =
            global::Windows.UI.Xaml.DependencyProperty.Register(
                name: "TupleIntString",
                propertyType: typeof(global::System.Tuple<int, string>),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: new global::Windows.UI.Xaml.PropertyMetadata(
                    defaultValue: default(global::System.Tuple<int, string>),
                    propertyChangedCallback: null));

        /// <summary>
        /// Default value: default(Tuple&lt;int, string&gt;)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::System.Tuple<int, string>? TupleIntString
        {
            get => (global::System.Tuple<int, string>?)GetValue(TupleIntStringProperty);
            set => SetValue(TupleIntStringProperty, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnTupleIntStringChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnTupleIntStringChanged(global::System.Tuple<int, string>? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnTupleIntStringChanged(global::System.Tuple<int, string>? oldValue, global::System.Tuple<int, string>? newValue);
    }
}