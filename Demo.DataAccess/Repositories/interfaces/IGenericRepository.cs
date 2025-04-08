
using System.Linq.Expressions;
using Demo.DataAccess.Models.Shared;

namespace Demo.DataAccess.Repositories.interfaces
{
    public interface IGenericRepository<TEntity> 
    {
        int Add(TEntity TEntity);
        IEnumerable<TEntity> GetAll(bool WithTracking = false);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity , bool>> predicate);
        TEntity GetById(int id);
        int remove(TEntity TEntity);
        int Update(TEntity TEntity);
    }
}
