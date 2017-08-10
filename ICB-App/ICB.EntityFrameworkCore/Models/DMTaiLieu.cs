namespace ICB.EntityFrameworkCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DMTaiLieu")]
    public partial class DMTaiLieu
    {
        [Key]
        public int IDTL { get; set; }

        [Required]
        [StringLength(250)]
        public string TaiLieu { get; set; }

        public int? STT { get; set; }
    }
}
