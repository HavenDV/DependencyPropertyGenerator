//HintName: MyControl.Properties.IsSpinning.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Description<br/>
        /// Default value: true
        /// </summary>
        public static readonly global::Windows.UI.Xaml.DependencyProperty IsSpinningProperty =
            global::Windows.UI.Xaml.DependencyProperty.Register(
                name: "IsSpinning",
                propertyType: typeof(bool),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: new global::Windows.UI.Xaml.PropertyMetadata(
                    defaultValue: (bool)true,
                    propertyChangedCallback: static (sender, args) =>
                    {
                        ((global::H.Generators.IntegrationTests.MyControl)sender).OnIsSpinningChanged(
                            (bool)args.OldValue,
                            (bool)args.NewValue);
                    }));

        /// <summary>
        /// Description<br/>
        /// Default value: true
        /// </summary>
        [global::System.ComponentModel.Category("Category")]
        [global::System.ComponentModel.Description("Description")]
        public bool IsSpinning
        {
            get => (bool)GetValue(IsSpinningProperty);
            set => SetValue(IsSpinningProperty, value);
        }

        partial void OnIsSpinningChanged();
        partial void OnIsSpinningChanged(bool newValue);
        partial void OnIsSpinningChanged(bool oldValue, bool newValue);
    }
}