namespace Ald.Dal.Entities.Base
{
    public abstract class NamedEntity : Entity
    {
        //[Required]
        public string Name { get; set; }
    }
}
