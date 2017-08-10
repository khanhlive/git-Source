namespace ICB.EntityFrameworkCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiPhi")]
    public partial class ChiPhi
    {
        [Key]
        public int ID_CP { get; set; }

        public int ID_DMCP { get; set; }

        [StringLength(250)]
        public string NoiDung { get; set; }

        public DateTime NgayNhap { get; set; }

        public int? MaHD { get; set; }

        public int? MaCB { get; set; }

        public double SoTien { get; set; }

        public bool Status { get; set; }

        public int MaCBth { get; set; }

        public int? Trangthai_CP { get; set; }

        public byte? PhanLoai { get; set; }

        public virtual DM_CP DM_CP { get; set; }
    }
}
