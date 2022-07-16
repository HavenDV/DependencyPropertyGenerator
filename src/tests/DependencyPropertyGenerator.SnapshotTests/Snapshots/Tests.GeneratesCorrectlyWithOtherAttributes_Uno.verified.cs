﻿//HintName: MyControl.Properties.IsSpinning5.generated.cs

#nullable enable

namespace H.Generators.IntegrationTests
{
    public partial class MyControl
    {
        /// <summary>
        /// Default value: default(bool)
        /// </summary>
        public static readonly global::Windows.UI.Xaml.DependencyProperty IsSpinning5Property =
            global::Windows.UI.Xaml.DependencyProperty.Register(
                name: "IsSpinning5",
                propertyType: typeof(bool),
                ownerType: typeof(global::H.Generators.IntegrationTests.MyControl),
                typeMetadata: global::Windows.UI.Xaml.PropertyMetadata.Create(
                    defaultValue: default(bool),
                    propertyChangedCallback: static (sender, args) =>
                    {
                        ((global::H.Generators.IntegrationTests.MyControl)sender).OnIsSpinning5Changed();
                        ((global::H.Generators.IntegrationTests.MyControl)sender).OnIsSpinning5Changed(
                            (bool)args.NewValue);
                        ((global::H.Generators.IntegrationTests.MyControl)sender).OnIsSpinning5Changed(
                            (bool)args.OldValue,
                            (bool)args.NewValue);
                    }));

        /// <summary>
        /// Default value: default(bool)
        /// </summary>
        public bool IsSpinning5
        {
            get => (bool)GetValue(IsSpinning5Property);
            set => SetValue(IsSpinning5Property, value);
        }

        partial void OnIsSpinning5Changed();
        partial void OnIsSpinning5Changed(bool newValue);
        partial void OnIsSpinning5Changed(bool oldValue, bool newValue);
    }
}