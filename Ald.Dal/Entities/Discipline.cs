using Ald.Dal.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ald.Dal.Entities
{
    public class Discipline : NamedEntity
    {
        [Required]
        [MaxLength(50)]
        public string Index { get; set; }

        [Required]
        [MaxLength(255)]
        public override string Name { get; set; }

        public int CycleId { get; set; }

        public virtual Cycle Cycle { get; set; }

        // public virtual List<Specialization> Specializations { get; set; } = new List<Specialization>();

        public virtual List<EducationPlan> EducationPlans { get; set; } = new List<EducationPlan>();
    }
}
