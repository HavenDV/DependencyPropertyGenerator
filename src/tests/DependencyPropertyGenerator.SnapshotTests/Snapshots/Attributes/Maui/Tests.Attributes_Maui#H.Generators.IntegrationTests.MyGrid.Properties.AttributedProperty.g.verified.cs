//HintName: H.Generators.IntegrationTests.MyGrid.Properties.AttributedProperty.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class MyGrid
    {
        /// <summary>
        /// Identifies the <see cref="AttributedProperty"/> dependency property.<br/>
        /// Default value: default(string)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        public static readonly global::Microsoft.Maui.Controls.BindableProperty AttributedPropertyProperty =
            global::Microsoft.Maui.Controls.BindableProperty.Create(
                propertyName: "AttributedProperty",
                returnType: typeof(string),
                declaringType: typeof(global::H.Generators.IntegrationTests.MyGrid),
                defaultValue: default(string),
                defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
                validateValue: null,
                propertyChanged: null,
                propertyChanging: null,
                coerceValue: null,
                defaultValueCreator: null);

        /// <summary>
        /// Description<br/>
        /// Default value: default(string)
        /// </summary>
        [global::System.ComponentModel.Category("Category")]
        [global::System.ComponentModel.Description("Description")]
        [global::System.ComponentModel.TypeConverter(typeof(global::System.ComponentModel.EnumConverter))]
        [global::System.ComponentModel.Bindable(true)]
        [global::System.ComponentModel.DesignerSerializationVisibility(global::System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [global::System.CLSCompliant(false)]
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public string? AttributedProperty
        {
            get => (string?)GetValue(AttributedPropertyProperty);
            set => SetValue(AttributedPropertyProperty, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnAttributedPropertyChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnAttributedPropertyChanged(string? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnAttributedPropertyChanged(string? oldValue, string? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnAttributedPropertyChanging();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnAttributedPropertyChanging(string? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnAttributedPropertyChanging(string? oldValue, string? newValue);
    }
}