//HintName: MyUIElement.Properties.BindEventsProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyUIElement
    {
        /// <summary>
        /// Identifies the <see cref="BindEventsProperty"/> dependency property.<br/>
        /// Default value: default(object)
        /// </summary>
        public static readonly global::Avalonia.StyledProperty<object?> BindEventsPropertyProperty =
            global::Avalonia.AvaloniaProperty.Register<global::H.Generators.IntegrationTests.MyUIElement, object?>(
                name: "BindEventsProperty",
                defaultValue: default(object),
                inherits: false,
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                validate: null,
                coerce: null);

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
                this.PointerEnter -= OnBindEventsPropertyChanged_PointerEnter;
                this.PointerLeave -= OnBindEventsPropertyChanged_PointerLeave;
            }
            if (newValue is not default(object))
            {
                this.PointerEnter += OnBindEventsPropertyChanged_PointerEnter;
                this.PointerLeave += OnBindEventsPropertyChanged_PointerLeave;
            }

            OnBindEventsPropertyChanged_AfterBind(
                oldValue,
                newValue);
        }
    }
}