using System;
using System.Collections.Generic;
using System.Linq;
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
                    return _dbContext.Set<TEntity>().ToList();
                else
                    return _dbContext.Set<TEntity>().AsNoTracking().ToList();

            }

            //get TEntity by id
            public TEntity GetById(int id) => _dbContext.Set<TEntity>().Find(id);

            //update TEntity
            public int Update(TEntity Entity)
            {
                _dbContext.Set<TEntity>().Update(Entity);
                return _dbContext.SaveChanges();
            }

            //delete TEntity
            public int remove(TEntity Entity)
            {

                _dbContext.Set<TEntity>().Remove(Entity);
                return _dbContext.SaveChanges();
            }

            //add TEntity(insert)
            public int Add(TEntity Entity)
            {
                _dbContext.Set<TEntity>().Add(Entity);
                return _dbContext.SaveChanges();

            }
        }
}
