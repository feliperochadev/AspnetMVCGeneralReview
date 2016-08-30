using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetReviewGeral.Infraestruture.Repositories.Interfaces
{
    interface IRepositoryBase<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllAsNoTracking();
        IQueryable<TEntity> GetWithCondition(Func<TEntity, bool> predicate);
        IQueryable<TEntity> GetWithConditionAsNoTracking(Func<TEntity, bool> predicate);
        TEntity Find(params object[] key);
        Task<TEntity> FindAsync(params object[] key);
        void Update(TEntity obj);
        void Add(TEntity obj);
        bool Remove(params object[] key);
        void RemoveRange(IEnumerable<TEntity> objs);
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
