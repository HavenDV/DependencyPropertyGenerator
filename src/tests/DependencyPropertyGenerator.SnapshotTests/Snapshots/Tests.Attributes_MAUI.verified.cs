//HintName: MyGrid.Properties.AttributedProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyGrid
    {
        /// <summary>
        /// Description<br/>
        /// Default value: default(string)
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindableProperty AttributedPropertyProperty =
            global::Microsoft.Maui.Controls.BindableProperty.Create(
            propertyName: "AttributedProperty",
            returnType: typeof(string),
            declaringType: typeof(global::H.Generators.IntegrationTests.MyGrid),
            defaultValue: default(string),
            defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
            validateValue: null,
            propertyChanged: static (sender, oldValue, newValue) =>
            {
                ((global::H.Generators.IntegrationTests.MyGrid)sender).OnAttributedPropertyChanged();
                ((global::H.Generators.IntegrationTests.MyGrid)sender).OnAttributedPropertyChanged(
                    (string?)newValue);
                ((global::H.Generators.IntegrationTests.MyGrid)sender).OnAttributedPropertyChanged(
                    (string?)oldValue,
                    (string?)newValue);
            },
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
        public string? AttributedProperty
        {
            get => (string?)GetValue(AttributedPropertyProperty);
            set => SetValue(AttributedPropertyProperty, value);
        }

        partial void OnAttributedPropertyChanged();
        partial void OnAttributedPropertyChanged(string? newValue);
        partial void OnAttributedPropertyChanged(string? oldValue, string? newValue);
    }
}