using Ald.App.ViewModels.Base;
using Ald.Dal.Entities;
using Ald.Ifs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ald.App.ViewModels.Controls
{
    internal class GroupsViewModel : ViewModel
    {
        #region Приватные поля

        /// <summary>
        /// Репозиторий (хранилище) учебных групп.
        /// </summary>
        private readonly IRepository<Group> _groupsRepository;

        private Group _selectedGroup;
        private Specialization _selectedSpecialization;
        private string _selectedCourse;

        #endregion // Приватные поля.

        #region Свойста

        /// <summary>
        /// Список учебных групп.
        /// </summary>
        public List<Group> Groups { get; set; }

        /// <summary>
        /// Список специальностей.
        /// </summary>
        public List<Specialization> Specializations { get; set; } = new List<Specialization>();

        /// <summary>
        /// Список курсов.
        /// </summary>
        public List<string> Courses { get; set; } = new List<string>() { "Все курсы", "4", "3", "2", "1" };

        /// <summary>
        /// Выбранная учебная группа.
        /// </summary>
        public Group SelectedGroup
        {
            get => _selectedGroup;
            set
            {
                if (!SetProperty(ref _selectedGroup, value)) return;
            }
        }

        /// <summary>
        /// Выбранная специальность.
        /// </summary>
        public Specialization SelectedSpecialization
        {
            get => _selectedSpecialization;
            set
            {
                if (!SetProperty(ref _selectedSpecialization, value)) return;

                SortGroups(_selectedCourse, _selectedSpecialization.Name);
            }
        }

        /// <summary>
        /// Выбранный курс.
        /// </summary>
        public string SelectedCourse
        {
            get => _selectedCourse;
            set
            {
                if (!SetProperty(ref _selectedCourse, value)) return;

                SortGroups(_selectedCourse, _selectedSpecialization.Name);
            }
        }

        #endregion // Свойста.

        #region Команды

        #endregion // Команды.

        #region Конструкторы

        /// <summary>
        /// Отладочный конструктор.
        /// Необходим для тестирования отображения данных в представлении.
        /// </summary>
        public GroupsViewModel()
        {
            if (!App.IsDesignMode)
            {
                throw new InvalidOperationException("Данный конструктор разрешено" +
                    " использовать только в режиме разработки!"
                );
            }
        }

        public GroupsViewModel(IRepository<Group> groupsRepository)
        {
            _groupsRepository = groupsRepository;

            Groups = _groupsRepository.Items.ToList();

            Specializations.Add(new Specialization { Name = "Все специальности", Groups = Groups });

            foreach (var group in Groups)
            {
                if (Groups.Count > 0 && Specializations.Contains(group.Specialization)) continue;
                Specializations.Add(group.Specialization);
            }

            SelectedSpecialization = Specializations[0];
            SelectedCourse = Courses[0];

            SelectFirstGroup();
        }

        #endregion // Конструкторы.

        #region Приватные методы

        /// <summary>
        /// Отсортировать список учебных групп.
        /// </summary>
        /// <param name="course">
        /// Курс.
        /// </param>
        /// <param name="specializationName">
        /// Наименование специальности.
        /// </param>
        private void SortGroups(string course, string specializationName)
        {
            if (course == null || specializationName == null) return;

            if (string.IsNullOrWhiteSpace(course) || string.IsNullOrWhiteSpace(specializationName)) return;

            if (course == "Все курсы" && specializationName == "Все специальности")
            {
                Groups = _groupsRepository.Items.ToList();

                InvokePropertyChanged(nameof(Groups));
                SelectFirstGroup();
            }
            else if (course != "Все курсы" && specializationName == "Все специальности")
            {
                Groups = _groupsRepository.Items
                    .Where(g => g.Course == Convert.ToInt32(course))
                    .ToList();

                InvokePropertyChanged(nameof(Groups));
                SelectFirstGroup();
            }
            else if (course == "Все курсы" && specializationName != "Все специальности")
            {
                Groups = _groupsRepository.Items
                    .Where(g => g.Specialization.Id == _selectedSpecialization.Id)
                    .ToList();

                InvokePropertyChanged(nameof(Groups));
                SelectFirstGroup();
            }
            else if (course != "Все курсы" && specializationName != "Все специальности")
            {
                Groups = _groupsRepository.Items
                    .Where(g => g.Specialization.Id == _selectedSpecialization.Id &&
                    g.Course == Convert.ToInt32(_selectedCourse))
                    .ToList();

                InvokePropertyChanged(nameof(Groups));
                SelectFirstGroup();
            }
            else
            {
                throw new InvalidOperationException(nameof(SortGroups));
            }
        }

        /// <summary>
        /// Выбрать первую учебную группу в списке.
        /// </summary>
        /// <remarks>
        /// Если список пуст, то соответственно ни одна группа не будет выбрана.
        /// </remarks>
        private void SelectFirstGroup()
        {
            if (Groups != null && Groups.Count >= 1)
                SelectedGroup = Groups[0];
        }

        #endregion // Приватные методы.
    }
}
