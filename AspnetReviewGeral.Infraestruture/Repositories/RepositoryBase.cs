using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AspnetReviewGeral.Infraestruture.EFConfig;
using AspnetReviewGeral.Infraestruture.Repositories.Interfaces;

namespace AspnetReviewGeral.Infraestruture.Repositories
{
    public abstract class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        NatterEFContext natterEFContext = new NatterEFContext();

        public IQueryable<TEntity> GetAll()
        {
            return natterEFContext.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAllAsReadOnly()
        {
            return natterEFContext.Set<TEntity>().AsNoTracking();
        }

        public IQueryable<TEntity> GetWithCondition(Func<TEntity, bool> predicate)
        {
            return GetAll().Where(predicate).AsQueryable();
        }

        public IQueryable<TEntity> GetWithConditionAsReadOnly(Func<TEntity, bool> predicate)
        {
            return GetAllAsReadOnly().Where(predicate).AsQueryable();
        }

        public TEntity Find(params object[] key)
        {
            return natterEFContext.Set<TEntity>().Find(key);
        }

        public async Task<TEntity> FindAsync(params object[] key)
        {
            return await natterEFContext.Set<TEntity>().FindAsync(key);
        }

        public virtual void Update(TEntity obj)
        {
            natterEFContext.Entry(obj).State = EntityState.Modified;
        }

        public virtual void Add(TEntity obj)
        {
            natterEFContext.Set<TEntity>().Add(obj);
        }

        public virtual bool Remove(params object[] key)
        {
            var obj = natterEFContext.Set<TEntity>().Find(key);
            if (obj == null) return false;
            natterEFContext.Set<TEntity>().Remove(obj);
            return true;
        }

        public virtual bool RemoveRange(IEnumerable<TEntity> objs)
        {
            var enumerable = objs as IList<TEntity> ?? objs.ToList();
            if (!enumerable.Any()) return false;
            natterEFContext.Set<TEntity>().RemoveRange(enumerable);
            return true;
        }

        public void SaveChanges()
        {
            natterEFContext.SaveChanges();
            Dispose();
        }

        public async Task SaveChangesAsync()
        {
            await natterEFContext.SaveChangesAsync();
            Dispose();
        }

        public void Dispose()
        {
            natterEFContext.Dispose();
        }
    }
}
