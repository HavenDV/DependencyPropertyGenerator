//HintName: H.Generators.IntegrationTests.MyGrid.Properties.SomeProperty.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class MyGrid
    {
        /// <summary>
        /// Identifies the <see cref="SomeProperty"/> dependency property.<br/>
        /// Default value: default(string)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        public static readonly global::Avalonia.StyledProperty<string?> SomePropertyProperty =
            global::Avalonia.AvaloniaProperty.Register<global::H.Generators.IntegrationTests.MyGrid, string?>(
                name: "SomeProperty",
                defaultValue: default(string),
                inherits: false,
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                validate: null,
                coerce: null);

        /// <summary>
        /// Default value: default(string)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public string? SomeProperty
        {
            get => (string?)GetValue(SomePropertyProperty);
            set => SetValue(SomePropertyProperty, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnSomePropertyChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnSomePropertyChanged(string? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnSomePropertyChanged(string? oldValue, string? newValue);
        private static partial string? GetSomePropertyDefaultValue();
    }
}