//HintName: H.Generators.IntegrationTests.MyControl.Properties.ReadOnlyProperty.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class MyControl
    {
        /// <summary>
        /// Identifies the <see cref="ReadOnlyProperty"/> dependency property.<br/>
        /// Default value: default(bool)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        public static readonly global::Microsoft.UI.Xaml.DependencyProperty ReadOnlyPropertyProperty =
            global::Microsoft.UI.Xaml.DependencyProperty.Register(
                name: "ReadOnlyProperty",
                propertyType: typeof(bool),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: new global::Microsoft.UI.Xaml.PropertyMetadata(
                    defaultValue: default(bool),
                    propertyChangedCallback: null));

        /// <summary>
        /// Default value: default(bool)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public bool ReadOnlyProperty
        {
            get => (bool)GetValue(ReadOnlyPropertyProperty);
            protected set => SetValue(ReadOnlyPropertyProperty, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnReadOnlyPropertyChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnReadOnlyPropertyChanged(bool newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnReadOnlyPropertyChanged(bool oldValue, bool newValue);
    }
}