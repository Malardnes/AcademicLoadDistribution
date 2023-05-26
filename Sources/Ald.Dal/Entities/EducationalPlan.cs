using Ald.Dal.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ald.Dal.Entities
{
    public class EducationalPlan : Entity
    {
        [Required]
        public int SpecializationId { get; set; }
        public virtual Specialization Specialization { get; set; }

        [Required]
        public int DisciplineId { get; set; }
        public virtual Discipline Discipline { get; set; }

        [Required]
        public int AttestationTypeId { get; set; }
        public virtual AttestationType AttestationType { get; set; }

        [Required]
        public int EducationTypeId { get; set; }
        public virtual EducationType EducationType { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int Course { get; set; }

        [Required]
        public int Semester { get; set; }

        [Required]
        public int WeeksCount { get; set; }

        [Required]
        public int Hours { get; set; }

        public virtual ICollection<TeachingLoad> TeachingLoads { get; set; }
    }
}
