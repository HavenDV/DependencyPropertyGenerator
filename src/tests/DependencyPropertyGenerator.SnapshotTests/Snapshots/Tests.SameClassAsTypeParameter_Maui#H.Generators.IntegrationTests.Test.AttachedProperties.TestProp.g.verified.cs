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
        public static readonly global::Microsoft.Maui.Controls.BindableProperty TestPropProperty =
            global::Microsoft.Maui.Controls.BindableProperty.CreateAttached(
                propertyName: "TestProp",
                returnType: typeof(global::H.Generators.IntegrationTests.Test),
                declaringType: typeof(global::H.Generators.IntegrationTests.Test),
                defaultValue: default(global::H.Generators.IntegrationTests.Test),
                defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
                validateValue: null,
                propertyChanged: static (sender, oldValue, newValue) =>
                {
                    TestChanged(
                        (global::Microsoft.Maui.Controls.Grid)sender,
                        (global::H.Generators.IntegrationTests.Test?)newValue);
                },
                propertyChanging: null,
                coerceValue: null,
                defaultValueCreator: null);

        /// <summary>
        /// Default value: default(Test)
        /// </summary>
        public static void SetTestProp(global::Microsoft.Maui.Controls.BindableObject element, global::H.Generators.IntegrationTests.Test? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(TestPropProperty, value);
        }

        /// <summary>
        /// Default value: default(Test)
        /// </summary>
        public static global::H.Generators.IntegrationTests.Test? GetTestProp(global::Microsoft.Maui.Controls.BindableObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (global::H.Generators.IntegrationTests.Test?)element.GetValue(TestPropProperty);
        }

        static partial void OnTestPropChanging();
        static partial void OnTestPropChanging(global::Microsoft.Maui.Controls.Grid grid);
        static partial void OnTestPropChanging(global::Microsoft.Maui.Controls.Grid grid, global::H.Generators.IntegrationTests.Test? newValue);
        static partial void OnTestPropChanging(global::Microsoft.Maui.Controls.Grid grid, global::H.Generators.IntegrationTests.Test? oldValue, global::H.Generators.IntegrationTests.Test? newValue);
    }
}