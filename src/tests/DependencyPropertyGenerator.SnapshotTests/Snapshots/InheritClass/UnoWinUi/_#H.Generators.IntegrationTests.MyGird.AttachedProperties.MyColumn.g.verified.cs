//HintName: H.Generators.IntegrationTests.MyGird.AttachedProperties.MyColumn.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class MyGird
    {
        /// <summary>
        /// Identifies the MyColumn dependency property.<br/>
        /// Default value: default(int)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        public static readonly global::Microsoft.UI.Xaml.DependencyProperty MyColumnProperty =
            global::Microsoft.UI.Xaml.DependencyProperty.RegisterAttached(
                name: "MyColumn",
                propertyType: typeof(int),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyGird),
                new global::Microsoft.UI.Xaml.PropertyMetadata(
                    defaultValue: default(int),
                    propertyChangedCallback: null));

        /// <summary>
        /// Default value: default(int)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static void SetMyColumn(global::Microsoft.UI.Xaml.DependencyObject element, int value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(MyColumnProperty, value);
        }

        /// <summary>
        /// Default value: default(int)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static int GetMyColumn(global::Microsoft.UI.Xaml.DependencyObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (int)element.GetValue(MyColumnProperty);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnMyColumnChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnMyColumnChanged(global::Microsoft.UI.Xaml.FrameworkElement frameworkElement);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnMyColumnChanged(global::Microsoft.UI.Xaml.FrameworkElement frameworkElement, int newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnMyColumnChanged(global::Microsoft.UI.Xaml.FrameworkElement frameworkElement, int oldValue, int newValue);
    }
}