#nullable enable

namespace DependencyPropertyGenerator;

/// <summary>
/// Describes the timing of binding source updates.
/// </summary>
public enum SourceTrigger
{
    /// <summary>
    /// The default System.Windows.Data.UpdateSourceTrigger value of the binding target
    /// property. The default value for most dependency properties is 
    /// System.Windows.Data.UpdateSourceTrigger.PropertyChanged,
    /// while the System.Windows.Controls.TextBox.Text property has a default value of
    /// System.Windows.Data.UpdateSourceTrigger.LostFocus.
    /// </summary>
    Default = 0,

    /// <summary>
    /// Updates the binding source immediately whenever the binding target property changes.
    /// </summary>
    PropertyChanged = 1,

    /// <summary>
    /// Updates the binding source whenever the binding target element loses focus.
    /// </summary>
    LostFocus = 2,

    /// <summary>
    /// Updates the binding source only when you call the System.Windows.Data.BindingExpression.UpdateSource method.
    /// </summary>
    Explicit = 3,
}