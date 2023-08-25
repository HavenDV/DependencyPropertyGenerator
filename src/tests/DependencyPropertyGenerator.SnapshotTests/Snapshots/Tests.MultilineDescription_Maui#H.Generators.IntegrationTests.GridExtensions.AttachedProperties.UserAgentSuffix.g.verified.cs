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
        public static readonly global::Microsoft.Maui.Controls.BindableProperty UserAgentSuffixProperty =
            global::Microsoft.Maui.Controls.BindableProperty.CreateAttached(
                propertyName: "UserAgentSuffix",
                returnType: typeof(string),
                declaringType: typeof(global::H.Generators.IntegrationTests.GridExtensions),
                defaultValue: default(string),
                defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
                validateValue: null,
                propertyChanged: null,
                propertyChanging: null,
                coerceValue: null,
                defaultValueCreator: null);

        /// <summary>
        /// A suffix that is added to the default user agent, surrounded by square brackets.
        /// Can be used to identify the web view as belonging to a certain app/version on the server side.<br/>
        /// Default value: default(string)
        /// </summary>
        [global::System.ComponentModel.Description(@"A suffix that is added to the default user agent, surrounded by square brackets.
Can be used to identify the web view as belonging to a certain app/version on the server side.")]
        public static void SetUserAgentSuffix(global::Microsoft.Maui.Controls.BindableObject element, string? value)
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
        public static string? GetUserAgentSuffix(global::Microsoft.Maui.Controls.BindableObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (string?)element.GetValue(UserAgentSuffixProperty);
        }

        static partial void OnUserAgentSuffixChanged();
        static partial void OnUserAgentSuffixChanged(global::Microsoft.Maui.Controls.Grid grid);
        static partial void OnUserAgentSuffixChanged(global::Microsoft.Maui.Controls.Grid grid, string? newValue);
        static partial void OnUserAgentSuffixChanged(global::Microsoft.Maui.Controls.Grid grid, string? oldValue, string? newValue);
        static partial void OnUserAgentSuffixChanging();
        static partial void OnUserAgentSuffixChanging(global::Microsoft.Maui.Controls.Grid grid);
        static partial void OnUserAgentSuffixChanging(global::Microsoft.Maui.Controls.Grid grid, string? newValue);
        static partial void OnUserAgentSuffixChanging(global::Microsoft.Maui.Controls.Grid grid, string? oldValue, string? newValue);
    }
}