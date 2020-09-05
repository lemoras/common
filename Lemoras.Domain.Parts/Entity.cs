namespace Lemoras.Domain.Parts
{
    public abstract class Entity : Entity<int>, IEntity
    {
        protected Entity() { }
    }

    public abstract class Entity<TId> : IEntity<TId>
    {
        public TId Id { get; protected set; }

        protected Entity() { }
    }
}
