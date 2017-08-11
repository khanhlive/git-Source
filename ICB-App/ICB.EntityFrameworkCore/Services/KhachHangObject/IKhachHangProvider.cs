using ICB.EntityFrameworkCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICB.EntityFrameworkCore.Services.KhachHangObject
{
    public interface IKhachHangProvider: IApplicationProvider<Models.KhachHang,string>
    {
        
    }
}
