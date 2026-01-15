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
    public partial class FrmTranscriptReport : Form
    {
        private List<TranscriptSummary> lstTranscriptSummary;
        public FrmTranscriptReport(List<TranscriptSummary> lstTranscriptSummary)
        {
            InitializeComponent();
            this.lstTranscriptSummary = lstTranscriptSummary;
        }

        private void FrmReportTranscript_Load(object sender, EventArgs e)
        {
            try
            {
                TranscriptSummaryBindingSource.DataSource = lstTranscriptSummary;

                Center center = new Center();
                center = (new BLLCenter()).Get();

                Employee employee = new Employee();
                employee = (new BLLEmployee()).Get(Program.Username);

                ReportParameter[] param = new ReportParameter[]
                {
                new ReportParameter("centerName",center.CenterName),
                new ReportParameter("phoneNumber",center.PhoneNumber),
                new ReportParameter("email",center.Email),
                new ReportParameter("fax",center.Fax),
                new ReportParameter("website",center.Website),
                new ReportParameter("address",center.Address),
                new ReportParameter("printDate",DateTime.Now.ToShortDateString()),
                new ReportParameter("courseName",lstTranscriptSummary[0].CourseName),
                new ReportParameter("employeeName",employee.EmployeeName),
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
