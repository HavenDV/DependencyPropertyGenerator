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
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        public static readonly global::System.Windows.DependencyProperty BindEventsPropertyProperty =
            global::System.Windows.DependencyProperty.Register(
                name: "BindEventsProperty",
                propertyType: typeof(object),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyUIElement),
                typeMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: default(object),
                    flags: global::System.Windows.FrameworkPropertyMetadataOptions.None,
                    propertyChangedCallback: static (sender, args) =>
                    {
                        ((global::H.Generators.IntegrationTests.MyUIElement)sender).OnBindEventsPropertyChanged(
                            (object?)args.OldValue,
                            (object?)args.NewValue);
                    },
                    coerceValueCallback: null,
                    isAnimationProhibited: false),
                validateValueCallback: null);

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public object? BindEventsProperty
        {
            get => (object?)GetValue(BindEventsPropertyProperty);
            set => SetValue(BindEventsPropertyProperty, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnBindEventsPropertyChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        partial void OnBindEventsPropertyChanged(object? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
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
                this.MouseEnter -= OnBindEventsPropertyChanged_MouseEnter;
                this.MouseLeave -= OnBindEventsPropertyChanged_MouseLeave;
            }
            if (newValue is not default(object))
            {
                this.MouseEnter += OnBindEventsPropertyChanged_MouseEnter;
                this.MouseLeave += OnBindEventsPropertyChanged_MouseLeave;
            }

            OnBindEventsPropertyChanged_AfterBind(
                oldValue,
                newValue);
        }
    }
}