using ICB.WebCore.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;

namespace ICB.WebCore.Controllers
{
    public class khachhangController : ApiController
    {
        [MyAuthorize]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            using (var db = new ICB.EntityFrameworkCore.Models.ICB_DbContext())
            {
                var Data = (from cp in db.ChiPhis
                            join hdong in db.HopDongs on cp.MaHD equals hdong.MaHD
                            join kh in db.KhachHangs on hdong.MaKH equals kh.MaKH
                            join noidungcp in db.DM_CP on cp.ID_DMCP equals noidungcp.ID_DMCP
                            join cpct in db.ChiPhicts on cp.ID_CP equals cpct.ID_CP
                            where cp.MaHD == 14556
                            select new
                            {
                                ID_CP = cp.ID_CP,
                                MaCB = cpct.MaCB,
                                SoTien = cp.SoTien,
                                NoiDungChiPhi = noidungcp.NoiDung,
                                NgayNhap = cp.NgayNhap,
                                TenHD = hdong.TenHD,
                                MaHD = hdong.MaHD,
                                MaQD = hdong.MaQD,
                                MaKH = hdong.MaKH,
                                TenKH = kh.TenKH
                            }).ToList();
                var d = (from a in Data
                         join b in db.DMCanBoes on a.MaCB equals b.MaCB into kq
                         from c in kq.DefaultIfEmpty()
                         select new
                         {
                             ID_CP = a.ID_CP,
                             SoTien = a.SoTien,
                             NoiDungChiPhi = a.NoiDungChiPhi,
                             NgayNhap = a.NgayNhap,
                             TenHD = a.TenHD,
                             MaHD = a.MaHD,
                             MaQD = a.MaQD,
                             MaKH = a.MaKH,
                             TenKH = a.TenKH,
                             tencb = c == null ? "" : c.TenCB
                         }).ToList();
                var datasource = (from dd in d
                                  group dd.tencb by new { dd.ID_CP, dd.MaHD, dd.MaKH, dd.MaQD, dd.NgayNhap, dd.NoiDungChiPhi, dd.SoTien, dd.TenHD, dd.TenKH } into kq
                                  select new
                                  {
                                      ID_CP = kq.Key.ID_CP,
                                      SoTien = kq.Key.SoTien,
                                      NoiDungChiPhi = kq.Key.NoiDungChiPhi,
                                      NgayNhap = kq.Key.NgayNhap,
                                      TenHD = kq.Key.TenHD,
                                      MaHD = kq.Key.MaHD,
                                      MaQD = kq.Key.MaQD,
                                      MaKH = kq.Key.MaKH,
                                      TenKH = kq.Key.TenKH,
                                      tencb = kq.Select(p => p).Distinct()
                                  }).AsEnumerable().Select(p => new {
                                      ID_CP = p.ID_CP,
                                      MaCB = string.Join(" + ", p.tencb),
                                      SoTien = p.SoTien,
                                      NoiDungChiPhi = p.NoiDungChiPhi,
                                      NgayNhap = p.NgayNhap,
                                      TenHD = p.TenHD,
                                      MaHD = p.MaHD,
                                      MaQD = p.MaQD,
                                      MaKH = p.MaKH,
                                      TenKH = p.TenKH
                                  }).ToList();
                return Ok(datasource);
            }
            
        }

        [HttpGet]
        public IHttpActionResult layall()
        {
            return Ok("getall");
        }

        [MyAuthorize]
        [HttpGet]
        public IHttpActionResult getkhachhang()
        {
            using (var db = new ICB.EntityFrameworkCore.Models.ICB_DbContext())
            {
                 
                return Ok("");
            }
        }
    }
}
