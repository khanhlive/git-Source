using ICB.EntityFrameworkCore.EFGenericRepository;
using ICB.EntityFrameworkCore.Models;
using ICB.EntityFrameworkCore.Services.CanboObject;
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
            return Ok(await provider.GetAllAsync());
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetByID(string id)
        {
            //CanBoProvider provider = new CanBoProvider();
            KhachHangManager provider = new KhachHangManager();
            return Ok(await provider.GetAsync(id));
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetFunc(int id)
        {
            CanBoProvider provider = new CanBoProvider();
            return Ok(await provider.GetAsync(p => p.MaCB == id));
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
