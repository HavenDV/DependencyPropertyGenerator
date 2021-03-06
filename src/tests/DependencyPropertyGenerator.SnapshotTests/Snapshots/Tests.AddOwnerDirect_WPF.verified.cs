//HintName: UnrelatedStateControl.AddOwner.Text.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class UnrelatedStateControl
    {
        /// <summary>
        /// Default value: default(string)
        /// </summary>
        public static readonly global::System.Windows.DependencyProperty TextProperty =
            global::System.Windows.Controls.TextBox.TextProperty.AddOwner(
                ownerType: typeof(global::H.Generators.IntegrationTests.UnrelatedStateControl),
                null);

        /// <summary>
        /// Default value: default(string)
        /// </summary>
        public string? Text
        {
            get => (string?)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        partial void OnTextChanged();
        partial void OnTextChanged(string? newValue);
        partial void OnTextChanged(string? oldValue, string? newValue);
    }
}