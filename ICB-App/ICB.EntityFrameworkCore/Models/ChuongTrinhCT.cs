namespace ICB.EntityFrameworkCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChuongTrinhCT")]
    public partial class ChuongTrinhCT
    {
        [Key]
        public int IDCT { get; set; }

        public int? IDCTDG { get; set; }

        public DateTime? ThoiGian { get; set; }

        public string DanhGia { get; set; }

        public string GhiChu { get; set; }

        public virtual ChuongTrinhDanhGia ChuongTrinhDanhGia { get; set; }
    }
}
