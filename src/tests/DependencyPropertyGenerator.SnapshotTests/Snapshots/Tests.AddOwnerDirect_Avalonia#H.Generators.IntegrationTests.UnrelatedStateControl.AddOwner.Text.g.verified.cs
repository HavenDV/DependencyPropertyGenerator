//HintName: H.Generators.IntegrationTests.UnrelatedStateControl.AddOwner.Text.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class UnrelatedStateControl
    {
        /// <summary>
        /// Identifies the <see cref="Text"/> dependency property.<br/>
        /// Default value: default(string)
        /// </summary>
        public static readonly global::Avalonia.DirectProperty<global::H.Generators.IntegrationTests.UnrelatedStateControl, string?> TextProperty =
            global::Avalonia.Controls.TextBox.TextProperty.AddOwner<global::H.Generators.IntegrationTests.UnrelatedStateControl>(
                getter: static sender => sender.Text,
                setter: static (sender, value) => sender.Text = value,
                unsetValue: default(string),
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                enableDataValidation: false);

        private string? _text = default(string);

        /// <summary>
        /// Default value: default(string)
        /// </summary>
        public string? Text
        {
            get => _text;
            private set
            {
                var oldValue = _text;
                SetAndRaise(TextProperty, ref _text, value);
                OnTextChanged();
                OnTextChanged(
                    (string?)value);
                OnTextChanged(
                    (string?)oldValue,
                    (string?)value);
            }
        }

        partial void OnTextChanged();
        partial void OnTextChanged(string? newValue);
        partial void OnTextChanged(string? oldValue, string? newValue);
    }
}