﻿//HintName: H.Generators.IntegrationTests.MyGrid.Properties.SomeProperty.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class MyGrid
    {
        /// <summary>
        /// Identifies the <see cref="SomeProperty"/> dependency property.<br/>
        /// Default value: default(string)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        public static readonly global::Windows.UI.Xaml.DependencyProperty SomePropertyProperty =
            global::Windows.UI.Xaml.DependencyProperty.Register(
                name: "SomeProperty",
                propertyType: typeof(string),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyGrid),
                typeMetadata: global::Windows.UI.Xaml.PropertyMetadata.Create(
                    createDefaultValueCallback: static () => GetSomePropertyDefaultValue(),
                    propertyChangedCallback: null));

        /// <summary>
        /// Default value: default(string)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public string? SomeProperty
        {
            get => (string?)GetValue(SomePropertyProperty);
            set => SetValue(SomePropertyProperty, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        partial void OnSomePropertyChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        partial void OnSomePropertyChanged(string? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        partial void OnSomePropertyChanged(string? oldValue, string? newValue);
        private static partial string? GetSomePropertyDefaultValue();
    }
}