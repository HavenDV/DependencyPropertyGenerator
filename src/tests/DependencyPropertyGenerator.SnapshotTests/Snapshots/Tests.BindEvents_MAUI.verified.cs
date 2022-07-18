//HintName: MyUIElement.Properties.BindEventsProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyUIElement
    {
        /// <summary>
        /// Default value: default(object)
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindableProperty BindEventsPropertyProperty =
            global::Microsoft.Maui.Controls.BindableProperty.Create(
            propertyName: "BindEventsProperty",
            returnType: typeof(object),
            declaringType: typeof(global::H.Generators.IntegrationTests.MyUIElement),
            defaultValue: default(object),
            defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
            validateValue: null,
            propertyChanged: static (sender, oldValue, newValue) =>
            {
                ((global::H.Generators.IntegrationTests.MyUIElement)sender).OnBindEventsPropertyChanged();
                ((global::H.Generators.IntegrationTests.MyUIElement)sender).OnBindEventsPropertyChanged(
                    (object?)newValue);
                ((global::H.Generators.IntegrationTests.MyUIElement)sender).OnBindEventsPropertyChanged(
                    (object?)oldValue,
                    (object?)newValue);
            },
            propertyChanging: static (sender, oldValue, newValue) =>
            {
                ((global::H.Generators.IntegrationTests.MyUIElement)sender).OnBindEventsPropertyChanging();
                ((global::H.Generators.IntegrationTests.MyUIElement)sender).OnBindEventsPropertyChanging(
                    (object?)newValue);
                ((global::H.Generators.IntegrationTests.MyUIElement)sender).OnBindEventsPropertyChanging(
                    (object?)oldValue,
                    (object?)newValue);
            },
            coerceValue: null,
            defaultValueCreator: null);

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
        partial void OnBindEventsPropertyChanging();
        partial void OnBindEventsPropertyChanging(object? newValue);
        partial void OnBindEventsPropertyChanging(object? oldValue, object? newValue);

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
                this.Loaded -= OnBindEventsPropertyChanged_Loaded;
                this.Unloaded -= OnBindEventsPropertyChanged_Unloaded;
            }
            if (newValue is not default(object))
            {
                this.Loaded += OnBindEventsPropertyChanged_Loaded;
                this.Unloaded += OnBindEventsPropertyChanged_Unloaded;
            }

            OnBindEventsPropertyChanged_AfterBind(
                oldValue,
                newValue);
        }
    }
}