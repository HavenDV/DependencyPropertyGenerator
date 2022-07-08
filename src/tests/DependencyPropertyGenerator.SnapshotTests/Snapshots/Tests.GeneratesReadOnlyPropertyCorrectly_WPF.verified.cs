//HintName: MyControl.Properties.ReadOnlyProperty.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Default value: default(bool)
        /// </summary>
        private static readonly global::System.Windows.DependencyPropertyKey ReadOnlyPropertyPropertyKey =
            global::System.Windows.DependencyProperty.RegisterReadOnly(
                name: "ReadOnlyProperty",
                propertyType: typeof(bool),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: default(bool),
                    flags: global::System.Windows.FrameworkPropertyMetadataOptions.None,
                    propertyChangedCallback: static (sender, args) =>
                    {
                        ((global::H.Generators.IntegrationTests.MyControl)sender).OnReadOnlyPropertyChanged();
                        ((global::H.Generators.IntegrationTests.MyControl)sender).OnReadOnlyPropertyChanged(
                            (bool)args.NewValue);
                        ((global::H.Generators.IntegrationTests.MyControl)sender).OnReadOnlyPropertyChanged(
                            (bool)args.OldValue,
                            (bool)args.NewValue);
                    },
                    coerceValueCallback: null,
                    isAnimationProhibited: false),
                validateValueCallback: null);

        /// <summary>
        /// Default value: default(bool)
        /// </summary>
        public static readonly global::System.Windows.DependencyProperty ReadOnlyPropertyProperty
            = ReadOnlyPropertyPropertyKey.DependencyProperty;

        /// <summary>
        /// Default value: default(bool)
        /// </summary>
        public bool ReadOnlyProperty
        {
            get => (bool)GetValue(ReadOnlyPropertyProperty);
            protected set => SetValue(ReadOnlyPropertyPropertyKey, value);
        }

        partial void OnReadOnlyPropertyChanged();
        partial void OnReadOnlyPropertyChanged(bool newValue);
        partial void OnReadOnlyPropertyChanged(bool oldValue, bool newValue);
    }
}