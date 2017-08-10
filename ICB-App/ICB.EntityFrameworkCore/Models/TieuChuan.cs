namespace ICB.EntityFrameworkCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TieuChuan")]
    public partial class TieuChuan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TieuChuan()
        {
            Checklists = new HashSet<Checklist>();
        }

        [Key]
        public int MaTC { get; set; }

        [StringLength(250)]
        public string TenTC { get; set; }

        public int? Status { get; set; }

        [StringLength(50)]
        public string KyHieu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Checklist> Checklists { get; set; }
    }
}
