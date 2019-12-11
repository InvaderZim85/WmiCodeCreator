using MahApps.Metro.Controls.Dialogs;

namespace WmiCodeCreator.View
{
    /// <summary>
    /// The interface for the user controls
    /// </summary>
    internal interface IUserControl
    {
        /// <summary>
        /// Gets the description of the user control
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Init the user control
        /// </summary>
        /// <param name="dialogCoordinator">The instance of the mah apps dialog coordinator</param>
        void InitControl(IDialogCoordinator dialogCoordinator);
    }
}
