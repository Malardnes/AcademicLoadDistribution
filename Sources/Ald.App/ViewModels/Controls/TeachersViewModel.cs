using Ald.App.ViewModels.Base;
using Ald.Dal.Entities;
using Ald.Ifs;

namespace Ald.App.ViewModels.Controls
{
    internal class TeachersViewModel : ViewModel
    {
        private IRepository<Teacher> _teachersRepository;

        public TeachersViewModel(IRepository<Teacher> teachersRepository)
        {
            _teachersRepository = teachersRepository;
        }
    }
}
