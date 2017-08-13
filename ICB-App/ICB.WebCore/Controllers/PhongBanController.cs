using ICB.EntityFrameworkCore.Models;
using ICB.EntityFrameworkCore.Services.DanhMucs.PhongBans;
using NDK.ApplicationCore.Extensions.ResponseResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ICB.WebCore.Controllers
{
    public class PhongBanController : ApiController
    {
        [HttpGet]
        public async Task<ICollection<PhongBan>> GetAll()
        {
            using (var provider = new DM_PhongBanProvider())
            {
                return await provider.GetAllAsync();
            }
        }

        //[ResponseType(typeof(PhongBan))]
        public async Task<ResponseResultBase<PhongBan, object>> GetByID(string id)
        {
            using (var provider = new DM_PhongBanProvider())
            {
                PhongBan PhongBan = await provider.GetByIDAsync(id);
                if (PhongBan == null)
                {
                    return new ResponseResultBase<PhongBan, object> { status = false, statusCode = HttpStatusCode.NotFound, result = null };
                }

                return new ResponseResultBase<PhongBan, object> { status = true, statusCode = HttpStatusCode.OK, result = PhongBan };
            }


        }


        //[ResponseType(typeof(ResponseResultBase<PhongBan, object>))]
        [HttpPut]
        public async Task<ResponseResultBase<PhongBan, object>> Update(string id, PhongBan PhongBan)
        {
            if (!ModelState.IsValid)
            {
                return new ResponseResultBase<PhongBan, object> { status = false, statusCode = HttpStatusCode.BadRequest, result = null, error = ModelState.ToString() };
            }

            if (id != PhongBan.MaPhongBan)
            {
                return new ResponseResultBase<PhongBan, object> { status = false, statusCode = HttpStatusCode.Accepted, result = null, error = null };
            }
            using (var provider = new DM_PhongBanProvider())
            {
                var result = await provider.UpdateAsync(PhongBan, id);
                if (result.Item1 == AccessEntityStatusCode.OK)
                {
                    return new ResponseResultBase<PhongBan, object> { status = true, statusCode = HttpStatusCode.OK, result = PhongBan, error = null };
                }
                else
                {
                    return new ResponseResultBase<PhongBan, object> { status = false, statusCode = HttpStatusCode.NotModified, result = PhongBan, error = null };
                }
            }
        }

        //[ResponseType(typeof(ResponseResultBase<PhongBan, object>))]
        [HttpPost]
        public async Task<ResponseResultBase<PhongBan, object>> Insert(PhongBan PhongBan)
        {

            if (!ModelState.IsValid)
            {
                return new ResponseResultBase<PhongBan, object> { status = false, statusCode = HttpStatusCode.BadRequest, result = null, error = ModelState.ToString() };
            }

            using (var provider = new DM_PhongBanProvider())
            {
                var result = await provider.InsertAsync(PhongBan);
                if (result.Item1 == AccessEntityStatusCode.OK)
                {
                    return new ResponseResultBase<PhongBan, object> { status = true, statusCode = HttpStatusCode.OK, result = PhongBan, error = null };
                }
                else
                {
                    return new ResponseResultBase<PhongBan, object> { status = false, statusCode = HttpStatusCode.NotModified, result = PhongBan, error = null };
                }
            }

        }

        //[ResponseType(typeof(ResponseResultBase<object, object>))]
        [HttpDelete]
        public async Task<ResponseResultBase<PhongBan, object>> Delete(string id)
        {
            using (var provider = new DM_PhongBanProvider())
            {
                var PhongBan = await provider.GetByIDAsync(id);
                if (PhongBan == null)
                {
                    return new ResponseResultBase<PhongBan, object> { status = true, statusCode = HttpStatusCode.NotFound, result = null, error = null };
                }
                else
                {
                    var result = await provider.DeleteAsync(PhongBan);
                    if (result == AccessEntityStatusCode.OK)
                    {
                        return new ResponseResultBase<PhongBan, object> { status = true, statusCode = HttpStatusCode.OK, result = PhongBan, error = null };
                    }
                    else
                        return new ResponseResultBase<PhongBan, object> { status = false, statusCode = HttpStatusCode.NotModified, result = PhongBan, error = null };
                }
            }

        }
    }
}
