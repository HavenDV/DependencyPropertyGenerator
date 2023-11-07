//HintName: Namespace2.MyControl.Properties.MyProperty.g.cs

#nullable enable

namespace Namespace2
{
    partial class MyControl
    {
        /// <summary>
        /// Identifies the <see cref="MyProperty"/> dependency property.<br/>
        /// Default value: default(int)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        public static readonly global::Windows.UI.Xaml.DependencyProperty MyPropertyProperty =
            global::Windows.UI.Xaml.DependencyProperty.Register(
                name: "MyProperty",
                propertyType: typeof(int),
                ownerType: typeof(global::Namespace2.MyControl),
                typeMetadata: new global::Windows.UI.Xaml.PropertyMetadata(
                    defaultValue: default(int),
                    propertyChangedCallback: null));

        /// <summary>
        /// Default value: default(int)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public int MyProperty
        {
            get => (int)GetValue(MyPropertyProperty);
            set => SetValue(MyPropertyProperty, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnMyPropertyChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnMyPropertyChanged(int newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnMyPropertyChanged(int oldValue, int newValue);
    }
}