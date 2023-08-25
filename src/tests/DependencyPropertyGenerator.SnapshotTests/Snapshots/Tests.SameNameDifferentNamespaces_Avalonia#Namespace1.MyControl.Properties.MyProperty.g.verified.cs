//HintName: Namespace1.MyControl.Properties.MyProperty.g.cs

#nullable enable

namespace Namespace1
{
    public partial class MyControl
    {
        /// <summary>
        /// Identifies the <see cref="MyProperty"/> dependency property.<br/>
        /// Default value: default(int)
        /// </summary>
        public static readonly global::Avalonia.StyledProperty<int> MyPropertyProperty =
            global::Avalonia.AvaloniaProperty.Register<global::Namespace1.MyControl, int>(
                name: "MyProperty",
                defaultValue: default(int),
                inherits: false,
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                validate: null,
                coerce: null);

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
    }
}