using Ald.App.Infrastructure.Commands.Base;
using System.Windows;

namespace Ald.App.Infrastructure.Commands
{
    /// <summary>
    /// Команда закрытия текущего окна.
    /// </summary>
    internal class CloseWindowCommand : Command
    {
        public override bool CanExecute(object parameter) => parameter is Window window && window is not null;

        public override void Execute(object parameter) => App.CurrentWindow.Close();
    }
}
