namespace ICB.EntityFrameworkCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CongVan")]
    public partial class CongVan
    {
        [Key]
        public int IDCV { get; set; }

        public int? MaHD { get; set; }

        [Required]
        [StringLength(500)]
        public string NoiDung { get; set; }

        [StringLength(250)]
        public string File { get; set; }

        [StringLength(500)]
        public string MoTa { get; set; }

        public int? PhanLoai { get; set; }

        public DateTime? NgayGuiNhan { get; set; }

        public int MaCB { get; set; }

        public int MaCBth { get; set; }

        public string GhiChu { get; set; }
    }
}
