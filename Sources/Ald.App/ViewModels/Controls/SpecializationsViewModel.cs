using Ald.App.ViewModels.Base;
using Ald.Dal.Entities;
using Ald.Ifs;
using System.Collections.Generic;
using System.Linq;

namespace Ald.App.ViewModels.Controls
{
    internal class SpecializationsViewModel : ViewModel
    {
        private IRepository<Specialization> _specializationsRepository;
        private Specialization _selectedSpecialization;
        private readonly string _allSpecializationsName = "Все специальности";

        public List<Specialization> Specializations { get; set; }

        public Specialization SelectedSpecialization
        {
            get => _selectedSpecialization;
            set
            {
                if (!SetProperty(ref _selectedSpecialization, value)) return;
            }
        }

        public SpecializationsViewModel(
            IRepository<Specialization> specializationsRepository
        )
        {
            _specializationsRepository = specializationsRepository;

            Specializations = _specializationsRepository.Items.ToList();

            List<Group> groups = new List<Group>();

            foreach (var specialization in Specializations)
            {
                groups.AddRange(specialization.Groups.Where(g => g.Specialization.Id == specialization.Id).ToList());
            }

            Specializations.Insert(0, new Specialization { Name = _allSpecializationsName, Groups = groups });
        }
    }
}
