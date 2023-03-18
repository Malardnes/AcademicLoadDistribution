using Ald.Dal.Entities.Base;
using System.Collections.Generic;

namespace Ald.Dal.Entities
{
    public class Teacher : Person
    {
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public virtual List<TeachingLoad> TeachingLoads { get; set; } = new List<TeachingLoad>();
    }
}
