//HintName: H.Generators.IntegrationTests.MyGird.AttachedProperties.MyColumn.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class MyGird
    {
        /// <summary>
        /// Identifies the MyColumn dependency property.<br/>
        /// Default value: default(int)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        public static readonly global::Microsoft.Maui.Controls.BindableProperty MyColumnProperty =
            global::Microsoft.Maui.Controls.BindableProperty.CreateAttached(
                propertyName: "MyColumn",
                returnType: typeof(int),
                declaringType: typeof(global::H.Generators.IntegrationTests.MyGird),
                defaultValue: default(int),
                defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
                validateValue: null,
                propertyChanged: null,
                propertyChanging: null,
                coerceValue: null,
                defaultValueCreator: null);

        /// <summary>
        /// Default value: default(int)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static void SetMyColumn(global::Microsoft.Maui.Controls.BindableObject element, int value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(MyColumnProperty, value);
        }

        /// <summary>
        /// Default value: default(int)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static int GetMyColumn(global::Microsoft.Maui.Controls.BindableObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (int)element.GetValue(MyColumnProperty);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnMyColumnChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnMyColumnChanged(global::Microsoft.Maui.Controls.VisualElement visualElement);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnMyColumnChanged(global::Microsoft.Maui.Controls.VisualElement visualElement, int newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnMyColumnChanged(global::Microsoft.Maui.Controls.VisualElement visualElement, int oldValue, int newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnMyColumnChanging();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnMyColumnChanging(global::Microsoft.Maui.Controls.VisualElement visualElement);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnMyColumnChanging(global::Microsoft.Maui.Controls.VisualElement visualElement, int newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnMyColumnChanging(global::Microsoft.Maui.Controls.VisualElement visualElement, int oldValue, int newValue);
    }
}