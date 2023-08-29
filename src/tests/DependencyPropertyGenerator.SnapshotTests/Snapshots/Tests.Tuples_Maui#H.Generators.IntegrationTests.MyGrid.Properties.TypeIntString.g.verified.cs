//HintName: H.Generators.IntegrationTests.MyGrid.Properties.TypeIntString.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyGrid
    {
        /// <summary>
        /// Identifies the <see cref="TypeIntString"/> dependency property.<br/>
        /// Default value: default((int, string))
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindableProperty TypeIntStringProperty =
            global::Microsoft.Maui.Controls.BindableProperty.Create(
                propertyName: "TypeIntString",
                returnType: typeof((int, string)),
                declaringType: typeof(global::H.Generators.IntegrationTests.MyGrid),
                defaultValue: default((int, string)),
                defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
                validateValue: null,
                propertyChanged: null,
                propertyChanging: null,
                coerceValue: null,
                defaultValueCreator: null);

        /// <summary>
        /// Default value: default((int, string))
        /// </summary>
        public (int, string) TypeIntString
        {
            get => ((int, string))GetValue(TypeIntStringProperty);
            set => SetValue(TypeIntStringProperty, value);
        }

        partial void OnTypeIntStringChanged();
        partial void OnTypeIntStringChanged((int, string) newValue);
        partial void OnTypeIntStringChanged((int, string) oldValue, (int, string) newValue);
        partial void OnTypeIntStringChanging();
        partial void OnTypeIntStringChanging((int, string) newValue);
        partial void OnTypeIntStringChanging((int, string) oldValue, (int, string) newValue);
    }
}