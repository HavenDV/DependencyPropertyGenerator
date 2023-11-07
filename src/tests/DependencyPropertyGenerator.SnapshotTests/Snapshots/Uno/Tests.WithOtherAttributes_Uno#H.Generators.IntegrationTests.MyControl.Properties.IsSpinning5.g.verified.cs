//HintName: H.Generators.IntegrationTests.MyControl.Properties.IsSpinning5.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class MyControl
    {
        /// <summary>
        /// Identifies the <see cref="IsSpinning5"/> dependency property.<br/>
        /// Default value: default(bool)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        public static readonly global::Windows.UI.Xaml.DependencyProperty IsSpinning5Property =
            global::Windows.UI.Xaml.DependencyProperty.Register(
                name: "IsSpinning5",
                propertyType: typeof(bool),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: new global::Windows.UI.Xaml.PropertyMetadata(
                    defaultValue: default(bool),
                    propertyChangedCallback: static (sender, args) =>
                    {
                        ((global::H.Generators.IntegrationTests.MyControl)sender).OnIsSpinning5Changed(
                            (bool)args.OldValue,
                            (bool)args.NewValue);
                    }));

        /// <summary>
        /// Default value: default(bool)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public bool IsSpinning5
        {
            get => (bool)GetValue(IsSpinning5Property);
            set => SetValue(IsSpinning5Property, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnIsSpinning5Changed();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnIsSpinning5Changed(bool newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnIsSpinning5Changed(bool oldValue, bool newValue);
    }
}