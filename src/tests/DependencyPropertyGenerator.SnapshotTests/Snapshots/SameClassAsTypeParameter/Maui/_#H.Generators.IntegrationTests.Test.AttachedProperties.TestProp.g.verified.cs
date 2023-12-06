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
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
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
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static void SetTestProp(global::Microsoft.Maui.Controls.BindableObject element, global::H.Generators.IntegrationTests.Test? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(TestPropProperty, value);
        }

        /// <summary>
        /// Default value: default(Test)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static global::H.Generators.IntegrationTests.Test? GetTestProp(global::Microsoft.Maui.Controls.BindableObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (global::H.Generators.IntegrationTests.Test?)element.GetValue(TestPropProperty);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnTestPropChanging();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnTestPropChanging(global::Microsoft.Maui.Controls.Grid grid);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnTestPropChanging(global::Microsoft.Maui.Controls.Grid grid, global::H.Generators.IntegrationTests.Test? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnTestPropChanging(global::Microsoft.Maui.Controls.Grid grid, global::H.Generators.IntegrationTests.Test? oldValue, global::H.Generators.IntegrationTests.Test? newValue);
    }
}