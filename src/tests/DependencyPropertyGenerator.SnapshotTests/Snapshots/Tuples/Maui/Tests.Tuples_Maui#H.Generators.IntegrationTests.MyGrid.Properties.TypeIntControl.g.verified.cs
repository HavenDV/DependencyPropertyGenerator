//HintName: H.Generators.IntegrationTests.MyGrid.Properties.TypeIntControl.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class MyGrid
    {
        /// <summary>
        /// Identifies the <see cref="TypeIntControl"/> dependency property.<br/>
        /// Default value: default((int, VisualElement))
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        public static readonly global::Microsoft.Maui.Controls.BindableProperty TypeIntControlProperty =
            global::Microsoft.Maui.Controls.BindableProperty.Create(
                propertyName: "TypeIntControl",
                returnType: typeof((int, global::Microsoft.Maui.Controls.VisualElement)),
                declaringType: typeof(global::H.Generators.IntegrationTests.MyGrid),
                defaultValue: default((int, global::Microsoft.Maui.Controls.VisualElement)),
                defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
                validateValue: null,
                propertyChanged: null,
                propertyChanging: null,
                coerceValue: null,
                defaultValueCreator: null);

        /// <summary>
        /// Default value: default((int, VisualElement))
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public (int, global::Microsoft.Maui.Controls.VisualElement) TypeIntControl
        {
            get => ((int, global::Microsoft.Maui.Controls.VisualElement))GetValue(TypeIntControlProperty);
            set => SetValue(TypeIntControlProperty, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        partial void OnTypeIntControlChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        partial void OnTypeIntControlChanged((int, global::Microsoft.Maui.Controls.VisualElement) newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        partial void OnTypeIntControlChanged((int, global::Microsoft.Maui.Controls.VisualElement) oldValue, (int, global::Microsoft.Maui.Controls.VisualElement) newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        partial void OnTypeIntControlChanging();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        partial void OnTypeIntControlChanging((int, global::Microsoft.Maui.Controls.VisualElement) newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        partial void OnTypeIntControlChanging((int, global::Microsoft.Maui.Controls.VisualElement) oldValue, (int, global::Microsoft.Maui.Controls.VisualElement) newValue);
    }
}