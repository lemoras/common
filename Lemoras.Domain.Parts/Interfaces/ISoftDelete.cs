namespace Lemoras.Domain.Parts
{
    public interface ISoftDelete
    {
        DeleteAuditable DeleteAuditable { get; }
        void SoftDelete();
    }
}