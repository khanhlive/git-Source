
using ICB.EntityFrameworkCore.Models;
using ICB.EntityFrameworkCore.Services.CanBos;
using ICB.EntityFrameworkCore.Services.KhachHangs;
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
            CanBoProvider provider = new CanBoProvider();
            return Ok(await provider.FindAllAsync(p=>p.MaCB!=0));
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetByID(string id)
        {
            //CanBoProvider provider = new CanBoProvider();
            KhachHangProvider provider = new KhachHangProvider();
            return Ok(await provider.GetByIDAsync(id));
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
