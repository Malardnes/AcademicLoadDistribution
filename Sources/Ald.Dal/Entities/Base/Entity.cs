using Ald.Ifs;

namespace Ald.Dal.Entities.Base
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
