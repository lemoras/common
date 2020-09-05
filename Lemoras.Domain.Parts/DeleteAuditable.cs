using System;

namespace Lemoras.Domain.Parts
{
    public class DeleteAuditable : IDeleteAuditable
    {
        public int DeletedBy { get; private set; }
        public DateTime DeleteDate { get; private set; }

        public DeleteAuditable(int deletedBy)
        {
            this.DeletedBy = deletedBy;
            this.DeleteDate = DateTime.UtcNow;
        }
    }
}