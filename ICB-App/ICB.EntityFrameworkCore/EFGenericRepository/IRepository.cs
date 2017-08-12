using ICB.Extensions.ResponseResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ICB.EntityFrameworkCore.EFGenericRepository
{
    public interface IRepository<T,KeyType> where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        AccessEntityStatusCode Insert(T item);
        Task<Tuple<AccessEntityStatusCode, T>> InsertAsync(T item);
        Tuple<AccessEntityStatusCode, T> Update(T item, KeyType id);
        Task<Tuple<AccessEntityStatusCode, T>> UpdateAsync(T item, KeyType id);
        AccessEntityStatusCode Delete(T item);
        Task<AccessEntityStatusCode> DeleteAsync(T item);
        IQueryable<T> Select();
        T GetByID(KeyType id);
        Task<T> GetByIDAsync(KeyType id);
        T Find(Expression<Func<T, bool>> match);
        Task<T> FindAsync(Expression<Func<T, bool>> match);
        ICollection<T> FindAll(Expression<Func<T, bool>> match);
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);
        int Count();
        Task<int> CountAsync();
    }
}
