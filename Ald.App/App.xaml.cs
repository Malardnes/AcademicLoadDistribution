using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Ald.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Свойство - используемое во время процесса разработки.
        /// </summary>
        public static bool IsDesignMode { get; private set; } = true;

        /// <summary>
        /// Свойство для чтения. Возвращает текущее активное окно программы или null, если нет активных окон.
        /// </summary>
        public static Window ActiveWindow =>
            Application.Current.Windows.OfType<Window>().SingleOrDefault(window => window.IsActive);

        /// <summary>
        /// Свойство для чтения. Возвращает окно программы на котором установлен фокус ввода или null,
        /// если ни на одном из окон фокус ввода установлен не был.
        /// </summary>
        public static Window FocusedWindow =>
            Application.Current.Windows.OfType<Window>().SingleOrDefault(window => window.IsFocused);

        /// <summary>
        /// Свойство для чтения. Возвращает текущее окно программы или null, если окна отсутствуют.
        /// </summary>
        public static Window CurrentWindow => ActiveWindow ?? FocusedWindow;

        /// <summary>
        /// Метод - вызываемый при старте программы.
        /// </summary>
        /// <param name="e">
        /// Событие - возникающее при старте программы.
        /// </param>
        protected override void OnStartup(StartupEventArgs e)
        {
            IsDesignMode = false;

            base.OnStartup(e);
        }

        /// <summary>
        /// Метод - вызываемый при завершении работы программы.
        /// </summary>
        /// <param name="e">
        /// Событие - возникающее при завершении работы программы.
        /// </param>
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }
    }
}
