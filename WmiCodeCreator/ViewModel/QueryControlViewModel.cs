using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Gemini.Framework;
using MahApps.Metro.Controls.Dialogs;
using WmiCodeCreator.Business;
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
        /// Contains the cancellation token source
        /// </summary>
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));

        /// <summary>
        /// The action to set the source code
        /// </summary>
        private Action<string> _setSourceCode;

        /// <summary>
        /// Contains the source code
        /// </summary>
        private string _sourceCode;

        /// <summary>
        /// Backing field for <see cref="Namespaces"/>
        /// </summary>
        private List<NamespaceItem> _namespaces;

        /// <summary>
        /// Gets or sets the list with the WMI namespaces
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
        /// Gets or sets the selected WMI namespace
        /// </summary>
        public NamespaceItem SelectedNamespace
        {
            get => _selectedNamespace;
            set
            {
                if (SetField(ref _selectedNamespace, value) && value != null)
                {
                    if (value.Classes != null && value.Classes.Any())
                    {
                        Classes = value.Classes;
                    }
                    else
                    {
                        LoadClasses();
                    }
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
        /// Backing field for <see cref="SelectedProperties"/>
        /// </summary>
        private List<PropertyItem> _selectedProperties = new List<PropertyItem>();

        /// <summary>
        /// Gets or sets the list with the selected properties
        /// </summary>
        public List<PropertyItem> SelectedProperties
        {
            get => _selectedProperties;
            set => SetField(ref _selectedProperties, value);
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
        /// <param name="setSourceCode">The action to set the source code</param>
        public void InitViewModel(IDialogCoordinator dialogCoordinator, Action<string> setSourceCode)
        {
            _dialogCoordinator = dialogCoordinator;

            _setSourceCode = setSourceCode;

            Namespaces = WmiHelper.Namespaces;
        }

        /// <summary>
        /// The command to load the values
        /// </summary>
        public ICommand LoadValuesCommand => new DelegateCommand(LoadValues);

        /// <summary>
        /// The command to create the code
        /// </summary>
        public ICommand CreateCodeCommand => new DelegateCommand(CreateCode);

        /// <summary>
        /// Loads the classes
        /// </summary>
        private async void LoadClasses()
        {
            if (string.IsNullOrEmpty(SelectedNamespace?.Name))
                return;

            var controller =
                await _dialogCoordinator.ShowProgressAsync(this, "Loading", "Please wait while loading the classes");

            try
            {
                var classes = await Task.Run(() => WmiHelper.LoadClasses(SelectedNamespace.Name));
                Classes = classes;
                SelectedNamespace.Classes = classes;
            }
            catch (ManagementException mex)
            {
                await _dialogCoordinator.ShowMessageAsync(this, "Error",
                    $"An error has occured while loading the classes.\r\n\r\nMessage: {mex.Message}");
            }
            finally
            {
                await controller.CloseAsync();
            }
        }

        /// <summary>
        /// Loads the properties of the selected class
        /// </summary>
        private async void LoadProperties()
        {
            if (string.IsNullOrEmpty(SelectedNamespace?.Name) || string.IsNullOrEmpty(SelectedClass?.Name))
                return;

            var controller =
                await _dialogCoordinator.ShowProgressAsync(this, "Loading", "Please wait while loading the properties");

            try
            {
                var properties = await Task.Run(() => WmiHelper.LoadProperties(SelectedNamespace.Name, SelectedClass.Name));
                Properties = properties;
                SelectedClass.Properties = properties;
            }
            catch (ManagementException mex)
            {
                await _dialogCoordinator.ShowMessageAsync(this, "Error",
                    $"An error has occured while loading the properties.\r\n\r\nMessage: {mex.Message}");
            }
            finally
            {
                await controller.CloseAsync();
            }
        }

        /// <summary>
        /// Loads the values of the selected property, class and namespace
        /// </summary>
        private async void LoadValues()
        {
            if (string.IsNullOrEmpty(SelectedNamespace?.Name) || string.IsNullOrEmpty(SelectedClass?.Name) ||
                SelectedProperties == null || !SelectedProperties.Any())
                return;

            var token = _cancellationTokenSource.Token;

            var controller =
                await _dialogCoordinator.ShowProgressAsync(this, "Loading", "Please wait while loading the values",
                    true);
            controller.SetIndeterminate();

            controller.Canceled += (s, e) =>
            {
                _cancellationTokenSource.Cancel();
            };

            try
            {
                var values = await Task.Run(() => WmiHelper.LoadValues(SelectedNamespace.Name, SelectedClass.Name,
                    SelectedProperties.Select(s => s.Name).ToList(), token), token);

                Values = values;
            }
            catch (ManagementException mex)
            {
                await _dialogCoordinator.ShowMessageAsync(this, "Error",
                    $"An error has occured while loading the values.\r\n\r\nMessage: {mex.Message}");
            }
            catch (TaskCanceledException)
            {
                await _dialogCoordinator.ShowMessageAsync(this, "Warning", "Action aborted.");
            }
            catch (Exception ex)
            {
                await _dialogCoordinator.ShowMessageAsync(this, "Error",
                    $"An error has occured while loading the values.\r\n\r\nMessage: {ex.Message}");
            }
            finally
            {
                await controller.CloseAsync();
            }
        }

        /// <summary>
        /// Creates the csharp code according to the selected items
        /// </summary>
        private async void CreateCode()
        {
            try
            {
                _sourceCode = CodeCreator.CreateCSharpCode(SelectedNamespace, SelectedClass, SelectedProperties);
                _setSourceCode(_sourceCode);
            }
            catch (Exception ex)
            {
                await _dialogCoordinator.ShowMessageAsync(this, "Error",
                    $"An error has occured while creating the code.\r\n\r\nMessage: {ex.Message}");
            }
        }
    }
}
