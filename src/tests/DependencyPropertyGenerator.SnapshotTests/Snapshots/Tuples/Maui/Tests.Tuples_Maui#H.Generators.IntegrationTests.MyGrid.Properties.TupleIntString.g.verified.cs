//HintName: H.Generators.IntegrationTests.MyGrid.Properties.TupleIntString.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class MyGrid
    {
        /// <summary>
        /// Identifies the <see cref="TupleIntString"/> dependency property.<br/>
        /// Default value: default(Tuple&lt;int, string&gt;)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        public static readonly global::Microsoft.Maui.Controls.BindableProperty TupleIntStringProperty =
            global::Microsoft.Maui.Controls.BindableProperty.Create(
                propertyName: "TupleIntString",
                returnType: typeof(global::System.Tuple<int, string>),
                declaringType: typeof(global::H.Generators.IntegrationTests.MyGrid),
                defaultValue: default(global::System.Tuple<int, string>),
                defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
                validateValue: null,
                propertyChanged: null,
                propertyChanging: null,
                coerceValue: null,
                defaultValueCreator: null);

        /// <summary>
        /// Default value: default(Tuple&lt;int, string&gt;)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::System.Tuple<int, string>? TupleIntString
        {
            get => (global::System.Tuple<int, string>?)GetValue(TupleIntStringProperty);
            set => SetValue(TupleIntStringProperty, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        partial void OnTupleIntStringChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        partial void OnTupleIntStringChanged(global::System.Tuple<int, string>? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        partial void OnTupleIntStringChanged(global::System.Tuple<int, string>? oldValue, global::System.Tuple<int, string>? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        partial void OnTupleIntStringChanging();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        partial void OnTupleIntStringChanging(global::System.Tuple<int, string>? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        partial void OnTupleIntStringChanging(global::System.Tuple<int, string>? oldValue, global::System.Tuple<int, string>? newValue);
    }
}