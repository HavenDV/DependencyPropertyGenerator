//HintName: H.Generators.IntegrationTests.UIElementExtensions.AttachedProperties.BindEventProperty.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    static partial class UIElementExtensions
    {
        /// <summary>
        /// Identifies the BindEventProperty dependency property.<br/>
        /// Default value: default(object)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        public static readonly global::System.Windows.DependencyProperty BindEventPropertyProperty =
            global::System.Windows.DependencyProperty.RegisterAttached(
                name: "BindEventProperty",
                propertyType: typeof(object),
                ownerType: typeof(global::H.Generators.IntegrationTests.UIElementExtensions),
                defaultMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: default(object),
                    flags: global::System.Windows.FrameworkPropertyMetadataOptions.None,
                    propertyChangedCallback: static (sender, args) =>
                    {
                        OnBindEventPropertyChanged(
                            (global::System.Windows.UIElement)sender,
                            (object?)args.OldValue,
                            (object?)args.NewValue);
                    },
                    coerceValueCallback: null,
                    isAnimationProhibited: false),
                validateValueCallback: null);

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static void SetBindEventProperty(global::System.Windows.DependencyObject element, object? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(BindEventPropertyProperty, value);
        }

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        [global::System.Windows.AttachedPropertyBrowsableForType(typeof(global::System.Windows.UIElement))]
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static object? GetBindEventProperty(global::System.Windows.DependencyObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (object?)element.GetValue(BindEventPropertyProperty);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnBindEventPropertyChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnBindEventPropertyChanged(global::System.Windows.UIElement uIElement);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnBindEventPropertyChanged(global::System.Windows.UIElement uIElement, object? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnBindEventPropertyChanged(global::System.Windows.UIElement uIElement, object? oldValue, object? newValue);

        static partial void OnBindEventPropertyChanged_BeforeBind(
            global::System.Windows.UIElement uIElement,
            object? oldValue,
            object? newValue);
        static partial void OnBindEventPropertyChanged_AfterBind(
            global::System.Windows.UIElement uIElement,
            object? oldValue,
            object? newValue);

        static partial void OnBindEventPropertyChanged(
            global::System.Windows.UIElement uIElement,
            object? oldValue,
            object? newValue)
        {
            OnBindEventPropertyChanged_BeforeBind(
                uIElement,
                oldValue,
                newValue);

            if (oldValue is not default(object))
            {
                uIElement.KeyUp -= OnBindEventPropertyChanged_KeyUp;
            }
            if (newValue is not default(object))
            {
                uIElement.KeyUp += OnBindEventPropertyChanged_KeyUp;
            }

            OnBindEventPropertyChanged_AfterBind(
                uIElement,
                oldValue,
                newValue);
        }
    }
}