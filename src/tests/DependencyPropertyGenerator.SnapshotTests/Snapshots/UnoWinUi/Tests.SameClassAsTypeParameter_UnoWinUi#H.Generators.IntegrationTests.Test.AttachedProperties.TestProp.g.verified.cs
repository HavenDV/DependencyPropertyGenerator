//HintName: H.Generators.IntegrationTests.Test.AttachedProperties.TestProp.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class Test
    {
        /// <summary>
        /// Identifies the TestProp dependency property.<br/>
        /// Default value: default(Test)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        public static readonly global::Microsoft.UI.Xaml.DependencyProperty TestPropProperty =
            global::Microsoft.UI.Xaml.DependencyProperty.RegisterAttached(
                name: "TestProp",
                propertyType: typeof(global::H.Generators.IntegrationTests.Test),
                ownerType: typeof(global::H.Generators.IntegrationTests.Test),
                new global::Microsoft.UI.Xaml.PropertyMetadata(
                    defaultValue: default(global::H.Generators.IntegrationTests.Test),
                    propertyChangedCallback: static (sender, args) =>
                    {
                        TestChanged(
                            (global::Microsoft.UI.Xaml.Controls.Grid)sender,
                            (global::H.Generators.IntegrationTests.Test?)args.NewValue);
                    }));

        /// <summary>
        /// Default value: default(Test)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static void SetTestProp(global::Microsoft.UI.Xaml.DependencyObject element, global::H.Generators.IntegrationTests.Test? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(TestPropProperty, value);
        }

        /// <summary>
        /// Default value: default(Test)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static global::H.Generators.IntegrationTests.Test? GetTestProp(global::Microsoft.UI.Xaml.DependencyObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (global::H.Generators.IntegrationTests.Test?)element.GetValue(TestPropProperty);
        }

    }
}