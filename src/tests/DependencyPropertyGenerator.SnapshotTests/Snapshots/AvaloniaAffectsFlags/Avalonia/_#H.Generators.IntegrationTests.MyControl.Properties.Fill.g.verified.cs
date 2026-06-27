//HintName: H.Generators.IntegrationTests.MyControl.Properties.Fill.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class MyControl
    {
        /// <summary>
        /// Identifies the <see cref="Fill"/> dependency property.<br/>
        /// Default value: default(IBrush)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        public static readonly global::Avalonia.StyledProperty<global::Avalonia.Media.IBrush?> FillProperty =
            global::Avalonia.AvaloniaProperty.Register<global::H.Generators.IntegrationTests.MyControl, global::Avalonia.Media.IBrush?>(
                name: "Fill",
                defaultValue: default(global::Avalonia.Media.IBrush),
                inherits: false,
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                validate: null,
                coerce: null);

        /// <summary>
        /// Default value: default(IBrush)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::Avalonia.Media.IBrush? Fill
        {
            get => (global::Avalonia.Media.IBrush?)GetValue(FillProperty);
            set => SetValue(FillProperty, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        partial void OnFillChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        partial void OnFillChanged(global::Avalonia.Media.IBrush? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        partial void OnFillChanged(global::Avalonia.Media.IBrush? oldValue, global::Avalonia.Media.IBrush? newValue);
    }
}