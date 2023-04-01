using Ald.App.ViewModels.Base;
using Ald.Dal.Entities;
using Ald.Ifs;

namespace Ald.App.ViewModels.Controls
{
    internal class DisciplinesViewModel : ViewModel
    {
        private IRepository<Discipline> _disciplinesRepository;

        public DisciplinesViewModel(IRepository<Discipline> disciplinesRepository)
        {
            _disciplinesRepository = disciplinesRepository;
        }
    }
}
