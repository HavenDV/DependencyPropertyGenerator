﻿//HintName: H.Generators.IntegrationTests.Generatable.Properties.Property.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class Generatable
    {
        /// <summary>
        /// Identifies the <see cref="Property"/> dependency property.<br/>
        /// Default value: default(int?)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        public static readonly global::Windows.UI.Xaml.DependencyProperty PropertyProperty =
            global::Windows.UI.Xaml.DependencyProperty.Register(
                name: "Property",
                propertyType: typeof(int?),
                ownerType: typeof(global::H.Generators.IntegrationTests.Generatable),
                typeMetadata: new global::Windows.UI.Xaml.PropertyMetadata(
                    defaultValue: default(int?),
                    propertyChangedCallback: null));

        /// <summary>
        /// Default value: default(int?)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public int? Property
        {
            get => (int?)GetValue(PropertyProperty);
            set => SetValue(PropertyProperty, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        partial void OnPropertyChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        partial void OnPropertyChanged(int? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        partial void OnPropertyChanged(int? oldValue, int? newValue);
    }
}