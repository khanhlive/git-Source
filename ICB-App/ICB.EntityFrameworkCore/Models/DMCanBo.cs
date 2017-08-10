namespace ICB.EntityFrameworkCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DMCanBo")]
    public partial class DMCanBo
    {
        [Key]
        public int MaCB { get; set; }

        [StringLength(250)]
        public string TenCB { get; set; }

        [StringLength(50)]
        public string PhongBan { get; set; }

        public int? GioiTinh { get; set; }

        public DateTime? NamSinh { get; set; }

        public string QueQuan { get; set; }

        public int? IDCV { get; set; }

        public int PhanLoai { get; set; }

        [StringLength(500)]
        public string NaceCode { get; set; }

        [StringLength(50)]
        public string SoCMTND { get; set; }

        public DateTime? NgayCapCMTND { get; set; }

        [StringLength(500)]
        public string GhiChu { get; set; }

        public int? Status { get; set; }

        public int? MoiGioi { get; set; }
    }
}
