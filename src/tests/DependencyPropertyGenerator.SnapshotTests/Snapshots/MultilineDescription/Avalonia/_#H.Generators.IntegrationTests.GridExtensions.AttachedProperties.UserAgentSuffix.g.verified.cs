//HintName: H.Generators.IntegrationTests.GridExtensions.AttachedProperties.UserAgentSuffix.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class GridExtensions : global::Avalonia.AvaloniaObject
    {
        /// <summary>
        /// Identifies the UserAgentSuffix dependency property.<br/>
        /// Default value: default(string)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        public static readonly global::Avalonia.AttachedProperty<string?> UserAgentSuffixProperty =
            global::Avalonia.AvaloniaProperty.RegisterAttached<global::H.Generators.IntegrationTests.GridExtensions, global::Avalonia.Controls.Grid, string?>(
                name: "UserAgentSuffix",
                defaultValue: default(string),
                inherits: false,
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                validate: null,
                coerce: null);

        /// <summary>
        /// A suffix that is added to the default user agent, surrounded by square brackets.
        /// Can be used to identify the web view as belonging to a certain app/version on the server side.<br/>
        /// Default value: default(string)
        /// </summary>
        [global::System.ComponentModel.Description(@"A suffix that is added to the default user agent, surrounded by square brackets.
Can be used to identify the web view as belonging to a certain app/version on the server side.")]
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static void SetUserAgentSuffix(global::Avalonia.AvaloniaObject element, string? value)
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
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static string? GetUserAgentSuffix(global::Avalonia.AvaloniaObject element)
        {
            element = element ?? throw new global::System.ArgumentNullException(nameof(element));

            return (string?)element.GetValue(UserAgentSuffixProperty);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnUserAgentSuffixChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnUserAgentSuffixChanged(global::Avalonia.Controls.Grid grid);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnUserAgentSuffixChanged(global::Avalonia.Controls.Grid grid, string? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "0.0.0.0")]
        static partial void OnUserAgentSuffixChanged(global::Avalonia.Controls.Grid grid, string? oldValue, string? newValue);
    }
}