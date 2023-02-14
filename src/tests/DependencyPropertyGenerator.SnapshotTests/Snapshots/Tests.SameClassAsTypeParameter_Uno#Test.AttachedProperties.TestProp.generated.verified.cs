//HintName: Test.AttachedProperties.TestProp.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class Test
    {
        /// <summary>
        /// Identifies the TestProp dependency property.<br/>
        /// Default value: default(Test)
        /// </summary>
        public static readonly global::Windows.UI.Xaml.DependencyProperty TestPropProperty =
            global::Windows.UI.Xaml.DependencyProperty.RegisterAttached(
                name: "TestProp",
                propertyType: typeof(global::H.Generators.IntegrationTests.Test),
                ownerType: typeof(global::H.Generators.IntegrationTests.Test),
                typeMetadata: new global::Windows.UI.Xaml.PropertyMetadata(
                    defaultValue: default(global::H.Generators.IntegrationTests.Test),
                    propertyChangedCallback: static (sender, args) =>
                    {
                        TestChanged(
                            (global::Windows.UI.Xaml.Controls.Grid)sender,
                            (global::H.Generators.IntegrationTests.Test?)args.NewValue);
                    }));

        /// <summary>
        /// Default value: default(Test)
        /// </summary>
        public static void SetTestProp(global::Windows.UI.Xaml.DependencyObject element, global::H.Generators.IntegrationTests.Test? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(TestPropProperty, value);
        }

        /// <summary>
        /// Default value: default(Test)
        /// </summary>
        public static global::H.Generators.IntegrationTests.Test? GetTestProp(global::Windows.UI.Xaml.DependencyObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (global::H.Generators.IntegrationTests.Test?)element.GetValue(TestPropProperty);
        }

    }
}