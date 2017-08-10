using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICB.EntityFrameworkCore.Models;
using System.Data.Entity;

namespace ICB.EntityFrameworkCore.Services
{
    public class KhachHangProvider
    {
        public async Task<List<KhachHang>> GetAllAsync()
        {
            var db = new ICB_DbContext();
            var q = from a in db.KhachHangs select a;
            return await q.ToListAsync();
        }
    }
}
