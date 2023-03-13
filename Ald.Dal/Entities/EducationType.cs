using Ald.Dal.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ald.Dal.Entities
{
    public class EducationType : NamedEntity
    {
        [Required]
        [MaxLength(255)]
        public override string Name { get; set; }

        public virtual List<EducationPlan> EducationPlans { get; set; } = new List<EducationPlan>();
    }
}
