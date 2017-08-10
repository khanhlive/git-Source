namespace ICB.EntityFrameworkCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThanhPhanDanhGia")]
    public partial class ThanhPhanDanhGia
    {
        [Key]
        public int IDTPDG { get; set; }

        public int? IDCTDG { get; set; }

        public int? MaCB { get; set; }

        public int? IDCV { get; set; }

        public int? Ploai { get; set; }

        [StringLength(250)]
        public string TenCB { get; set; }

        public DateTime? NgayLapDoan { get; set; }

        public int MaCBth { get; set; }

        public virtual ChuongTrinhDanhGia ChuongTrinhDanhGia { get; set; }
    }
}
