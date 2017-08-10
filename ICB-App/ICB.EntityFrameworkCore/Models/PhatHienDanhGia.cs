namespace ICB.EntityFrameworkCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhatHienDanhGia")]
    public partial class PhatHienDanhGia
    {
        [Key]
        public int IDPHDG { get; set; }

        public int IDCTDG { get; set; }

        [StringLength(255)]
        public string MaCanCu { get; set; }

        [StringLength(50)]
        public string DanhGia { get; set; }

        [StringLength(10)]
        public string KetLuan { get; set; }

        [StringLength(2000)]
        public string PhatHien { get; set; }

        public int MaCB { get; set; }

        public virtual ChuongTrinhDanhGia ChuongTrinhDanhGia { get; set; }
    }
}
