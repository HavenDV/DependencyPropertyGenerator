//HintName: GridExtensions.AttachedProperties.AttachedProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public static partial class GridExtensions
    {
        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static readonly global::Microsoft.UI.Xaml.DependencyProperty AttachedPropertyProperty =
            global::Microsoft.UI.Xaml.DependencyProperty.RegisterAttached(
                name: "AttachedProperty",
                propertyType: typeof(object),
                ownerType: typeof(global::H.Generators.IntegrationTests.GridExtensions),
                typeMetadata: new global::Microsoft.UI.Xaml.PropertyMetadata(
                    defaultValue: default(object),
                    propertyChangedCallback: static (sender, args) =>
                    {
                        OnAttachedPropertyChanged();
                        OnAttachedPropertyChanged(
                            (global::Microsoft.UI.Xaml.Controls.Grid)sender);
                        OnAttachedPropertyChanged(
                            (global::Microsoft.UI.Xaml.Controls.Grid)sender,
                            (object?)args.NewValue);
                        OnAttachedPropertyChanged(
                            (global::Microsoft.UI.Xaml.Controls.Grid)sender,
                            (object?)args.OldValue,
                            (object?)args.NewValue);
                    }));

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static void SetAttachedProperty(global::Microsoft.UI.Xaml.DependencyObject element, object? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(AttachedPropertyProperty, value);
        }

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static object? GetAttachedProperty(global::Microsoft.UI.Xaml.DependencyObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (object?)element.GetValue(AttachedPropertyProperty);
        }

        static partial void OnAttachedPropertyChanged();
        static partial void OnAttachedPropertyChanged(global::Microsoft.UI.Xaml.Controls.Grid grid);
        static partial void OnAttachedPropertyChanged(global::Microsoft.UI.Xaml.Controls.Grid grid, object? newValue);
        static partial void OnAttachedPropertyChanged(global::Microsoft.UI.Xaml.Controls.Grid grid, object? oldValue, object? newValue);
    }
}