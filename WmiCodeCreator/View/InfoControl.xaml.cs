using System.Windows.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace WmiCodeCreator.View
{
    /// <summary>
    /// Interaction logic for InfoControl.xaml
    /// </summary>
    public partial class InfoControl : UserControl, IUserControl
    {
        /// <summary>
        /// Gets the description
        /// </summary>
        public string Description => "Info";

        /// <summary>
        /// Creates a new instance of the <see cref="InfoControl"/>
        /// </summary>
        public InfoControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Init the control
        /// </summary>
        /// <param name="dialogCoordinator">The instance of the mah apps dialog coordinator</param>
        public void InitControl(IDialogCoordinator dialogCoordinator)
        {
            // Not needed in this case
        }
    }
}
