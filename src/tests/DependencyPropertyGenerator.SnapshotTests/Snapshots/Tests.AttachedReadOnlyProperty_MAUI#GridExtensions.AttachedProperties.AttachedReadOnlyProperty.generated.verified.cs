//HintName: GridExtensions.AttachedProperties.AttachedReadOnlyProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public static partial class GridExtensions
    {
        /// <summary>
        /// Identifies the <see cref="AttachedReadOnlyProperty"/> dependency property.<br/>
        /// Default value: default(object)
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindablePropertyKey AttachedReadOnlyPropertyPropertyKey =
            global::Microsoft.Maui.Controls.BindableProperty.CreateAttachedReadOnly(
            propertyName: "AttachedReadOnlyProperty",
            returnType: typeof(object),
            declaringType: typeof(global::H.Generators.IntegrationTests.GridExtensions),
            defaultValue: default(object),
            defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWayToSource,
            validateValue: null,
            propertyChanged: null,
            propertyChanging: null,
            coerceValue: null,
            defaultValueCreator: null);

        /// <summary>
        /// Identifies the <see cref="AttachedReadOnlyProperty"/> dependency property.<br/>
        /// Default value: default(object)
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindableProperty AttachedReadOnlyPropertyProperty
            = AttachedReadOnlyPropertyPropertyKey.BindableProperty;

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        internal static void SetAttachedReadOnlyProperty(global::Microsoft.Maui.Controls.BindableObject element, object? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(AttachedReadOnlyPropertyPropertyKey, value);
        }

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static object? GetAttachedReadOnlyProperty(global::Microsoft.Maui.Controls.BindableObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (object?)element.GetValue(AttachedReadOnlyPropertyProperty);
        }

        static partial void OnAttachedReadOnlyPropertyChanged();
        static partial void OnAttachedReadOnlyPropertyChanged(global::Microsoft.Maui.Controls.Grid grid);
        static partial void OnAttachedReadOnlyPropertyChanged(global::Microsoft.Maui.Controls.Grid grid, object? newValue);
        static partial void OnAttachedReadOnlyPropertyChanged(global::Microsoft.Maui.Controls.Grid grid, object? oldValue, object? newValue);
        static partial void OnAttachedReadOnlyPropertyChanging();
        static partial void OnAttachedReadOnlyPropertyChanging(global::Microsoft.Maui.Controls.Grid grid);
        static partial void OnAttachedReadOnlyPropertyChanging(global::Microsoft.Maui.Controls.Grid grid, object? newValue);
        static partial void OnAttachedReadOnlyPropertyChanging(global::Microsoft.Maui.Controls.Grid grid, object? oldValue, object? newValue);
    }
}