//HintName: H.Generators.IntegrationTests.MyControl.Properties.TypeIntControl.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class MyControl
    {
        /// <summary>
        /// Identifies the <see cref="TypeIntControl"/> dependency property.<br/>
        /// Default value: default((int, FrameworkElement))
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        public static readonly global::Windows.UI.Xaml.DependencyProperty TypeIntControlProperty =
            global::Windows.UI.Xaml.DependencyProperty.Register(
                name: "TypeIntControl",
                propertyType: typeof((int, global::Windows.UI.Xaml.FrameworkElement)),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: new global::Windows.UI.Xaml.PropertyMetadata(
                    defaultValue: default((int, global::Windows.UI.Xaml.FrameworkElement)),
                    propertyChangedCallback: null));

        /// <summary>
        /// Default value: default((int, FrameworkElement))
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public (int, global::Windows.UI.Xaml.FrameworkElement) TypeIntControl
        {
            get => ((int, global::Windows.UI.Xaml.FrameworkElement))GetValue(TypeIntControlProperty);
            set => SetValue(TypeIntControlProperty, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnTypeIntControlChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnTypeIntControlChanged((int, global::Windows.UI.Xaml.FrameworkElement) newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnTypeIntControlChanged((int, global::Windows.UI.Xaml.FrameworkElement) oldValue, (int, global::Windows.UI.Xaml.FrameworkElement) newValue);
    }
}