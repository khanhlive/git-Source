using ICB.EntityFrameworkCore.Models;
using ICB.EntityFrameworkCore.Services.DanhMucs.NaceCodes;
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
    public class NaceCodeController : ApiController
    {
        [HttpGet]
        public async Task<ICollection<DMNaceCode>> GetAll()
        {
            using (var provider = new DM_NaceCodeProvider())
            {
                return await provider.GetAllAsync();
            }
        }

        //[ResponseType(typeof(DMNaceCode))]
        public async Task<ResponseResultBase<DMNaceCode, object>> GetByID(string id)
        {
            using (var provider = new DM_NaceCodeProvider())
            {
                DMNaceCode DMNaceCode = await provider.GetByIDAsync(id);
                if (DMNaceCode == null)
                {
                    return new ResponseResultBase<DMNaceCode, object> { status = false, statusCode = HttpStatusCode.NotFound, result = null };
                }

                return new ResponseResultBase<DMNaceCode, object> { status = true, statusCode = HttpStatusCode.OK, result = DMNaceCode };
            }


        }


        //[ResponseType(typeof(ResponseResultBase<DMNaceCode, object>))]
        [HttpPut]
        public async Task<ResponseResultBase<DMNaceCode, object>> Update(string id, DMNaceCode DMNaceCode)
        {
            if (!ModelState.IsValid)
            {
                return new ResponseResultBase<DMNaceCode, object> { status = false, statusCode = HttpStatusCode.BadRequest, result = null, error = ModelState.ToString() };
            }

            if (id != DMNaceCode.NaceCode)
            {
                return new ResponseResultBase<DMNaceCode, object> { status = false, statusCode = HttpStatusCode.Accepted, result = null, error = null };
            }
            using (var provider = new DM_NaceCodeProvider())
            {
                var result = await provider.UpdateAsync(DMNaceCode, id);
                if (result.Item1 == AccessEntityStatusCode.OK)
                {
                    return new ResponseResultBase<DMNaceCode, object> { status = true, statusCode = HttpStatusCode.OK, result = DMNaceCode, error = null };
                }
                else
                {
                    return new ResponseResultBase<DMNaceCode, object> { status = false, statusCode = HttpStatusCode.NotModified, result = DMNaceCode, error = null };
                }
            }
        }

        //[ResponseType(typeof(ResponseResultBase<DMNaceCode, object>))]
        [HttpPost]
        public async Task<ResponseResultBase<DMNaceCode, object>> Insert(DMNaceCode DMNaceCode)
        {

            if (!ModelState.IsValid)
            {
                return new ResponseResultBase<DMNaceCode, object> { status = false, statusCode = HttpStatusCode.BadRequest, result = null, error = ModelState.ToString() };
            }

            using (var provider = new DM_NaceCodeProvider())
            {
                var result = await provider.InsertAsync(DMNaceCode);
                if (result.Item1 == AccessEntityStatusCode.OK)
                {
                    return new ResponseResultBase<DMNaceCode, object> { status = true, statusCode = HttpStatusCode.OK, result = DMNaceCode, error = null };
                }
                else
                {
                    return new ResponseResultBase<DMNaceCode, object> { status = false, statusCode = HttpStatusCode.NotModified, result = DMNaceCode, error = null };
                }
            }

        }

        //[ResponseType(typeof(ResponseResultBase<object, object>))]
        [HttpDelete]
        public async Task<ResponseResultBase<DMNaceCode, object>> Delete(string id)
        {
            using (var provider = new DM_NaceCodeProvider())
            {
                var DMNaceCode = await provider.GetByIDAsync(id);
                if (DMNaceCode == null)
                {
                    return new ResponseResultBase<DMNaceCode, object> { status = true, statusCode = HttpStatusCode.NotFound, result = null, error = null };
                }
                else
                {
                    var result = await provider.DeleteAsync(DMNaceCode);
                    if (result == AccessEntityStatusCode.OK)
                    {
                        return new ResponseResultBase<DMNaceCode, object> { status = true, statusCode = HttpStatusCode.OK, result = DMNaceCode, error = null };
                    }
                    else
                        return new ResponseResultBase<DMNaceCode, object> { status = false, statusCode = HttpStatusCode.NotModified, result = DMNaceCode, error = null };
                }
            }

        }
    }
}
