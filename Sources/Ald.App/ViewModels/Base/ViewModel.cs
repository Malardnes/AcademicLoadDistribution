using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ald.App.ViewModels.Base
{
    /// <summary>
    /// Базовый класс модели представления.
    /// </summary>
    internal abstract class ViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Событие - возникающее при изменении значения свойства.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Метод - генерирующий событие изменения значения свойства.
        /// </summary>
        /// <param name="propertyName">
        /// Наименование свойства.
        /// </param>
        protected virtual void InvokePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Функция проверки соответствия значения поля свойства к значению этого свойства.
        /// Разрешает проблему цикличности при обновлении значений свойств.
        /// </summary>
        /// <typeparam name="T">
        /// Шаблонный тип.
        /// </typeparam>
        /// <param name="field">
        /// Поле свойства.
        /// </param>
        /// <param name="value">
        /// Значение свойства.
        /// </param>
        /// <param name="propertyName">
        /// Наименование свойства.
        /// </param>
        /// <returns>
        /// true - если удалось изменить значение свойства, false - если значение свойства соответствует полю.
        /// </returns>
        protected virtual bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            InvokePropertyChanged(propertyName);
            return true;
        }
    }
}
