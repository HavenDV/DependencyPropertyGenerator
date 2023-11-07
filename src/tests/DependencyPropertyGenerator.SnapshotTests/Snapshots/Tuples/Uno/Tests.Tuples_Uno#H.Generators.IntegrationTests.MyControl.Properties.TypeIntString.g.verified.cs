//HintName: H.Generators.IntegrationTests.MyControl.Properties.TypeIntString.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class MyControl
    {
        /// <summary>
        /// Identifies the <see cref="TypeIntString"/> dependency property.<br/>
        /// Default value: default((int, string))
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        public static readonly global::Windows.UI.Xaml.DependencyProperty TypeIntStringProperty =
            global::Windows.UI.Xaml.DependencyProperty.Register(
                name: "TypeIntString",
                propertyType: typeof((int, string)),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: new global::Windows.UI.Xaml.PropertyMetadata(
                    defaultValue: default((int, string)),
                    propertyChangedCallback: null));

        /// <summary>
        /// Default value: default((int, string))
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public (int, string) TypeIntString
        {
            get => ((int, string))GetValue(TypeIntStringProperty);
            set => SetValue(TypeIntStringProperty, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnTypeIntStringChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnTypeIntStringChanged((int, string) newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnTypeIntStringChanged((int, string) oldValue, (int, string) newValue);
    }
}