//HintName: MyGrid.Properties.ReadOnlyProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyGrid
    {
        /// <summary>
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
            propertyChanged: static (sender, oldValue, newValue) =>
            {
                ((global::H.Generators.IntegrationTests.MyGrid)sender).OnReadOnlyPropertyChanged();
                ((global::H.Generators.IntegrationTests.MyGrid)sender).OnReadOnlyPropertyChanged(
                    (bool)newValue);
                ((global::H.Generators.IntegrationTests.MyGrid)sender).OnReadOnlyPropertyChanged(
                    (bool)oldValue,
                    (bool)newValue);
            },
            propertyChanging: static (sender, oldValue, newValue) =>
            {
                ((global::H.Generators.IntegrationTests.MyGrid)sender).OnReadOnlyPropertyChanging();
                ((global::H.Generators.IntegrationTests.MyGrid)sender).OnReadOnlyPropertyChanging(
                    (bool)newValue);
                ((global::H.Generators.IntegrationTests.MyGrid)sender).OnReadOnlyPropertyChanging(
                    (bool)oldValue,
                    (bool)newValue);
            },
            coerceValue: null,
            defaultValueCreator: null);

        /// <summary>
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