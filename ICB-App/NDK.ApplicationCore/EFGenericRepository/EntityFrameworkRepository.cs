
using NDK.ApplicationCore.Extensions.ResponseResults;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NDK.ApplicationCore.EFGenericRepository
{
    
    public class EntityFrameworkRepository<T, KeyType> : IRepository<T, KeyType> where T : class
    {

        private readonly DbSet<T> dbSet;

        protected DbContext context;
        public EntityFrameworkRepository(DbContext db)
        {
            this.context = db;// new Models.ICB_DbContext();
            this.dbSet = this.context.Set<T>();
            //this.db = new DbContext();
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
            if (counter>0)
            {
                this.context.Entry(item).GetDatabaseValues();
                return Tuple.Create(AccessEntityStatusCode.OK,item);
            }
            else
            {
                return Tuple.Create(AccessEntityStatusCode.Failed, item);
            }
        }

        public IQueryable<T> Select()
        {
            return this.dbSet;
        }

        public Tuple<AccessEntityStatusCode, T> Update(T item, KeyType id)
        {
            var model = this.context.Set<T>().Find(id);
            if (model!=null)
            {
                this.context.Set<T>().Attach(item);
                this.context.Entry<T>(item).State = EntityState.Modified;
                int counter = this.context.SaveChanges();
                this.context.Entry<T>(item).GetDatabaseValues();
                return Tuple.Create(counter > 0 ? AccessEntityStatusCode.OK : AccessEntityStatusCode.Failed, item);
            }
            else
            {
                return Tuple.Create( AccessEntityStatusCode.NotFound, item);
            }
            
        }

        public async Task<Tuple<AccessEntityStatusCode, T>> UpdateAsync(T item, KeyType id)
        {
            var model =await this.context.Set<T>().FindAsync(id);
            if (model != null)
            {
                this.context.Set<T>().Attach(item);
                this.context.Entry<T>(item).State = EntityState.Modified;
                int counter = await this.context.SaveChangesAsync();
                this.context.Entry<T>(item).GetDatabaseValues();
                return Tuple.Create(counter > 0 ? AccessEntityStatusCode.OK : AccessEntityStatusCode.Failed, item);
            }
            else
            {
                return Tuple.Create(AccessEntityStatusCode.NotFound, item);
            }
        }
    }
    
}
