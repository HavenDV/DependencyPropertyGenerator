//HintName: H.Generators.IntegrationTests.MyControl.Properties.TypeIntControl.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Identifies the <see cref="TypeIntControl"/> dependency property.<br/>
        /// Default value: default((int, Control))
        /// </summary>
        public static readonly global::Avalonia.StyledProperty<(int, global::Avalonia.Controls.Control)> TypeIntControlProperty =
            global::Avalonia.AvaloniaProperty.Register<global::H.Generators.IntegrationTests.MyControl, (int, global::Avalonia.Controls.Control)>(
                name: "TypeIntControl",
                defaultValue: default((int, global::Avalonia.Controls.Control)),
                inherits: false,
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                validate: null,
                coerce: null);

        /// <summary>
        /// Default value: default((int, Control))
        /// </summary>
        public (int, global::Avalonia.Controls.Control) TypeIntControl
        {
            get => ((int, global::Avalonia.Controls.Control))GetValue(TypeIntControlProperty);
            set => SetValue(TypeIntControlProperty, value);
        }

        partial void OnTypeIntControlChanged();
        partial void OnTypeIntControlChanged((int, global::Avalonia.Controls.Control) newValue);
        partial void OnTypeIntControlChanged((int, global::Avalonia.Controls.Control) oldValue, (int, global::Avalonia.Controls.Control) newValue);
    }
}