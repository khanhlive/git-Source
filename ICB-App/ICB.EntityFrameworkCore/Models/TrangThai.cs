namespace ICB.EntityFrameworkCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrangThai")]
    public partial class TrangThai
    {
        [Key]
        public int MaTT { get; set; }

        [StringLength(250)]
        public string TenTT { get; set; }

        public int? Status { get; set; }
    }
}
