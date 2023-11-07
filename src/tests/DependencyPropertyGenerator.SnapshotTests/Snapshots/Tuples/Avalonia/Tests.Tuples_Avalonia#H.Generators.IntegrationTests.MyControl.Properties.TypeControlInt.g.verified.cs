//HintName: H.Generators.IntegrationTests.MyControl.Properties.TypeControlInt.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class MyControl
    {
        /// <summary>
        /// Identifies the <see cref="TypeControlInt"/> dependency property.<br/>
        /// Default value: default((Control, int))
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        public static readonly global::Avalonia.StyledProperty<(global::Avalonia.Controls.Control, int)> TypeControlIntProperty =
            global::Avalonia.AvaloniaProperty.Register<global::H.Generators.IntegrationTests.MyControl, (global::Avalonia.Controls.Control, int)>(
                name: "TypeControlInt",
                defaultValue: default((global::Avalonia.Controls.Control, int)),
                inherits: false,
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                validate: null,
                coerce: null);

        /// <summary>
        /// Default value: default((Control, int))
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public (global::Avalonia.Controls.Control, int) TypeControlInt
        {
            get => ((global::Avalonia.Controls.Control, int))GetValue(TypeControlIntProperty);
            set => SetValue(TypeControlIntProperty, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnTypeControlIntChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnTypeControlIntChanged((global::Avalonia.Controls.Control, int) newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnTypeControlIntChanged((global::Avalonia.Controls.Control, int) oldValue, (global::Avalonia.Controls.Control, int) newValue);
    }
}