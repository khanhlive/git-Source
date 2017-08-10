namespace ICB.EntityFrameworkCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhamViDG")]
    public partial class PhamViDG
    {
        public int IDCTDG { get; set; }

        [Required]
        [StringLength(200)]
        public string HangHoa { get; set; }

        [StringLength(200)]
        public string HangHoaUS { get; set; }

        [StringLength(500)]
        public string TSKyThuat { get; set; }

        [StringLength(250)]
        public string LuongMau { get; set; }

        [StringLength(500)]
        public string GhiChu { get; set; }

        [Key]
        public int IDPhamViDG { get; set; }

        [StringLength(250)]
        public string QuyChuan { get; set; }

        public int? CBLayMau { get; set; }
    }
}
