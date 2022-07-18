//HintName: GridExtensions.AttachedProperties.AttachedProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class GridExtensions : global::Avalonia.AvaloniaObject
    {
        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static readonly global::Avalonia.AttachedProperty<object?> AttachedPropertyProperty =
            global::Avalonia.AvaloniaProperty.RegisterAttached<global::H.Generators.IntegrationTests.GridExtensions, global::Avalonia.Controls.Grid, object?>(
                name: "AttachedProperty",
                defaultValue: default(object),
                inherits: false,
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                validate: null,
                coerce: null);

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static void SetAttachedProperty(global::Avalonia.IAvaloniaObject element, object? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(AttachedPropertyProperty, value);
        }

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static object? GetAttachedProperty(global::Avalonia.IAvaloniaObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (object?)element.GetValue(AttachedPropertyProperty);
        }

        static partial void OnAttachedPropertyChanged();
        static partial void OnAttachedPropertyChanged(global::Avalonia.Controls.Grid grid);
        static partial void OnAttachedPropertyChanged(global::Avalonia.Controls.Grid grid, object? newValue);
        static partial void OnAttachedPropertyChanged(global::Avalonia.Controls.Grid grid, object? oldValue, object? newValue);
    }
}