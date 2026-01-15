using BLLayer;
using DTLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTrungTamTinHoc
{
    public partial class FrmTuitionSummary : Form
    {
        private BindingSource bdTuitionSummary;
        private List<TuitionSummary> lstTuitionSummary;
        public FrmTuitionSummary()
        {
            InitializeComponent();
            bdTuitionSummary = new BindingSource();
            lstTuitionSummary = new List<TuitionSummary>();
        }

        private void FrmTuitionSummary_Load(object sender, EventArgs e)
        {
            List<Level> lstLevel = new List<Level>();
            lstLevel = (new BLLLevel()).GetAll();


            List<Course> lstCourse = new List<Course>();
            foreach (Level level in lstLevel)
            {
                TreeNode treeNode = new TreeNode(level.LevelName);
                treeNode.Tag = level.LevelID;
                treCourse.Nodes.Add(treeNode);
            }

            // binding data
            dgvTuitionSummary.DataSource = bdTuitionSummary;
        }

        private void treCourse_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string LevelID = treCourse.SelectedNode.Tag.ToString();

                lstTuitionSummary = (new BLLReport()).TuitionSummary(LevelID);
                bdTuitionSummary.DataSource = lstTuitionSummary;
            }
            catch (Exception)
            {
            }
        }

        private void reportToolStripButton_Click(object sender, EventArgs e)
        {
            (new Report.FrmTuitionSummaryReport(lstTuitionSummary)).ShowDialog();
        }
    }
}
