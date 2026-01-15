namespace DTLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Course")]
    public partial class Course
    {
        public Course()
        {
            Registers = new HashSet<Register>();
            Transcripts = new HashSet<Transcript>();
        }

        [StringLength(10)]
        public string CourseID { get; set; }

        [StringLength(100)]
        public string CourseName { get; set; }

        public TimeSpan Time { get; set; }

        [Column(TypeName = "date")]
        public DateTime Opening { get; set; }

        [Column(TypeName = "date")]
        public DateTime Closing { get; set; }

        [StringLength(100)]
        public string Schedule { get; set; }

        [Column(TypeName = "money")]
        public decimal Tuition { get; set; }

        public bool Status { get; set; }

        [StringLength(10)]
        public string LevelID { get; set; }

        [StringLength(10)]
        public string EmployeeID { get; set; }

        public int Number { get; set; }

        [StringLength(100)]
        public string Room { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Level Level { get; set; }

        public virtual ICollection<Register> Registers { get; set; }

        public virtual ICollection<Transcript> Transcripts { get; set; }
    }
}
