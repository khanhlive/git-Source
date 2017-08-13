
using ICB.EntityFrameworkCore.Models;
using ICB.EntityFrameworkCore.Services.DanhMucs.CanBos;
using ICB.EntityFrameworkCore.Services.KhachHangs;
using NDK.ApplicationCore.Extensions.ResponseResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ICB.WebCore.Controllers
{
    public class canboController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            using (CanBoProvider provider = new CanBoProvider())
            {
                return Ok(await provider.FindAllAsync(p => p.MaCB != 0));
            }
            
        }

        [HttpGet]
        public async Task<ResponseResultBase<KhachHang,object>> GetByID(string id)
        {
            //CanBoProvider provider = new CanBoProvider();
            
            using (KhachHangProvider provider = new KhachHangProvider())
            {
                var kh = await provider.GetByIDAsync(id);
                return new ResponseResultBase<KhachHang, object> { status = true, result = kh, statusCode = System.Net.HttpStatusCode.OK, error = null };
            }
            
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetFunc(int id)
        {
            
            CanBoProvider provider = new CanBoProvider();
            return Ok(await provider.FindAsync(p => p.MaCB == id));
        }

        [HttpGet]
        public async Task<IHttpActionResult> Insert(DMCanBo model)
        {
            if (ModelState.IsValid)
            {
                CanBoProvider provider = new CanBoProvider();
                return Ok(await provider.InsertAsync(model));
            }
            else
            {
                return Content(System.Net.HttpStatusCode.InternalServerError, "-1");
            }
            
        }
    }
}
