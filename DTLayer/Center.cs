using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTLayer
{
    public class Center
    {
        [Key]
        public string CenterID { get; set; }

        [StringLength(250)]
        public string CenterName { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string  PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Fax { get; set; }

        [StringLength(100)]
        public string Website { get; set; }
    }
}
