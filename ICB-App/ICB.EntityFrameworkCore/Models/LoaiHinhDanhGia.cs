namespace ICB.EntityFrameworkCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiHinhDanhGia")]
    public partial class LoaiHinhDanhGia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiHinhDanhGia()
        {
            ChuongTrinhDanhGias = new HashSet<ChuongTrinhDanhGia>();
        }

        [Key]
        public int MaLHDG { get; set; }

        [StringLength(250)]
        public string TenLoaiHinh { get; set; }

        public int? Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChuongTrinhDanhGia> ChuongTrinhDanhGias { get; set; }
    }
}
