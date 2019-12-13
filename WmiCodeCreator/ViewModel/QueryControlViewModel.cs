using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MahApps.Metro.Controls.Dialogs;
using WmiCodeCreator.Business;
using WmiCodeCreator.DataObject;
using WmiCodeCreator.View.ParamValues;
using ZimLabs.WpfBase;

namespace WmiCodeCreator.ViewModel
{
    /// <summary>
    /// Provides the logic for the query control
    /// </summary>
    internal class QueryControlViewModel : ViewModelBase
    {
        /// <summary>
        /// The action to set the source code
        /// </summary>
        private Action<string> _setSourceCode;

        /// <summary>
        /// The action to set the property text
        /// </summary>
        private Action<string> _setPropertyText;

        /// <summary>
        /// Contains the source code
        /// </summary>
        private string _sourceCode;

        /// <summary>
        /// Contains the property text
        /// </summary>
        private string _propertyText;

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
        /// Backing field for <see cref="PropertyHeader"/>
        /// </summary>
        private string _propertyHeader = "Properties";

        /// <summary>
        /// Gets or sets the property header
        /// </summary>
        public string PropertyHeader
        {
            get => _propertyHeader;
            set => SetField(ref _propertyHeader, value);
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
        /// Init the view model
        /// </summary>
        /// <param name="dialogCoordinator">The instance of the mah apps dialog coordinator</param>
        /// <param name="setSourceCode">The action to set the source code</param>
        /// <param name="setPropertyText">The action to set the property text</param>
        public void InitViewModel(IDialogCoordinator dialogCoordinator, Action<string> setSourceCode, Action<string> setPropertyText)
        {
            SetDialogCoordinator(dialogCoordinator);

            _setSourceCode = setSourceCode;
            _setPropertyText = setPropertyText;

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
        /// The command to copy the source code to the clip board
        /// </summary>
        public ICommand CopyCommand => new RelayCommand<CopyType>((t) =>
        {
            Clipboard.SetText(t == CopyType.PropertyText ? _propertyText : _sourceCode);
        });

        /// <summary>
        /// The command to show the help
        /// </summary>
        public ICommand ShowHelpCommand => new DelegateCommand(() =>
        {
            var queryPath =
                $"https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/{SelectedClass.Name.Replace("_", "-")}";

            Process.Start(queryPath);
        });

        /// <summary>
        /// Loads the classes
        /// </summary>
        private async void LoadClasses()
        {
            if (string.IsNullOrEmpty(SelectedNamespace?.Name))
                return;

            var msg = "Please wait while loading the classes...";
            var controller = await ShowProgress("Loading", msg);
            controller.SetIndeterminate();

            WmiHelper.InfoEvent += m => controller.SetMessage($"{msg}\r\n\r\n{m}");

            try
            {
                var classes = await ExecuteAction(token => WmiHelper.LoadClasses(SelectedNamespace.Name, false, token));
                Classes = classes;
                SelectedNamespace.Classes = classes;
            }
            catch (ManagementException mex)
            {
                await ShowMessage("Error", $"An error has occured while loading the classes.\r\n\r\nMessage: {mex.Message}");
            }
            catch (Exception ex)
            {
                await ShowMessage("Error",
                    $"An error has occured while loading the classes.\r\n\r\nMessage: {ex.Message}");
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

            var controller = await ShowProgress("Loading", "Please wait while loading the properties");

            try
            {
                var properties = await ExecuteAction(token =>
                    WmiHelper.LoadProperties(SelectedNamespace.Name, SelectedClass.Name, token));
                Properties = properties;
                SelectedClass.Properties = properties;

                PropertyHeader = $"Properties ({properties.Count})";
            }
            catch (ManagementException mex)
            {
                await ShowMessage("Error", $"An error has occured while loading the properties.\r\n\r\nMessage: {mex.Message}");
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
                SelectedProperties == null)
                return;

            var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            var token = cancellationTokenSource.Token;

            var controller =
                await ShowProgress("Loading", "Please wait while loading the values.");
            controller.SetIndeterminate();

            try
            {
                var values = await Task.Run(() => WmiHelper.LoadValues(SelectedNamespace.Name, SelectedClass.Name, token), token);

                SetPropertyText(values);
            }
            catch (ManagementException mex)
            {
                await ShowMessage("Error",
                    $"An error has occured while loading the values.\r\n\r\nMessage: {mex.Message}");
            }
            catch (TaskCanceledException)
            {
                await ShowMessage("Warning",
                    "The process takes longer than expected and was aborted.");
            }
            catch (Exception ex)
            {
                await ShowMessage("Error",
                    $"An error has occured while loading the values.\r\n\r\nMessage: {ex.Message}");
            }
            finally
            {
                await controller.CloseAsync();
                cancellationTokenSource.Dispose();
            }
        }

        /// <summary>
        /// Sets the property text
        /// </summary>
        /// <param name="values">The list with the values</param>
        private void SetPropertyText(List<string> values)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{values.Count} instances found");

            var count = 1;
            foreach (var entry in values.Distinct())
            {
                sb.AppendLine($"---- {count++} ----");
                sb.AppendLine(entry);
            }

            _propertyText = sb.ToString();
            _setPropertyText(_propertyText);
        }

        /// <summary>
        /// Creates the csharp code according to the selected items
        /// </summary>
        private async void CreateCode()
        {
            try
            {
                if (SelectedProperties == null || !SelectedProperties.Any())
                {
                    _setSourceCode("// Select a property from the left...");
                    return;
                }

                _sourceCode = CodeCreator.CreateCSharpCode(SelectedNamespace, SelectedClass, SelectedProperties);
                _setSourceCode(_sourceCode);
            }
            catch (Exception ex)
            {
                await ShowMessage("Error",
                    $"An error has occured while creating the code.\r\n\r\nMessage: {ex.Message}");
            }
        }
    }
}
