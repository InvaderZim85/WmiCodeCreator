using System.Windows.Controls;
using MahApps.Metro.Controls.Dialogs;
using WmiCodeCreator.ViewModel;

namespace WmiCodeCreator.View
{
    /// <summary>
    /// Interaction logic for BrowseControl.xaml
    /// </summary>
    public partial class BrowseControl : UserControl, IUserControl
    {
        /// <summary>
        /// Gets the description of the control
        /// </summary>
        public string Description => "Browse the namespaces on this computer";

        /// <summary>
        /// Creates a new instance of the <see cref="BrowseControl"/>
        /// </summary>
        public BrowseControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Init the control
        /// </summary>
        /// <param name="dialogCoordinator">The instance of the mah apps dialog coordinator</param>
        public void InitControl(IDialogCoordinator dialogCoordinator)
        {
            if (DataContext is BrowseControlViewModel viewModel)
                viewModel.InitViewModel(dialogCoordinator);
        }
    }
}
