namespace DTLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Diary")]
    public partial class Diary
    {
        [Key]
        public int DiaryID { get; set; }

        [StringLength(10), ForeignKey("Employee")]
        public string EmployeeID { get; set; }

        [StringLength(100)]
        public string Action { get; set; }

        [Column(TypeName ="datetime")]
        public DateTime Date { get; set; }

        [StringLength(100)]
        public string Status { get; set; }

        [Column(TypeName ="bit")]
        public bool Auto { get; set; }


        public virtual Employee Employee { get; set; }
    }
}
