using Ald.Dal.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ald.Dal.Entities
{
    public class Teacher : Person
    {
        public virtual ICollection<TeachingLoad> TeachingLoads { get; set; }
    }
}
