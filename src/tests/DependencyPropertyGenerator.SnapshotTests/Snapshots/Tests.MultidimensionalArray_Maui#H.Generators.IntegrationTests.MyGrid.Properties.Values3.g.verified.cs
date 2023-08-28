﻿//HintName: H.Generators.IntegrationTests.MyGrid.Properties.Values3.g.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyGrid
    {
        /// <summary>
        /// Identifies the <see cref="Values3"/> dependency property.<br/>
        /// Default value: default(int[,,])
        /// </summary>
        public static readonly global::Microsoft.Maui.Controls.BindableProperty Values3Property =
            global::Microsoft.Maui.Controls.BindableProperty.Create(
                propertyName: "Values3",
                returnType: typeof(int[,,]),
                declaringType: typeof(global::H.Generators.IntegrationTests.MyGrid),
                defaultValue: default(int[,,]),
                defaultBindingMode: global::Microsoft.Maui.Controls.BindingMode.OneWay,
                validateValue: null,
                propertyChanged: null,
                propertyChanging: null,
                coerceValue: null,
                defaultValueCreator: null);

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
        partial void OnValues3Changing();
        partial void OnValues3Changing(int[,,]? newValue);
        partial void OnValues3Changing(int[,,]? oldValue, int[,,]? newValue);
    }
}