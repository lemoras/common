using System.Text;

namespace Lemoras.Domain.Parts.Utils
{
    public static class CardHelper
    {
        public static string GenerateCardDisplayName(string cardNumber)
        {   
            var sb = new StringBuilder();
            sb.Append(cardNumber.Substring(0, 4));
            sb.Append(" **** **** ");
            sb.Append(cardNumber.Substring(12));
            return sb.ToString();
        }
    }
}
