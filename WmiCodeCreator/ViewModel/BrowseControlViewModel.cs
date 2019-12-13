using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Windows.Input;
using MahApps.Metro.Controls.Dialogs;
using WmiCodeCreator.Business;
using WmiCodeCreator.DataObject;
using ZimLabs.WpfBase;

namespace WmiCodeCreator.ViewModel
{
    internal class BrowseControlViewModel : ViewModelBase
    {
        /// <summary>
        /// Backing field for <see cref="Namespaces"/>
        /// </summary>
        private List<NamespaceItem> _namespaces;

        /// <summary>
        /// Gets or sets the namespaces
        /// </summary>
        public List<NamespaceItem> Namespaces
        {
            get => _namespaces;
            set => SetField(ref _namespaces, value);
        }

        /// <summary>
        /// Backing field for <see cref="SelectedNamespace"/>
        /// </summary>
        private NamespaceItem _selectedNamespace;

        /// <summary>
        /// Gets or sets the selected namespace
        /// </summary>
        public NamespaceItem SelectedNamespace
        {
            get => _selectedNamespace;
            set
            {
                if (SetField(ref _selectedNamespace, value) && value != null)
                {
                    if (value.ClassesCompleteList != null && value.ClassesCompleteList.Any())
                    {
                        Classes = value.ClassesCompleteList;
                    }
                    else
                    {
                        LoadClasses();
                    }

                    DescriptionClass = "";
                    DescriptionMethod = "";
                    DescriptionProperty = "";
                }
            }
        }

        /// <summary>
        /// Backing field for <see cref="Classes"/>
        /// </summary>
        private List<ClassItem> _classes;

        /// <summary>
        /// Gets or sets the list with the classes of the WMI namespace
        /// </summary>
        public List<ClassItem> Classes
        {
            get => _classes;
            set => SetField(ref _classes, value);
        }

        /// <summary>
        /// Backing field for <see cref="SelectedClass"/>
        /// </summary>
        private ClassItem _selectedClass;

        /// <summary>
        /// Gets or sets the selected WMI class
        /// </summary>
        public ClassItem SelectedClass
        {
            get => _selectedClass;
            set
            {
                if (SetField(ref _selectedClass, value) && value != null)
                {
                    if (value.Properties != null && value.Properties.Any())
                    {
                        Properties = value.Properties;
                    }
                    else
                    {
                        LoadProperties();
                    }
                }

                DescriptionClass = value?.Description ?? "";
                DescriptionMethod = "";
                DescriptionProperty = "";

                // Empty the list
                Methods = new List<MethodItem>();
                Qualifier = new List<string>();
            }
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
        /// Backing field for <see cref="SelectedProperty"/>
        /// </summary>
        private PropertyItem _selectedProperty;

        /// <summary>
        /// Gets or sets the selected property
        /// </summary>
        public PropertyItem SelectedProperty
        {
            get => _selectedProperty;
            set
            {
                SetField(ref _selectedProperty, value);
                DescriptionProperty = value?.Description ?? "";
            }
        }

        /// <summary>
        /// Backing field for <see cref="Methods"/>
        /// </summary>
        private List<MethodItem> _methods;

        /// <summary>
        /// Gets or sets the list with the methods
        /// </summary>
        public List<MethodItem> Methods
        {
            get => _methods;
            set => SetField(ref _methods, value);
        }

        /// <summary>
        /// Backing field for <see cref="SelectedMethod"/>
        /// </summary>
        private MethodItem _selectedMethod;

        /// <summary>
        /// Gets or sets the selected method
        /// </summary>
        public MethodItem SelectedMethod
        {
            get => _selectedMethod;
            set
            {
                SetField(ref _selectedMethod, value);
                DescriptionMethod = value?.Description ?? "";
            }
        }

        /// <summary>
        /// Backing field for <see cref="Qualifier"/>
        /// </summary>
        private List<string> _qualifier;

        /// <summary>
        /// Gets or sets the list with the qualifier
        /// </summary>
        public List<string> Qualifier
        {
            get => _qualifier;
            set => SetField(ref _qualifier, value);
        }

        /// <summary>
        /// Backing field for <see cref="DescriptionClass"/>
        /// </summary>
        private string _descriptionClass;

        /// <summary>
        /// Gets or sets the description text
        /// </summary>
        public string DescriptionClass
        {
            get => _descriptionClass;
            set => SetField(ref _descriptionClass, value);
        }

        /// <summary>
        /// Backing field for <see cref="DescriptionProperty"/>
        /// </summary>
        private string _descriptionProperty;

        /// <summary>
        /// Gets or sets the description of the selected property
        /// </summary>
        public string DescriptionProperty
        {
            get => _descriptionProperty;
            set => SetField(ref _descriptionProperty, value);
        }

        /// <summary>
        /// Backing field for <see cref="DescriptionMethod"/>
        /// </summary>
        private string _descriptionMethod;

        /// <summary>
        /// Gets or set the description of the selected method
        /// </summary>
        public string DescriptionMethod
        {
            get => _descriptionMethod;
            set => SetField(ref _descriptionMethod, value);
        }

        /// <summary>
        /// Init the view model
        /// </summary>
        /// <param name="dialogCoordinator">The instance of the mah apps dialog coordinator</param>
        public void InitViewModel(IDialogCoordinator dialogCoordinator)
        {
            SetDialogCoordinator(dialogCoordinator);

            Namespaces = WmiHelper.Namespaces;
        }

        /// <summary>
        /// Loads the classes
        /// </summary>
        private async void LoadClasses()
        {
            Classes = await LoadClasses(SelectedNamespace, true);
        }

        /// <summary>
        /// The command to load the methods
        /// </summary>
        public ICommand LoadAdditionalDataCommand => new DelegateCommand(LoadAdditionalData);

        /// <summary>
        /// Loads the properties of the selected class
        /// </summary>
        private async void LoadProperties()
        {
            Properties = await LoadProperties(SelectedNamespace, SelectedClass);
            SelectedClass.Properties = Properties;
        }

        /// <summary>
        /// Loads the methods of the class
        /// </summary>
        private async void LoadAdditionalData()
        {
            if (SelectedNamespace == null || SelectedClass == null)
                return;

            if (SelectedClass.Methods != null && SelectedClass.Methods.Any())
            {
                Methods = SelectedClass.Methods;
                return;
            }

            var controller =
                await ShowProgress("Loading", "Please wait while loading the methods...");
            controller.SetIndeterminate();

            try
            {
                var methods = await ExecuteAction(token => WmiHelper.LoadMethods(SelectedNamespace.Name, SelectedClass.Name, token));
                Methods = methods;
                SelectedClass.Methods = methods;

                // Step 2: Load the qualifier
                controller.SetMessage("Please wait while loading the qualifiers...");
                var qualifier = await ExecuteAction(token =>
                    WmiHelper.LoadQualifiers(SelectedNamespace.Name, SelectedClass.Name, token));

                    Qualifier = qualifier;
                SelectedClass.Qualifiers = qualifier;
            }
            catch (ManagementException mex)
            {
                await ShowMessage("Error",
                    $"An error has occured while loading the methods.\r\n\r\nMessage: {mex.Message}");
            }
            finally
            {
                await controller.CloseAsync();
            }
        }
    }
}
