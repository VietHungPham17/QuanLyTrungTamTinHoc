namespace DTLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        public Student()
        {
            Registers = new HashSet<Register>();
            Transcripts = new HashSet<Transcript>();
        }

        [StringLength(10)]
        public string StudentID { get; set; }

        [StringLength(100)]
        public string StudentName { get; set; }

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

        public virtual ICollection<Register> Registers { get; set; }

        public virtual ICollection<Transcript> Transcripts { get; set; }
    }
}
