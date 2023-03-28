using Ald.App.ViewModels.Base;
using Ald.App.ViewModels.Windows;
using Ald.Dal.Entities;
using Ald.Ifs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ald.App.ViewModels.Controls
{
    internal class GroupsViewModel : ViewModel
    {
        private readonly IRepository<Group> _groupsRepository;
        private readonly IRepository<Specialization> _specializationsRepository;

        private Group _selectedGroup;
        private Specialization _selectedSpecialization;
        private string _selectedCourse;

        public List<Group> Groups { get; set; }

        public List<Specialization> Specializations { get; set; } = new List<Specialization>();

        public List<string> Courses { get; set; } = new List<string>() { "Все курсы", "4", "3", "2", "1" };

        public Group SelectedGroup
        {
            get => _selectedGroup;
            set
            {
                if (!SetProperty(ref _selectedGroup, value)) return;
            }
        }

        public Specialization SelectedSpecialization
        {
            get => _selectedSpecialization;
            set
            {
                if (!SetProperty(ref _selectedSpecialization, value)) return;

                SortGroups(_selectedCourse, _selectedSpecialization.Name);
            }
        }

        public string SelectedCourse
        {
            get => _selectedCourse;
            set
            {
                if (!SetProperty(ref _selectedCourse, value)) return;

                SortGroups(_selectedCourse, _selectedSpecialization.Name);
            }
        }

        /// <summary>
        /// Отладочный конструктор.
        /// Необходим для тестирования отображения данных в представлении.
        /// </summary>
        public GroupsViewModel()
        {
            if (!App.IsDesignMode)
            {
                throw new InvalidOperationException("Данный конструктор необходимо" +
                    " использовать в режиме разработки!"
                );
            }
        }

        public GroupsViewModel(
            IRepository<Group> groupsRepository,
            IRepository<Specialization> specializationsRepository
        )
        {
            _groupsRepository = groupsRepository;
            _specializationsRepository = specializationsRepository;

            Groups = _groupsRepository.Items.ToList();

            Specializations = specializationsRepository.Items.ToList();
            Specializations.Insert(0, new Specialization { Name = "Все специальности", Groups = Groups });

            foreach (var group in Groups)
            {
                if (Groups.Count > 0 && Specializations.Contains(group.Specialization)) continue;
                Specializations.Add(group.Specialization);
            }

            SelectedSpecialization = Specializations[0];
            SelectedCourse = Courses[0];

            InvokePropertyChanged(nameof(Courses));
            InvokePropertyChanged(nameof(Specializations));
            InvokePropertyChanged(nameof(Groups));

            SelectFirstGroup();
        }

        private void SortGroups(string course, string specializationName)
        {
            if (course == null || specializationName == null) return;

            if (course.Length == 0 || specializationName.Length == 0) return;

            if (course == "Все курсы" && specializationName == "Все специальности")
            {
                Groups = _groupsRepository.Items.ToList();
                InvokePropertyChanged(nameof(Groups));
                SelectFirstGroup();
                return;
            }
            else if (course != "Все курсы" && specializationName == "Все специальности")
            {
                Groups = _groupsRepository.Items
                    .Where(g => g.Course == Convert.ToInt32(course))
                    .ToList();

                InvokePropertyChanged(nameof(Groups));
                SelectFirstGroup();
                return;
            }
            else if (course == "Все курсы" && specializationName != "Все специальности")
            {
                Groups = _groupsRepository.Items
                    .Where(g => g.Specialization.Id == _selectedSpecialization.Id)
                    .ToList();

                InvokePropertyChanged(nameof(Groups));
                SelectFirstGroup();
                return;
            }
            else if (course != "Все курсы" && specializationName != "Все специальности")
            {
                Groups = _groupsRepository.Items
                    .Where(g => g.Specialization.Id == _selectedSpecialization.Id &&
                    g.Course == Convert.ToInt32(_selectedCourse))
                    .ToList();

                InvokePropertyChanged(nameof(Groups));
                SelectFirstGroup();
                return;
            }
            else
            {
                throw new InvalidOperationException(nameof(SortGroups));
            }
        }

        private void SelectFirstGroup()
        {
            if (Groups != null && Groups.Count >= 1)
                SelectedGroup = Groups[0];
        }
    }
}
