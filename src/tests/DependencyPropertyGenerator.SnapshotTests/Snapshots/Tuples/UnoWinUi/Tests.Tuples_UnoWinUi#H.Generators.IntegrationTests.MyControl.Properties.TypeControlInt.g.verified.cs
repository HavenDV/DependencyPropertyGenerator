//HintName: H.Generators.IntegrationTests.MyControl.Properties.TypeControlInt.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class MyControl
    {
        /// <summary>
        /// Identifies the <see cref="TypeControlInt"/> dependency property.<br/>
        /// Default value: default((FrameworkElement, int))
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        public static readonly global::Microsoft.UI.Xaml.DependencyProperty TypeControlIntProperty =
            global::Microsoft.UI.Xaml.DependencyProperty.Register(
                name: "TypeControlInt",
                propertyType: typeof((global::Microsoft.UI.Xaml.FrameworkElement, int)),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: new global::Microsoft.UI.Xaml.PropertyMetadata(
                    defaultValue: default((global::Microsoft.UI.Xaml.FrameworkElement, int)),
                    propertyChangedCallback: null));

        /// <summary>
        /// Default value: default((FrameworkElement, int))
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public (global::Microsoft.UI.Xaml.FrameworkElement, int) TypeControlInt
        {
            get => ((global::Microsoft.UI.Xaml.FrameworkElement, int))GetValue(TypeControlIntProperty);
            set => SetValue(TypeControlIntProperty, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        partial void OnTypeControlIntChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        partial void OnTypeControlIntChanged((global::Microsoft.UI.Xaml.FrameworkElement, int) newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        partial void OnTypeControlIntChanged((global::Microsoft.UI.Xaml.FrameworkElement, int) oldValue, (global::Microsoft.UI.Xaml.FrameworkElement, int) newValue);
    }
}