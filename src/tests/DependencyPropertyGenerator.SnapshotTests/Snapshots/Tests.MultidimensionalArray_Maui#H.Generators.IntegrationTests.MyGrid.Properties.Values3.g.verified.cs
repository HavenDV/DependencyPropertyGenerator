//HintName: H.Generators.IntegrationTests.MyGrid.Properties.Values3.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyGrid
    {
        /// <summary>
        /// Identifies the <see cref="Values3"/> dependency property.<br/>
        /// Default value: default(int[,,])
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        public static readonly global::Microsoft.Maui.Controls.BindableProperty Values3Property =
            global::Microsoft.Maui.Controls.BindableProperty.Create(
                propertyName: "Values3",
                returnType: typeof(int[,,]),
                declaringType: typeof(global::H.Generators.IntegrationTests.MyGrid),
                defaultValue: default(int[,,]),
                defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
                validateValue: null,
                propertyChanged: null,
                propertyChanging: null,
                coerceValue: null,
                defaultValueCreator: null);

        /// <summary>
        /// Default value: default(int[,,])
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public int[,,]? Values3
        {
            get => (int[,,]?)GetValue(Values3Property);
            set => SetValue(Values3Property, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnValues3Changed();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnValues3Changed(int[,,]? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnValues3Changed(int[,,]? oldValue, int[,,]? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnValues3Changing();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnValues3Changing(int[,,]? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnValues3Changing(int[,,]? oldValue, int[,,]? newValue);
    }
}