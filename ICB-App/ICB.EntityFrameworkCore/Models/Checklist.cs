namespace ICB.EntityFrameworkCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Checklist")]
    public partial class Checklist
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(250)]
        public string MaCanCu { get; set; }

        public string NoiDungDanhGia { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaTC { get; set; }

        public int? STT { get; set; }

        public int? Status { get; set; }

        public virtual TieuChuan TieuChuan { get; set; }
    }
}
