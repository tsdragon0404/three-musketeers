namespace Core.Data
{
    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey ID { get; set; }
    }

    public abstract class EntityWithTypedId<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public virtual TPrimaryKey ID { get; set; }
    }

    public abstract class Entity : EntityWithTypedId<long>
    {
        
    }
}