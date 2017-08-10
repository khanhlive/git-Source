namespace ICB.EntityFrameworkCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhongBan")]
    public partial class PhongBan
    {
        [Key]
        [StringLength(50)]
        public string MaPhongBan { get; set; }

        [StringLength(250)]
        public string TenPhongBan { get; set; }
    }
}
