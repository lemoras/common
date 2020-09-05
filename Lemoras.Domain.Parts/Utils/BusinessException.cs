using System;

namespace Lemoras.Domain.Parts.Utils
{
    public class BusinessException : Exception
    {
        public BusinessException(string message)
            :base(message)
        {
                
        }
    }
}
