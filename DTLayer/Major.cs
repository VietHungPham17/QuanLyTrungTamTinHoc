namespace DTLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Major")]
    public partial class Major
    {
        public Major()
        {
            Employees = new HashSet<Employee>();
        }

        [StringLength(10)]
        public string MajorID { get; set; }

        [StringLength(100)]
        public string MajorName { get; set; }

        [StringLength(100)]
        public string JobFunction { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
