//HintName: H.Generators.IntegrationTests.Generatable.Properties.Headers.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class Generatable
    {
        /// <summary>
        /// Identifies the <see cref="Headers"/> dependency property.<br/>
        /// Default value: default(Dictionary&lt;string, string&gt;)
        /// </summary>
        public static readonly global::Windows.UI.Xaml.DependencyProperty HeadersProperty =
            global::Windows.UI.Xaml.DependencyProperty.Register(
                name: "Headers",
                propertyType: typeof(global::System.Collections.Generic.Dictionary<string, string>),
                ownerType: typeof(global::H.Generators.IntegrationTests.Generatable),
                typeMetadata: new global::Windows.UI.Xaml.PropertyMetadata(
                    defaultValue: default(global::System.Collections.Generic.Dictionary<string, string>),
                    propertyChangedCallback: null));

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