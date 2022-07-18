//HintName: UnrelatedStateControl.AddOwner.Background.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class UnrelatedStateControl
    {
        /// <summary>
        /// Default value: default(Brush)
        /// </summary>
        public static readonly global::System.Windows.DependencyProperty BackgroundProperty =
            global::System.Windows.Controls.Border.BackgroundProperty.AddOwner(
                ownerType: typeof(global::H.Generators.IntegrationTests.UnrelatedStateControl),
                null);

        /// <summary>
        /// Default value: default(Brush)
        /// </summary>
        public global::System.Windows.Media.Brush? Background
        {
            get => (global::System.Windows.Media.Brush?)GetValue(BackgroundProperty);
            set => SetValue(BackgroundProperty, value);
        }

        partial void OnBackgroundChanged();
        partial void OnBackgroundChanged(global::System.Windows.Media.Brush? newValue);
        partial void OnBackgroundChanged(global::System.Windows.Media.Brush? oldValue, global::System.Windows.Media.Brush? newValue);
    }
}