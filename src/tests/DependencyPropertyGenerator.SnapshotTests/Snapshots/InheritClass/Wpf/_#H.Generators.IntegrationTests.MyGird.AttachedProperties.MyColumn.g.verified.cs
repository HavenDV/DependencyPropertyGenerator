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
        public static readonly global::System.Windows.DependencyProperty MyColumnProperty =
            global::System.Windows.DependencyProperty.RegisterAttached(
                name: "MyColumn",
                propertyType: typeof(int),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyGird),
                defaultMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: default(int),
                    flags: global::System.Windows.FrameworkPropertyMetadataOptions.None,
                    propertyChangedCallback: null,
                    coerceValueCallback: null,
                    isAnimationProhibited: false),
                validateValueCallback: null);

        /// <summary>
        /// Default value: default(int)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static void SetMyColumn(global::System.Windows.DependencyObject element, int value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(MyColumnProperty, value);
        }

        /// <summary>
        /// Default value: default(int)
        /// </summary>
        [global::System.Windows.AttachedPropertyBrowsableForType(typeof(global::System.Windows.FrameworkElement))]
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static int GetMyColumn(global::System.Windows.DependencyObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (int)element.GetValue(MyColumnProperty);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnMyColumnChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnMyColumnChanged(global::System.Windows.FrameworkElement frameworkElement);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnMyColumnChanged(global::System.Windows.FrameworkElement frameworkElement, int newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnMyColumnChanged(global::System.Windows.FrameworkElement frameworkElement, int oldValue, int newValue);
    }
}