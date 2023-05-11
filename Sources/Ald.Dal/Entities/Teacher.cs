using Ald.Dal.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ald.Dal.Entities
{
    public class Teacher : Person
    {
        /*[Required]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }*/

        public virtual ICollection<TeachingLoad> TeachingLoads { get; set; }
    }
}
