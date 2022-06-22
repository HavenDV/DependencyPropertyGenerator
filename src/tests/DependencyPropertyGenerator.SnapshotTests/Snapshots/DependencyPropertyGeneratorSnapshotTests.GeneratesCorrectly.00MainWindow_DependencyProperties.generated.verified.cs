//HintName: MainWindow_DependencyProperties.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MainWindow
    {
        /// <summary>
        /// Description<br/>
        /// Default value: true
        /// </summary>
        public static readonly global::System.Windows.DependencyProperty IsSpinningProperty =
            global::System.Windows.DependencyProperty.Register(
                name: "IsSpinning",
                propertyType: typeof(bool),
                ownerType: typeof(global::H.Generators.IntegrationTests.MainWindow),
                typeMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: true,
                    flags: global::System.Windows.FrameworkPropertyMetadataOptions.None,
                    propertyChangedCallback: static (sender, args) =>
                        ((global::H.Generators.IntegrationTests.MainWindow)sender).OnIsSpinningChanged(
                            (bool)args.OldValue,
                            (bool)args.NewValue)));

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

        partial void OnIsSpinningChanged(bool oldValue, bool newValue);
    }
}