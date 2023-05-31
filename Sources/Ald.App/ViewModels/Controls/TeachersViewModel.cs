using Ald.App.Infrastructure.Commands.Base;
using Ald.App.ViewModels.Base;
using Ald.App.ViewModels.Windows;
using Ald.Dal.Entities;
using Ald.Ifs;
using System.Windows.Input;

namespace Ald.App.ViewModels.Controls
{
    internal class TeachersViewModel : ViewModel
    {
        private IRepository<Teacher> _teachersRepository;
        private MainWindowViewModel _currentViewModel;

        public TeachersViewModel(
            MainWindowViewModel currentViewModel,
            IRepository<Teacher> teachersRepository)
        {
            _teachersRepository = teachersRepository;
            _currentViewModel = currentViewModel;
        }

        /// <summary>
        /// Отобразить представление учебных групп.
        /// </summary>
        private ICommand _showGroupsViewCommand;

        /// <summary>
        /// Отобразить представление учебных групп.
        /// </summary>
        public ICommand ShowGroupsViewCommand => _showGroupsViewCommand
            ??= new DelegateCommand(OnTeacherAdd, CanAddTeacher);

        /// <summary>
        /// Проверка возможности выполения - отобразить представление учебных групп.
        /// </summary>
        private bool CanAddTeacher(object p) => true;

        /// <summary>
        /// Логика выполнения - отобразить представление учебных групп.
        /// </summary>
        private void OnTeacherAdd(object p)
        {
            _currentViewModel.CurrentViewModel = new AddTeachersViewModel();
        }
    }
}
