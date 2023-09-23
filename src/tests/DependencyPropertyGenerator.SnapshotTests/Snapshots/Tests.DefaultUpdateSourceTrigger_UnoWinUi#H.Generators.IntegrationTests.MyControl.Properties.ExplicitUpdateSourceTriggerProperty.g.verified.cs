//HintName: H.Generators.IntegrationTests.MyControl.Properties.ExplicitUpdateSourceTriggerProperty.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Identifies the <see cref="ExplicitUpdateSourceTriggerProperty"/> dependency property.<br/>
        /// Default value: default(bool)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        public static readonly global::Microsoft.UI.Xaml.DependencyProperty ExplicitUpdateSourceTriggerPropertyProperty =
            global::Microsoft.UI.Xaml.DependencyProperty.Register(
                name: "ExplicitUpdateSourceTriggerProperty",
                propertyType: typeof(bool),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: new global::Microsoft.UI.Xaml.PropertyMetadata(
                    defaultValue: default(bool),
                    propertyChangedCallback: null));

        /// <summary>
        /// Default value: default(bool)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public bool ExplicitUpdateSourceTriggerProperty
        {
            get => (bool)GetValue(ExplicitUpdateSourceTriggerPropertyProperty);
            set => SetValue(ExplicitUpdateSourceTriggerPropertyProperty, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnExplicitUpdateSourceTriggerPropertyChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnExplicitUpdateSourceTriggerPropertyChanged(bool newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnExplicitUpdateSourceTriggerPropertyChanged(bool oldValue, bool newValue);
    }
}