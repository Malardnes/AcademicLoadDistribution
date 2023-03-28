using Ald.App.Infrastructure.Commands.Base;
using Ald.App.ViewModels.Base;
using Ald.App.ViewModels.Controls;
using Ald.Dal.Entities;
using Ald.Ifs;
using System.Windows.Input;

namespace Ald.App.ViewModels.Windows
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Приватные поля

        /// <summary>
        /// Текущая дочерняя модель-представление.
        /// </summary>
        private ViewModel _currentViewModel;

        /// <summary>
        /// Репозиторий (хранилище) учебных групп.
        /// </summary>
        private readonly IRepository<Group> _groupsRepository;

        /// <summary>
        /// Репозиторий (хранилище) учебных специальностей.
        /// </summary>
        private readonly IRepository<Specialization> _specializationsRepository;

        #endregion // Приватные поля.

        #region Свойства

        /// <summary>
        /// Текущая дочерняя модель-представление.
        /// </summary>
        public ViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        #endregion // Свойства.

        #region Команды

        #region Отобразить представление учебных групп

        /// <summary>
        /// Отобразить представление учебных групп.
        /// </summary>
        private ICommand _showGroupsViewCommand;

        /// <summary>
        /// Отобразить представление учебных групп.
        /// </summary>
        public ICommand ShowGroupsViewCommand => _showGroupsViewCommand
            ??= new DelegateCommand(OnShowGroupsViewCommandExecuted, CanShowGroupsViewCommandExecute);

        /// <summary>
        /// Проверка возможности выполения - отобразить представление учебных групп.
        /// </summary>
        private bool CanShowGroupsViewCommandExecute(object p) => true;

        /// <summary>
        /// Логика выполнения - отобразить представление учебных групп.
        /// </summary>
        private void OnShowGroupsViewCommandExecuted(object p)
        {
            CurrentViewModel = new GroupsViewModel(_groupsRepository);
        }

        #endregion // Отобразить представление учебных групп.

        #region Отобразить представление специальностей

        /// <summary>
        /// Отобразить представление специальностей.
        /// </summary>
        private ICommand _showSpecializationsViewCommand;

        /// <summary>
        /// Отобразить представление специальностей.
        /// </summary>
        public ICommand ShowSpecializationsViewCommand => _showSpecializationsViewCommand
            ??= new DelegateCommand(OnShowSpecializationsViewCommandExecuted, CanShowSpecializationsViewCommandExecute);

        /// <summary>
        /// Проверка возможности выполения - отобразить представление специальностей.
        /// </summary>
        private bool CanShowSpecializationsViewCommandExecute(object p) => true;

        /// <summary>
        /// Логика выполнения - отобразить представление специальностей.
        /// </summary>
        private void OnShowSpecializationsViewCommandExecuted(object p)
        {

        }

        #endregion // Отобразить представление специальностей.

        #endregion // Команды.

        #region Конструкторы

        public MainWindowViewModel(
            IRepository<Group> groupsRepository,
            IRepository<Specialization> specializationsRepository
        )
        {
            _groupsRepository = groupsRepository;
            _specializationsRepository = specializationsRepository;
        }

        #endregion // Конструкторы.

        #region Приватные методы

        #endregion // Приватные методы.
    }
}
