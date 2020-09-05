using System;

namespace Lemoras.Domain.Parts
{
    public interface IDeleteAuditable
    {
        int DeletedBy { get; }
        DateTime DeleteDate { get; }
        
    }
}