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
        private ViewModel _currentViewModel;
        private readonly IRepository<Group> _groupsRepository;
        private readonly IRepository<Specialization> _specializationsRepository;

        #region Свойства

        public ViewModel CurrentViewModel { get => _currentViewModel; set => SetProperty(ref _currentViewModel, value); }

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
            CurrentViewModel = new GroupsViewModel(
                _groupsRepository,
                _specializationsRepository
            );
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
        public ICommand ShowSpecializationsViewCommand => _showGroupsViewCommand
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

        public MainWindowViewModel(
            IRepository<Group> groupsRepository,
            IRepository<Specialization> specializationsRepository
        )
        {
            _groupsRepository = groupsRepository;
            _specializationsRepository = specializationsRepository;
        }
    }
}
