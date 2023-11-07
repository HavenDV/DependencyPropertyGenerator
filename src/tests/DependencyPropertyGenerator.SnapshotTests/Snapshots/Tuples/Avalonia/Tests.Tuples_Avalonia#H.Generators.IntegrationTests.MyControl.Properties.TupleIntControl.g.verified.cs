//HintName: H.Generators.IntegrationTests.MyControl.Properties.TupleIntControl.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class MyControl
    {
        /// <summary>
        /// Identifies the <see cref="TupleIntControl"/> dependency property.<br/>
        /// Default value: default(Tuple&lt;int, Control&gt;)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        public static readonly global::Avalonia.StyledProperty<global::System.Tuple<int, global::Avalonia.Controls.Control>?> TupleIntControlProperty =
            global::Avalonia.AvaloniaProperty.Register<global::H.Generators.IntegrationTests.MyControl, global::System.Tuple<int, global::Avalonia.Controls.Control>?>(
                name: "TupleIntControl",
                defaultValue: default(global::System.Tuple<int, global::Avalonia.Controls.Control>),
                inherits: false,
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                validate: null,
                coerce: null);

        /// <summary>
        /// Default value: default(Tuple&lt;int, Control&gt;)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::System.Tuple<int, global::Avalonia.Controls.Control>? TupleIntControl
        {
            get => (global::System.Tuple<int, global::Avalonia.Controls.Control>?)GetValue(TupleIntControlProperty);
            set => SetValue(TupleIntControlProperty, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnTupleIntControlChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnTupleIntControlChanged(global::System.Tuple<int, global::Avalonia.Controls.Control>? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnTupleIntControlChanged(global::System.Tuple<int, global::Avalonia.Controls.Control>? oldValue, global::System.Tuple<int, global::Avalonia.Controls.Control>? newValue);
    }
}