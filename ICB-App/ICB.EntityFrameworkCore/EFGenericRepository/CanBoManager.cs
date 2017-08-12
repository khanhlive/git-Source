using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICB.EntityFrameworkCore.EFGenericRepository
{
    public class CanBoManager : EntityFrameworkRepository<Models.DMCanBo,int>
    {
    }

    public class KhachHangManager : EntityFrameworkRepository<Models.KhachHang, string>
    {
    }
}
