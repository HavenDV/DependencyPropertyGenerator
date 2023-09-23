//HintName: H.Generators.IntegrationTests.GridExtensions.AttachedProperties.AttachedReadOnlyProperty.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public static partial class GridExtensions
    {
        /// <summary>
        /// Identifies the AttachedReadOnlyProperty dependency property.<br/>
        /// Default value: default(object)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        public static readonly global::Microsoft.UI.Xaml.DependencyProperty AttachedReadOnlyPropertyProperty =
            global::Microsoft.UI.Xaml.DependencyProperty.RegisterAttached(
                name: "AttachedReadOnlyProperty",
                propertyType: typeof(object),
                ownerType: typeof(global::H.Generators.IntegrationTests.GridExtensions),
                typeMetadata: new global::Microsoft.UI.Xaml.PropertyMetadata(
                    defaultValue: default(object),
                    propertyChangedCallback: null));

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal static void SetAttachedReadOnlyProperty(global::Microsoft.UI.Xaml.DependencyObject element, object? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(AttachedReadOnlyPropertyProperty, value);
        }

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static object? GetAttachedReadOnlyProperty(global::Microsoft.UI.Xaml.DependencyObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (object?)element.GetValue(AttachedReadOnlyPropertyProperty);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        static partial void OnAttachedReadOnlyPropertyChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        static partial void OnAttachedReadOnlyPropertyChanged(global::Microsoft.UI.Xaml.Controls.Grid grid);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        static partial void OnAttachedReadOnlyPropertyChanged(global::Microsoft.UI.Xaml.Controls.Grid grid, object? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        static partial void OnAttachedReadOnlyPropertyChanged(global::Microsoft.UI.Xaml.Controls.Grid grid, object? oldValue, object? newValue);
    }
}