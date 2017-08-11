using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ICB.EntityFrameworkCore.Services.Interfaces
{
    public interface IApplicationProvider<T,H>
    {
        Task<T> GetByIDAsync(H id);
        Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetAllAsync();
        Task<T> InsertAsync(T model);
        Task<bool> UpdateAsync(T model);
        Task<bool> DeleteAsync(T model);

    }
}
