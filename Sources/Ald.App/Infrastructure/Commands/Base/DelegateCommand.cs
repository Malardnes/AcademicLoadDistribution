using System;

namespace Ald.App.Infrastructure.Commands.Base
{
    /// <summary>
    /// Класс, который позволяет создать команду.
    /// </summary>
    internal class DelegateCommand : Command
    {
        // Делегат на метод, выполняющий команду.
        private readonly Action<object> _execute;

        // Делегат на функцию, которая определяет, возможно ли выполнение команды в данный момент.
        private readonly Func<object, bool> _canExecute;

        /// <summary>
        /// Конструктор команды - создает команду.
        /// </summary>
        /// <param name="execute">
        /// Делегат на метод, выполняющий команду.
        /// </param>
        /// <param name="canExecute">
        /// Делегат на функцию, которая определяет,
        /// возможно ли выполнение команды в данный момент.
        /// </param>
        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
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
        public override bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;

        /// <summary>
        /// Метод, который будет вызываться при вызове команды.
        /// </summary>
        /// <param name="parameter">
        /// Данные, используемые командой. Если команда не требует передачи данных,
        /// этому объекту может быть присвоено значение null.
        /// </param>
        public override void Execute(object parameter) => _execute(parameter);
    }
}
