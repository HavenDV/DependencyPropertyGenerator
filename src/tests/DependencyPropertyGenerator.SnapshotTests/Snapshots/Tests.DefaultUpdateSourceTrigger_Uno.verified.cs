//HintName: MyControl.Properties.ExplicitUpdateSourceTriggerProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Default value: default(bool)
        /// </summary>
        public static readonly global::Windows.UI.Xaml.DependencyProperty ExplicitUpdateSourceTriggerPropertyProperty =
            global::Windows.UI.Xaml.DependencyProperty.Register(
                name: "ExplicitUpdateSourceTriggerProperty",
                propertyType: typeof(bool),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: new global::Windows.UI.Xaml.PropertyMetadata(
                    defaultValue: default(bool),
                    propertyChangedCallback: null));

        /// <summary>
        /// Default value: default(bool)
        /// </summary>
        public bool ExplicitUpdateSourceTriggerProperty
        {
            get => (bool)GetValue(ExplicitUpdateSourceTriggerPropertyProperty);
            set => SetValue(ExplicitUpdateSourceTriggerPropertyProperty, value);
        }

        partial void OnExplicitUpdateSourceTriggerPropertyChanged();
        partial void OnExplicitUpdateSourceTriggerPropertyChanged(bool newValue);
        partial void OnExplicitUpdateSourceTriggerPropertyChanged(bool oldValue, bool newValue);
    }
}