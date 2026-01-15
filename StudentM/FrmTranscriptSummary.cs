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
    public partial class FrmTranscriptSummary : Form
    {
        private BindingSource bdTranscriptSummary;
        private List<TranscriptSummary> lstTranscriptSummary;
        public FrmTranscriptSummary()
        {
            InitializeComponent();
            bdTranscriptSummary = new BindingSource();
            lstTranscriptSummary = new List<TranscriptSummary>();
        }
        private void FrmTranscriptSummary_Load(object sender, EventArgs e)
        {
            List<Level> lstLevel = new List<Level>();
            lstLevel = (new BLLLevel()).GetAll();


            List<Course> lstCourse = new List<Course>();
            foreach (Level level in lstLevel)
            {
                TreeNode treeNode = new TreeNode(level.LevelName);
                treeNode.Tag = level.LevelID;
                lstCourse = (new BLLCourse()).GetByLevel(level.LevelID);
                foreach (Course course in lstCourse)
                {
                    TreeNode treeNodeChild =
                        new TreeNode(course.CourseName);

                    treeNode.Nodes.Add(treeNodeChild);

                    treeNodeChild.Tag = course.CourseID;
                }
                treCourse.Nodes.Add(treeNode);
            }

            // binding data
            dgvTranscript.DataSource = bdTranscriptSummary;
        }

        private void treCourse_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string CourseID = treCourse.SelectedNode.Tag.ToString();

                // is level
                Level level = (new BLLLevel()).Get(CourseID);
                if (level != null) return;

                lstTranscriptSummary = (new BLLReport()).Transcript(CourseID);
                bdTranscriptSummary.DataSource = lstTranscriptSummary;
            }
            catch (Exception)
            {
            }
        }

        private void reportToolStripButton_Click(object sender, EventArgs e)
        {
            (new Report.FrmTranscriptReport(lstTranscriptSummary)).ShowDialog();
        }
    }
}
