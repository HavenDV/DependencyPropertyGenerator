//HintName: Generatable.Properties.Headers.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class Generatable
    {
        /// <summary>
        /// Identifies the <see cref="Headers"/> dependency property.<br/>
        /// Default value: default(Dictionary&lt;string, string&gt;)
        /// </summary>
        public static readonly global::System.Windows.DependencyProperty HeadersProperty =
            global::System.Windows.DependencyProperty.Register(
                name: "Headers",
                propertyType: typeof(global::System.Collections.Generic.Dictionary<string, string>),
                ownerType: typeof(global::H.Generators.IntegrationTests.Generatable),
                typeMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: default(global::System.Collections.Generic.Dictionary<string, string>),
                    flags: global::System.Windows.FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    propertyChangedCallback: null,
                    coerceValueCallback: null,
                    isAnimationProhibited: false),
                validateValueCallback: null);

        /// <summary>
        /// Default value: default(Dictionary&lt;string, string&gt;)
        /// </summary>
        public global::System.Collections.Generic.Dictionary<string, string>? Headers
        {
            get => (global::System.Collections.Generic.Dictionary<string, string>?)GetValue(HeadersProperty);
            set => SetValue(HeadersProperty, value);
        }

        partial void OnHeadersChanged();
        partial void OnHeadersChanged(global::System.Collections.Generic.Dictionary<string, string>? newValue);
        partial void OnHeadersChanged(global::System.Collections.Generic.Dictionary<string, string>? oldValue, global::System.Collections.Generic.Dictionary<string, string>? newValue);
    }
}