using Ald.Dal.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ald.Dal.Entities
{
    public class Specialization : NamedEntity
    {
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        [Required]
        [MaxLength(255)]
        public override string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Qualification { get; set; }

        public int EducationYears { get; set; }

        public int EducationMonths { get; set; }

        public virtual List<Group> Groups { get; set; } = new List<Group>();

        public virtual List<EducationPlan> EducationPlans { get; set; } = new List<EducationPlan>();

        // public virtual List<Discipline> Disciplines { get; set; } = new List<Discipline>();
    }
}
