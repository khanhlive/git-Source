using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ICB.HostAPI.Controllers
{
    public class demoController : ApiController
    {
        public IEnumerable<ICB.EntityFrameworkCore.Models.Admin> Get()
        {
            using (var db = new ICB.EntityFrameworkCore.Models.ICB_DbContext())
            {
                return db.Admins.ToList();
            }
            
        }
    }
}
