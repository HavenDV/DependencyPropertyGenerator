//HintName: H.Generators.IntegrationTests.MyControl.Properties.TypeIntControl.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Identifies the <see cref="TypeIntControl"/> dependency property.<br/>
        /// Default value: default((int, FrameworkElement))
        /// </summary>
        public static readonly global::System.Windows.DependencyProperty TypeIntControlProperty =
            global::System.Windows.DependencyProperty.Register(
                name: "TypeIntControl",
                propertyType: typeof((int, global::System.Windows.FrameworkElement)),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: default((int, global::System.Windows.FrameworkElement)),
                    flags: global::System.Windows.FrameworkPropertyMetadataOptions.None,
                    propertyChangedCallback: null,
                    coerceValueCallback: null,
                    isAnimationProhibited: false),
                validateValueCallback: null);

        /// <summary>
        /// Default value: default((int, FrameworkElement))
        /// </summary>
        public (int, global::System.Windows.FrameworkElement) TypeIntControl
        {
            get => ((int, global::System.Windows.FrameworkElement))GetValue(TypeIntControlProperty);
            set => SetValue(TypeIntControlProperty, value);
        }

        partial void OnTypeIntControlChanged();
        partial void OnTypeIntControlChanged((int, global::System.Windows.FrameworkElement) newValue);
        partial void OnTypeIntControlChanged((int, global::System.Windows.FrameworkElement) oldValue, (int, global::System.Windows.FrameworkElement) newValue);
    }
}