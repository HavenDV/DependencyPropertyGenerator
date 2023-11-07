//HintName: H.Generators.IntegrationTests.MyGrid.Properties.TupleControlInt.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class MyGrid
    {
        /// <summary>
        /// Identifies the <see cref="TupleControlInt"/> dependency property.<br/>
        /// Default value: default(Tuple&lt;VisualElement, int&gt;)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        public static readonly global::Microsoft.Maui.Controls.BindableProperty TupleControlIntProperty =
            global::Microsoft.Maui.Controls.BindableProperty.Create(
                propertyName: "TupleControlInt",
                returnType: typeof(global::System.Tuple<global::Microsoft.Maui.Controls.VisualElement, int>),
                declaringType: typeof(global::H.Generators.IntegrationTests.MyGrid),
                defaultValue: default(global::System.Tuple<global::Microsoft.Maui.Controls.VisualElement, int>),
                defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
                validateValue: null,
                propertyChanged: null,
                propertyChanging: null,
                coerceValue: null,
                defaultValueCreator: null);

        /// <summary>
        /// Default value: default(Tuple&lt;VisualElement, int&gt;)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::System.Tuple<global::Microsoft.Maui.Controls.VisualElement, int>? TupleControlInt
        {
            get => (global::System.Tuple<global::Microsoft.Maui.Controls.VisualElement, int>?)GetValue(TupleControlIntProperty);
            set => SetValue(TupleControlIntProperty, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnTupleControlIntChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnTupleControlIntChanged(global::System.Tuple<global::Microsoft.Maui.Controls.VisualElement, int>? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnTupleControlIntChanged(global::System.Tuple<global::Microsoft.Maui.Controls.VisualElement, int>? oldValue, global::System.Tuple<global::Microsoft.Maui.Controls.VisualElement, int>? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnTupleControlIntChanging();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnTupleControlIntChanging(global::System.Tuple<global::Microsoft.Maui.Controls.VisualElement, int>? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnTupleControlIntChanging(global::System.Tuple<global::Microsoft.Maui.Controls.VisualElement, int>? oldValue, global::System.Tuple<global::Microsoft.Maui.Controls.VisualElement, int>? newValue);
    }
}