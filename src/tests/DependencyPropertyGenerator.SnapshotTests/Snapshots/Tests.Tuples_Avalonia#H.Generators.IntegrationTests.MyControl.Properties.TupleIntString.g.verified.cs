//HintName: H.Generators.IntegrationTests.MyControl.Properties.TupleIntString.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Identifies the <see cref="TupleIntString"/> dependency property.<br/>
        /// Default value: default(Tuple&lt;int, string&gt;)
        /// </summary>
        public static readonly global::Avalonia.StyledProperty<global::System.Tuple<int, string>?> TupleIntStringProperty =
            global::Avalonia.AvaloniaProperty.Register<global::H.Generators.IntegrationTests.MyControl, global::System.Tuple<int, string>?>(
                name: "TupleIntString",
                defaultValue: default(global::System.Tuple<int, string>),
                inherits: false,
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                validate: null,
                coerce: null);

        /// <summary>
        /// Default value: default(Tuple&lt;int, string&gt;)
        /// </summary>
        public global::System.Tuple<int, string>? TupleIntString
        {
            get => (global::System.Tuple<int, string>?)GetValue(TupleIntStringProperty);
            set => SetValue(TupleIntStringProperty, value);
        }

        partial void OnTupleIntStringChanged();
        partial void OnTupleIntStringChanged(global::System.Tuple<int, string>? newValue);
        partial void OnTupleIntStringChanged(global::System.Tuple<int, string>? oldValue, global::System.Tuple<int, string>? newValue);
    }
}