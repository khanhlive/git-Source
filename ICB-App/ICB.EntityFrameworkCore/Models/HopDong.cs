namespace ICB.EntityFrameworkCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HopDong")]
    public partial class HopDong
    {
        [StringLength(20)]
        public string MaKH { get; set; }

        [StringLength(250)]
        public string TenHD { get; set; }

        public DateTime? NgayKy { get; set; }

        public DateTime? NgayDeNghi { get; set; }

        public DateTime? NgayChungNhan { get; set; }

        public int MaTC { get; set; }

        [Column(TypeName = "ntext")]
        public string PhamViDanhGia { get; set; }

        public string HeThongQL { get; set; }

        [StringLength(255)]
        public string QLHoSo { get; set; }

        public int? Status { get; set; }

        [StringLength(250)]
        public string PhamViSanPham { get; set; }

        [StringLength(250)]
        public string LoaiTru { get; set; }

        [StringLength(250)]
        public string PhuongThuc { get; set; }

        public int? SoNhanVien { get; set; }

        [StringLength(50)]
        public string SoLuong { get; set; }

        public double? GiaTriHD { get; set; }

        public int IDLoaiHD { get; set; }

        public int HDKy { get; set; }

        public int PhanLoai { get; set; }

        public DateTime? NgayHetHan { get; set; }

        public DateTime? HanThanhToan { get; set; }

        public int? TrangThaiTT { get; set; }

        [Column(TypeName = "ntext")]
        public string PhamViDanhGiaUS { get; set; }

        [StringLength(50)]
        public string SoChungChi { get; set; }

        [StringLength(500)]
        public string NaceCode { get; set; }

        public int LanChungNhan { get; set; }

        [Required]
        [StringLength(50)]
        public string MaQD { get; set; }

        [Key]
        public int MaHD { get; set; }

        [StringLength(50)]
        public string VicasHD { get; set; }

        public int MaCBth { get; set; }

        [StringLength(50)]
        public string MaDG { get; set; }

        public string GhiChu { get; set; }

        public DateTime? NgayChungNhanSP { get; set; }

        public DateTime? NgayHetHanSP { get; set; }

        [StringLength(50)]
        public string SoChungNhanSP { get; set; }

        [StringLength(50)]
        public string VicasSP { get; set; }

        [StringLength(200)]
        public string TieuChuanSP { get; set; }

        public int? MaCBPhuTrach { get; set; }

        public DateTime? NgayChungNhanHT { get; set; }

        [StringLength(20)]
        public string MaDVKhac { get; set; }

        public int VAT { get; set; }
    }
}
