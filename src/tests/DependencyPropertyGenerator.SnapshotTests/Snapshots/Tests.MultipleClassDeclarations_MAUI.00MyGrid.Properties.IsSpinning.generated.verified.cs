//HintName: MyGrid.Properties.IsSpinning.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyGrid
    {
        /// <summary>
        /// Default value: default(bool)
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindableProperty IsSpinningProperty =
            global::Microsoft.Maui.Controls.BindableProperty.Create(
            propertyName: "IsSpinning",
            returnType: typeof(bool),
            declaringType: typeof(global::H.Generators.IntegrationTests.MyGrid),
            defaultValue: default(bool),
            defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
            validateValue: null,
            propertyChanged: static (sender, oldValue, newValue) =>
            {
                ((global::H.Generators.IntegrationTests.MyGrid)sender).OnIsSpinningChanged();
            },
            propertyChanging: null,
            coerceValue: null,
            defaultValueCreator: null);

        /// <summary>
        /// Default value: default(bool)
        /// </summary>
        public bool IsSpinning
        {
            get => (bool)GetValue(IsSpinningProperty);
            set => SetValue(IsSpinningProperty, value);
        }

        partial void OnIsSpinningChanged();
        partial void OnIsSpinningChanged(bool newValue);
        partial void OnIsSpinningChanged(bool oldValue, bool newValue);
        partial void OnIsSpinningChanging();
        partial void OnIsSpinningChanging(bool newValue);
        partial void OnIsSpinningChanging(bool oldValue, bool newValue);
    }
}