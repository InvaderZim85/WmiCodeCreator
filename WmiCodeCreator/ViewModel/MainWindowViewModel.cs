using MahApps.Metro.Controls.Dialogs;
using ZimLabs.WpfBase;

namespace WmiCodeCreator.ViewModel
{
    /// <summary>
    /// Provides the logic for the main window (MVVM pattern)
    /// </summary>
    internal class MainWindowViewModel : ObservableObject
    {
        /// <summary>
        /// Contains the instance of the mah apps dialog coordinator
        /// </summary>
        private IDialogCoordinator _dialogCoordinator;

        /// <summary>
        /// Init the view model
        /// </summary>
        /// <param name="dialogCoordinator">The instance of the mah apps dialog coordinator</param>
        public void InitViewModel(IDialogCoordinator dialogCoordinator)
        {
            _dialogCoordinator = dialogCoordinator;
        }
    }
}
