namespace DTLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Register")]
    public partial class Register
    {
        public Register()
        {
            Receipts = new HashSet<Receipt>();
            Transcripts = new HashSet<Transcript>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string StudentID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string CourseID { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        public int Exemption { get; set; }

        [Column(TypeName = "money")]
        public decimal Total { get; set; }

        [Column(TypeName = "money")]
        public decimal Payment { get; set; }

        [Column(TypeName = "money")]
        public decimal Debt { get; set; }

        public string Note { get; set; }

        public virtual Course Course { get; set; }

        public virtual ICollection<Receipt> Receipts { get; set; }

        public virtual Student Student { get; set; }

        public virtual ICollection<Transcript> Transcripts { get; set; }
    }
}
