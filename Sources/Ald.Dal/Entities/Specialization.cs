using Ald.Dal.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ald.Dal.Entities
{
    public class Specialization : NamedEntity
    {
        [Required]
        [MaxLength(255)]
        public override string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Qualification { get; set; }

        [Required]
        public int EducationYears { get; set; }

        [Required]
        public int EducationMonths { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<EducationalPlan> EducationalPlans { get; set; }
    }
}
