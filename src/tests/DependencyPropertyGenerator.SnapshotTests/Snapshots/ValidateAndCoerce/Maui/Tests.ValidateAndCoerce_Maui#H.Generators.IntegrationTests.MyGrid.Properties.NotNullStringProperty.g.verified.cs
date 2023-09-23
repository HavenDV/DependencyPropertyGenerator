//HintName: H.Generators.IntegrationTests.MyGrid.Properties.NotNullStringProperty.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyGrid
    {
        /// <summary>
        /// Identifies the <see cref="NotNullStringProperty"/> dependency property.<br/>
        /// Default value: ""
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        public static readonly global::Microsoft.Maui.Controls.BindableProperty NotNullStringPropertyProperty =
            global::Microsoft.Maui.Controls.BindableProperty.Create(
                propertyName: "NotNullStringProperty",
                returnType: typeof(string),
                declaringType: typeof(global::H.Generators.IntegrationTests.MyGrid),
                defaultValue: (string)"",
                defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
                validateValue: static (_, value) =>
                    IsNotNullStringPropertyValid(
                        (string?)value),
                propertyChanged: null,
                propertyChanging: null,
                coerceValue: static (sender, value) =>
                        ((global::H.Generators.IntegrationTests.MyGrid)sender).CoerceNotNullStringProperty(
                            (string?)value),
                defaultValueCreator: null);

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
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnNotNullStringPropertyChanging();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnNotNullStringPropertyChanging(string? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnNotNullStringPropertyChanging(string? oldValue, string? newValue);
        private partial string? CoerceNotNullStringProperty(string? value);
        private static partial bool IsNotNullStringPropertyValid(string? value);
    }
}