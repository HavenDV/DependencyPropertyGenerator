//HintName: H.Generators.IntegrationTests.MyGrid.Properties.IsSpinning2.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyGrid
    {
        /// <summary>
        /// Identifies the <see cref="IsSpinning2"/> dependency property.<br/>
        /// Default value: default(bool)
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindableProperty IsSpinning2Property =
            global::Microsoft.Maui.Controls.BindableProperty.Create(
                propertyName: "IsSpinning2",
                returnType: typeof(bool),
                declaringType: typeof(global::H.Generators.IntegrationTests.MyGrid),
                defaultValue: default(bool),
                defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
                validateValue: null,
                propertyChanged: static (sender, oldValue, newValue) =>
                {
                    ((global::H.Generators.IntegrationTests.MyGrid)sender).OnIsSpinning2Changed(
                        (bool)newValue);
                },
                propertyChanging: null,
                coerceValue: null,
                defaultValueCreator: null);

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
        partial void OnIsSpinning2Changing();
        partial void OnIsSpinning2Changing(bool newValue);
        partial void OnIsSpinning2Changing(bool oldValue, bool newValue);
    }
}