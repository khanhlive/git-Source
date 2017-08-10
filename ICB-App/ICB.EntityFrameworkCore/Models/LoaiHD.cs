namespace ICB.EntityFrameworkCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiHD")]
    public partial class LoaiHD
    {
        [Key]
        public int IDLoaiHD { get; set; }

        [Required]
        [StringLength(250)]
        public string TenLoaiHD { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }
    }
}
