namespace ICB.EntityFrameworkCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DM_CP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DM_CP()
        {
            ChiPhis = new HashSet<ChiPhi>();
        }

        [Key]
        public int ID_DMCP { get; set; }

        [Required]
        [StringLength(250)]
        public string NoiDung { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        public int Status { get; set; }

        public double DonGia { get; set; }

        public int? PhanLoai { get; set; }

        public int? IDNhomCP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiPhi> ChiPhis { get; set; }
    }
}
