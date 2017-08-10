namespace ICB.EntityFrameworkCore.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ICB_DbContext : DbContext
    {
        public ICB_DbContext()
            : base("name=ICB_DbContext")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Checklist> Checklists { get; set; }
        public virtual DbSet<ChiPhi> ChiPhis { get; set; }
        public virtual DbSet<ChiPhict> ChiPhicts { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<ChuongTrinhCT> ChuongTrinhCTs { get; set; }
        public virtual DbSet<ChuongTrinhDanhGia> ChuongTrinhDanhGias { get; set; }
        public virtual DbSet<CongVan> CongVans { get; set; }
        public virtual DbSet<DM_CP> DM_CP { get; set; }
        public virtual DbSet<DMCanBo> DMCanBoes { get; set; }
        public virtual DbSet<DMNaceCode> DMNaceCodes { get; set; }
        public virtual DbSet<DMTaiLieu> DMTaiLieux { get; set; }
        public virtual DbSet<DoiTuongPQ> DoiTuongPQs { get; set; }
        public virtual DbSet<GiaTriHD> GiaTriHDs { get; set; }
        public virtual DbSet<HDLD> HDLDs { get; set; }
        public virtual DbSet<HeThong> HeThongs { get; set; }
        public virtual DbSet<HopDong> HopDongs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiHD> LoaiHDs { get; set; }
        public virtual DbSet<LoaiHinhDanhGia> LoaiHinhDanhGias { get; set; }
        public virtual DbSet<PhamViDG> PhamViDGs { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }
        public virtual DbSet<PhatHienDanhGia> PhatHienDanhGias { get; set; }
        public virtual DbSet<PhongBan> PhongBans { get; set; }
        public virtual DbSet<ThamXet> ThamXets { get; set; }
        public virtual DbSet<ThanhPhanDanhGia> ThanhPhanDanhGias { get; set; }
        public virtual DbSet<ThanhToan> ThanhToans { get; set; }
        public virtual DbSet<ThongBao> ThongBaos { get; set; }
        public virtual DbSet<ThongBaoCT> ThongBaoCTs { get; set; }
        public virtual DbSet<TieuChuan> TieuChuans { get; set; }
        public virtual DbSet<TrangThai> TrangThais { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiPhict>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<ChuongTrinhDanhGia>()
                .Property(e => e.IDTL)
                .IsUnicode(false);

            modelBuilder.Entity<ChuongTrinhDanhGia>()
                .HasMany(e => e.PhatHienDanhGias)
                .WithRequired(e => e.ChuongTrinhDanhGia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DM_CP>()
                .HasMany(e => e.ChiPhis)
                .WithRequired(e => e.DM_CP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DMCanBo>()
                .Property(e => e.NaceCode)
                .IsUnicode(false);

            modelBuilder.Entity<DMCanBo>()
                .Property(e => e.SoCMTND)
                .IsUnicode(false);

            modelBuilder.Entity<DMNaceCode>()
                .Property(e => e.NaceCode)
                .IsUnicode(false);

            modelBuilder.Entity<HeThong>()
                .Property(e => e.MaSoThue)
                .IsUnicode(false);

            modelBuilder.Entity<HeThong>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<HeThong>()
                .Property(e => e.Website)
                .IsUnicode(false);

            modelBuilder.Entity<HeThong>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<HeThong>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<HeThong>()
                .Property(e => e.Vicas)
                .IsUnicode(false);

            modelBuilder.Entity<HeThong>()
                .Property(e => e.SoTaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<HeThong>()
                .Property(e => e.FomatDate)
                .IsUnicode(false);

            modelBuilder.Entity<HopDong>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<HopDong>()
                .Property(e => e.SoLuong)
                .IsUnicode(false);

            modelBuilder.Entity<HopDong>()
                .Property(e => e.SoChungChi)
                .IsUnicode(false);

            modelBuilder.Entity<HopDong>()
                .Property(e => e.NaceCode)
                .IsUnicode(false);

            modelBuilder.Entity<HopDong>()
                .Property(e => e.MaDVKhac)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MaSoThue)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SoTaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<TieuChuan>()
                .Property(e => e.KyHieu)
                .IsUnicode(false);

            modelBuilder.Entity<TieuChuan>()
                .HasMany(e => e.Checklists)
                .WithRequired(e => e.TieuChuan)
                .WillCascadeOnDelete(false);
        }
    }
}
