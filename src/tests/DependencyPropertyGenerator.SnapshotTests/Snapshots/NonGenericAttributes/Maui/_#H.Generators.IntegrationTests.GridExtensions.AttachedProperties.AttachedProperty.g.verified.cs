//HintName: H.Generators.IntegrationTests.GridExtensions.AttachedProperties.AttachedProperty.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public static partial class GridExtensions
    {
        /// <summary>
        /// Identifies the AttachedProperty dependency property.<br/>
        /// Default value: default(object)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        public static readonly global::Microsoft.Maui.Controls.BindableProperty AttachedPropertyProperty =
            global::Microsoft.Maui.Controls.BindableProperty.CreateAttached(
                propertyName: "AttachedProperty",
                returnType: typeof(object),
                declaringType: typeof(global::H.Generators.IntegrationTests.GridExtensions),
                defaultValue: default(object),
                defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
                validateValue: null,
                propertyChanged: null,
                propertyChanging: null,
                coerceValue: null,
                defaultValueCreator: null);

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static void SetAttachedProperty(global::Microsoft.Maui.Controls.BindableObject element, object? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(AttachedPropertyProperty, value);
        }

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static object? GetAttachedProperty(global::Microsoft.Maui.Controls.BindableObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (object?)element.GetValue(AttachedPropertyProperty);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnAttachedPropertyChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnAttachedPropertyChanged(global::Microsoft.Maui.Controls.Grid grid);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnAttachedPropertyChanged(global::Microsoft.Maui.Controls.Grid grid, object? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnAttachedPropertyChanged(global::Microsoft.Maui.Controls.Grid grid, object? oldValue, object? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnAttachedPropertyChanging();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnAttachedPropertyChanging(global::Microsoft.Maui.Controls.Grid grid);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnAttachedPropertyChanging(global::Microsoft.Maui.Controls.Grid grid, object? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnAttachedPropertyChanging(global::Microsoft.Maui.Controls.Grid grid, object? oldValue, object? newValue);
    }
}