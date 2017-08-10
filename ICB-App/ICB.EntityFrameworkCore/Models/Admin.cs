namespace ICB.EntityFrameworkCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaCB { get; set; }

        [StringLength(250)]
        public string TenDN { get; set; }

        [StringLength(50)]
        public string MatKhau { get; set; }

        public int? Ploai { get; set; }
    }
}
