//HintName: MyGrid.Properties.ReadOnlyProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyGrid
    {
        /// <summary>
        /// Identifies the <see cref="ReadOnlyProperty"/> dependency property.<br/>
        /// Default value: default(bool)
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindablePropertyKey ReadOnlyPropertyPropertyKey =
            global::Microsoft.Maui.Controls.BindableProperty.CreateReadOnly(
                propertyName: "ReadOnlyProperty",
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
        /// Identifies the <see cref="ReadOnlyProperty"/> dependency property.<br/>
        /// Default value: default(bool)
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindableProperty ReadOnlyPropertyProperty
            = ReadOnlyPropertyPropertyKey.BindableProperty;

        /// <summary>
        /// Default value: default(bool)
        /// </summary>
        public bool ReadOnlyProperty
        {
            get => (bool)GetValue(ReadOnlyPropertyProperty);
            protected set => SetValue(ReadOnlyPropertyPropertyKey, value);
        }

        partial void OnReadOnlyPropertyChanged();
        partial void OnReadOnlyPropertyChanged(bool newValue);
        partial void OnReadOnlyPropertyChanged(bool oldValue, bool newValue);
        partial void OnReadOnlyPropertyChanging();
        partial void OnReadOnlyPropertyChanging(bool newValue);
        partial void OnReadOnlyPropertyChanging(bool oldValue, bool newValue);
    }
}