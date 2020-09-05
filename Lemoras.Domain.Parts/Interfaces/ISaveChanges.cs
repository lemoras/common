using System.Threading;
using System.Threading.Tasks;

namespace Lemoras.Domain.Parts
{
    public interface ISaveChanges
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}