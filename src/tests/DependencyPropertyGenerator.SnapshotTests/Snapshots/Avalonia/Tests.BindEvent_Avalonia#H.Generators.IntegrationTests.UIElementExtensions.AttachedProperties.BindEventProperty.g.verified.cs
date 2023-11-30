//HintName: H.Generators.IntegrationTests.UIElementExtensions.AttachedProperties.BindEventProperty.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class UIElementExtensions : global::Avalonia.AvaloniaObject
    {
        /// <summary>
        /// Identifies the BindEventProperty dependency property.<br/>
        /// Default value: default(object)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        public static readonly global::Avalonia.AttachedProperty<object?> BindEventPropertyProperty =
            global::Avalonia.AvaloniaProperty.RegisterAttached<global::H.Generators.IntegrationTests.UIElementExtensions, global::Avalonia.Input.InputElement, object?>(
                name: "BindEventProperty",
                defaultValue: default(object),
                inherits: false,
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                validate: null,
                coerce: null);

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static void SetBindEventProperty(global::Avalonia.AvaloniaObject element, object? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(BindEventPropertyProperty, value);
        }

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static object? GetBindEventProperty(global::Avalonia.AvaloniaObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (object?)element.GetValue(BindEventPropertyProperty);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnBindEventPropertyChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnBindEventPropertyChanged(global::Avalonia.Input.InputElement inputElement);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnBindEventPropertyChanged(global::Avalonia.Input.InputElement inputElement, object? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnBindEventPropertyChanged(global::Avalonia.Input.InputElement inputElement, object? oldValue, object? newValue);

        static partial void OnBindEventPropertyChanged_BeforeBind(
            global::Avalonia.Input.InputElement inputElement,
            object? oldValue,
            object? newValue);
        static partial void OnBindEventPropertyChanged_AfterBind(
            global::Avalonia.Input.InputElement inputElement,
            object? oldValue,
            object? newValue);

        static partial void OnBindEventPropertyChanged(
            global::Avalonia.Input.InputElement inputElement,
            object? oldValue,
            object? newValue)
        {
            OnBindEventPropertyChanged_BeforeBind(
                inputElement,
                oldValue,
                newValue);

            if (oldValue is not default(object))
            {
                inputElement.KeyUp -= OnBindEventPropertyChanged_KeyUp;
            }
            if (newValue is not default(object))
            {
                inputElement.KeyUp += OnBindEventPropertyChanged_KeyUp;
            }

            OnBindEventPropertyChanged_AfterBind(
                inputElement,
                oldValue,
                newValue);
        }
    }
}