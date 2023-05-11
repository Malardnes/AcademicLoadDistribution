using Ald.Dal.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Ald.Dal.Entities
{
    public class Group : NamedEntity
    {
        [Required]
        public int SpecializationId { get; set; }
        public virtual Specialization Specialization { get; set; }

        [Required]
        [MaxLength(50)]
        public override string Name { get; set; }

        [Required]
        public int Course { get; set; }

        [Required]
        public int StudentsCount { get; set; }

        [Required]
        public DateTime StartEducationDate { get; set; }

        [Required]
        public DateTime EndEducationDate { get; set; }

        [Required]
        public bool IsGraduate { get; set; }
    }
}
