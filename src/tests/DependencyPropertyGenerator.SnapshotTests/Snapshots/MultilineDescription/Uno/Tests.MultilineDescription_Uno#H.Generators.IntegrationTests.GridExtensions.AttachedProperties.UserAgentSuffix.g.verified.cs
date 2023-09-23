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
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        public static readonly global::Windows.UI.Xaml.DependencyProperty UserAgentSuffixProperty =
            global::Windows.UI.Xaml.DependencyProperty.RegisterAttached(
                name: "UserAgentSuffix",
                propertyType: typeof(string),
                ownerType: typeof(global::H.Generators.IntegrationTests.GridExtensions),
                typeMetadata: new global::Windows.UI.Xaml.PropertyMetadata(
                    defaultValue: default(string),
                    propertyChangedCallback: null));

        /// <summary>
        /// A suffix that is added to the default user agent, surrounded by square brackets.
        /// Can be used to identify the web view as belonging to a certain app/version on the server side.<br/>
        /// Default value: default(string)
        /// </summary>
        [global::System.ComponentModel.Description(@"A suffix that is added to the default user agent, surrounded by square brackets.
Can be used to identify the web view as belonging to a certain app/version on the server side.")]
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static void SetUserAgentSuffix(global::Windows.UI.Xaml.DependencyObject element, string? value)
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
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static string? GetUserAgentSuffix(global::Windows.UI.Xaml.DependencyObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (string?)element.GetValue(UserAgentSuffixProperty);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        static partial void OnUserAgentSuffixChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        static partial void OnUserAgentSuffixChanged(global::Windows.UI.Xaml.Controls.Grid grid);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        static partial void OnUserAgentSuffixChanged(global::Windows.UI.Xaml.Controls.Grid grid, string? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.2.0")]
        static partial void OnUserAgentSuffixChanged(global::Windows.UI.Xaml.Controls.Grid grid, string? oldValue, string? newValue);
    }
}