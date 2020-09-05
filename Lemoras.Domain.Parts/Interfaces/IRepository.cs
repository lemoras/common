using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lemoras.Domain.Parts
{
    public interface IRepository<TModel> : IRepository<TModel, int> where TModel : class
    {
    }

    public interface IRepository<TModel, TId> where TModel : class
    {
        Task<TModel> Find(TId id);
        Task<IList<TModel>> GetAll();
    }
}