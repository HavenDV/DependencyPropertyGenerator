//HintName: MyControl.Properties.Text.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Default value: default(string)
        /// </summary>
        public static readonly global::Windows.UI.Xaml.DependencyProperty TextProperty =
            global::Windows.UI.Xaml.DependencyProperty.Register(
                name: "Text",
                propertyType: typeof(string),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: global::Windows.UI.Xaml.PropertyMetadata.Create(
                    defaultValue: default(string),
                    propertyChangedCallback: static (sender, args) =>
                    {
                        ((global::H.Generators.IntegrationTests.MyControl)sender).OnTextChanged();
                        ((global::H.Generators.IntegrationTests.MyControl)sender).OnTextChanged(
                            (string?)args.NewValue);
                        ((global::H.Generators.IntegrationTests.MyControl)sender).OnTextChanged(
                            (string?)args.OldValue,
                            (string?)args.NewValue);
                    }));

        /// <summary>
        /// Default value: default(string)
        /// </summary>
        public string? Text
        {
            get => (string?)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        partial void OnTextChanged();
        partial void OnTextChanged(string? newValue);
        partial void OnTextChanged(string? oldValue, string? newValue);
    }
}