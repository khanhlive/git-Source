namespace ICB.EntityFrameworkCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HeThong")]
    public partial class HeThong
    {
        [Key]
        public int IDHT { get; set; }

        [Required]
        [StringLength(250)]
        public string TenDV { get; set; }

        [StringLength(50)]
        public string MaSoThue { get; set; }

        [StringLength(50)]
        public string DienThoai { get; set; }

        [StringLength(50)]
        public string Website { get; set; }

        [Required]
        [StringLength(50)]
        public string ThuTruongDV { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(250)]
        public string logo { get; set; }

        [StringLength(50)]
        public string Fax { get; set; }

        [StringLength(250)]
        public string TruSo { get; set; }

        [StringLength(50)]
        public string Vicas { get; set; }

        [StringLength(50)]
        public string SoTaiKhoan { get; set; }

        [StringLength(50)]
        public string FomatDate { get; set; }
    }
}
