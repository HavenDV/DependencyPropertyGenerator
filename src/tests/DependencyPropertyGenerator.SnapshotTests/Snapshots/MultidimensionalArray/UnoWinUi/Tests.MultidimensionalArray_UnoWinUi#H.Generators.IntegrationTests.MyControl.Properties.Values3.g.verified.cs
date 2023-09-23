//HintName: H.Generators.IntegrationTests.MyControl.Properties.Values3.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Identifies the <see cref="Values3"/> dependency property.<br/>
        /// Default value: default(int[,,])
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        public static readonly global::Microsoft.UI.Xaml.DependencyProperty Values3Property =
            global::Microsoft.UI.Xaml.DependencyProperty.Register(
                name: "Values3",
                propertyType: typeof(int[,,]),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: new global::Microsoft.UI.Xaml.PropertyMetadata(
                    defaultValue: default(int[,,]),
                    propertyChangedCallback: null));

        /// <summary>
        /// Default value: default(int[,,])
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public int[,,]? Values3
        {
            get => (int[,,]?)GetValue(Values3Property);
            set => SetValue(Values3Property, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnValues3Changed();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnValues3Changed(int[,,]? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnValues3Changed(int[,,]? oldValue, int[,,]? newValue);
    }
}