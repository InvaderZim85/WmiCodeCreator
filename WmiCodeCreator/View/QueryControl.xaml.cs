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
        /// <param name="dialogCoordinator">The instance of the mah apps dialog coordinator</param>
        public void InitControl(IDialogCoordinator dialogCoordinator)
        {
            if (!(DataContext is QueryControlViewModel viewModel)) 
                return;

            viewModel.InitViewModel(dialogCoordinator, SetSourceCode, SetPropertyText);
        }

        /// <summary>
        /// Sets the text of the source code control
        /// </summary>
        /// <param name="sourceCode">The source code</param>
        private void SetSourceCode(string sourceCode)
        {
            CodeEditorControl.Text = sourceCode;
        }

        /// <summary>
        /// Sets the text of the property text control
        /// </summary>
        /// <param name="propertyText">The property text</param>
        private void SetPropertyText(string propertyText)
        {
            CodeEditorPropertyText.Text = propertyText;
        }
    }
}
