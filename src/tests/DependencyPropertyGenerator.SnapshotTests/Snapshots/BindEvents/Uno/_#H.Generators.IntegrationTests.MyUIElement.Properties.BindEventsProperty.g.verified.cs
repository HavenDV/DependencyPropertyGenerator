//HintName: H.Generators.IntegrationTests.MyUIElement.Properties.BindEventsProperty.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class MyUIElement
    {
        /// <summary>
        /// Identifies the <see cref="BindEventsProperty"/> dependency property.<br/>
        /// Default value: default(object)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        public static readonly global::Windows.UI.Xaml.DependencyProperty BindEventsPropertyProperty =
            global::Windows.UI.Xaml.DependencyProperty.Register(
                name: "BindEventsProperty",
                propertyType: typeof(object),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyUIElement),
                typeMetadata: new global::Windows.UI.Xaml.PropertyMetadata(
                    defaultValue: default(object),
                    propertyChangedCallback: static (sender, args) =>
                    {
                        ((global::H.Generators.IntegrationTests.MyUIElement)sender).OnBindEventsPropertyChanged(
                            (object?)args.OldValue,
                            (object?)args.NewValue);
                    }));

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public object? BindEventsProperty
        {
            get => (object?)GetValue(BindEventsPropertyProperty);
            set => SetValue(BindEventsPropertyProperty, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        partial void OnBindEventsPropertyChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        partial void OnBindEventsPropertyChanged(object? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        partial void OnBindEventsPropertyChanged(object? oldValue, object? newValue);

        partial void OnBindEventsPropertyChanged_BeforeBind(
            object? oldValue,
            object? newValue);
        partial void OnBindEventsPropertyChanged_AfterBind(
            object? oldValue,
            object? newValue);

        partial void OnBindEventsPropertyChanged(
            object? oldValue,
            object? newValue)
        {
            OnBindEventsPropertyChanged_BeforeBind(
                oldValue,
                newValue);

            if (oldValue is not default(object))
            {
                this.PointerEntered -= OnBindEventsPropertyChanged_PointerEntered;
                this.PointerExited -= OnBindEventsPropertyChanged_PointerExited;
            }
            if (newValue is not default(object))
            {
                this.PointerEntered += OnBindEventsPropertyChanged_PointerEntered;
                this.PointerExited += OnBindEventsPropertyChanged_PointerExited;
            }

            OnBindEventsPropertyChanged_AfterBind(
                oldValue,
                newValue);
        }
    }
}