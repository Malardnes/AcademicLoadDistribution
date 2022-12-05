using Ald.App.Infrastructure.Commands.Base;

namespace Ald.App.Infrastructure.Commands
{
    /// <summary>
    /// Команда завершения работы программы.
    /// </summary>
    internal class CloseApplicationCommand : Command
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter) => App.Current.Shutdown(0);
    }
}
