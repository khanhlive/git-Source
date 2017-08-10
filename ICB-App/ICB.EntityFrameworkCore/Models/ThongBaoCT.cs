namespace ICB.EntityFrameworkCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongBaoCT")]
    public partial class ThongBaoCT
    {
        public int ID { get; set; }

        public int IDThongBao { get; set; }

        public int MaCB { get; set; }

        public int TrangThai { get; set; }
    }
}
