//HintName: H.Generators.IntegrationTests.UIElementExtensions.AttachedProperties.BindEventProperty.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public static partial class UIElementExtensions
    {
        /// <summary>
        /// Identifies the BindEventProperty dependency property.<br/>
        /// Default value: default(object)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        public static readonly global::Windows.UI.Xaml.DependencyProperty BindEventPropertyProperty =
            global::Windows.UI.Xaml.DependencyProperty.RegisterAttached(
                name: "BindEventProperty",
                propertyType: typeof(object),
                ownerType: typeof(global::H.Generators.IntegrationTests.UIElementExtensions),
                typeMetadata: new global::Windows.UI.Xaml.PropertyMetadata(
                    defaultValue: default(object),
                    propertyChangedCallback: static (sender, args) =>
                    {
                        OnBindEventPropertyChanged(
                            (global::Windows.UI.Xaml.UIElement)sender,
                            (object?)args.OldValue,
                            (object?)args.NewValue);
                    }));

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static void SetBindEventProperty(global::Windows.UI.Xaml.DependencyObject element, object? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(BindEventPropertyProperty, value);
        }

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static object? GetBindEventProperty(global::Windows.UI.Xaml.DependencyObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (object?)element.GetValue(BindEventPropertyProperty);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        static partial void OnBindEventPropertyChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        static partial void OnBindEventPropertyChanged(global::Windows.UI.Xaml.UIElement uIElement);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        static partial void OnBindEventPropertyChanged(global::Windows.UI.Xaml.UIElement uIElement, object? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        static partial void OnBindEventPropertyChanged(global::Windows.UI.Xaml.UIElement uIElement, object? oldValue, object? newValue);

        static partial void OnBindEventPropertyChanged_BeforeBind(
            global::Windows.UI.Xaml.UIElement uIElement,
            object? oldValue,
            object? newValue);
        static partial void OnBindEventPropertyChanged_AfterBind(
            global::Windows.UI.Xaml.UIElement uIElement,
            object? oldValue,
            object? newValue);

        static partial void OnBindEventPropertyChanged(
            global::Windows.UI.Xaml.UIElement uIElement,
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