//HintName: H.Generators.IntegrationTests.MyControl.Properties.TypeIntString.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Identifies the <see cref="TypeIntString"/> dependency property.<br/>
        /// Default value: default((int, string))
        /// </summary>
        public static readonly global::Avalonia.StyledProperty<(int, string)> TypeIntStringProperty =
            global::Avalonia.AvaloniaProperty.Register<global::H.Generators.IntegrationTests.MyControl, (int, string)>(
                name: "TypeIntString",
                defaultValue: default((int, string)),
                inherits: false,
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                validate: null,
                coerce: null);

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
    }
}