
using Demo.DataAccess.Models.Shared;

namespace Demo.DataAccess.Repositories.interfaces
{
    public interface IGenericRepository<TEntity> 
    {
        int Add(TEntity TEntity);
        IEnumerable<TEntity> GetAll(bool WithTracking = false);
        TEntity GetById(int id);
        int remove(TEntity TEntity);
        int Update(TEntity TEntity);
    }
}
