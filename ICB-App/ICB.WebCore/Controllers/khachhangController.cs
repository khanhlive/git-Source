using ICB.WebCore.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;
using ICB.EntityFrameworkCore.Services.KhachHangs;

namespace ICB.WebCore.Controllers
{
    public class khachhangController : ApiController
    {
        
        [HttpGet]
        public async Task<IHttpActionResult> GetByID(string id)
        {
            KhachHangProvider provider = new KhachHangProvider();
            return Ok(await provider.GetByIDAsync(id));
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetFunc(string id)
        {
            KhachHangProvider provider = new KhachHangProvider();
            return Ok(await provider.FindAsync(p=>p.MaKH== id));
        }

        
    }
}
