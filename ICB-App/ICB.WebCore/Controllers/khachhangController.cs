using ICB.WebCore.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ICB.WebCore.Controllers
{
    public class khachhangController : ApiController
    {
        [MyAuthorize]
        public IHttpActionResult Get()
        {
            using (var db = new ICB.EntityFrameworkCore.Models.ICB_DbContext())
            {
                var hds = (from hd in db.HopDongs select hd).ToList();//.Where(p=>p.MaHD== 14556 || p.MaHD== 14555 || p.MaHD== 14552)

                var q2 = (from hd in hds
                          join chiphi in db.ChiPhis on hd.MaHD equals chiphi.MaHD
                          join chiphict in db.ChiPhicts on chiphi.ID_CP equals chiphict.ID_CP
                          join dmcp in db.DM_CP on chiphict.ID_DMCP equals dmcp.ID_DMCP
                          select new
                          {
                              hd,
                              chiphi.ID_DMCP,
                              ID_DMCPct = chiphict.ID_DMCP,
                              tenct = dmcp.NoiDung,
                              sotien = chiphict.SoTien
                          }
                          ).ToList();
                var q3 = (from a in q2
                          group new { a.tenct, a.sotien } by new { a.hd, a.ID_DMCP } into kq
                          select new
                          {
                              kq.Key.hd.MaHD,
                              kq.Key.ID_DMCP,
                              tongtien = kq.Count() == 0 ? 0 : kq.Sum(p => p.sotien),
                              chitiets = kq.Select(p => new { p.sotien, p.tenct })
                          }).ToList();
                var q4 = (from a in q3
                          group a by a.MaHD into kq
                          select new
                          {
                              hd = kq.Key,
                              chiphihoso = kq.FirstOrDefault(p => p.ID_DMCP == 37) != null ? kq.FirstOrDefault(p => p.ID_DMCP == 37).tongtien : 0,
                              chiphidanhgia = kq.FirstOrDefault(p => p.ID_DMCP == 23) != null ? kq.FirstOrDefault(p => p.ID_DMCP == 23).tongtien : 0,
                              chiphihoahong = kq.FirstOrDefault(p => p.ID_DMCP == 9) != null ? kq.FirstOrDefault(p => p.ID_DMCP == 9).tongtien : 0,
                              chiphithunghiems = kq.FirstOrDefault(p => p.ID_DMCP == 19) != null ? kq.FirstOrDefault(p => p.ID_DMCP == 19).chitiets : null
                          }).ToList();
                return Ok(q4);
            }
            
        }
    }
}
