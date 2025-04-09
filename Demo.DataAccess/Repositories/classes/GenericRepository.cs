using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Data.contexts;
using Demo.DataAccess.Models.Shared;
using Demo.DataAccess.Repositories.interfaces;

namespace Demo.DataAccess.Repositories.classes
{
    public class GenericRepository<TEntity>(AppDbContext _dbContext) : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
       

            //CRUD
            //get all TEntitys
            public IEnumerable<TEntity> GetAll(bool WithTracking = false)
            {
                if (WithTracking)
                    return _dbContext.Set<TEntity>().Where(e=> e.IsDeleted != true).ToList();
                else
                    return _dbContext.Set<TEntity>().Where(e => e.IsDeleted != true).AsNoTracking().ToList();

            }

            //get TEntity by id
            public TEntity GetById(int id) => _dbContext.Set<TEntity>().Find(id);

            //update TEntity
            public void Update(TEntity Entity)
            {
                _dbContext.Set<TEntity>().Update(Entity);
                
            }

            //delete TEntity
            public void remove(TEntity Entity)
            {

                _dbContext.Set<TEntity>().Remove(Entity);
               
            }

            //add TEntity(insert)
            public int Add(TEntity Entity)
            {
                _dbContext.Set<TEntity>().Add(Entity);
                return _dbContext.SaveChanges();

            }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate).ToList();
        }

        void IGenericRepository<TEntity>.Add(TEntity TEntity)
        {
            throw new NotImplementedException();
        }
    }
}
