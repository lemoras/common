using System;

namespace Lemoras.Domain.Parts
{
    public interface ICreateAuditable
    {
        int CreatedBy { get; }
        DateTime CreateDate { get; }
    }
}