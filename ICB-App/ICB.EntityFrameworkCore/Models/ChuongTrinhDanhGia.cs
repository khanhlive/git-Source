namespace ICB.EntityFrameworkCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChuongTrinhDanhGia")]
    public partial class ChuongTrinhDanhGia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChuongTrinhDanhGia()
        {
            ChuongTrinhCTs = new HashSet<ChuongTrinhCT>();
            PhatHienDanhGias = new HashSet<PhatHienDanhGia>();
            ThanhPhanDanhGias = new HashSet<ThanhPhanDanhGia>();
        }

        [Key]
        public int IDCTDG { get; set; }

        public int? MaHD { get; set; }

        public int? MaLHDG { get; set; }

        public int? SoNgayDanhGia { get; set; }

        public DateTime? NgayBatDau { get; set; }

        public DateTime? NgayKetThuc { get; set; }

        [Column(TypeName = "ntext")]
        public string NhanXet { get; set; }

        [StringLength(500)]
        public string IDTL { get; set; }

        public int NoiDanhGia { get; set; }

        public int DVDanhGia { get; set; }

        public int MaCBth { get; set; }

        public DateTime? NgayTraKQTN { get; set; }

        [Column(TypeName = "ntext")]
        public string DonViThuNghiem { get; set; }

        public DateTime? NgayBanGiaoMau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChuongTrinhCT> ChuongTrinhCTs { get; set; }

        public virtual LoaiHinhDanhGia LoaiHinhDanhGia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatHienDanhGia> PhatHienDanhGias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThanhPhanDanhGia> ThanhPhanDanhGias { get; set; }
    }
}
