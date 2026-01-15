namespace DTLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [Key]
        [StringLength(10)]
        public string Username { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        [Column(TypeName ="bit")]
        public bool Status { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
