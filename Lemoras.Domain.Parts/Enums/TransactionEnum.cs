namespace Lemoras.Domain.Parts
{
    public enum TransactionStatus
    {
        None = 0,
        InOperation,
        BrokenOperation,
        Approved,
        Rejected,
        Refund,
        Canceled
    }

    public enum TransactionEventStatus
    {
        None = 0,
        ProvisionSent,
        ProvisionApproved,
        PaymentSent,
        PaymentApproved,
        ChangeBalanceAmount,
        RejectBlockageBalanceAmount,
        RejectBalanceAmount
    }

    public enum PaymentType
    {
        None = 0,
        Asseco,
        Paycell
    }

    public enum PathType
    {
        None = 0,
        Sale3d,
        Sale
    }

    public enum CardType
    {
        None = 0,
        Visa,
        Mastercard,
        Troy
    }

    public enum ActivityType
    {
        None = 0,
        Deposit,
        Withdraw
    }
}
