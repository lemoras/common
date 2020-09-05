using System;

namespace Lemoras.Domain.Parts.Utils
{
    public class FraudException : Exception
    {
        public FraudException(string message) : base(message)
        {

        }
    }
}
