using Ald.Dal.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ald.Dal.Entities
{
    public class Department : NamedEntity
    {
        [Required]
        [MaxLength(255)]
        public override string Name { get; set; }

        public virtual List<Specialization> Specializations { get; set; } = new List<Specialization>();

        public virtual List<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
