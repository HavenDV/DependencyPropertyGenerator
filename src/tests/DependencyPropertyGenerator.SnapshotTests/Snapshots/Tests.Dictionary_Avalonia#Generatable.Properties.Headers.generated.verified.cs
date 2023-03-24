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
        public static readonly global::Avalonia.StyledProperty<global::System.Collections.Generic.Dictionary<string, string>?> HeadersProperty =
            global::Avalonia.AvaloniaProperty.Register<global::H.Generators.IntegrationTests.Generatable, global::System.Collections.Generic.Dictionary<string, string>?>(
                name: "Headers",
                defaultValue: default(global::System.Collections.Generic.Dictionary<string, string>),
                inherits: false,
                defaultBindingMode: global::Avalonia.Data.BindingMode.TwoWay,
                validate: null,
                coerce: null);

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