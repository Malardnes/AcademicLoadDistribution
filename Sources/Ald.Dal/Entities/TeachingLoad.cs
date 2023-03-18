using Ald.Dal.Entities.Base;
using System.Collections.Generic;

namespace Ald.Dal.Entities
{
    public class TeachingLoad : Entity
    {
        public int EducationPlanId { get; set; }
        
        public virtual EducationPlan EducationPlan { get; set; }
        
        public int TeacherId { get; set; }
        
        public virtual Teacher Teacher { get; set; }
        
        public int GroupId { get; set; }

        public virtual Group Group { get; set; }
    }
}
