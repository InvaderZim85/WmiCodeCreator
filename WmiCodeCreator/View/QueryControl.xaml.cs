using System.Windows.Controls;
using MahApps.Metro.Controls.Dialogs;
using WmiCodeCreator.ViewModel;

namespace WmiCodeCreator.View
{
    /// <summary>
    /// Interaction logic for QueryControl.xaml
    /// </summary>
    public partial class QueryControl : UserControl, IUserControl
    {
        /// <summary>
        /// Gets the description of the class
        /// </summary>
        public string Description => "Query for data from a WMI class";

        /// <summary>
        /// Creates a new instance of the <see cref="QueryControl"/>
        /// </summary>
        public QueryControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Init the control
        /// </summary>
        public void InitControl()
        {
            if (DataContext is QueryControlViewModel viewModel)
                viewModel.InitViewModel(DialogCoordinator.Instance);
        }
    }
}
