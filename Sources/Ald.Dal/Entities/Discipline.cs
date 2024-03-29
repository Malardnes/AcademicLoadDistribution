﻿using Ald.Dal.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ald.Dal.Entities
{
    public class Discipline : NamedEntity
    {
        [Required]
        [MaxLength(50)]
        public string Index { get; set; }

        [Required]
        [MaxLength(255)]
        public override string Name { get; set; }

        [Required]
        public int CycleId { get; set; }
        public virtual Cycle Cycle { get; set; }

        public virtual ICollection<EducationalPlan> EducationPlans { get; set; }
    }
}
