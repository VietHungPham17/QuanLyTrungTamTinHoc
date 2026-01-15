namespace DTLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Level")]
    public partial class Level
    {
        public Level()
        {
            Courses = new HashSet<Course>();
        }

        [StringLength(10)]
        public string LevelID { get; set; }

        [StringLength(100)]
        public string LevelName { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
