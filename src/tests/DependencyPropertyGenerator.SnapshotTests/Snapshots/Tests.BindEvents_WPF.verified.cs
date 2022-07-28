//HintName: MyUIElement.Properties.BindEventsProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyUIElement
    {
        /// <summary>
        /// Default value: default(object)
        /// </summary>
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
        public object? BindEventsProperty
        {
            get => (object?)GetValue(BindEventsPropertyProperty);
            set => SetValue(BindEventsPropertyProperty, value);
        }

        partial void OnBindEventsPropertyChanged();
        partial void OnBindEventsPropertyChanged(object? newValue);
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