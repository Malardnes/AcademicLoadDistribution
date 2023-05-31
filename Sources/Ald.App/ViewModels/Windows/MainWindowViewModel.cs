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
        /// Репозиторий (хранилище) специальностей.
        /// </summary>
        private readonly IRepository<Specialization> _specializationsRepository;

        /// <summary>
        /// Репозиторий (хранилище) дисциплин.
        /// </summary>
        private readonly IRepository<Discipline> _disciplinesRepository;

        /// <summary>
        /// Репозиторий (хранилище) учебных планов.
        /// </summary>
        private readonly IRepository<EducationalPlan> _educationPlansRepository;

        /// <summary>
        /// Репозиторий (хранилище) информации о преподавателях.
        /// </summary>
        private readonly IRepository<Teacher> _teachersRepository;

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
            CurrentViewModel = new SpecializationsViewModel(_specializationsRepository);
        }

        #endregion // Отобразить представление специальностей.

        #region Отобразить представление дисциплин

        /// <summary>
        /// Отобразить представление дисциплин.
        /// </summary>
        private ICommand _showDisciplinesViewCommand;

        /// <summary>
        /// Отобразить представление дисциплин.
        /// </summary>
        public ICommand ShowDisciplinesViewCommand => _showDisciplinesViewCommand
            ??= new DelegateCommand(OnShowDisciplinesViewCommandExecuted, CanShowDisciplinesViewCommandExecute);

        /// <summary>
        /// Проверка возможности выполения - отобразить представление дисциплин.
        /// </summary>
        private bool CanShowDisciplinesViewCommandExecute(object p) => true;

        /// <summary>
        /// Логика выполнения - отобразить представление дисциплин.
        /// </summary>
        private void OnShowDisciplinesViewCommandExecuted(object p)
        {
            CurrentViewModel = new DisciplinesViewModel(_disciplinesRepository);
        }

        #endregion // Отобразить представление дисциплин.

        #region Отобразить представление учебных планов

        /// <summary>
        /// Отобразить представление учебных планов.
        /// </summary>
        private ICommand _showEducationalPlansViewCommand;

        /// <summary>
        /// Отобразить представление учебных планов.
        /// </summary>
        public ICommand ShowEducationalPlansViewCommand => _showEducationalPlansViewCommand
            ??= new DelegateCommand(OnShowEducationalPlansViewCommandExecuted, CanShowEducationalPlansViewCommandExecute);

        /// <summary>
        /// Проверка возможности выполения - отобразить представление учебных планов.
        /// </summary>
        private bool CanShowEducationalPlansViewCommandExecute(object p) => true;

        /// <summary>
        /// Логика выполнения - отобразить представление учебных планов.
        /// </summary>
        private void OnShowEducationalPlansViewCommandExecuted(object p)
        {
            CurrentViewModel = new EducationalPlansViewModel();
        }

        #endregion // Отобразить представление учебных планов.

        #region Отобразить представление преподавателей

        /// <summary>
        /// Отобразить представление преподавателей.
        /// </summary>
        private ICommand _showTeachersViewCommand;

        /// <summary>
        /// Отобразить представление преподавателей.
        /// </summary>
        public ICommand ShowTeachersViewCommand => _showTeachersViewCommand
            ??= new DelegateCommand(OnShowTeachersViewCommandExecuted, CanShowTeachersViewCommandExecute);

        /// <summary>
        /// Проверка возможности выполения - отобразить представление преподавателей.
        /// </summary>
        private bool CanShowTeachersViewCommandExecute(object p) => true;

        /// <summary>
        /// Логика выполнения - отобразить представление преподавателей.
        /// </summary>
        private void OnShowTeachersViewCommandExecuted(object p)
        {
            CurrentViewModel = new TeachersViewModel(this, _teachersRepository);
        }

        #endregion // Отобразить представление преподавателей.

        #endregion // Команды.

        #region Конструкторы

        public MainWindowViewModel(
            IRepository<Group> groupsRepository,
            IRepository<Specialization> specializationsRepository,
            IRepository<Discipline> disciplinesRepository,
            IRepository<EducationalPlan> educationPlansRepository,
            IRepository<Teacher> teachersRepository
        )
        {
            _groupsRepository = groupsRepository;
            _specializationsRepository = specializationsRepository;
            _disciplinesRepository = disciplinesRepository;
            _educationPlansRepository = educationPlansRepository;
            _teachersRepository = teachersRepository;
        }

        #endregion // Конструкторы.

        #region Приватные методы

        #endregion // Приватные методы.
    }
}
