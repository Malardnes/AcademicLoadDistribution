using Ald.Dal.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ald.Dal.Entities
{
    public class EducationalPlan : Entity
    {
        [Required]
        public int SpecializationId { get; set; }
        public virtual Specialization Specialization { get; set; }

        public virtual ICollection<ContentOfTheEducationalPlan> EducationalPlanContents { get; set; }
    }
}
