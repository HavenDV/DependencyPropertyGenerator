//HintName: MyControl.Properties.IsSpinning.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Default value: default(bool)
        /// </summary>
        public static readonly global::Avalonia.StyledProperty<bool> IsSpinningProperty =
            global::Avalonia.AvaloniaProperty.Register<global::H.Generators.IntegrationTests.MyControl, bool>(
                name: "IsSpinning",
                defaultValue: default(bool),
                inherits: false,
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                validate: null,
                coerce: null,
                notifying: null);

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
    }
}