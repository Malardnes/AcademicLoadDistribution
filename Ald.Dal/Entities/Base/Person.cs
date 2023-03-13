using System.ComponentModel.DataAnnotations;

namespace Ald.Dal.Entities.Base
{
    public abstract class Person : NamedEntity
    {
        [Required]
        [MaxLength(255)]
        public virtual string Surname { get; set; }

        [MaxLength(255)]
        public virtual string Patronymic { get; set; }
    }
}
