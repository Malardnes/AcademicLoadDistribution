using Ald.Dal.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Ald.Dal.Entities
{
    public class TeachingLoad : Entity
    {
        [Required]
        public string GroupName { get; set; }

        [Required]
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        [Required]
        public int ContentOfTheEducationalPlanId { get; set; }
        public virtual EducationalPlan ContentOfTheEducationalPlan { get; set; }
    }
}
