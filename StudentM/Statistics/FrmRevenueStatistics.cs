using BLLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTrungTamTinHoc.Statistics
{
    public partial class FrmRevenueStatistics : Form
    {
        public FrmRevenueStatistics()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime FromDate = dtpFromDate.Value;
                DateTime ToDate = dtpToDate.Value;
                dgvRevenue.DataSource = (new BLLStatistics()).Revenue(FromDate, ToDate);

                int numStudent = 0;
                decimal numTuition = 0;
                decimal numTotal = 0;
                float numExemption = 0;

                foreach (DataGridViewRow row in dgvRevenue.Rows)
                {
                    numStudent = numStudent + (int)row.Cells["Number"].Value;
                    numTuition = numTuition + (decimal)row.Cells["Tuition"].Value;
                    numTotal = numTotal + (decimal)row.Cells["Total"].Value;
                    numExemption = numExemption + (float)row.Cells["Exemption"].Value;
                }
                lblNumStudent.Text = numStudent.ToString();
                lblNumTuition.Text = string.Format("{0:c0}", numTuition);
                lblNumTotal.Text = string.Format("{0:c0}", numTotal);
                lblNumExemption.Text = string.Format("{0}" + "%", numExemption / dgvRevenue.Rows.Count);
            }
            catch (Exception)
            {
            }
        }

        private void FrmRevenueStatistics_Load(object sender, EventArgs e)
        {

        }
    }
}
