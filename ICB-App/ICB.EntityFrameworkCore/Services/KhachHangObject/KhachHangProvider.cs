using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ICB.EntityFrameworkCore.Models;
using System.Linq.Expressions;

namespace ICB.EntityFrameworkCore.Services.KhachHangObject
{
    public class KhachHangProvider : IKhachHangProvider
    {
        public async Task<bool> DeleteAsync(KhachHang model)
        {
            using (var db = new Models.ICB_DbContext())
            {
                db.KhachHangs.Attach(model);
                db.Entry<KhachHang>(model).State = EntityState.Deleted;
                int counter = await db.SaveChangesAsync();
                return (counter > 0);

            }
        }

        public async Task<List<KhachHang>> GetAllAsync()
        {
            using (var db = new Models.ICB_DbContext())
            {
                return await db.KhachHangs.ToListAsync();
            }
        }

        public async Task<List<KhachHang>> GetAsync(Expression<Func<KhachHang, bool>> predicate)
        {
            using (var db = new Models.ICB_DbContext())
            {
                return await db.KhachHangs.Where(predicate).ToListAsync();
            }
        }

        public async Task<KhachHang> GetByIDAsync(string id)
        {
            using (var db = new Models.ICB_DbContext())
            {
                return await db.KhachHangs.FirstOrDefaultAsync(p => p.MaKH == id);
            }
        }

        public async Task<KhachHang> InsertAsync(KhachHang model)
        {
            using (var db = new Models.ICB_DbContext())
            {
                db.KhachHangs.Add(model);
                int counter = await db.SaveChangesAsync();
                await db.Entry<Models.KhachHang>(model).GetDatabaseValuesAsync();
                return model;
                
            }
        }

        public async Task<bool> UpdateAsync(KhachHang model)
        {
            using (var db = new Models.ICB_DbContext())
            {
                db.KhachHangs.Attach(model);
                db.Entry<KhachHang>(model).State = EntityState.Modified;
                int counter = await db.SaveChangesAsync();
                return (counter > 0);

            }
        }
    }
}
