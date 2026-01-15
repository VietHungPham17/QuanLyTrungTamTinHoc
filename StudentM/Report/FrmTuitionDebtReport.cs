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
    public partial class FrmTuitionDebtReport : Form
    {
        private List<TuitionDebt> lstTuitionDebt;
        public FrmTuitionDebtReport(List<TuitionDebt> lstTuitionDebt)
        {
            InitializeComponent();
            this.lstTuitionDebt = lstTuitionDebt;
        }

        private void FrmReportTuitionDebt_Load(object sender, EventArgs e)
        {
            try
            {
                decimal debt = lstTuitionDebt.Sum(t => t.Debt);

                
                Center center = new Center();
                center = (new BLLCenter()).Get();
                string employeeName = (new BLLEmployee()).Get(Program.Username).EmployeeName;
                ReportParameter[] param = new ReportParameter[]
                {
                    new ReportParameter("centerName",center.CenterName),
                    new ReportParameter("phoneNumber",center.PhoneNumber),
                    new ReportParameter("email",center.Email),
                    new ReportParameter("fax",center.Fax),
                    new ReportParameter("website",center.Website),
                    new ReportParameter("address",center.Address),

                    new ReportParameter("printDate",DateTime.Now.ToShortDateString()),
                    new ReportParameter("employeeName",employeeName),

                    new ReportParameter("debt",string.Format("{0:C0}",debt))
                };
                reportViewer1.LocalReport.SetParameters(param);
            }
            catch (Exception)
            {

            }

            try
            {
                TuitionDebtBindingSource.DataSource = lstTuitionDebt;
                this.reportViewer1.RefreshReport();
            }
            catch (Exception)
            {
            }
        }
    }
}
