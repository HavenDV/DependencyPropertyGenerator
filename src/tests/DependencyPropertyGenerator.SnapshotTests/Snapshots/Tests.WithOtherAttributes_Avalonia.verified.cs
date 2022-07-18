//HintName: MyControl.Properties.IsSpinning5.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Default value: default(bool)
        /// </summary>
        public static readonly global::Avalonia.StyledProperty<bool> IsSpinning5Property =
            global::Avalonia.AvaloniaProperty.Register<global::H.Generators.IntegrationTests.MyControl, bool>(
                name: "IsSpinning5",
                defaultValue: default(bool),
                inherits: false,
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                validate: null,
                coerce: null,
                notifying: null);

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
    }
}