//HintName: H.Generators.IntegrationTests.Test.AttachedProperties.TestProp.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class Test
    {
        /// <summary>
        /// Identifies the TestProp dependency property.<br/>
        /// Default value: default(Test)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        public static readonly global::System.Windows.DependencyProperty TestPropProperty =
            global::System.Windows.DependencyProperty.RegisterAttached(
                name: "TestProp",
                propertyType: typeof(global::H.Generators.IntegrationTests.Test),
                ownerType: typeof(global::H.Generators.IntegrationTests.Test),
                defaultMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: default(global::H.Generators.IntegrationTests.Test),
                    flags: global::System.Windows.FrameworkPropertyMetadataOptions.None,
                    propertyChangedCallback: static (sender, args) =>
                    {
                        TestChanged(
                            (global::System.Windows.Controls.Grid)sender,
                            (global::H.Generators.IntegrationTests.Test?)args.NewValue);
                    },
                    coerceValueCallback: null,
                    isAnimationProhibited: false),
                validateValueCallback: null);

        /// <summary>
        /// Default value: default(Test)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static void SetTestProp(global::System.Windows.DependencyObject element, global::H.Generators.IntegrationTests.Test? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(TestPropProperty, value);
        }

        /// <summary>
        /// Default value: default(Test)
        /// </summary>
        [global::System.Windows.AttachedPropertyBrowsableForType(typeof(global::System.Windows.Controls.Grid))]
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static global::H.Generators.IntegrationTests.Test? GetTestProp(global::System.Windows.DependencyObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (global::H.Generators.IntegrationTests.Test?)element.GetValue(TestPropProperty);
        }

    }
}