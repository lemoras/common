using System;

namespace Lemoras.Domain.Parts
{
    public interface IModifyAuditable
    {
        int ModifiedBy { get; }
        DateTime ModifyDate { get; }
    }
}