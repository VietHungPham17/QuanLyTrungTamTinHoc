using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTLayer
{
    public class TuitionDebt
    {
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDay { get; set; }
        public string PhoneNumber { get; set; }
        public string CourseID { get; set; }
        public string CourseName { get; set; }
        public decimal Debt { get; set; }


        // center

        //public string CenterID { get; set; }

        //public string CenterName { get; set; }

        //public string Address { get; set; }

        //public string CenterPhone { get; set; }

        //public string Email { get; set; }

        //public string Fax { get; set; }

        //public string Website { get; set; }
    }
}
