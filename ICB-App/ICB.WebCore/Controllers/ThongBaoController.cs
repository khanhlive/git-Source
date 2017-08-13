using ICB.EntityFrameworkCore.Models;
using ICB.EntityFrameworkCore.Services.ThongBaos;
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
    public class ThongBaoController : ApiController
    {
        [HttpGet]
        public async Task<ICollection<ThongBao>> GetAll()
        {
            using (var provider = new ThongBaoProvider())
            {
                return await provider.GetAllAsync();
            }
        }

        //[ResponseType(typeof(ThongBao))]
        public async Task<ResponseResultBase<ThongBao, object>> GetByID(int id)
        {
            using (var provider = new ThongBaoProvider())
            {
                ThongBao ThongBao = await provider.GetByIDAsync(id);
                if (ThongBao == null)
                {
                    return new ResponseResultBase<ThongBao, object> { status = false, statusCode = HttpStatusCode.NotFound, result = null };
                }

                return new ResponseResultBase<ThongBao, object> { status = true, statusCode = HttpStatusCode.OK, result = ThongBao };
            }


        }


        //[ResponseType(typeof(ResponseResultBase<ThongBao, object>))]
        [HttpPut]
        public async Task<ResponseResultBase<ThongBao, object>> Update(int id, ThongBao ThongBao)
        {
            if (!ModelState.IsValid)
            {
                return new ResponseResultBase<ThongBao, object> { status = false, statusCode = HttpStatusCode.BadRequest, result = null, error = ModelState.ToString() };
            }

            if (id != ThongBao.ID)
            {
                return new ResponseResultBase<ThongBao, object> { status = false, statusCode = HttpStatusCode.Accepted, result = null, error = null };
            }
            using (var provider = new ThongBaoProvider())
            {
                var result = await provider.UpdateAsync(ThongBao, id);
                if (result.Item1 == AccessEntityStatusCode.OK)
                {
                    return new ResponseResultBase<ThongBao, object> { status = true, statusCode = HttpStatusCode.OK, result = ThongBao, error = null };
                }
                else
                {
                    return new ResponseResultBase<ThongBao, object> { status = false, statusCode = HttpStatusCode.NotModified, result = ThongBao, error = null };
                }
            }
        }

        //[ResponseType(typeof(ResponseResultBase<ThongBao, object>))]
        [HttpPost]
        public async Task<ResponseResultBase<ThongBao, object>> Insert(ThongBao ThongBao)
        {

            if (!ModelState.IsValid)
            {
                return new ResponseResultBase<ThongBao, object> { status = false, statusCode = HttpStatusCode.BadRequest, result = null, error = ModelState.ToString() };
            }

            using (var provider = new ThongBaoProvider())
            {
                var result = await provider.InsertAsync(ThongBao);
                if (result.Item1 == AccessEntityStatusCode.OK)
                {
                    return new ResponseResultBase<ThongBao, object> { status = true, statusCode = HttpStatusCode.OK, result = ThongBao, error = null };
                }
                else
                {
                    return new ResponseResultBase<ThongBao, object> { status = false, statusCode = HttpStatusCode.NotModified, result = ThongBao, error = null };
                }
            }

        }

        //[ResponseType(typeof(ResponseResultBase<object, object>))]
        [HttpDelete]
        public async Task<ResponseResultBase<ThongBao, object>> Delete(int id)
        {
            using (var provider = new ThongBaoProvider())
            {
                var ThongBao = await provider.GetByIDAsync(id);
                if (ThongBao == null)
                {
                    return new ResponseResultBase<ThongBao, object> { status = true, statusCode = HttpStatusCode.NotFound, result = null, error = null };
                }
                else
                {
                    var result = await provider.DeleteAsync(ThongBao);
                    if (result == AccessEntityStatusCode.OK)
                    {
                        return new ResponseResultBase<ThongBao, object> { status = true, statusCode = HttpStatusCode.OK, result = ThongBao, error = null };
                    }
                    else
                        return new ResponseResultBase<ThongBao, object> { status = false, statusCode = HttpStatusCode.NotModified, result = ThongBao, error = null };
                }
            }

        }
    }
}
