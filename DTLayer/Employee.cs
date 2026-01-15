namespace DTLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        public Employee()
        {
            Courses = new HashSet<Course>();
            Diaries = new HashSet<Diary>();
            Receipts = new HashSet<Receipt>();
            Transcripts = new HashSet<Transcript>();
        }

        [StringLength(10)]
        public string EmployeeID { get; set; }

        [StringLength(100)]
        public string EmployeeName { get; set; }

        [StringLength(5)]
        public string Gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDay { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(250)]
        public string Staying { get; set; }

        [StringLength(250)]
        public string Education { get; set; }

        [StringLength(250)]
        public string University { get; set; }

        [Column(TypeName = "image")]
        public byte[] Avatar { get; set; }

        public bool Status { get; set; }

        [Column(TypeName = "money")]
        public decimal Salary { get; set; }

        [StringLength(10)]
        public string MajorID { get; set; }

        public virtual Account Account { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Diary> Diaries { get; set; }

        public virtual Major Major { get; set; }

        public virtual ICollection<Receipt> Receipts { get; set; }

        public virtual ICollection<Transcript> Transcripts { get; set; }
    }
}
