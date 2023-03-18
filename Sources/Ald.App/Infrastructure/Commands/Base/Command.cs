using System;
using System.Windows.Input;

namespace Ald.App.Infrastructure.Commands.Base
{
    /// <summary>
    /// Базовый класс команды.
    /// </summary>
    internal abstract class Command : ICommand
    {
        /// <summary>
        /// Событие - возникающее, когда происходят изменения, влияющие на то, должна ли команда выполняться или нет.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <summary>
        /// Функция - которая определяет, может ли команда выполняться в ее текущем состоянии.
        /// </summary>
        /// <param name="parameter">
        /// Данные, используемые командой. Если команда не требует передачи данных,
        /// этому объекту может быть присвоено значение null.
        /// </param>
        /// <returns>
        /// true, если эта команда может быть выполнена, в противном случае - false.
        /// </returns>
        public abstract bool CanExecute(object parameter);

        /// <summary>
        /// Метод, который будет вызываться при вызове команды.
        /// </summary>
        /// <param name="parameter">
        /// Данные, используемые командой. Если команда не требует передачи данных,
        /// этому объекту может быть присвоено значение null.
        /// </param>
        public abstract void Execute(object parameter);
    }
}
