namespace ICB.EntityFrameworkCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [Key]
        [StringLength(20)]
        public string MaKH { get; set; }

        [Required]
        public string TenKH { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        public DateTime? NgayNhap { get; set; }

        public int? MaCBQL { get; set; }

        [StringLength(250)]
        public string NguoiDaiDien { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(250)]
        public string Web { get; set; }

        [Column(TypeName = "ntext")]
        public string TruSo { get; set; }

        [Column(TypeName = "ntext")]
        public string TruSoKhac { get; set; }

        [StringLength(50)]
        public string SoDienThoai { get; set; }

        [StringLength(50)]
        public string MaSoThue { get; set; }

        [StringLength(50)]
        public string Fax { get; set; }

        [StringLength(100)]
        public string ChucVu_NguoiDaiDien { get; set; }

        [Column(TypeName = "ntext")]
        public string TruSoUS { get; set; }

        [Column(TypeName = "ntext")]
        public string TruSoKhacUS { get; set; }

        [StringLength(250)]
        public string SoTaiKhoan { get; set; }

        [StringLength(500)]
        public string LienHe { get; set; }

        public int MaCBth { get; set; }

        public int? PhanLoai { get; set; }
    }
}
