//HintName: H.Generators.IntegrationTests.GridExtensions.AttachedProperties.Mode.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public static partial class GridExtensions
    {
        /// <summary>
        /// Identifies the Mode dependency property.<br/>
        /// Default value: Mode2
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        public static readonly global::Microsoft.Maui.Controls.BindableProperty ModeProperty =
            global::Microsoft.Maui.Controls.BindableProperty.CreateAttached(
                propertyName: "Mode",
                returnType: typeof(global::H.Generators.IntegrationTests.Mode),
                declaringType: typeof(global::H.Generators.IntegrationTests.GridExtensions),
                defaultValue: (global::H.Generators.IntegrationTests.Mode)1,
                defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
                validateValue: null,
                propertyChanged: static (sender, oldValue, newValue) =>
                {
                    OnModeChanged(
                        (global::Microsoft.Maui.Controls.Grid)sender,
                        (global::H.Generators.IntegrationTests.Mode)oldValue,
                        (global::H.Generators.IntegrationTests.Mode)newValue);
                },
                propertyChanging: null,
                coerceValue: null,
                defaultValueCreator: null);

        /// <summary>
        /// Default value: Mode2
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static void SetMode(global::Microsoft.Maui.Controls.BindableObject element, global::H.Generators.IntegrationTests.Mode value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(ModeProperty, value);
        }

        /// <summary>
        /// Default value: Mode2
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static global::H.Generators.IntegrationTests.Mode GetMode(global::Microsoft.Maui.Controls.BindableObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (global::H.Generators.IntegrationTests.Mode)element.GetValue(ModeProperty);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        static partial void OnModeChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        static partial void OnModeChanged(global::Microsoft.Maui.Controls.Grid grid);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        static partial void OnModeChanged(global::Microsoft.Maui.Controls.Grid grid, global::H.Generators.IntegrationTests.Mode newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        static partial void OnModeChanged(global::Microsoft.Maui.Controls.Grid grid, global::H.Generators.IntegrationTests.Mode oldValue, global::H.Generators.IntegrationTests.Mode newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        static partial void OnModeChanging();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        static partial void OnModeChanging(global::Microsoft.Maui.Controls.Grid grid);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        static partial void OnModeChanging(global::Microsoft.Maui.Controls.Grid grid, global::H.Generators.IntegrationTests.Mode newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        static partial void OnModeChanging(global::Microsoft.Maui.Controls.Grid grid, global::H.Generators.IntegrationTests.Mode oldValue, global::H.Generators.IntegrationTests.Mode newValue);
    }
}