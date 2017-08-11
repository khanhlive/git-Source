using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ICB.EntityFrameworkCore.Models;
using System.Linq.Expressions;

namespace ICB.EntityFrameworkCore.Services.KhachHangObject
{
    public class KhachHangProvider : IKhachHangProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(KhachHang model)
        {
            using (var db = new Models.ICB_DbContext())
            {
                db.KhachHangs.Attach(model);
                db.Entry<KhachHang>(model).State = EntityState.Deleted;
                int counter = await db.SaveChangesAsync();
                return (counter > 0);

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<KhachHang>> GetAllAsync()
        {
            using (var db = new Models.ICB_DbContext())
            {
                return await db.KhachHangs.ToListAsync();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<List<KhachHang>> GetAsync(Expression<Func<KhachHang, bool>> predicate)
        {
            using (var db = new Models.ICB_DbContext())
            {
                return await db.KhachHangs.Where(predicate).ToListAsync();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<KhachHang> GetByIDAsync(string id)
        {
            using (var db = new Models.ICB_DbContext())
            {
                return await db.KhachHangs.FirstOrDefaultAsync(p => p.MaKH == id);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<KhachHang> InsertAsync(KhachHang model)
        {
            using (var db = new Models.ICB_DbContext())
            {
                db.KhachHangs.Add(model);
                int counter = await db.SaveChangesAsync();
                await db.Entry<Models.KhachHang>(model).GetDatabaseValuesAsync();
                return model;

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(KhachHang model)
        {
            using (var db = new Models.ICB_DbContext())
            {
                db.KhachHangs.Attach(model);
                db.Entry<KhachHang>(model).State = EntityState.Modified;
                int counter = await db.SaveChangesAsync();
                return (counter > 0);

            }
        }

        /// <summary>
        /// Lấy danh sách chi phí hợp đồng
        /// </summary>
        /// <param name="mahd">Mã hợp đồng</param>
        /// <returns></returns>
        public async Task<object> GetChiPhiHopDongAsync(int mahd)
        {
            using (var db = new Models.ICB_DbContext())
            {
                var Data = await (from cp in db.ChiPhis
                                  join hdong in db.HopDongs on cp.MaHD equals hdong.MaHD
                                  join kh in db.KhachHangs on hdong.MaKH equals kh.MaKH
                                  join noidungcp in db.DM_CP on cp.ID_DMCP equals noidungcp.ID_DMCP
                                  join cpct in db.ChiPhicts on cp.ID_CP equals cpct.ID_CP
                                  where cp.MaHD == mahd
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
                                  }).ToListAsync();
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
                return datasource;
            }
        }

        public async Task<object> GetBangTongHopKhachHangAsync()
        {
            using (ICB_DbContext db = new ICB_DbContext())
            {

                var q1 = await (from hd in db.HopDongs
                                join kh in db.KhachHangs on hd.MaKH equals kh.MaKH
                                join tc in db.TieuChuans on hd.MaTC equals tc.MaTC
                                join gthd in db.GiaTriHDs on hd.MaHD equals gthd.MaHD into giatrihd
                                join cb in db.DMCanBoes on hd.MaCBth equals cb.MaCB
                                select new {
                                    TenKH = kh.TenKH,
                                    MaKH = hd.MaKH,
                                    MaHD = hd.MaHD,
                                    NgayCapCC = hd.NgayChungNhan,
                                    NgayCCDi = hd.NgayChungNhan,
                                    NguoiMoiGioi = hd.QLHoSo,
                                    SoHD = "",
                                    TieuChuan = tc.TenTC,
                                    GhiChu = hd.GhiChu,
                                    MaDG = hd.MaDG,
                                    VAT = hd.VAT,
                                    NguoiPhuTrach = cb.TenCB,
                                    DoanhThu = giatrihd.Count() > 0 ? giatrihd.Sum(p => p.SoTien) : 0,
                                    DoanhThuThuNgiem = giatrihd.Count(p => p.NoiDung == "27") > 0 ? giatrihd.Where(p => p.NoiDung == "27").Sum(p => p.SoTien) : 0

                                }).ToListAsync();
                var q2 = (from hd in q1
                          join chiphi in db.ChiPhis on hd.MaHD equals chiphi.MaHD
                          join chiphict in db.ChiPhicts on chiphi.ID_CP equals chiphict.ID_CP
                          join dmcp in db.DM_CP on chiphict.ID_DMCP equals dmcp.ID_DMCP
                          select new
                          {
                              hd,
                              chiphi.ID_CP,
                              chiphi.ID_DMCP,
                              ID_DMCPct = chiphict.ID_DMCP,
                              chiphict.SoTien,
                              Noidung = dmcp.NoiDung
                          }).ToList();
                var q3 = (from a in q2
                          group new { a.SoTien, a.Noidung, a.ID_DMCPct, a.ID_DMCP } by a.hd into kq
                          select new
                          {
                              TenKH = kq.Key.TenKH,
                              MaKH = kq.Key.MaKH,
                              MaHD = kq.Key.MaHD,
                              NgayCapCC = kq.Key.NgayCapCC,
                              NgayCCDi = kq.Key.NgayCCDi,
                              NguoiMoiGioi = kq.Key.NguoiMoiGioi,
                              SoHD = "",
                              TieuChuan = kq.Key.TieuChuan,
                              GhiChu = kq.Key.GhiChu,
                              MaDG = kq.Key.MaDG,
                              VAT = kq.Key.VAT,
                              NguoiPhuTrach = kq.Key.NguoiPhuTrach,
                              DoanhThu = kq.Key.DoanhThu,
                              DoanhThuThuNgiem = kq.Key.DoanhThuThuNgiem,
                              chiphidanhgia = kq.Where(p => p.ID_DMCP == 23).Sum(p => p.SoTien),
                              chiphihoso = kq.Where(p => p.ID_DMCP == 37).Sum(p => p.SoTien),
                              chiphihoahong = kq.Where(p => p.ID_DMCP == 9).Sum(p => p.SoTien),
                              lan1=kq.Where(p=>p.ID_DMCP==19 && p.Noidung.Contains("1")).Sum(p=>p.SoTien),
                              lan2 = kq.Where(p => p.ID_DMCP == 19 && p.Noidung.Contains("2")).Sum(p => p.SoTien),
                              lan3 = kq.Where(p => p.ID_DMCP == 19 && p.Noidung.Contains("3")).Sum(p => p.SoTien)
                          }).ToList();
                return q3.ToList();
            }
        }



    }
}
