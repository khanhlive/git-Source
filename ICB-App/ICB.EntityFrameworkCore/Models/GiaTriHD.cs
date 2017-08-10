namespace ICB.EntityFrameworkCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GiaTriHD")]
    public partial class GiaTriHD
    {
        [Key]
        public int IdGiaTriHD { get; set; }

        public int MaHD { get; set; }

        public int PhanLoai { get; set; }

        [StringLength(250)]
        public string NoiDung { get; set; }

        public double SoTien { get; set; }

        [Column(TypeName = "date")]
        public DateTime NamTToan { get; set; }

        public int TrangThaiTT { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }
    }
}
