//HintName: MyControl.Properties.NotNullStringProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Default value: ""
        /// </summary>
        public static readonly global::System.Windows.DependencyProperty NotNullStringPropertyProperty =
            global::System.Windows.DependencyProperty.Register(
                name: "NotNullStringProperty",
                propertyType: typeof(string),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: (string)"",
                    flags: global::System.Windows.FrameworkPropertyMetadataOptions.None,
                    propertyChangedCallback: null,
                    coerceValueCallback: static (sender, value) =>
                        ((global::H.Generators.IntegrationTests.MyControl)sender).CoerceNotNullStringProperty(
                            (string?)value),
                    isAnimationProhibited: false),
                validateValueCallback: static value =>
                    IsNotNullStringPropertyValid(
                        (string?)value));

        /// <summary>
        /// Default value: ""
        /// </summary>
        public string? NotNullStringProperty
        {
            get => (string?)GetValue(NotNullStringPropertyProperty);
            set => SetValue(NotNullStringPropertyProperty, value);
        }

        partial void OnNotNullStringPropertyChanged();
        partial void OnNotNullStringPropertyChanged(string? newValue);
        partial void OnNotNullStringPropertyChanged(string? oldValue, string? newValue);
        private partial string? CoerceNotNullStringProperty(string? value);
        private static partial bool IsNotNullStringPropertyValid(string? value);
    }
}