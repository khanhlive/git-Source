namespace ICB.EntityFrameworkCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DMNaceCode")]
    public partial class DMNaceCode
    {
        [Key]
        [StringLength(50)]
        public string NaceCode { get; set; }

        [Required]
        [StringLength(250)]
        public string NganhKinhTe { get; set; }

        [StringLength(250)]
        public string NganhKinhTeUS { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }
    }
}
