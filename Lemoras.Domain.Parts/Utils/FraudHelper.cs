using Lemoras.Domain.Parts;

namespace Lemoras.Domain.Parts.Utils
{
    public static class FraudHelper
    {
        public static void CheckFraud(long userId, IApplicationContext context)
        {
            if (userId != context.UserId)
            {
                if (context.SecurityType != SecurityType.Admin)
                {
                    throw new FraudException($"Fraud handle used by {context.UserId}");
                }
            }
        }
    }
}
