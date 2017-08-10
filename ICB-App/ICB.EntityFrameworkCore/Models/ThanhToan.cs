namespace ICB.EntityFrameworkCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThanhToan")]
    public partial class ThanhToan
    {
        [Key]
        public int MaThanhToan { get; set; }

        public int MaHD { get; set; }

        public double? SoTien { get; set; }

        public DateTime? NgayThanhToan { get; set; }

        [StringLength(255)]
        public string NoiDungTT { get; set; }

        public int MaCBth { get; set; }

        public int? IdGiaTriHD { get; set; }

        [StringLength(50)]
        public string SoHoaDon { get; set; }

        public DateTime? NgayVietHDon { get; set; }

        public int? TrangThaiHDon { get; set; }
    }
}
