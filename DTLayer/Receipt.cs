namespace DTLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Receipt")]
    public partial class Receipt
    {
        [StringLength(10)]
        public string ReceiptID { get; set; }

        [StringLength(10)]
        public string StudentID { get; set; }

        [StringLength(10)]
        public string CourseID { get; set; }

        [StringLength(10)]
        public string EmployeeID { get; set; }

        [Column(TypeName = "money")]
        public decimal Payment { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Register Register { get; set; }
    }
}
