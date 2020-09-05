namespace Lemoras.Domain.Parts
{
    public enum UserType
    {
        None = 0,
        Admin,
        Customer
    }

    public enum SecurityType
    {
        None = 0,
        Admin,
        Standard,
        Dealer,
        Customer,
        Client
    }

    public enum UserStatus
    {
        None = 0,
        Created,
        Active,
        Passive,
        Deleted
    }
}
