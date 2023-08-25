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
        public static readonly global::Microsoft.Maui.Controls.BindableProperty HeadersProperty =
            global::Microsoft.Maui.Controls.BindableProperty.Create(
                propertyName: "Headers",
                returnType: typeof(global::System.Collections.Generic.Dictionary<string, string>),
                declaringType: typeof(global::H.Generators.IntegrationTests.Generatable),
                defaultValue: default(global::System.Collections.Generic.Dictionary<string, string>),
                defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.TwoWay,
                validateValue: null,
                propertyChanged: null,
                propertyChanging: null,
                coerceValue: null,
                defaultValueCreator: null);

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
        partial void OnHeadersChanging();
        partial void OnHeadersChanging(global::System.Collections.Generic.Dictionary<string, string>? newValue);
        partial void OnHeadersChanging(global::System.Collections.Generic.Dictionary<string, string>? oldValue, global::System.Collections.Generic.Dictionary<string, string>? newValue);
    }
}