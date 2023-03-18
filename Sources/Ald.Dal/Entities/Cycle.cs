using Ald.Dal.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ald.Dal.Entities
{
    public class Cycle : NamedEntity
    {
        [Required]
        [MaxLength(50)]
        public string Index { get; set; }

        [Required]
        [MaxLength(255)]
        public override string Name { get; set; }

        public virtual List<Discipline> Disciplines { get; set; } = new List<Discipline>();

        public int CycleTypeId { get; set; }

        public virtual CycleType CycleType { get; set; }
    }
}
