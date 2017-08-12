using ICB.Extensions.ResponseResults;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ICB.EntityFrameworkCore.EFGenericRepository
{
    public class EntityFrameworkRepository<T, KeyType> : IRepository<T, KeyType> where T : class
    {
        private readonly DbSet<T> dbSet;

        private ICB.EntityFrameworkCore.Models.ICB_DbContext context;

        public EntityFrameworkRepository()
        {
            this.context = new Models.ICB_DbContext();
            this.dbSet = this.context.Set<T>();
        }

        public int Count()
        {
            return this.dbSet.Count();
        }

        public async Task<int> CountAsync()
        {
            return await this.dbSet.CountAsync();
        }

        public AccessEntityStatusCode Delete(T item)
        {
            this.context.Set<T>().Attach(item);
            this.context.Entry<T>(item).State = EntityState.Deleted;
            int counter = this.context.SaveChanges();
            return (counter > 0 ? AccessEntityStatusCode.OK : AccessEntityStatusCode.Failed);
        }

        public async Task<AccessEntityStatusCode> DeleteAsync(T item)
        {
            this.context.Set<T>().Attach(item);
            this.context.Entry<T>(item).State = EntityState.Deleted;
            int counter = await this.context.SaveChangesAsync();
            return (counter > 0 ? AccessEntityStatusCode.OK : AccessEntityStatusCode.Failed);
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            return this.context.Set<T>().FirstOrDefault(match);
        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            return this.context.Set<T>().Where(match).ToList();
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await this.context.Set<T>().Where(match).ToListAsync();
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await this.context.Set<T>().FirstOrDefaultAsync(match);
        }

        public T GetByID(KeyType id)
        {
            return this.context.Set<T>().Find(id);
        }

        public async Task<T> GetByIDAsync(KeyType id)
        {
            return await this.context.Set<T>().FindAsync(id);
        }

        public AccessEntityStatusCode Insert(T item)
        {
            this.context.Set<T>().Add(item);
            int counter = this.context.SaveChanges();
            return (counter > 0 ? AccessEntityStatusCode.OK : AccessEntityStatusCode.Failed);
        }

        public async Task<Tuple<AccessEntityStatusCode,T>> InsertAsync(T item)
        {
            this.context.Set<T>().Add(item);
            int counter = await this.context.SaveChangesAsync();
            this.context.Entry(item).GetDatabaseValues();
            return (item);
        }

        public IQueryable<T> Select()
        {
            return this.dbSet;
        }

        public T Update(T item, KeyType id)
        {
            this.context.Set<T>().Attach(item);
            this.context.Entry<T>(item).State = EntityState.Modified;
            int counter = this.context.SaveChanges();
            return (counter > 0);
        }

        public Task<bool> UpdateAsync(T item, KeyType id)
        {
            throw new NotImplementedException();
        }
    }
}
