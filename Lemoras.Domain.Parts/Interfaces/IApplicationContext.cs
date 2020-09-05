namespace Lemoras.Domain.Parts
{
    public interface IApplicationContext<TContract> : IApplicationContext where TContract : class
    {
        TContract Contract { get; }
    }

    public interface IApplicationContext
    {
        int UserId { get; }

        string Token { get; }

        SecurityType SecurityType { get; }
    }
}
