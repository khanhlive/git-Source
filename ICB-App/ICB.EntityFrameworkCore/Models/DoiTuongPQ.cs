namespace ICB.EntityFrameworkCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DoiTuongPQ")]
    public partial class DoiTuongPQ
    {
        [Key]
        public int MaDoiTuong { get; set; }

        [StringLength(500)]
        public string TenForm { get; set; }

        [Required]
        [StringLength(500)]
        public string TenDoiTuong { get; set; }

        public int TrangThai { get; set; }

        [StringLength(1000)]
        public string MoTa { get; set; }
    }
}
