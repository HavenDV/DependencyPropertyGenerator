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
        public static readonly global::Microsoft.UI.Xaml.DependencyProperty TupleIntStringProperty =
            global::Microsoft.UI.Xaml.DependencyProperty.Register(
                name: "TupleIntString",
                propertyType: typeof(global::System.Tuple<int, string>),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: new global::Microsoft.UI.Xaml.PropertyMetadata(
                    defaultValue: default(global::System.Tuple<int, string>),
                    propertyChangedCallback: null));

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