﻿//HintName: H.Generators.IntegrationTests.Generatable.Properties.Headers.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class Generatable
    {
        /// <summary>
        /// Identifies the <see cref="Headers"/> dependency property.<br/>
        /// Default value: default(Dictionary&lt;string, string&gt;)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        public static readonly global::Microsoft.UI.Xaml.DependencyProperty HeadersProperty =
            global::Microsoft.UI.Xaml.DependencyProperty.Register(
                name: "Headers",
                propertyType: typeof(global::System.Collections.Generic.Dictionary<string, string>),
                ownerType: typeof(global::H.Generators.IntegrationTests.Generatable),
                typeMetadata: new global::Microsoft.UI.Xaml.PropertyMetadata(
                    defaultValue: default(global::System.Collections.Generic.Dictionary<string, string>),
                    propertyChangedCallback: null));

        /// <summary>
        /// Default value: default(Dictionary&lt;string, string&gt;)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::System.Collections.Generic.Dictionary<string, string>? Headers
        {
            get => (global::System.Collections.Generic.Dictionary<string, string>?)GetValue(HeadersProperty);
            set => SetValue(HeadersProperty, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        partial void OnHeadersChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        partial void OnHeadersChanged(global::System.Collections.Generic.Dictionary<string, string>? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        partial void OnHeadersChanged(global::System.Collections.Generic.Dictionary<string, string>? oldValue, global::System.Collections.Generic.Dictionary<string, string>? newValue);
    }
}