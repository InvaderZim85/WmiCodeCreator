using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using WmiCodeCreator.ViewModel;

namespace WmiCodeCreator.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        /// <summary>
        /// Creates a new instance of the <see cref="MainWindow"/>
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Occurs when the window was loaded
        /// </summary>
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainWindowViewModel viewModel)
                viewModel.InitViewModel(DialogCoordinator.Instance);
        }
    }
}
