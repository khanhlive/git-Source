namespace ICB.EntityFrameworkCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiPhict")]
    public partial class ChiPhict
    {
        [Key]
        public int ID_CPct { get; set; }

        public int ID_CP { get; set; }

        public int? MaCB { get; set; }

        [StringLength(20)]
        public string MaKH { get; set; }

        public double SoTien { get; set; }

        [StringLength(250)]
        public string NoiDung { get; set; }

        public int? ID_DMCP { get; set; }

        public int? Status { get; set; }
    }
}
