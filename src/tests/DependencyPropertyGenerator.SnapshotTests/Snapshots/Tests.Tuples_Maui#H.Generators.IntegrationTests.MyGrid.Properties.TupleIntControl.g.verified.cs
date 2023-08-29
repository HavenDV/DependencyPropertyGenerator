//HintName: H.Generators.IntegrationTests.MyGrid.Properties.TupleIntControl.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyGrid
    {
        /// <summary>
        /// Identifies the <see cref="TupleIntControl"/> dependency property.<br/>
        /// Default value: default(Tuple&lt;int, VisualElement&gt;)
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindableProperty TupleIntControlProperty =
            global::Microsoft.Maui.Controls.BindableProperty.Create(
                propertyName: "TupleIntControl",
                returnType: typeof(global::System.Tuple<int, global::Microsoft.Maui.Controls.VisualElement>),
                declaringType: typeof(global::H.Generators.IntegrationTests.MyGrid),
                defaultValue: default(global::System.Tuple<int, global::Microsoft.Maui.Controls.VisualElement>),
                defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
                validateValue: null,
                propertyChanged: null,
                propertyChanging: null,
                coerceValue: null,
                defaultValueCreator: null);

        /// <summary>
        /// Default value: default(Tuple&lt;int, VisualElement&gt;)
        /// </summary>
        public global::System.Tuple<int, global::Microsoft.Maui.Controls.VisualElement>? TupleIntControl
        {
            get => (global::System.Tuple<int, global::Microsoft.Maui.Controls.VisualElement>?)GetValue(TupleIntControlProperty);
            set => SetValue(TupleIntControlProperty, value);
        }

        partial void OnTupleIntControlChanged();
        partial void OnTupleIntControlChanged(global::System.Tuple<int, global::Microsoft.Maui.Controls.VisualElement>? newValue);
        partial void OnTupleIntControlChanged(global::System.Tuple<int, global::Microsoft.Maui.Controls.VisualElement>? oldValue, global::System.Tuple<int, global::Microsoft.Maui.Controls.VisualElement>? newValue);
        partial void OnTupleIntControlChanging();
        partial void OnTupleIntControlChanging(global::System.Tuple<int, global::Microsoft.Maui.Controls.VisualElement>? newValue);
        partial void OnTupleIntControlChanging(global::System.Tuple<int, global::Microsoft.Maui.Controls.VisualElement>? oldValue, global::System.Tuple<int, global::Microsoft.Maui.Controls.VisualElement>? newValue);
    }
}