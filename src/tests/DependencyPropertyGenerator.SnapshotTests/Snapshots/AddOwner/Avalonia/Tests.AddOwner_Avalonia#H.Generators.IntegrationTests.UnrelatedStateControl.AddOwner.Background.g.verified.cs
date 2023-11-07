//HintName: H.Generators.IntegrationTests.UnrelatedStateControl.AddOwner.Background.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    partial class UnrelatedStateControl
    {
        /// <summary>
        /// Identifies the <see cref="Background"/> dependency property.<br/>
        /// Default value: default(IBrush)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        public static readonly global::Avalonia.StyledProperty<global::Avalonia.Media.IBrush?> BackgroundProperty =
            global::Avalonia.Controls.Border.BackgroundProperty.AddOwner<global::H.Generators.IntegrationTests.UnrelatedStateControl>(
                null);

        /// <summary>
        /// Default value: default(IBrush)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::Avalonia.Media.IBrush? Background
        {
            get => (global::Avalonia.Media.IBrush?)GetValue(BackgroundProperty);
            set => SetValue(BackgroundProperty, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        partial void OnBackgroundChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        partial void OnBackgroundChanged(global::Avalonia.Media.IBrush? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.3.0")]
        partial void OnBackgroundChanged(global::Avalonia.Media.IBrush? oldValue, global::Avalonia.Media.IBrush? newValue);
    }
}