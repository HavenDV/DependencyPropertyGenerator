//HintName: GridExtensions.AttachedProperties.BindEventProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public static partial class GridExtensions
    {
        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static readonly global::System.Windows.DependencyProperty BindEventPropertyProperty =
            global::System.Windows.DependencyProperty.RegisterAttached(
                name: "BindEventProperty",
                propertyType: typeof(object),
                ownerType: typeof(global::H.Generators.IntegrationTests.GridExtensions),
                defaultMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: default(object),
                    flags: global::System.Windows.FrameworkPropertyMetadataOptions.None,
                    propertyChangedCallback: static (sender, args) =>
                    {
                        OnBindEventPropertyChanged();
                        OnBindEventPropertyChanged(
                            (global::System.Windows.Controls.Grid)sender);
                        OnBindEventPropertyChanged(
                            (global::System.Windows.Controls.Grid)sender,
                            (object?)args.NewValue);
                        OnBindEventPropertyChanged(
                            (global::System.Windows.Controls.Grid)sender,
                            (object?)args.OldValue,
                            (object?)args.NewValue);
                    },
                    coerceValueCallback: null,
                    isAnimationProhibited: false),
                validateValueCallback: null);

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static void SetBindEventProperty(global::System.Windows.DependencyObject element, object? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(BindEventPropertyProperty, value);
        }

        /// <summary>
        /// Default value: default(object)
        /// </summary>
        [global::System.Windows.AttachedPropertyBrowsableForType(typeof(global::System.Windows.Controls.Grid))]
        public static object? GetBindEventProperty(global::System.Windows.DependencyObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (object?)element.GetValue(BindEventPropertyProperty);
        }

        static partial void OnBindEventPropertyChanged();
        static partial void OnBindEventPropertyChanged(global::System.Windows.Controls.Grid sender);
        static partial void OnBindEventPropertyChanged(global::System.Windows.Controls.Grid sender, object? newValue);
        static partial void OnBindEventPropertyChanged(global::System.Windows.Controls.Grid sender, object? oldValue, object? newValue);

        static partial void OnBindEventPropertyChanged_BeforeBind(
            global::System.Windows.Controls.Grid sender,
            object? oldValue,
            object? newValue);
        static partial void OnBindEventPropertyChanged_AfterBind(
            global::System.Windows.Controls.Grid sender,
            object? oldValue,
            object? newValue);

        static partial void OnBindEventPropertyChanged(
            global::System.Windows.Controls.Grid sender,
            object? oldValue,
            object? newValue)
        {
            OnBindEventPropertyChanged_BeforeBind(
                sender,
                oldValue,
                newValue);

            if (oldValue is not default(object))
            {
                sender.MouseWheel -= OnBindEventPropertyChanged_MouseWheel;
            }
            if (newValue is not default(object))
            {
                sender.MouseWheel += OnBindEventPropertyChanged_MouseWheel;
            }

            OnBindEventPropertyChanged_AfterBind(
                sender,
                oldValue,
                newValue);
        }
    }
}