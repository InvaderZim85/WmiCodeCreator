using System.Collections.Generic;
using MahApps.Metro.Controls.Dialogs;
using WmiCodeCreator.DataObject;
using ZimLabs.WpfBase;

namespace WmiCodeCreator.ViewModel
{
    /// <summary>
    /// Provides the logic for the query control
    /// </summary>
    internal class QueryControlViewModel : ObservableObject
    {
        /// <summary>
        /// Contains the instance of the mah apps dialog coordinator
        /// </summary>
        private IDialogCoordinator _dialogCoordinator;

        /// <summary>
        /// Backing field for <see cref="Namespaces"/>
        /// </summary>
        private List<string> _namespaces;

        /// <summary>
        /// Gets or sets the list with the WMI namespaces
        /// </summary>
        public List<string> Namespaces
        {
            get => _namespaces;
            set => SetField(ref _namespaces, value);
        }

        /// <summary>
        /// Backing field for <see cref="SelectedNamespace"/>
        /// </summary>
        private string _selectedNamespace;

        /// <summary>
        /// Gets or sets the selected WMI namespace
        /// </summary>
        public string SelectedNamespace
        {
            get => _selectedNamespace;
            set => SetField(ref _selectedNamespace, value);
        }

        /// <summary>
        /// Backing field for <see cref="Classes"/>
        /// </summary>
        private List<string> _classes;

        /// <summary>
        /// Gets or sets the list with the classes of the WMI namespace
        /// </summary>
        public List<string> Classes
        {
            get => _classes;
            set => SetField(ref _classes, value);
        }

        /// <summary>
        /// Backing field for <see cref="SelectedClass"/>
        /// </summary>
        private string _selectedClass;

        /// <summary>
        /// Gets or sets the selected WMI class
        /// </summary>
        public string SelectedClass
        {
            get => _selectedClass;
            set => SetField(ref _selectedClass, value);
        }

        /// <summary>
        /// Backing field for <see cref="Properties"/>
        /// </summary>
        private List<PropertyItem> _properties;

        /// <summary>
        /// Gets or sets the list with the properties of the WMI class
        /// </summary>
        public List<PropertyItem> Properties
        {
            get => _properties;
            set => SetField(ref _properties, value);
        }

        /// <summary>
        /// Backing field for <see cref="Values"/>
        /// </summary>
        private List<ValueItem> _values;

        /// <summary>
        /// Gets or sets the list with the values
        /// </summary>
        public List<ValueItem> Values
        {
            get => _values;
            set => SetField(ref _values, value);
        }

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
