﻿//HintName: H.Generators.IntegrationTests.MyControl.Properties.Values3.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Identifies the <see cref="Values3"/> dependency property.<br/>
        /// Default value: default(int[,,])
        /// </summary>
        public static readonly global::Windows.UI.Xaml.DependencyProperty Values3Property =
            global::Windows.UI.Xaml.DependencyProperty.Register(
                name: "Values3",
                propertyType: typeof(int[,,]),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: new global::Windows.UI.Xaml.PropertyMetadata(
                    defaultValue: default(int[,,]),
                    propertyChangedCallback: null));

        /// <summary>
        /// Default value: default(int[,,])
        /// </summary>
        public int[,,]? Values3
        {
            get => (int[,,]?)GetValue(Values3Property);
            set => SetValue(Values3Property, value);
        }

        partial void OnValues3Changed();
        partial void OnValues3Changed(int[,,]? newValue);
        partial void OnValues3Changed(int[,,]? oldValue, int[,,]? newValue);
    }
}