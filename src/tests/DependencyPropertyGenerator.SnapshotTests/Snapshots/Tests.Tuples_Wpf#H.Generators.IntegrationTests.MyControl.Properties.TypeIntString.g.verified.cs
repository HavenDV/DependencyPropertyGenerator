//HintName: H.Generators.IntegrationTests.MyControl.Properties.TypeIntString.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Identifies the <see cref="TypeIntString"/> dependency property.<br/>
        /// Default value: default((int, string))
        /// </summary>
        public static readonly global::System.Windows.DependencyProperty TypeIntStringProperty =
            global::System.Windows.DependencyProperty.Register(
                name: "TypeIntString",
                propertyType: typeof((int, string)),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: default((int, string)),
                    flags: global::System.Windows.FrameworkPropertyMetadataOptions.None,
                    propertyChangedCallback: null,
                    coerceValueCallback: null,
                    isAnimationProhibited: false),
                validateValueCallback: null);

        /// <summary>
        /// Default value: default((int, string))
        /// </summary>
        public (int, string) TypeIntString
        {
            get => ((int, string))GetValue(TypeIntStringProperty);
            set => SetValue(TypeIntStringProperty, value);
        }

        partial void OnTypeIntStringChanged();
        partial void OnTypeIntStringChanged((int, string) newValue);
        partial void OnTypeIntStringChanged((int, string) oldValue, (int, string) newValue);
    }
}