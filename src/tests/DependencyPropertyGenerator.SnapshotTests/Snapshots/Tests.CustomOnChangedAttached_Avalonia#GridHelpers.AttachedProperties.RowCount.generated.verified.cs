//HintName: GridHelpers.AttachedProperties.RowCount.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class GridHelpers : global::Avalonia.AvaloniaObject
    {
        /// <summary>
        /// Identifies the <see cref="RowCount"/> dependency property.<br/>
        /// Default value: -1
        /// </summary>
        public static readonly global::Avalonia.AttachedProperty<int> RowCountProperty =
            global::Avalonia.AvaloniaProperty.RegisterAttached<global::H.Generators.IntegrationTests.GridHelpers, global::Avalonia.Controls.Grid, int>(
                name: "RowCount",
                defaultValue: (int)-1,
                inherits: false,
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                validate: null,
                coerce: null);

        /// <summary>
        /// Default value: -1
        /// </summary>
        public static void SetRowCount(global::Avalonia.IAvaloniaObject element, int value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(RowCountProperty, value);
        }

        /// <summary>
        /// Default value: -1
        /// </summary>
        public static int GetRowCount(global::Avalonia.IAvaloniaObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (int)element.GetValue(RowCountProperty);
        }

    }
}