using Deneme.Data.Context;
using Deneme.Data.Entities;
using Deneme.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Data.InMemoryRepository
{
    public class InSqlRepository<ITEntity> :InIRepository<ITEntity> where ITEntity : BaseEntity
    {
        private readonly InMemoryContext _db;
        private readonly DbSet<ITEntity> _dbSet;

        public InSqlRepository(InMemoryContext db)
        {
            _db = db;
            _dbSet = _db.Set<ITEntity>();
        }
        public void Add(ITEntity entity)
        {
            _dbSet.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {

            var entity = _dbSet.Find(id);
            Delete(entity);
        }

        public void Delete(ITEntity entity)
        {
            entity.IsDeleted = true;
            entity.ModifiedDate = DateTime.Now;
            _dbSet.Update(entity);
            _db.SaveChanges();
        }

        public ITEntity Get(Expression<Func<ITEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

       
        public IQueryable<ITEntity> GetAll(Expression<Func<ITEntity, bool>> predicate = null)
        {
            return predicate is not null ? _dbSet.Where(predicate) : _dbSet;
        }

        public ITEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(ITEntity entity)
        {
            entity.ModifiedDate = DateTime.Now;
            _dbSet.Update(entity);
            _db.SaveChanges();
        }

       

      
    }
}
