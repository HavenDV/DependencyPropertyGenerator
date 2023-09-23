//HintName: H.Generators.IntegrationTests.MyGrid.Properties.SomeProperty.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyGrid
    {
        /// <summary>
        /// Identifies the <see cref="SomeProperty"/> dependency property.<br/>
        /// Default value: default(string)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        public static readonly global::System.Windows.DependencyProperty SomePropertyProperty =
            global::System.Windows.DependencyProperty.Register(
                name: "SomeProperty",
                propertyType: typeof(string),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyGrid),
                typeMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: default(string),
                    flags: global::System.Windows.FrameworkPropertyMetadataOptions.None,
                    propertyChangedCallback: null,
                    coerceValueCallback: null,
                    isAnimationProhibited: false),
                validateValueCallback: null);

        /// <summary>
        /// Default value: default(string)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public string? SomeProperty
        {
            get => (string?)GetValue(SomePropertyProperty);
            set => SetValue(SomePropertyProperty, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnSomePropertyChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnSomePropertyChanged(string? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnSomePropertyChanged(string? oldValue, string? newValue);
        private static partial string? GetSomePropertyDefaultValue();
    }
}