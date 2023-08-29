//HintName: H.Generators.IntegrationTests.MyControl.Properties.TypeControlInt.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Identifies the <see cref="TypeControlInt"/> dependency property.<br/>
        /// Default value: default((FrameworkElement, int))
        /// </summary>
        public static readonly global::System.Windows.DependencyProperty TypeControlIntProperty =
            global::System.Windows.DependencyProperty.Register(
                name: "TypeControlInt",
                propertyType: typeof((global::System.Windows.FrameworkElement, int)),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: default((global::System.Windows.FrameworkElement, int)),
                    flags: global::System.Windows.FrameworkPropertyMetadataOptions.None,
                    propertyChangedCallback: null,
                    coerceValueCallback: null,
                    isAnimationProhibited: false),
                validateValueCallback: null);

        /// <summary>
        /// Default value: default((FrameworkElement, int))
        /// </summary>
        public (global::System.Windows.FrameworkElement, int) TypeControlInt
        {
            get => ((global::System.Windows.FrameworkElement, int))GetValue(TypeControlIntProperty);
            set => SetValue(TypeControlIntProperty, value);
        }

        partial void OnTypeControlIntChanged();
        partial void OnTypeControlIntChanged((global::System.Windows.FrameworkElement, int) newValue);
        partial void OnTypeControlIntChanged((global::System.Windows.FrameworkElement, int) oldValue, (global::System.Windows.FrameworkElement, int) newValue);
    }
}