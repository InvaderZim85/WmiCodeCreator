﻿using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using MahApps.Metro.Controls.Dialogs;
using WmiCodeCreator.Business;
using WmiCodeCreator.View;
using WmiCodeCreator.View.ParamValues;
using ZimLabs.Utility;
using ZimLabs.WpfBase;

namespace WmiCodeCreator.ViewModel
{
    /// <summary>
    /// Provides the logic for the main window (MVVM pattern)
    /// </summary>
    internal class MainWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// Contains the dictionary with the controls
        /// </summary>
        private readonly Dictionary<MenuType, IUserControl> _controlDictionary = new Dictionary<MenuType, IUserControl>();

        /// <summary>
        /// Backing field for <see cref="Control"/>
        /// </summary>
        private object _control;

        /// <summary>
        /// Gets or sets the currently selected content
        /// </summary>
        public object Control
        {
            get => _control;
            set => SetField(ref _control, value);
        }

        /// <summary>
        /// Backing field for <see cref="ControlDescription"/>
        /// </summary>
        private string _controlDescription = "WMI Code Creator";

        /// <summary>
        /// Gets or sets the description of the control
        /// </summary>
        public string ControlDescription
        {
            get => _controlDescription;
            set => SetField(ref _controlDescription, value);
        }

        /// <summary>
        /// Backing field for <see cref="Version"/>
        /// </summary>
        private string _version = "Version: /";

        /// <summary>
        /// Gets or sets the version
        /// </summary>
        public string Version
        {
            get => _version;
            set => SetField(ref _version, value);
        }

        /// <summary>
        /// Init the view model
        /// </summary>
        /// <param name="dialogCoordinator">The instance of the mah apps dialog coordinator</param>
        public void InitViewModel(IDialogCoordinator dialogCoordinator)
        {
            SetDialogCoordinator(dialogCoordinator);

            Version = $"Version: {Assembly.GetExecutingAssembly().GetName().Version}";

            SwitchControl(MenuType.Info);
        }

        /// <summary>
        /// Init the wmi helper and loads the namespaces
        /// </summary>
        public async void InitWmiManager()
        {
            var msg = "Please wait while loading the namespaces...";
            var controller =
                await ShowProgress("Loading",
                    "Please wait while loading the namespaces...");

            WmiHelper.InfoEvent += m => controller.SetMessage($"{msg}\r\n\r\n{m}");

            controller.SetIndeterminate();
            try
            {
                await Task.Run(WmiHelper.LoadNamespaces);
            }
            catch (ManagementException mex)
            {
                await ShowMessage("Error",
                    $"An error has occured while preparing the WMI helper.\r\n\r\nMessage: {mex.Message}");
            }
            finally
            {
                await controller.CloseAsync();
            }
        }

        /// <summary>
        /// The menu command to select another control
        /// </summary>
        public ICommand MenuCommand => new RelayCommand<MenuType>(SwitchControl);

        /// <summary>
        /// Switches between the controls
        /// </summary>
        /// <param name="type">The desired type</param>
        private async void SwitchControl(MenuType type)
        {
            IUserControl control = null;

            if (_controlDictionary.ContainsKey(type))
            {
                control = _controlDictionary[type];
            }
            else
            {
                switch (type)
                {
                    case MenuType.Info:
                        control = new InfoControl();
                        break;
                    case MenuType.Query:
                        control = new QueryControl();
                        break;
                    case MenuType.Browse:
                        control = new BrowseControl();
                        break;
                    case MenuType.Help:
                        var path = Path.Combine(Global.GetBaseFolder(), "Manual.pdf");
                        Process.Start(path);
                        return;
                    default:
                        await ShowMessage("Error", "The given type is not supported.");
                        break;
                }

                _controlDictionary.Add(type, control);
            }

            if (control == null)
                return;

            ControlDescription = control.Description;
            control.InitControl(DialogCoordinator.Instance);

            Control = control;
        }
    }
}
