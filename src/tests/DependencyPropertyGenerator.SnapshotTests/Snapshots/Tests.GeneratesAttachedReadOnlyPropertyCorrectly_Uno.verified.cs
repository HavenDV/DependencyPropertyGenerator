//HintName: GridExtensions.AttachedProperties.AttachedReadOnlyProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public static partial class GridExtensions
    {
        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static readonly global::Windows.UI.Xaml.DependencyProperty AttachedReadOnlyPropertyProperty =
            global::Windows.UI.Xaml.DependencyProperty.RegisterAttached(
                name: "AttachedReadOnlyProperty",
                propertyType: typeof(object),
                ownerType: typeof(global::H.Generators.IntegrationTests.GridExtensions),
                typeMetadata: new global::Windows.UI.Xaml.PropertyMetadata(
                    defaultValue: default(object),
                    propertyChangedCallback: static (sender, args) =>
                    {
                        OnAttachedReadOnlyPropertyChanged();
                        OnAttachedReadOnlyPropertyChanged(
                            (global::Windows.UI.Xaml.Controls.Grid)sender);
                        OnAttachedReadOnlyPropertyChanged(
                            (global::Windows.UI.Xaml.Controls.Grid)sender,
                            (object?)args.NewValue);
                        OnAttachedReadOnlyPropertyChanged(
                            (global::Windows.UI.Xaml.Controls.Grid)sender,
                            (object?)args.OldValue,
                            (object?)args.NewValue);
                    }));

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        internal static void SetAttachedReadOnlyProperty(global::Windows.UI.Xaml.DependencyObject element, object? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(AttachedReadOnlyPropertyProperty, value);
        }

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static object? GetAttachedReadOnlyProperty(global::Windows.UI.Xaml.DependencyObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (object?)element.GetValue(AttachedReadOnlyPropertyProperty);
        }

        static partial void OnAttachedReadOnlyPropertyChanged();
        static partial void OnAttachedReadOnlyPropertyChanged(global::Windows.UI.Xaml.Controls.Grid sender);
        static partial void OnAttachedReadOnlyPropertyChanged(global::Windows.UI.Xaml.Controls.Grid sender, object? newValue);
        static partial void OnAttachedReadOnlyPropertyChanged(global::Windows.UI.Xaml.Controls.Grid sender, object? oldValue, object? newValue);
    }
}