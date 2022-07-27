//HintName: MyGrid.Properties.SomeProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyGrid
    {
        /// <summary>
        /// Default value: default(string)
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindableProperty SomePropertyProperty =
            global::Microsoft.Maui.Controls.BindableProperty.Create(
            propertyName: "SomeProperty",
            returnType: typeof(string),
            declaringType: typeof(global::H.Generators.IntegrationTests.MyGrid),
            defaultValue: default(string),
            defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
            validateValue: null,
            propertyChanged: null,
            propertyChanging: null,
            coerceValue: null,
            defaultValueCreator: static _ => GetSomePropertyDefaultValue());

        /// <summary>
        /// Default value: default(string)
        /// </summary>
        public string? SomeProperty
        {
            get => (string?)GetValue(SomePropertyProperty);
            set => SetValue(SomePropertyProperty, value);
        }

        partial void OnSomePropertyChanged();
        partial void OnSomePropertyChanged(string? newValue);
        partial void OnSomePropertyChanged(string? oldValue, string? newValue);
        partial void OnSomePropertyChanging();
        partial void OnSomePropertyChanging(string? newValue);
        partial void OnSomePropertyChanging(string? oldValue, string? newValue);
        private static partial string? GetSomePropertyDefaultValue();
    }
}