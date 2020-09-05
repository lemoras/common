using System;

namespace Lemoras.Domain.Parts
{
    public class CreateAuditable
    {
        public int CreatedBy { get; private set; }
        public DateTime CreateDate { get; private set; }

        public CreateAuditable(int createdBy)
        {
            this.CreatedBy = createdBy;
            this.CreateDate = DateTime.UtcNow;
        }
    }
}