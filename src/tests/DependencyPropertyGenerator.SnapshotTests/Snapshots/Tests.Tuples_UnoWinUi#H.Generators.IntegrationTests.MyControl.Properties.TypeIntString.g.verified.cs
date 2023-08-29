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
        public static readonly global::Microsoft.UI.Xaml.DependencyProperty TypeIntStringProperty =
            global::Microsoft.UI.Xaml.DependencyProperty.Register(
                name: "TypeIntString",
                propertyType: typeof((int, string)),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: new global::Microsoft.UI.Xaml.PropertyMetadata(
                    defaultValue: default((int, string)),
                    propertyChangedCallback: null));

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