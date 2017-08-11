using ICB.WebCore.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;
using ICB.EntityFrameworkCore.Services.KhachHangObject;

namespace ICB.WebCore.Controllers
{
    public class khachhangController : ApiController
    {
        
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            KhachHangProvider provider = new KhachHangProvider();
            return Ok(await provider.GetBangTongHopKhachHangAsync());
        }
        
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
            return Ok(await provider.GetAsync(p=>p.MaKH== id));
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetChiPhiHopDong(int mahd)
        {
            KhachHangProvider provider = new KhachHangProvider();
            return Ok(await provider.GetChiPhiHopDongAsync(mahd));
        }
    }
}
