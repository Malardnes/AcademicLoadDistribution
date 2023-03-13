using Ald.Dal.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Ald.Dal.Entities
{
    public class Group : NamedEntity
    {
        [Required]
        [MaxLength(50)]
        public override string Name { get; set; }

        public int Course { get; set; }

        public int StudentsCount { get; set; }

        public DateTime StartEducationDate { get; set; }

        public DateTime EndEducationDate { get; set; }

        public bool IsGraduate { get; set; }

        public int SpecializationId { get; set; }

        public virtual Specialization Specialization { get; set; }
    }
}
