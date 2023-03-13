using Ald.Dal.Entities.Base;

namespace Ald.Dal.Entities
{
    public class EducationPlan : Entity
    {
        public int SpecializationId { get; set; }

        public virtual Specialization Specialization { get; set; }

        public int DisciplineId { get; set; }

        public virtual Discipline Discipline { get; set; }

        public int AttestationTypeId { get; set; }

        public AttestationType AttestationType { get; set; }

        public int Year { get; set; }

        public int Course { get; set; }

        public int Semester { get; set; }

        public int WeeksCount { get; set; }

        public int Hours { get; set; }

        public int EducationTypeId { get; set; }

        public EducationType EducationType { get; set; }
    }
}
