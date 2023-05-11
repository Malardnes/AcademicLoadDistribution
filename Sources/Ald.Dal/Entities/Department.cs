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

        public virtual ICollection<Specialization> Specializations { get; set; }
    }
}
