namespace ICB.EntityFrameworkCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HDLD")]
    public partial class HDLD
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string MaHDLD { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaCB { get; set; }

        public int Status { get; set; }

        public int LoaiHD { get; set; }

        public int ThoiHan { get; set; }

        public double? MucLuong { get; set; }
    }
}
