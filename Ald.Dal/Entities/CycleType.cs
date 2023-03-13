using Ald.Dal.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ald.Dal.Entities
{
    public class CycleType : NamedEntity
    {
        [Required]
        [MaxLength(50)]
        public string Index { get; set; }

        [Required]
        [MaxLength(255)]
        public override string Name { get; set; }

        public virtual List<Cycle> Cycles { get; set; } = new List<Cycle>();
    }
}
