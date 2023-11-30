//HintName: H.Generators.IntegrationTests.GridExtensions.AttachedProperties.AttachedReadOnlyProperty.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    static partial class GridExtensions
    {
        /// <summary>
        /// Identifies the AttachedReadOnlyProperty dependency property.<br/>
        /// Default value: default(object)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        public static readonly global::Microsoft.Maui.Controls.BindablePropertyKey AttachedReadOnlyPropertyPropertyKey =
            global::Microsoft.Maui.Controls.BindableProperty.CreateAttachedReadOnly(
                propertyName: "AttachedReadOnlyProperty",
                returnType: typeof(object),
                declaringType: typeof(global::H.Generators.IntegrationTests.GridExtensions),
                defaultValue: default(object),
                defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWayToSource,
                validateValue: null,
                propertyChanged: null,
                propertyChanging: null,
                coerceValue: null,
                defaultValueCreator: null);

        /// <summary>
        /// Identifies the AttachedReadOnlyProperty dependency property.<br/>
        /// Default value: default(object)
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindableProperty AttachedReadOnlyPropertyProperty
            = AttachedReadOnlyPropertyPropertyKey.BindableProperty;

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal static void SetAttachedReadOnlyProperty(global::Microsoft.Maui.Controls.BindableObject element, object? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(AttachedReadOnlyPropertyPropertyKey, value);
        }

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static object? GetAttachedReadOnlyProperty(global::Microsoft.Maui.Controls.BindableObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (object?)element.GetValue(AttachedReadOnlyPropertyProperty);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnAttachedReadOnlyPropertyChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnAttachedReadOnlyPropertyChanged(global::Microsoft.Maui.Controls.Grid grid);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnAttachedReadOnlyPropertyChanged(global::Microsoft.Maui.Controls.Grid grid, object? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnAttachedReadOnlyPropertyChanged(global::Microsoft.Maui.Controls.Grid grid, object? oldValue, object? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnAttachedReadOnlyPropertyChanging();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnAttachedReadOnlyPropertyChanging(global::Microsoft.Maui.Controls.Grid grid);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnAttachedReadOnlyPropertyChanging(global::Microsoft.Maui.Controls.Grid grid, object? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnAttachedReadOnlyPropertyChanging(global::Microsoft.Maui.Controls.Grid grid, object? oldValue, object? newValue);
    }
}