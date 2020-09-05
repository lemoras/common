using System;

namespace Lemoras.Domain.Parts
{
    public class ModifyAuditable : IModifyAuditable
    {
        public int ModifiedBy { get; private set; }
        public DateTime ModifyDate { get; private set; }

        public ModifyAuditable(int modifiedBy)
        {
            this.ModifiedBy = modifiedBy;
            this.ModifyDate = DateTime.UtcNow;
        }
    }
}