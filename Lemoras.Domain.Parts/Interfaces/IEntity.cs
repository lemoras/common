namespace Lemoras.Domain.Parts
{
    public interface IEntity : IEntity<int>
    {
    }

    public interface IEntity<TId>
    {
        TId Id { get; }
    }
}