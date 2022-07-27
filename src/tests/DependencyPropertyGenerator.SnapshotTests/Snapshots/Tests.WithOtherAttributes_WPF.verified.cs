//HintName: MyControl.Properties.IsSpinning5.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Default value: default(bool)
        /// </summary>
        public static readonly global::System.Windows.DependencyProperty IsSpinning5Property =
            global::System.Windows.DependencyProperty.Register(
                name: "IsSpinning5",
                propertyType: typeof(bool),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: default(bool),
                    flags: global::System.Windows.FrameworkPropertyMetadataOptions.None,
                    propertyChangedCallback: static (sender, args) =>
                    {
                        ((global::H.Generators.IntegrationTests.MyControl)sender).OnIsSpinning5Changed(
                            (bool)args.OldValue,
                            (bool)args.NewValue);
                    },
                    coerceValueCallback: null,
                    isAnimationProhibited: false),
                validateValueCallback: null);

        /// <summary>
        /// Default value: default(bool)
        /// </summary>
        public bool IsSpinning5
        {
            get => (bool)GetValue(IsSpinning5Property);
            set => SetValue(IsSpinning5Property, value);
        }

        partial void OnIsSpinning5Changed();
        partial void OnIsSpinning5Changed(bool newValue);
        partial void OnIsSpinning5Changed(bool oldValue, bool newValue);
    }
}