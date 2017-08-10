namespace ICB.EntityFrameworkCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChucVu")]
    public partial class ChucVu
    {
        [Key]
        public int IDCV { get; set; }

        [StringLength(250)]
        public string TenChucVu { get; set; }

        public int? Status { get; set; }

        public int SoTT { get; set; }
    }
}
