//HintName: H.Generators.IntegrationTests.Test.AttachedProperties.TestProp.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class Test : global::Avalonia.AvaloniaObject
    {
        /// <summary>
        /// Identifies the TestProp dependency property.<br/>
        /// Default value: default(Test)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        public static readonly global::Avalonia.AttachedProperty<global::H.Generators.IntegrationTests.Test?> TestPropProperty =
            global::Avalonia.AvaloniaProperty.RegisterAttached<global::H.Generators.IntegrationTests.Test, global::Avalonia.Controls.Grid, global::H.Generators.IntegrationTests.Test?>(
                name: "TestProp",
                defaultValue: default(global::H.Generators.IntegrationTests.Test),
                inherits: false,
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                validate: null,
                coerce: null);

        /// <summary>
        /// Default value: default(Test)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static void SetTestProp(global::Avalonia.AvaloniaObject element, global::H.Generators.IntegrationTests.Test? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(TestPropProperty, value);
        }

        /// <summary>
        /// Default value: default(Test)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static global::H.Generators.IntegrationTests.Test? GetTestProp(global::Avalonia.AvaloniaObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (global::H.Generators.IntegrationTests.Test?)element.GetValue(TestPropProperty);
        }

    }
}