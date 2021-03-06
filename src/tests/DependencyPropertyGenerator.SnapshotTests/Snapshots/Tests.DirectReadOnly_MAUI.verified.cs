//HintName: MyGrid.Properties.IsSpinning.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyGrid
    {
        /// <summary>
        /// Default value: default(bool)
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindablePropertyKey IsSpinningPropertyKey =
            global::Microsoft.Maui.Controls.BindableProperty.CreateReadOnly(
            propertyName: "IsSpinning",
            returnType: typeof(bool),
            declaringType: typeof(global::H.Generators.IntegrationTests.MyGrid),
            defaultValue: default(bool),
            defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWayToSource,
            validateValue: null,
            propertyChanged: null,
            propertyChanging: null,
            coerceValue: null,
            defaultValueCreator: null);

        /// <summary>
        /// Default value: default(bool)
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindableProperty IsSpinningProperty
            = IsSpinningPropertyKey.BindableProperty;

        /// <summary>
        /// Default value: default(bool)
        /// </summary>
        public bool IsSpinning
        {
            get => (bool)GetValue(IsSpinningProperty);
            protected set => SetValue(IsSpinningPropertyKey, value);
        }

        partial void OnIsSpinningChanged();
        partial void OnIsSpinningChanged(bool newValue);
        partial void OnIsSpinningChanged(bool oldValue, bool newValue);
        partial void OnIsSpinningChanging();
        partial void OnIsSpinningChanging(bool newValue);
        partial void OnIsSpinningChanging(bool oldValue, bool newValue);
    }
}