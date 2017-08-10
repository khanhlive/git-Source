namespace ICB.EntityFrameworkCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThamXet")]
    public partial class ThamXet
    {
        public int MaHD { get; set; }

        public int ID { get; set; }

        public int MaCB_TX { get; set; }

        public DateTime NgayThamXet { get; set; }

        [StringLength(500)]
        public string GhiChu { get; set; }

        public int PLoai { get; set; }

        public int? KetLuan { get; set; }

        public int MaCBth { get; set; }
    }
}
