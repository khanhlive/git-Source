using ICB.EntityFrameworkCore.Models;
using ICB.EntityFrameworkCore.Services.CongVans;
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
    public class CongVanController : ApiController
    {
        [HttpGet]
        public async Task<ICollection<CongVan>> GetAll()
        {
            using (var provider = new CongVanProvider())
            {
                return await provider.GetAllAsync();
            }
        }

        //[ResponseType(typeof(CongVan))]
        public async Task<ResponseResultBase<CongVan, object>> GetByID(int id)
        {
            using (var provider = new CongVanProvider())
            {
                CongVan CongVan = await provider.GetByIDAsync(id);
                if (CongVan == null)
                {
                    return new ResponseResultBase<CongVan, object> { status = false, statusCode = HttpStatusCode.NotFound, result = null };
                }

                return new ResponseResultBase<CongVan, object> { status = true, statusCode = HttpStatusCode.OK, result = CongVan };
            }


        }


        //[ResponseType(typeof(ResponseResultBase<CongVan, object>))]
        [HttpPut]
        public async Task<ResponseResultBase<CongVan, object>> Update(int id, CongVan CongVan)
        {
            if (!ModelState.IsValid)
            {
                return new ResponseResultBase<CongVan, object> { status = false, statusCode = HttpStatusCode.BadRequest, result = null, error = ModelState.ToString() };
            }

            if (id != CongVan.IDCV)
            {
                return new ResponseResultBase<CongVan, object> { status = false, statusCode = HttpStatusCode.Accepted, result = null, error = null };
            }
            using (var provider = new CongVanProvider())
            {
                var result = await provider.UpdateAsync(CongVan, id);
                if (result.Item1 == AccessEntityStatusCode.OK)
                {
                    return new ResponseResultBase<CongVan, object> { status = true, statusCode = HttpStatusCode.OK, result = CongVan, error = null };
                }
                else
                {
                    return new ResponseResultBase<CongVan, object> { status = false, statusCode = HttpStatusCode.NotModified, result = CongVan, error = null };
                }
            }
        }

        //[ResponseType(typeof(ResponseResultBase<CongVan, object>))]
        [HttpPost]
        public async Task<ResponseResultBase<CongVan, object>> Insert(CongVan CongVan)
        {

            if (!ModelState.IsValid)
            {
                return new ResponseResultBase<CongVan, object> { status = false, statusCode = HttpStatusCode.BadRequest, result = null, error = ModelState.ToString() };
            }

            using (var provider = new CongVanProvider())
            {
                var result = await provider.InsertAsync(CongVan);
                if (result.Item1 == AccessEntityStatusCode.OK)
                {
                    return new ResponseResultBase<CongVan, object> { status = true, statusCode = HttpStatusCode.OK, result = CongVan, error = null };
                }
                else
                {
                    return new ResponseResultBase<CongVan, object> { status = false, statusCode = HttpStatusCode.NotModified, result = CongVan, error = null };
                }
            }

        }

        //[ResponseType(typeof(ResponseResultBase<object, object>))]
        [HttpDelete]
        public async Task<ResponseResultBase<CongVan, object>> Delete(int id)
        {
            using (var provider = new CongVanProvider())
            {
                var CongVan = await provider.GetByIDAsync(id);
                if (CongVan == null)
                {
                    return new ResponseResultBase<CongVan, object> { status = true, statusCode = HttpStatusCode.NotFound, result = null, error = null };
                }
                else
                {
                    var result = await provider.DeleteAsync(CongVan);
                    if (result == AccessEntityStatusCode.OK)
                    {
                        return new ResponseResultBase<CongVan, object> { status = true, statusCode = HttpStatusCode.OK, result = CongVan, error = null };
                    }
                    else
                        return new ResponseResultBase<CongVan, object> { status = false, statusCode = HttpStatusCode.NotModified, result = CongVan, error = null };
                }
            }

        }
    }
}
