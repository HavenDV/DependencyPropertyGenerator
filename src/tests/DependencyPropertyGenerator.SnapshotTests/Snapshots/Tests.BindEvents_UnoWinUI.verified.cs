//HintName: MyUIElement.Properties.BindEventsProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyUIElement
    {
        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static readonly global::Microsoft.UI.Xaml.DependencyProperty BindEventsPropertyProperty =
            global::Microsoft.UI.Xaml.DependencyProperty.Register(
                name: "BindEventsProperty",
                propertyType: typeof(object),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyUIElement),
                typeMetadata: new global::Microsoft.UI.Xaml.PropertyMetadata(
                    defaultValue: default(object),
                    propertyChangedCallback: static (sender, args) =>
                    {
                        ((global::H.Generators.IntegrationTests.MyUIElement)sender).OnBindEventsPropertyChanged(
                            (object?)args.OldValue,
                            (object?)args.NewValue);
                    }));

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
                this.PointerEntered -= OnBindEventsPropertyChanged_PointerEntered;
                this.PointerExited -= OnBindEventsPropertyChanged_PointerExited;
            }
            if (newValue is not default(object))
            {
                this.PointerEntered += OnBindEventsPropertyChanged_PointerEntered;
                this.PointerExited += OnBindEventsPropertyChanged_PointerExited;
            }

            OnBindEventsPropertyChanged_AfterBind(
                oldValue,
                newValue);
        }
    }
}