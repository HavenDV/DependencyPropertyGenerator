//HintName: H.Generators.IntegrationTests.MyGrid.Properties.TypeControlInt.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyGrid
    {
        /// <summary>
        /// Identifies the <see cref="TypeControlInt"/> dependency property.<br/>
        /// Default value: default((VisualElement, int))
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        public static readonly global::Microsoft.Maui.Controls.BindableProperty TypeControlIntProperty =
            global::Microsoft.Maui.Controls.BindableProperty.Create(
                propertyName: "TypeControlInt",
                returnType: typeof((global::Microsoft.Maui.Controls.VisualElement, int)),
                declaringType: typeof(global::H.Generators.IntegrationTests.MyGrid),
                defaultValue: default((global::Microsoft.Maui.Controls.VisualElement, int)),
                defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
                validateValue: null,
                propertyChanged: null,
                propertyChanging: null,
                coerceValue: null,
                defaultValueCreator: null);

        /// <summary>
        /// Default value: default((VisualElement, int))
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public (global::Microsoft.Maui.Controls.VisualElement, int) TypeControlInt
        {
            get => ((global::Microsoft.Maui.Controls.VisualElement, int))GetValue(TypeControlIntProperty);
            set => SetValue(TypeControlIntProperty, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnTypeControlIntChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnTypeControlIntChanged((global::Microsoft.Maui.Controls.VisualElement, int) newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnTypeControlIntChanged((global::Microsoft.Maui.Controls.VisualElement, int) oldValue, (global::Microsoft.Maui.Controls.VisualElement, int) newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnTypeControlIntChanging();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnTypeControlIntChanging((global::Microsoft.Maui.Controls.VisualElement, int) newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnTypeControlIntChanging((global::Microsoft.Maui.Controls.VisualElement, int) oldValue, (global::Microsoft.Maui.Controls.VisualElement, int) newValue);
    }
}