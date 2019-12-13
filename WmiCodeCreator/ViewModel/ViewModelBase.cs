using System;
using System.Threading;
using System.Threading.Tasks;
using MahApps.Metro.Controls.Dialogs;
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
