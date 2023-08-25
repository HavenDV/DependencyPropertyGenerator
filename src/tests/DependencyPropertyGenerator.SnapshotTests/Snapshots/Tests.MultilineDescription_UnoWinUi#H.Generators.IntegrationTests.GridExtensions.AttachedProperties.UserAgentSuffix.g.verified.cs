//HintName: H.Generators.IntegrationTests.GridExtensions.AttachedProperties.UserAgentSuffix.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public static partial class GridExtensions
    {
        /// <summary>
        /// Identifies the UserAgentSuffix dependency property.<br/>
        /// Default value: default(string)
        /// </summary>
        public static readonly global::Microsoft.UI.Xaml.DependencyProperty UserAgentSuffixProperty =
            global::Microsoft.UI.Xaml.DependencyProperty.RegisterAttached(
                name: "UserAgentSuffix",
                propertyType: typeof(string),
                ownerType: typeof(global::H.Generators.IntegrationTests.GridExtensions),
                typeMetadata: new global::Microsoft.UI.Xaml.PropertyMetadata(
                    defaultValue: default(string),
                    propertyChangedCallback: null));

        /// <summary>
        /// A suffix that is added to the default user agent, surrounded by square brackets.
        /// Can be used to identify the web view as belonging to a certain app/version on the server side.<br/>
        /// Default value: default(string)
        /// </summary>
        [global::System.ComponentModel.Description(@"A suffix that is added to the default user agent, surrounded by square brackets.
Can be used to identify the web view as belonging to a certain app/version on the server side.")]
        public static void SetUserAgentSuffix(global::Microsoft.UI.Xaml.DependencyObject element, string? value)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            element.SetValue(UserAgentSuffixProperty, value);
        }

        /// <summary>
        /// A suffix that is added to the default user agent, surrounded by square brackets.
        /// Can be used to identify the web view as belonging to a certain app/version on the server side.<br/>
        /// Default value: default(string)
        /// </summary>
        [global::System.ComponentModel.Description(@"A suffix that is added to the default user agent, surrounded by square brackets.
Can be used to identify the web view as belonging to a certain app/version on the server side.")]
        public static string? GetUserAgentSuffix(global::Microsoft.UI.Xaml.DependencyObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (string?)element.GetValue(UserAgentSuffixProperty);
        }

        static partial void OnUserAgentSuffixChanged();
        static partial void OnUserAgentSuffixChanged(global::Microsoft.UI.Xaml.Controls.Grid grid);
        static partial void OnUserAgentSuffixChanged(global::Microsoft.UI.Xaml.Controls.Grid grid, string? newValue);
        static partial void OnUserAgentSuffixChanged(global::Microsoft.UI.Xaml.Controls.Grid grid, string? oldValue, string? newValue);
    }
}