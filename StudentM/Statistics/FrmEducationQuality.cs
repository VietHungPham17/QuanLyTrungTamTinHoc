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
    public partial class FrmEducationQuality : Form
    {
        public FrmEducationQuality()
        {
            InitializeComponent();
        }

        private void FrmEducationQuality_Load(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime FromDate = dtpFromDate.Value;
                DateTime ToDate = dtpToDate.Value;

                dgvEducationQuality.DataSource =
                    (new BLLStatistics()).EducationQuality(FromDate, ToDate);


                int numStudent = 0;
                int numDone = 0;
                int numFail = 0;
                float numScore = 0;

                foreach (DataGridViewRow row in dgvEducationQuality.Rows)
                {
                    numStudent += (int)row.Cells["Number"].Value;
                    numDone += (int)row.Cells["Done"].Value;
                    numFail += (int)row.Cells["Fail"].Value;
                    numScore += (float)row.Cells["ScoreAVG"].Value;
                }
                lblNumStudent.Text = numStudent.ToString();
                lblDone.Text = numDone.ToString();
                lblFail.Text = numFail.ToString();
                lblScoreAVG.Text = string.Format("{0:00.00}", numScore/dgvEducationQuality.Rows.Count);
            }
            catch (Exception)
            {
            }
        }
    }
}
