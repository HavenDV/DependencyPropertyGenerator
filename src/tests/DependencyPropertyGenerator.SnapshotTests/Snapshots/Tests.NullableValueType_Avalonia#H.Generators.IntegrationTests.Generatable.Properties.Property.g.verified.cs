//HintName: H.Generators.IntegrationTests.Generatable.Properties.Property.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class Generatable
    {
        /// <summary>
        /// Identifies the <see cref="Property"/> dependency property.<br/>
        /// Default value: default(int?)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        public static readonly global::Avalonia.StyledProperty<int?> PropertyProperty =
            global::Avalonia.AvaloniaProperty.Register<global::H.Generators.IntegrationTests.Generatable, int?>(
                name: "Property",
                defaultValue: default(int?),
                inherits: false,
                defaultBindingMode: global::Avalonia.Data.BindingMode.OneWay,
                validate: null,
                coerce: null);

        /// <summary>
        /// Default value: default(int?)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public int? Property
        {
            get => (int?)GetValue(PropertyProperty);
            set => SetValue(PropertyProperty, value);
        }

        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnPropertyChanged();
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnPropertyChanged(int? newValue);
        [global::System.CodeDom.Compiler.GeneratedCode("DependencyPropertyGenerator", "1.3.1.0")]
        partial void OnPropertyChanged(int? oldValue, int? newValue);
    }
}