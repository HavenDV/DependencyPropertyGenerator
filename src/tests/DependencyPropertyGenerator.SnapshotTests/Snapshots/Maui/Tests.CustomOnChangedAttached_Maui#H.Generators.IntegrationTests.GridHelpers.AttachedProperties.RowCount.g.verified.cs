//HintName: H.Generators.IntegrationTests.GridHelpers.AttachedProperties.RowCount.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    static partial class GridHelpers
    {
        /// <summary>
        /// Identifies the RowCount dependency property.<br/>
        /// Default value: -1
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        public static readonly global::Microsoft.Maui.Controls.BindableProperty RowCountProperty =
            global::Microsoft.Maui.Controls.BindableProperty.CreateAttached(
                propertyName: "RowCount",
                returnType: typeof(int),
                declaringType: typeof(global::H.Generators.IntegrationTests.GridHelpers),
                defaultValue: (int)-1,
                defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
                validateValue: null,
                propertyChanged: static (sender, oldValue, newValue) =>
                {
                    OnRowCountChanged(
                        (global::Microsoft.Maui.Controls.Grid)sender,
                        (int)newValue);
                },
                propertyChanging: null,
                coerceValue: null,
                defaultValueCreator: null);

        /// <summary>
        /// Default value: -1
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static void SetRowCount(global::Microsoft.Maui.Controls.BindableObject element, int value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(RowCountProperty, value);
        }

        /// <summary>
        /// Default value: -1
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static int GetRowCount(global::Microsoft.Maui.Controls.BindableObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (int)element.GetValue(RowCountProperty);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        static partial void OnRowCountChanging();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        static partial void OnRowCountChanging(global::Microsoft.Maui.Controls.Grid grid);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        static partial void OnRowCountChanging(global::Microsoft.Maui.Controls.Grid grid, int newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        static partial void OnRowCountChanging(global::Microsoft.Maui.Controls.Grid grid, int oldValue, int newValue);
    }
}