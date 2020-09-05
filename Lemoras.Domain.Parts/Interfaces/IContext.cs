using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Lemoras.Domain.Parts
{
    public interface IContext : ISaveChanges
    {
        void Add(object obj);
        void Remove(object obj);
    }
    
    public interface IContext<TModel, TId> : IContext
    {
        Task<TModel> Find(TId id);
        Task<IList<TModel>> GetAll();
    }

    public interface IContext<TModel> : IContext<TModel, int>
    {
    }
}
