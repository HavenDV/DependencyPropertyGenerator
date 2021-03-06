//HintName: MyControl.Properties.IsSpinning2.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Default value: default(bool)
        /// </summary>
        public static readonly global::Avalonia.StyledProperty<bool> IsSpinning2Property =
            global::Avalonia.AvaloniaProperty.Register<global::H.Generators.IntegrationTests.MyControl, bool>(
                name: "IsSpinning2",
                defaultValue: default(bool),
                inherits: false,
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                validate: null,
                coerce: null,
                notifying: null);

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
    }
}