using ICB.EntityFrameworkCore.Models;
using ICB.EntityFrameworkCore.Services.Accounts;
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
    public class accountController : ApiController
    {
        [HttpGet]
        public async Task<ICollection<Admin>> GetAll()
        {
            using (var provider = new AccountProvider())
            {
                return await provider.GetAllAsync();
            }
        }

        //[ResponseType(typeof(Admin))]
        public async Task<ResponseResultBase<Admin, object>> GetByID(int id)
        {
            using (var provider = new AccountProvider())
            {
                Admin admin = await provider.GetByIDAsync(id);
                if (admin == null)
                {
                    return new ResponseResultBase<Admin, object> { status = false, statusCode = HttpStatusCode.NotFound, result = null };
                }

                return new ResponseResultBase<Admin, object> { status = true, statusCode = HttpStatusCode.OK, result = admin };
            }


        }


        //[ResponseType(typeof(ResponseResultBase<Admin, object>))]
        [HttpPut]
        public async Task<ResponseResultBase<Admin, object>> Update(int id, Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return new ResponseResultBase<Admin, object> { status = false, statusCode = HttpStatusCode.BadRequest, result = null, error = ModelState.ToString() };
            }

            if (id != admin.MaCB)
            {
                return new ResponseResultBase<Admin, object> { status = false, statusCode = HttpStatusCode.Accepted, result = null, error = null };
            }
            using (var provider = new AccountProvider())
            {
                var result = await provider.UpdateAsync(admin, id);
                if (result.Item1 == AccessEntityStatusCode.OK)
                {
                    return new ResponseResultBase<Admin, object> { status = true, statusCode = HttpStatusCode.OK, result = admin, error = null };
                }
                else
                {
                    return new ResponseResultBase<Admin, object> { status = false, statusCode = HttpStatusCode.NotModified, result = admin, error = null };
                }
            }
        }

        //[ResponseType(typeof(ResponseResultBase<Admin, object>))]
        [HttpPost]
        public async Task<ResponseResultBase<Admin, object>> Insert(Admin admin)
        {

            if (!ModelState.IsValid)
            {
                return new ResponseResultBase<Admin, object> { status = false, statusCode = HttpStatusCode.BadRequest, result = null, error = ModelState.ToString() };
            }

            using (var provider = new AccountProvider())
            {
                var result = await provider.InsertAsync(admin);
                if (result.Item1 == AccessEntityStatusCode.OK)
                {
                    return new ResponseResultBase<Admin, object> { status = true, statusCode = HttpStatusCode.OK, result = admin, error = null };
                }
                else
                {
                    return new ResponseResultBase<Admin, object> { status = false, statusCode = HttpStatusCode.NotModified, result = admin, error = null };
                }
            }

        }

        //[ResponseType(typeof(ResponseResultBase<object, object>))]
        [HttpDelete]
        public async Task<ResponseResultBase<Admin, object>> Delete(int id)
        {
            using (var provider = new AccountProvider())
            {
                var admin = await provider.GetByIDAsync(id);
                if (admin == null)
                {
                    return new ResponseResultBase<Admin, object> { status = true, statusCode = HttpStatusCode.NotFound, result = null, error = null };
                }
                else
                {
                    var result = await provider.DeleteAsync(admin);
                    if (result == AccessEntityStatusCode.OK)
                    {
                        return new ResponseResultBase<Admin, object> { status = true, statusCode = HttpStatusCode.OK, result = admin, error = null };
                    }
                    else
                        return new ResponseResultBase<Admin, object> { status = false, statusCode = HttpStatusCode.NotModified, result = admin, error = null };
                }
            }

        }
    }
}
