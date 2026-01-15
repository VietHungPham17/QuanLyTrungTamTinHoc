namespace DTLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transcript")]
    public partial class Transcript
    {
        [Key]
        [Column(Order = 0, TypeName = "datetime")]
        public DateTime TestDate { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string StudentID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string CourseID { get; set; }

        [Column(TypeName = "float")]
        public double Score { get; set; }

        [StringLength(100)]
        public string Note { get; set; }

        [Column(TypeName = "bit")]
        public bool Status { get; set; }

        [ForeignKey("Employee"),StringLength(10)]
        public string EmployeeID { get; set; }

        public virtual Course Course { get; set; }

        public virtual Register Register { get; set; }

        public virtual Student Student { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
