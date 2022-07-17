//HintName: MyControl.Properties.IsSpinning2.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Default value: default(bool)
        /// </summary>
        public static readonly global::Windows.UI.Xaml.DependencyProperty IsSpinning2Property =
            global::Windows.UI.Xaml.DependencyProperty.Register(
                name: "IsSpinning2",
                propertyType: typeof(bool),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: global::Windows.UI.Xaml.PropertyMetadata.Create(
                    defaultValue: default(bool),
                    propertyChangedCallback: static (sender, args) =>
                    {
                        ((global::H.Generators.IntegrationTests.MyControl)sender).OnIsSpinning2Changed();
                        ((global::H.Generators.IntegrationTests.MyControl)sender).OnIsSpinning2Changed(
                            (bool)args.NewValue);
                        ((global::H.Generators.IntegrationTests.MyControl)sender).OnIsSpinning2Changed(
                            (bool)args.OldValue,
                            (bool)args.NewValue);
                    }));

        /// <summary>
        /// Default value: default(bool)
        /// </summary>
        public bool IsSpinning2
        {
            get => (bool)GetValue(IsSpinning2Property);
            set => SetValue(IsSpinning2Property, value);
        }

        partial void OnIsSpinning2Changed();
        partial void OnIsSpinning2Changed(bool newValue);
        partial void OnIsSpinning2Changed(bool oldValue, bool newValue);
    }
}