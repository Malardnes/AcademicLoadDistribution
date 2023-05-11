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

        public virtual ICollection<ContentOfTheEducationalPlan> EducationPlans { get; set; }
    }
}
