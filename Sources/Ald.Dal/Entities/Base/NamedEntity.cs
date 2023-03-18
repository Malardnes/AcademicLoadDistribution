namespace Ald.Dal.Entities.Base
{
    public abstract class NamedEntity : Entity
    {
        public virtual string Name { get; set; }
    }
}
