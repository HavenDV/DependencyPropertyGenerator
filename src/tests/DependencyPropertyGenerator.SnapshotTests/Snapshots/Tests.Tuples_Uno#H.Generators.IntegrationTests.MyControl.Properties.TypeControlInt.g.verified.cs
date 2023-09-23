//HintName: H.Generators.IntegrationTests.MyControl.Properties.TypeControlInt.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Identifies the <see cref="TypeControlInt"/> dependency property.<br/>
        /// Default value: default((FrameworkElement, int))
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        public static readonly global::Windows.UI.Xaml.DependencyProperty TypeControlIntProperty =
            global::Windows.UI.Xaml.DependencyProperty.Register(
                name: "TypeControlInt",
                propertyType: typeof((global::Windows.UI.Xaml.FrameworkElement, int)),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: new global::Windows.UI.Xaml.PropertyMetadata(
                    defaultValue: default((global::Windows.UI.Xaml.FrameworkElement, int)),
                    propertyChangedCallback: null));

        /// <summary>
        /// Default value: default((FrameworkElement, int))
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public (global::Windows.UI.Xaml.FrameworkElement, int) TypeControlInt
        {
            get => ((global::Windows.UI.Xaml.FrameworkElement, int))GetValue(TypeControlIntProperty);
            set => SetValue(TypeControlIntProperty, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnTypeControlIntChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnTypeControlIntChanged((global::Windows.UI.Xaml.FrameworkElement, int) newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnTypeControlIntChanged((global::Windows.UI.Xaml.FrameworkElement, int) oldValue, (global::Windows.UI.Xaml.FrameworkElement, int) newValue);
    }
}