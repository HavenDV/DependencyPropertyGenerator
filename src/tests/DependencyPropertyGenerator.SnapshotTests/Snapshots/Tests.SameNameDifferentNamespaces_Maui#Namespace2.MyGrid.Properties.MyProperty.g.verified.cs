//HintName: Namespace2.MyGrid.Properties.MyProperty.g.cs

#nullable enable

namespace Namespace2
{
    public partial class MyGrid
    {
        /// <summary>
        /// Identifies the <see cref="MyProperty"/> dependency property.<br/>
        /// Default value: default(int)
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindableProperty MyPropertyProperty =
            global::Microsoft.Maui.Controls.BindableProperty.Create(
                propertyName: "MyProperty",
                returnType: typeof(int),
                declaringType: typeof(global::Namespace2.MyGrid),
                defaultValue: default(int),
                defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
                validateValue: null,
                propertyChanged: null,
                propertyChanging: null,
                coerceValue: null,
                defaultValueCreator: null);

        /// <summary>
        /// Default value: default(int)
        /// </summary>
        public int MyProperty
        {
            get => (int)GetValue(MyPropertyProperty);
            set => SetValue(MyPropertyProperty, value);
        }

        partial void OnMyPropertyChanged();
        partial void OnMyPropertyChanged(int newValue);
        partial void OnMyPropertyChanged(int oldValue, int newValue);
        partial void OnMyPropertyChanging();
        partial void OnMyPropertyChanging(int newValue);
        partial void OnMyPropertyChanging(int oldValue, int newValue);
    }
}