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
    public partial class FrmTuitionDebt : Form
    {

        private BindingSource bdStudent;
        private List<TuitionDebt> lstTuitionDebt;
        public FrmTuitionDebt()
        {
            InitializeComponent();
            bdStudent = new BindingSource();
            lstTuitionDebt = new List<TuitionDebt>();
        }

        private void FrmTuitionDebt_Load(object sender, EventArgs e)
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
            dgvStudent.DataSource = bdStudent;
        }

        private void treCourse_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string CourseID = treCourse.SelectedNode.Tag.ToString();

                // is level
                Level level = (new BLLLevel()).Get(CourseID);
                if (level != null) return;

                lstTuitionDebt = (new BLLReport()).TuitionDebt(CourseID);
                bdStudent.DataSource = lstTuitionDebt;
            }
            catch (Exception)
            {
            }
        }

        private void reportToolStripButton_Click(object sender, EventArgs e)
        {
            (new Report.FrmTuitionDebtReport(lstTuitionDebt)).ShowDialog();
        }
    }
}
