﻿//HintName: H.Generators.IntegrationTests.MyGrid.Properties.SomeProperty.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyGrid
    {
        /// <summary>
        /// Identifies the <see cref="SomeProperty"/> dependency property.<br/>
        /// Default value: default(string)
        /// </summary>
        public static readonly global::Windows.UI.Xaml.DependencyProperty SomePropertyProperty =
            global::Windows.UI.Xaml.DependencyProperty.Register(
                name: "SomeProperty",
                propertyType: typeof(string),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyGrid),
                typeMetadata: global::Windows.UI.Xaml.PropertyMetadata.Create(
                    createDefaultValueCallback: static () => GetSomePropertyDefaultValue(),
                    propertyChangedCallback: null));

        /// <summary>
        /// Default value: default(string)
        /// </summary>
        public string? SomeProperty
        {
            get => (string?)GetValue(SomePropertyProperty);
            set => SetValue(SomePropertyProperty, value);
        }

        partial void OnSomePropertyChanged();
        partial void OnSomePropertyChanged(string? newValue);
        partial void OnSomePropertyChanged(string? oldValue, string? newValue);
        private static partial string? GetSomePropertyDefaultValue();
    }
}