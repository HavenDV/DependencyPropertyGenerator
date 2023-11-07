//HintName: H.Generators.IntegrationTests.GridExtensions.AttachedProperties.SelectedItem.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    static partial class GridExtensions
    {
        /// <summary>
        /// Identifies the SelectedItem dependency property.<br/>
        /// Default value: default(object)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        public static readonly global::Microsoft.Maui.Controls.BindableProperty SelectedItemProperty =
            global::Microsoft.Maui.Controls.BindableProperty.CreateAttached(
                propertyName: "SelectedItem",
                returnType: typeof(object),
                declaringType: typeof(global::H.Generators.IntegrationTests.GridExtensions),
                defaultValue: default(object),
                defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.TwoWay,
                validateValue: null,
                propertyChanged: static (sender, oldValue, newValue) =>
                {
                    OnSelectedItemChanged(
                        (global::Microsoft.Maui.Controls.Grid)sender,
                        (object?)oldValue,
                        (object?)newValue);
                },
                propertyChanging: null,
                coerceValue: null,
                defaultValueCreator: null);

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static void SetSelectedItem(global::Microsoft.Maui.Controls.BindableObject element, object? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(SelectedItemProperty, value);
        }

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static object? GetSelectedItem(global::Microsoft.Maui.Controls.BindableObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (object?)element.GetValue(SelectedItemProperty);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        static partial void OnSelectedItemChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        static partial void OnSelectedItemChanged(global::Microsoft.Maui.Controls.Grid grid);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        static partial void OnSelectedItemChanged(global::Microsoft.Maui.Controls.Grid grid, object? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        static partial void OnSelectedItemChanged(global::Microsoft.Maui.Controls.Grid grid, object? oldValue, object? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        static partial void OnSelectedItemChanging();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        static partial void OnSelectedItemChanging(global::Microsoft.Maui.Controls.Grid grid);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        static partial void OnSelectedItemChanging(global::Microsoft.Maui.Controls.Grid grid, object? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        static partial void OnSelectedItemChanging(global::Microsoft.Maui.Controls.Grid grid, object? oldValue, object? newValue);
    }
}