using System;

namespace Lemoras.Domain.Parts.Utils
{
    public class TechnicalException : Exception
    {
        public TechnicalException(string message) : base(message)
        {

        }
    }
}
