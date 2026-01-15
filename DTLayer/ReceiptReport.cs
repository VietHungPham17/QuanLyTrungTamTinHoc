using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTLayer
{
    public class ReceiptReport
    {
        public string ReceiptID { get; set; }
        public DateTime Date { get; set; }
        public decimal Payment { get; set; }
        public string EmployeeID { get; set; }
    }
}
