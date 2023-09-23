//HintName: H.Generators.IntegrationTests.MyControl.Properties.TupleControlInt.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Identifies the <see cref="TupleControlInt"/> dependency property.<br/>
        /// Default value: default(Tuple&lt;Control, int&gt;)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        public static readonly global::Avalonia.StyledProperty<global::System.Tuple<global::Avalonia.Controls.Control, int>?> TupleControlIntProperty =
            global::Avalonia.AvaloniaProperty.Register<global::H.Generators.IntegrationTests.MyControl, global::System.Tuple<global::Avalonia.Controls.Control, int>?>(
                name: "TupleControlInt",
                defaultValue: default(global::System.Tuple<global::Avalonia.Controls.Control, int>),
                inherits: false,
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                validate: null,
                coerce: null);

        /// <summary>
        /// Default value: default(Tuple&lt;Control, int&gt;)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::System.Tuple<global::Avalonia.Controls.Control, int>? TupleControlInt
        {
            get => (global::System.Tuple<global::Avalonia.Controls.Control, int>?)GetValue(TupleControlIntProperty);
            set => SetValue(TupleControlIntProperty, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnTupleControlIntChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnTupleControlIntChanged(global::System.Tuple<global::Avalonia.Controls.Control, int>? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnTupleControlIntChanged(global::System.Tuple<global::Avalonia.Controls.Control, int>? oldValue, global::System.Tuple<global::Avalonia.Controls.Control, int>? newValue);
    }
}