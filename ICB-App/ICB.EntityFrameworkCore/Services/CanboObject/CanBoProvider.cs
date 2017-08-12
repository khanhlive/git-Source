using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ICB.EntityFrameworkCore.Models;
using System.Data.Entity;

namespace ICB.EntityFrameworkCore.Services.CanboObject
{
    public class CanBoProvider : ICanboProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(DMCanBo model)
        {
            using (var db = new ICB_DbContext())
            {
                db.DMCanBoes.Attach(model);
                db.Entry<DMCanBo>(model).State = System.Data.Entity.EntityState.Deleted;
                int counter = await db.SaveChangesAsync();
                return (counter > 0);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<DMCanBo>> GetAllAsync()
        {
            using (var db = new ICB_DbContext())
            {
                return await db.DMCanBoes.ToListAsync();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<List<DMCanBo>> GetAsync(Expression<Func<DMCanBo, bool>> predicate)
        {
            using (var db = new ICB_DbContext())
            {
                return await db.DMCanBoes.Where(predicate).ToListAsync();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DMCanBo> GetByIDAsync(int id)
        {
            using (var db = new ICB_DbContext())
            {
                DMCanBo canbo = await db.DMCanBoes.FirstOrDefaultAsync(p => p.MaCB == id);
                return canbo;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<DMCanBo> InsertAsync(DMCanBo model)
        {
            using (var db = new ICB_DbContext())
            {
                db.DMCanBoes.Add(model);
                int counter = await db.SaveChangesAsync();
                await db.Entry(model).GetDatabaseValuesAsync();
                return (model);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(DMCanBo model)
        {
            using (var db = new ICB_DbContext())
            {
                db.DMCanBoes.Attach(model);
                db.Entry<DMCanBo>(model).State = System.Data.Entity.EntityState.Modified;
                int counter = await db.SaveChangesAsync();
                return (counter > 0);
            }
        }
    }
}
