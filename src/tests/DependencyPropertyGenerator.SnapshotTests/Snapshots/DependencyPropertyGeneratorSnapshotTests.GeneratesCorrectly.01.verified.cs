﻿//HintName: MainWindow_DependencyProperties.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MainWindow
    {
        public static readonly global::System.Windows.DependencyProperty IsSpinningProperty =
            global::System.Windows.DependencyProperty.Register(
                name: "IsSpinning",
                propertyType: typeof(bool),
                ownerType: typeof(MainWindow),
                typeMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    true,
                    global::System.Windows.FrameworkPropertyMetadataOptions.None,
                    static (sender, args) => OnIsSpinningChanged((MainWindow)sender, (bool)args.OldValue, (bool)args.NewValue)));

        public bool IsSpinning
        {
            get => (bool)GetValue(IsSpinningProperty);
            set => SetValue(IsSpinningProperty, value);
        }

        static partial void OnIsSpinningChanged(MainWindow sender, bool oldValue, bool newValue);
    }
}