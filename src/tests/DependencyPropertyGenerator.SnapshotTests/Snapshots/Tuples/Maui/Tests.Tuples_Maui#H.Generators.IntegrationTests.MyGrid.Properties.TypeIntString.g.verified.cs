//HintName: H.Generators.IntegrationTests.MyGrid.Properties.TypeIntString.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class MyGrid
    {
        /// <summary>
        /// Identifies the <see cref="TypeIntString"/> dependency property.<br/>
        /// Default value: default((int, string))
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        public static readonly global::Microsoft.Maui.Controls.BindableProperty TypeIntStringProperty =
            global::Microsoft.Maui.Controls.BindableProperty.Create(
                propertyName: "TypeIntString",
                returnType: typeof((int, string)),
                declaringType: typeof(global::H.Generators.IntegrationTests.MyGrid),
                defaultValue: default((int, string)),
                defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
                validateValue: null,
                propertyChanged: null,
                propertyChanging: null,
                coerceValue: null,
                defaultValueCreator: null);

        /// <summary>
        /// Default value: default((int, string))
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public (int, string) TypeIntString
        {
            get => ((int, string))GetValue(TypeIntStringProperty);
            set => SetValue(TypeIntStringProperty, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnTypeIntStringChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnTypeIntStringChanged((int, string) newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnTypeIntStringChanged((int, string) oldValue, (int, string) newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnTypeIntStringChanging();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnTypeIntStringChanging((int, string) newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnTypeIntStringChanging((int, string) oldValue, (int, string) newValue);
    }
}