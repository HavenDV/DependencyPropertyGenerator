//HintName: MyGrid.Properties.IsSpinning.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyGrid
    {
        /// <summary>
        /// Default value: default(bool)
        /// </summary>
        public static readonly global::Avalonia.DirectProperty<global::H.Generators.IntegrationTests.MyGrid, bool> IsSpinningProperty =
            global::Avalonia.AvaloniaProperty.RegisterDirect<global::H.Generators.IntegrationTests.MyGrid, bool>(
                name: "IsSpinning",
                getter: static sender => sender.IsSpinning,
                setter: static (sender, value) => sender.IsSpinning = value,
                unsetValue: default(bool),
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                enableDataValidation: false);

        private bool _isSpinning = default(bool);

        /// <summary>
        /// Default value: default(bool)
        /// </summary>
        public bool IsSpinning
        {
            get => _isSpinning;
            private set
            {
                var oldValue = _isSpinning;
                SetAndRaise(IsSpinningProperty, ref _isSpinning, value);
                OnIsSpinningChanged();
                OnIsSpinningChanged(
                    (bool)value);
                OnIsSpinningChanged(
                    (bool)oldValue,
                    (bool)value);
            }
        }

        partial void OnIsSpinningChanged();
        partial void OnIsSpinningChanged(bool newValue);
        partial void OnIsSpinningChanged(bool oldValue, bool newValue);
    }
}