#nullable enable

namespace DependencyPropertyGenerator;

/// <summary>
/// Describes the direction of the data flow in a binding.
/// </summary>
public enum DefaultBindingMode
{
    /// <summary>
    /// Causes changes to either the source property or the target property to automatically
    /// update the other. This type of binding is appropriate for editable forms or other
    /// fully-interactive UI scenarios.
    /// </summary>
    TwoWay = 0,

    /// <summary>
    /// Updates the binding target (target) property when the binding source (source)
    /// changes. This type of binding is appropriate if the control being bound is implicitly
    /// read-only. For instance, you may bind to a source such as a stock ticker. Or
    /// perhaps your target property has no control interface provided for making changes,
    /// such as a data-bound background color of a table. If there is no need to monitor
    /// the changes of the target property, using the System.Windows.Data.BindingMode.OneWay
    /// binding mode avoids the overhead of the System.Windows.Data.BindingMode.TwoWay
    /// binding mode.
    /// </summary>
    OneWay = 1,

    /// <summary>
    /// Updates the binding target when the application starts or when the data context
    /// changes. This type of binding is appropriate if you are using data where either
    /// a snapshot of the current state is appropriate to use or the data is truly static.
    /// This type of binding is also useful if you want to initialize your target property
    /// with some value from a source property and the data context is not known in advance.
    /// This is essentially a simpler form of System.Windows.Data.BindingMode.OneWay
    /// binding that provides better performance in cases where the source value does
    /// not change.
    /// </summary>
    OneTime = 2,

    /// <summary>
    /// Updates the source property when the target property changes.
    /// </summary>
    OneWayToSource = 3,

    /// <summary>
    /// Uses the default System.Windows.Data.Binding.Mode value of the binding target.
    /// The default value varies for each dependency property. In general, user-editable
    /// control properties, such as those of text boxes and check boxes, default to two-way
    /// bindings, whereas most other properties default to one-way bindings. A programmatic
    /// way to determine whether a dependency property binds one-way or two-way by default
    /// is to get the property metadata of the property using System.Windows.DependencyProperty.GetMetadata(System.Type)
    /// and then check the Boolean value of the System.Windows.FrameworkPropertyMetadata.BindsTwoWayByDefault
    /// property.
    /// </summary>
    Default = 4,
}