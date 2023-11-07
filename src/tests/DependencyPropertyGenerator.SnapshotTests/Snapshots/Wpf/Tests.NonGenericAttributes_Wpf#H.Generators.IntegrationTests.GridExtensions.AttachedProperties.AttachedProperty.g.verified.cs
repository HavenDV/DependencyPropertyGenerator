//HintName: H.Generators.IntegrationTests.GridExtensions.AttachedProperties.AttachedProperty.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    static partial class GridExtensions
    {
        /// <summary>
        /// Identifies the AttachedProperty dependency property.<br/>
        /// Default value: default(object)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        public static readonly global::System.Windows.DependencyProperty AttachedPropertyProperty =
            global::System.Windows.DependencyProperty.RegisterAttached(
                name: "AttachedProperty",
                propertyType: typeof(object),
                ownerType: typeof(global::H.Generators.IntegrationTests.GridExtensions),
                defaultMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: default(object),
                    flags: global::System.Windows.FrameworkPropertyMetadataOptions.None,
                    propertyChangedCallback: null,
                    coerceValueCallback: null,
                    isAnimationProhibited: false),
                validateValueCallback: null);

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static void SetAttachedProperty(global::System.Windows.DependencyObject element, object? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(AttachedPropertyProperty, value);
        }

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        [global::System.Windows.AttachedPropertyBrowsableForType(typeof(global::System.Windows.Controls.Grid))]
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static object? GetAttachedProperty(global::System.Windows.DependencyObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (object?)element.GetValue(AttachedPropertyProperty);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        static partial void OnAttachedPropertyChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        static partial void OnAttachedPropertyChanged(global::System.Windows.Controls.Grid grid);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        static partial void OnAttachedPropertyChanged(global::System.Windows.Controls.Grid grid, object? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        static partial void OnAttachedPropertyChanged(global::System.Windows.Controls.Grid grid, object? oldValue, object? newValue);
    }
}