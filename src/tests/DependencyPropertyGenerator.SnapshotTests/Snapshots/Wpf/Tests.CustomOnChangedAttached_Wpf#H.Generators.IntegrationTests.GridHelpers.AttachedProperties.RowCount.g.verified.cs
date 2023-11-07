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
        public static readonly global::System.Windows.DependencyProperty RowCountProperty =
            global::System.Windows.DependencyProperty.RegisterAttached(
                name: "RowCount",
                propertyType: typeof(int),
                ownerType: typeof(global::H.Generators.IntegrationTests.GridHelpers),
                defaultMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: (int)-1,
                    flags: global::System.Windows.FrameworkPropertyMetadataOptions.None,
                    propertyChangedCallback: static (sender, args) =>
                    {
                        OnRowCountChanged(
                            (global::System.Windows.Controls.Grid)sender,
                            (int)args.NewValue);
                    },
                    coerceValueCallback: null,
                    isAnimationProhibited: false),
                validateValueCallback: null);

        /// <summary>
        /// Default value: -1
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static void SetRowCount(global::System.Windows.DependencyObject element, int value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(RowCountProperty, value);
        }

        /// <summary>
        /// Default value: -1
        /// </summary>
        [global::System.Windows.AttachedPropertyBrowsableForType(typeof(global::System.Windows.Controls.Grid))]
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static int GetRowCount(global::System.Windows.DependencyObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (int)element.GetValue(RowCountProperty);
        }

    }
}