//HintName: H.Generators.IntegrationTests.MyControl.Properties.NotNullStringProperty.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class MyControl
    {
        /// <summary>
        /// Identifies the <see cref="NotNullStringProperty"/> dependency property.<br/>
        /// Default value: ""
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        public static readonly global::System.Windows.DependencyProperty NotNullStringPropertyProperty =
            global::System.Windows.DependencyProperty.Register(
                name: "NotNullStringProperty",
                propertyType: typeof(string),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: (string)"",
                    flags: global::System.Windows.FrameworkPropertyMetadataOptions.None,
                    propertyChangedCallback: null,
                    coerceValueCallback: static (sender, value) =>
                        ((global::H.Generators.IntegrationTests.MyControl)sender).CoerceNotNullStringProperty(
                            (string?)value),
                    isAnimationProhibited: false),
                validateValueCallback: static value =>
                    IsNotNullStringPropertyValid(
                        (string?)value));

        /// <summary>
        /// Default value: ""
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public string? NotNullStringProperty
        {
            get => (string?)GetValue(NotNullStringPropertyProperty);
            set => SetValue(NotNullStringPropertyProperty, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnNotNullStringPropertyChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnNotNullStringPropertyChanged(string? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnNotNullStringPropertyChanged(string? oldValue, string? newValue);
        private partial string? CoerceNotNullStringProperty(string? value);
        private static partial bool IsNotNullStringPropertyValid(string? value);
    }
}