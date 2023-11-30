//HintName: H.Generators.IntegrationTests.GridExtensions.AttachedProperties.AttachedReadOnlyProperty.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class GridExtensions : global::Avalonia.AvaloniaObject
    {
        /// <summary>
        /// Identifies the AttachedReadOnlyProperty dependency property.<br/>
        /// Default value: default(object)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        public static readonly global::Avalonia.AttachedProperty<object?> AttachedReadOnlyPropertyProperty =
            global::Avalonia.AvaloniaProperty.RegisterAttached<global::H.Generators.IntegrationTests.GridExtensions, global::Avalonia.Controls.Grid, object?>(
                name: "AttachedReadOnlyProperty",
                defaultValue: default(object),
                inherits: false,
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                validate: null,
                coerce: null);

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal static void SetAttachedReadOnlyProperty(global::Avalonia.AvaloniaObject element, object? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(AttachedReadOnlyPropertyProperty, value);
        }

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static object? GetAttachedReadOnlyProperty(global::Avalonia.AvaloniaObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (object?)element.GetValue(AttachedReadOnlyPropertyProperty);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnAttachedReadOnlyPropertyChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnAttachedReadOnlyPropertyChanged(global::Avalonia.Controls.Grid grid);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnAttachedReadOnlyPropertyChanged(global::Avalonia.Controls.Grid grid, object? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnAttachedReadOnlyPropertyChanged(global::Avalonia.Controls.Grid grid, object? oldValue, object? newValue);
    }
}