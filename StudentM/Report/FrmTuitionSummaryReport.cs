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
    public partial class FrmTuitionSummaryReport : Form
    {
        private List<TuitionSummary> lstTuitionSummary;
        public FrmTuitionSummaryReport(List<TuitionSummary> lstTuitionSummary)
        {
            InitializeComponent();
            this.lstTuitionSummary = lstTuitionSummary;
        }

        private void FrmReportTuitionSummary_Load(object sender, EventArgs e)
        {
            try
            {
                Center center = new Center();
                center = (new BLLCenter()).Get();

                int number = lstTuitionSummary.Sum(t=>t.Number);
                decimal total = lstTuitionSummary.Sum(t => t.Tuition);

                ReportParameter[] param = new ReportParameter[]
                {
                    new ReportParameter("centerName",center.CenterName),
                    new ReportParameter("phoneNumber",center.PhoneNumber),
                    new ReportParameter("email",center.Email),
                    new ReportParameter("fax",center.Fax),
                    new ReportParameter("website",center.Website),
                    new ReportParameter("address",center.Address),

                    new ReportParameter("printDate",DateTime.Now.ToShortDateString()),
                    new ReportParameter("employeeName",(new BLLEmployee()).Get(Program.Username).EmployeeName),
                    new ReportParameter("number",number.ToString()),
                    new ReportParameter("total",string.Format("{0:C0}",total))
                };
                reportViewer1.LocalReport.SetParameters(param);

                TuitionSummaryBindingSource.DataSource = lstTuitionSummary;
                this.reportViewer1.RefreshReport();
            }
            catch (Exception)
            {

            }
        }
    }
}
