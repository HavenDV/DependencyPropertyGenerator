//HintName: H.Generators.IntegrationTests.MyControl.Properties.IsSpinning2.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Identifies the <see cref="IsSpinning2"/> dependency property.<br/>
        /// Default value: default(bool)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        public static readonly global::Avalonia.StyledProperty<bool> IsSpinning2Property =
            global::Avalonia.AvaloniaProperty.Register<global::H.Generators.IntegrationTests.MyControl, bool>(
                name: "IsSpinning2",
                defaultValue: default(bool),
                inherits: false,
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                validate: null,
                coerce: null);

        /// <summary>
        /// Default value: default(bool)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public bool IsSpinning2
        {
            get => (bool)GetValue(IsSpinning2Property);
            set => SetValue(IsSpinning2Property, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnIsSpinning2Changed();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnIsSpinning2Changed(bool newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnIsSpinning2Changed(bool oldValue, bool newValue);
    }
}