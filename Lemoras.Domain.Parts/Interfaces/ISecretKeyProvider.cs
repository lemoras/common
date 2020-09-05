namespace Lemoras.Domain.Parts
{
    public interface ISecretKeyProvider
    {
        byte[] GetSecretKey();
    }
}
