//HintName: MyGrid.Properties.ExplicitUpdateSourceTriggerProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyGrid
    {
        /// <summary>
        /// Identifies the <see cref="ExplicitUpdateSourceTriggerProperty"/> dependency property.<br/>
        /// Default value: default(bool)
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindableProperty ExplicitUpdateSourceTriggerPropertyProperty =
            global::Microsoft.Maui.Controls.BindableProperty.Create(
                propertyName: "ExplicitUpdateSourceTriggerProperty",
                returnType: typeof(bool),
                declaringType: typeof(global::H.Generators.IntegrationTests.MyGrid),
                defaultValue: default(bool),
                defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
                validateValue: null,
                propertyChanged: null,
                propertyChanging: null,
                coerceValue: null,
                defaultValueCreator: null);

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
        partial void OnExplicitUpdateSourceTriggerPropertyChanging();
        partial void OnExplicitUpdateSourceTriggerPropertyChanging(bool newValue);
        partial void OnExplicitUpdateSourceTriggerPropertyChanging(bool oldValue, bool newValue);
    }
}