//HintName: MyControl_AttributedProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Description<br/>
        /// Default value: default(string)
        /// </summary>
        public static readonly global::Windows.UI.Xaml.DependencyProperty AttributedPropertyProperty =
            global::Windows.UI.Xaml.DependencyProperty.Register(
                name: "AttributedProperty",
                propertyType: typeof(string),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: new global::Windows.UI.Xaml.PropertyMetadata(
                    defaultValue: default(string),
                    propertyChangedCallback: static (sender, args) =>
                        ((global::H.Generators.IntegrationTests.MyControl)sender).OnAttributedPropertyChanged(
                            (string?)args.OldValue,
                            (string?)args.NewValue)));

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

        partial void OnAttributedPropertyChanged(string? oldValue, string? newValue);
    }
}