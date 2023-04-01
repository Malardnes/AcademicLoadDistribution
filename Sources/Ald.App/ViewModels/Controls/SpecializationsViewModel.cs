using Ald.App.ViewModels.Base;
using Ald.Dal.Entities;
using Ald.Ifs;

namespace Ald.App.ViewModels.Controls
{
    internal class SpecializationsViewModel : ViewModel
    {
        private IRepository<Specialization> _specializationsRepository;

        public SpecializationsViewModel(
            IRepository<Specialization> specializationsRepository
        )
        {
            _specializationsRepository = specializationsRepository;
        }
    }
}
