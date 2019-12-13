using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Threading;
using System.Threading.Tasks;
using MahApps.Metro.Controls.Dialogs;
using WmiCodeCreator.Business;
using WmiCodeCreator.DataObject;
using ZimLabs.WpfBase;

namespace WmiCodeCreator.ViewModel
{
    /// <summary>
    /// Provides the base methods of a view model
    /// </summary>
    internal class ViewModelBase : ObservableObject
    {
        /// <summary>
        /// Contains the instance of the mah apps dialog coordinator
        /// </summary>
        private IDialogCoordinator _dialogCoordinator;

        /// <summary>
        /// Sets the dialog coordinator
        /// </summary>
        /// <param name="dialogCoordinator">The instance of the mah apps dialog coordinator</param>
        public void SetDialogCoordinator(IDialogCoordinator dialogCoordinator)
        {
            _dialogCoordinator = dialogCoordinator;
        }

        /// <summary>
        /// Executes an action asynchronously
        /// </summary>
        /// <typeparam name="TResult">The type of the result</typeparam>
        /// <param name="action">The action wich should be executed</param>
        /// <returns>The result</returns>
        protected async Task<TResult> ExecuteAction<TResult>(Func<CancellationToken, TResult> action)
        {
            var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            var token = cancellationTokenSource.Token;

            try
            {
                var result = await Task.Run(() => action(token), token);
                return result;
            }
            catch (TaskCanceledException)
            {
                await _dialogCoordinator.ShowMessageAsync(this, "Error",
                    "The execution was aborted due to an unusually long execution time.");

                return default;
            }
        }

        /// <summary>
        /// Loads the classes
        /// </summary>
        /// <param name="selectedNamespace">The selected namespace</param>
        /// <param name="completeList">true to get the complete list, otherwise false</param>
        /// <returns>The list with the classes</returns>
        protected async Task<List<ClassItem>> LoadClasses(NamespaceItem selectedNamespace, bool completeList)
        {
            if (selectedNamespace == null)
                return new List<ClassItem>();

            if (completeList && selectedNamespace.ClassesCompleteList != null &&
                selectedNamespace.ClassesCompleteList.Any())
            {
                return selectedNamespace.ClassesCompleteList;
            }

            if (!completeList && selectedNamespace.Classes != null && selectedNamespace.Classes.Any())
            {
                return selectedNamespace.Classes;
            }

            var msg = "Please wait while loading the classes...";
            var controller =
                await ShowProgress("Loading", msg);
            controller.SetIndeterminate();

            WmiHelper.InfoEvent += m => controller.SetMessage($"{msg}\r\n\r\n{m}");

            try
            {
                return await ExecuteAction(token => WmiHelper.LoadClasses(selectedNamespace.Name, true, token));
            }
            catch (ManagementException mex)
            {
                await ShowMessage("Error",
                    $"An error has occured while loading the classes.\r\n\r\nMessage: {mex.Message}");
                return new List<ClassItem>();
            }
            catch (Exception ex)
            {
                await ShowMessage("Error",
                    $"An error has occured while loading the classes.\r\n\r\nMessage: {ex.Message}");
                return new List<ClassItem>();
            }
            finally
            {
                await controller.CloseAsync();
            }
        }

        /// <summary>
        /// Loads the properties
        /// </summary>
        /// <param name="selectedNamespace">The selected namespace</param>
        /// <param name="selectedClass">The selected class</param>
        /// <returns>The list with the properties</returns>
        protected async Task<List<PropertyItem>> LoadProperties(NamespaceItem selectedNamespace,
            ClassItem selectedClass)
        {
            if (string.IsNullOrEmpty(selectedNamespace?.Name) || string.IsNullOrEmpty(selectedClass?.Name))
                return new List<PropertyItem>();

            var controller =
                await ShowProgress("Loading", "Please wait while loading the properties");

            try
            {
                return await ExecuteAction(token =>
                    WmiHelper.LoadProperties(selectedNamespace.Name, selectedClass.Name, token));
            }
            catch (ManagementException mex)
            {
                await ShowMessage("Error",
                    $"An error has occured while loading the properties.\r\n\r\nMessage: {mex.Message}");
                return new List<PropertyItem>();
            }
            finally
            {
                await controller.CloseAsync();
            }
        }

        /// <summary>
        /// Shows a message
        /// </summary>
        /// <param name="header">The header</param>
        /// <param name="message">The message</param>
        /// <returns>The awaitable task</returns>
        protected async Task ShowMessage(string header, string message)
        {
            await _dialogCoordinator.ShowMessageAsync(this, header, message);
        }

        /// <summary>
        /// Shows the mah apps progress dialog
        /// </summary>
        /// <param name="header">The header</param>
        /// <param name="message">The message</param>
        /// <returns>The controller of the progress dialog</returns>
        protected async Task<ProgressDialogController> ShowProgress(string header, string message)
        {
            return await _dialogCoordinator.ShowProgressAsync(this, header, message);
        }
    }
}
