﻿//HintName: GridExtensions.AttachedProperties.UserAgentSuffix.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public static partial class GridExtensions
    {
        /// <summary>
        /// Identifies the UserAgentSuffix dependency property.<br/>
        /// Default value: default(string)
        /// </summary>
        public static readonly global::System.Windows.DependencyProperty UserAgentSuffixProperty =
            global::System.Windows.DependencyProperty.RegisterAttached(
                name: "UserAgentSuffix",
                propertyType: typeof(string),
                ownerType: typeof(global::H.Generators.IntegrationTests.GridExtensions),
                defaultMetadata: new global::System.Windows.FrameworkPropertyMetadata(
                    defaultValue: default(string),
                    flags: global::System.Windows.FrameworkPropertyMetadataOptions.None,
                    propertyChangedCallback: null,
                    coerceValueCallback: null,
                    isAnimationProhibited: false),
                validateValueCallback: null);

        /// <summary>
        /// A suffix that is added to the default user agent, surrounded by square brackets.
        /// Can be used to identify the web view as belonging to a certain app/version on the server side.<br/>
        /// Default value: default(string)
        /// </summary>
        [global::System.ComponentModel.Description(@"A suffix that is added to the default user agent, surrounded by square brackets.
Can be used to identify the web view as belonging to a certain app/version on the server side.")]
        public static void SetUserAgentSuffix(global::System.Windows.DependencyObject element, string? value)
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
        [global::System.Windows.AttachedPropertyBrowsableForType(typeof(global::System.Windows.Controls.Grid))]
        public static string? GetUserAgentSuffix(global::System.Windows.DependencyObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (string?)element.GetValue(UserAgentSuffixProperty);
        }

        static partial void OnUserAgentSuffixChanged();
        static partial void OnUserAgentSuffixChanged(global::System.Windows.Controls.Grid grid);
        static partial void OnUserAgentSuffixChanged(global::System.Windows.Controls.Grid grid, string? newValue);
        static partial void OnUserAgentSuffixChanged(global::System.Windows.Controls.Grid grid, string? oldValue, string? newValue);
    }
}