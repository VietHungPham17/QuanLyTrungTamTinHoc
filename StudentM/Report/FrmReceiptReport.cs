using BLLayer;
using DTLayer;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTrungTamTinHoc.Report
{
    public partial class FrmReceiptReport : Form
    {
        private List<Receipt> lstReceipt;
        public FrmReceiptReport(List<Receipt> lstReceipt)
        {
            InitializeComponent();
            this.lstReceipt = lstReceipt;
        }

        private void FrmReportReceipt_Load(object sender, EventArgs e)
        {
            try
            {
                string courseID = lstReceipt[0].CourseID;
                string studentID = lstReceipt[0].StudentID;
                Register register = new Register();
                register = (new BLLRegister()).Get(studentID, courseID);
                Employee employee = new Employee();
                employee = (new BLLEmployee()).Get(Program.Username);
                Student student = new Student();
                student = (new BLLStudent()).Get(studentID);

                foreach (Receipt re in lstReceipt)
                {
                    string employeeName = (new BLLEmployee()).Get(re.EmployeeID).EmployeeName;
                    re.EmployeeID = employeeName;

                    string courseName = (new BLLCourse()).Get(re.CourseID).CourseName;
                    re.CourseID = courseName;
                }

                ReceiptReportBindingSource.DataSource = lstReceipt;

                Center center = new Center();
                center = (new BLLCenter()).Get();

                ReportParameter[] param = new ReportParameter[]
                {
                new ReportParameter("courseName",lstReceipt[0].CourseID),
                new ReportParameter("centerName",center.CenterName),
                new ReportParameter("phoneNumber",center.PhoneNumber),
                new ReportParameter("email",center.Email),
                new ReportParameter("fax",center.Fax),
                new ReportParameter("website",center.Website),
                new ReportParameter("address",center.Address),

                new ReportParameter("printDate",DateTime.Now.ToShortDateString()),
                new ReportParameter("payment",string.Format("{0:c0}",register.Payment)),
                new ReportParameter("debt",string.Format("{0:c0}",register.Debt)),
                new ReportParameter("tuition",string.Format("{0:c0}",register.Total)),
                new ReportParameter("employeeName",employee.EmployeeName),
                new ReportParameter("studentID",student.StudentID),
                new ReportParameter("studentName",student.StudentName)
                };
                reportViewer1.LocalReport.SetParameters(param);
            }
            catch (Exception)
            {

            }
            this.reportViewer1.RefreshReport();
        }
    }
}
