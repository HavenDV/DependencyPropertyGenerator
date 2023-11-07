//HintName: H.Generators.IntegrationTests.MyGrid.Properties.ReadOnlyProperty.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class MyGrid
    {
        /// <summary>
        /// Identifies the <see cref="ReadOnlyProperty"/> dependency property.<br/>
        /// Default value: default(bool)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        public static readonly global::Microsoft.Maui.Controls.BindablePropertyKey ReadOnlyPropertyPropertyKey =
            global::Microsoft.Maui.Controls.BindableProperty.CreateReadOnly(
                propertyName: "ReadOnlyProperty",
                returnType: typeof(bool),
                declaringType: typeof(global::H.Generators.IntegrationTests.MyGrid),
                defaultValue: default(bool),
                defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWayToSource,
                validateValue: null,
                propertyChanged: null,
                propertyChanging: null,
                coerceValue: null,
                defaultValueCreator: null);

        /// <summary>
        /// Identifies the <see cref="ReadOnlyProperty"/> dependency property.<br/>
        /// Default value: default(bool)
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindableProperty ReadOnlyPropertyProperty
            = ReadOnlyPropertyPropertyKey.BindableProperty;

        /// <summary>
        /// Default value: default(bool)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public bool ReadOnlyProperty
        {
            get => (bool)GetValue(ReadOnlyPropertyProperty);
            protected set => SetValue(ReadOnlyPropertyPropertyKey, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnReadOnlyPropertyChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnReadOnlyPropertyChanged(bool newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnReadOnlyPropertyChanged(bool oldValue, bool newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnReadOnlyPropertyChanging();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnReadOnlyPropertyChanging(bool newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnReadOnlyPropertyChanging(bool oldValue, bool newValue);
    }
}