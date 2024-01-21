using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Data.InMemoryRepository
{
  public  interface InIRepository<ITEntity> where ITEntity : class
    {
        void Add(ITEntity entity);
        void Delete(int id);
        void Delete(ITEntity entity);
        void Update(ITEntity entity);
        ITEntity GetById(int id);
        ITEntity Get(Expression<Func<ITEntity, bool>> predicate);

        IQueryable<ITEntity> GetAll(Expression<Func<ITEntity, bool>> predicate = null);
    }
}
