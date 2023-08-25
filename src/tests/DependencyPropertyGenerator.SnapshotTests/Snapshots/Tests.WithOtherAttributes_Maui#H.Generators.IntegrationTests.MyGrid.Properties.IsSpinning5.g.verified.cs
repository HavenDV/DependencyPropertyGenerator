//HintName: H.Generators.IntegrationTests.MyGrid.Properties.IsSpinning5.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyGrid
    {
        /// <summary>
        /// Identifies the <see cref="IsSpinning5"/> dependency property.<br/>
        /// Default value: default(bool)
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindableProperty IsSpinning5Property =
            global::Microsoft.Maui.Controls.BindableProperty.Create(
                propertyName: "IsSpinning5",
                returnType: typeof(bool),
                declaringType: typeof(global::H.Generators.IntegrationTests.MyGrid),
                defaultValue: default(bool),
                defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
                validateValue: null,
                propertyChanged: static (sender, oldValue, newValue) =>
                {
                    ((global::H.Generators.IntegrationTests.MyGrid)sender).OnIsSpinning5Changed(
                        (bool)oldValue,
                        (bool)newValue);
                },
                propertyChanging: null,
                coerceValue: null,
                defaultValueCreator: null);

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
        partial void OnIsSpinning5Changing();
        partial void OnIsSpinning5Changing(bool newValue);
        partial void OnIsSpinning5Changing(bool oldValue, bool newValue);
    }
}