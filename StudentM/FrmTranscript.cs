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
    public partial class FrmTranscript : Form
    {
        private BindingSource bdTranscript;
        private List<Transcript> lstTranscript;

        public FrmTranscript()
        {
            InitializeComponent();
            bdTranscript = new BindingSource();
            lstTranscript = new List<Transcript>();
        }

        private void FrmTranscript_Load(object sender, EventArgs e)
        {
            StudentName.DataSource = (new BLLStudent()).GetAll();
            StudentName.DisplayMember = "StudentName";
            StudentName.ValueMember = "StudentID";

            EmployeeID.DataSource = (new BLLEmployee()).GetAll();
            EmployeeID.DisplayMember = "EmployeeName";
            EmployeeID.ValueMember = "EmployeeID";

            List<Level> lstLevel = new List<Level>();
            lstLevel = (new BLLLevel()).GetAll();


            List<Course> lstCourse = new List<Course>();
            foreach (Level level in lstLevel)
            {
                TreeNode treeNode = new TreeNode(level.LevelName);
                treeNode.Tag = level.LevelID;
                lstCourse = (new BLLCourse()).GetByLevel(level.LevelID, true);
                foreach (Course course in lstCourse)
                {
                    TreeNode treeNodeChild =
                        new TreeNode(course.CourseName);

                    treeNode.Nodes.Add(treeNodeChild);

                    treeNodeChild.Tag = course.CourseID;
                }
                treCourse.Nodes.Add(treeNode);
            }

            dgvTranscript.DataSource = bdTranscript;

        }

        private void treCourse_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                TreeNode treeNode = treCourse.SelectedNode;

                string CourseID = treeNode.Tag.ToString();
                string CourseName = treeNode.Text;

                Level level = (new BLLLevel()).Get(CourseID);
                if (level != null) return;

                courseToolStripTextBox.Text = CourseID + " / " + CourseName;

                lstTranscript = (new BLLTranscript()).Get(CourseID);

                dateToolStripComboBox.Items.Clear();
                foreach (Transcript transcript in lstTranscript)
                {
                    string date = transcript.TestDate.ToString();
                    if (dateToolStripComboBox.Items.Contains(date) == false)
                        dateToolStripComboBox.Items.Add(date);
                }
                dateToolStripComboBox.SelectedIndex = dateToolStripComboBox.Items.Count - 1;

                // refresh dgv if cbo is null
                if (dateToolStripComboBox.Items.Count == 0)
                {
                    lstTranscript = new List<Transcript>();
                    bdTranscript.DataSource = lstTranscript;
                }
            }
            catch (Exception)
            {
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                string[] temp = courseToolStripTextBox.Text.Split('/');
                string CourseID = temp[0].Trim();
                if (string.IsNullOrEmpty(CourseID))
                {
                    MessageBox.Show("Chọn khóa học trước.", "Thông báo",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Bạn muốn tạo kỳ thi?", "Thông báo",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

                List<Student> lstStudent = new List<Student>();

                lstStudent = (new BLLStudent()).GetByCourse(CourseID);

                string DateString = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
                DateTime TestDate = DateTime.Parse(DateString);

                foreach (Student student in lstStudent)
                {
                    Transcript transcript = new Transcript();
                    transcript.TestDate = TestDate;
                    transcript.StudentID = student.StudentID;
                    transcript.CourseID = CourseID;
                    transcript.Score = 0;
                    transcript.Note = "";
                    transcript.Status = false;

                    (new BLLTranscript()).Insert(transcript);
                }

                MessageBox.Show("Tạo kỳ thì thành công.", "Thông báo",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);

                lstTranscript = (new BLLTranscript()).Get(CourseID);
                dateToolStripComboBox.Items.Clear();
                foreach (Transcript transcript in lstTranscript)
                {
                    DateTime date = transcript.TestDate;

                    if (dateToolStripComboBox.Items.Contains(date) == false)
                        dateToolStripComboBox.Items.Add(date);
                }
                dateToolStripComboBox.SelectedIndex = dateToolStripComboBox.Items.Count - 1;
            }
            catch (Exception)
            {
                MessageBox.Show("Tạo kỳ thì không thành công.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dateToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            DateTime date = new DateTime();

            date = DateTime.Parse(dateToolStripComboBox.SelectedItem.ToString());
            string[] temp = courseToolStripTextBox.Text.Split('/');
            string CourseID = temp[0].Trim();

            //StudentName.DataSource = (new BLLStudent()).GetAll();
            //StudentName.DisplayMember = "StudentName";
            //StudentName.ValueMember = "StudentID";

            //EmployeeID.DataSource = (new BLLEmployee()).GetAll();
            //EmployeeID.DisplayMember = "EmployeeName";
            //EmployeeID.ValueMember = "EmployeeID";

            lstTranscript = (new BLLTranscript()).Get(date, CourseID);
            bdTranscript.DataSource = lstTranscript;
            // text button
            if (lstTranscript[0].Status == true)
            {
                statusToolStripButton.Text = "Mở điểm";
                if ((new BLLEmployee()).Get(Program.Username).MajorID != "MJO00000")
                {
                    statusToolStripButton.Enabled = false;
                }
            }
            else
            {
                statusToolStripButton.Text = "Khóa điểm";
                statusToolStripButton.Enabled = true;
            }
        }

        private void dgvTranscript_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int index = dgvTranscript.CurrentCell.RowIndex;

                StudentName.DataSource = (new BLLStudent()).GetAll();
                StudentName.DisplayMember = "StudentName";
                StudentName.ValueMember = "StudentID";

                string StudentID = (string)dgvTranscript.Rows[index].Cells["StudentID"].Value;
                string CourseID = (string)dgvTranscript.Rows[index].Cells["CourseID"].Value;
                DateTime TestDate = (DateTime)dgvTranscript.Rows[index].Cells["TestDate"].Value;

                Program.StudentID = StudentID;
                Program.CourseID = CourseID;
                Program.TestDate = TestDate;


                (new FrmNewTranscript()).ShowDialog();

                EmployeeID.DataSource = (new BLLEmployee()).GetAll();
                EmployeeID.DisplayMember = "EmployeeName";
                EmployeeID.ValueMember = "EmployeeID";

                lstTranscript = (new BLLTranscript()).Get(TestDate, CourseID);
                bdTranscript.DataSource = lstTranscript;
            }
            catch (Exception)
            {
            }
        }

        private void statusToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime TestDate = new DateTime();
                TestDate = DateTime.Parse(dateToolStripComboBox.SelectedItem.ToString());

                string[] temp = courseToolStripTextBox.Text.Split('/');
                string CourseID = temp[0].Trim();

                List<Student> lstStudent = new List<Student>();
                lstStudent = (new BLLStudent()).GetByCourse(CourseID);

                bool status = true;

                if (lstTranscript[0].Status == true)
                {
                    status = false;

                    if (MessageBox.Show("Bạn có muốn mở khóa điểm?",
                "Thông báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.No) return;

                }
                else
                {
                    status = true;

                    if (MessageBox.Show("Bạn có muốn khóa điểm?",
               "Thông báo", MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning) == DialogResult.No) return;
                }

                foreach (Student student in lstStudent)
                {
                    Transcript transcript = new Transcript();
                    transcript = (new BLLTranscript()).Get(TestDate, CourseID, student.StudentID);
                    transcript.Status = status;

                    (new BLLTranscript()).Update(transcript);


                }


                if (statusToolStripButton.Text == "Mở điểm")
                {
                    MessageBox.Show("Đã mở xong.",
                  "Thông báo", MessageBoxButtons.OK,
                  MessageBoxIcon.Information);

                    statusToolStripButton.Text = "Khóa điểm";
                }
                else
                {
                    MessageBox.Show("Đã khóa xong.",
                  "Thông báo", MessageBoxButtons.OK,
                  MessageBoxIcon.Information);

                    statusToolStripButton.Text = "Mở điểm";

                    if ((new BLLEmployee()).Get(Program.Username).MajorID != "MJO00000")
                    {
                        statusToolStripButton.Enabled = false;
                    }
                }


                lstTranscript = (new BLLTranscript()).Get(TestDate, CourseID);
                bdTranscript.DataSource = lstTranscript;
            }
            catch (Exception)
            {
                MessageBox.Show("Thao tác không thành công.",
                   "Thông báo", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                string[] temp = courseToolStripTextBox.Text.Split('/');
                string CourseID = temp[0].Trim();
                if (string.IsNullOrEmpty(CourseID))
                {
                    MessageBox.Show("Chọn khóa học trước.", "Thông báo",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Bạn muốn xóa kỳ thi?", "Thông báo",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

                List<Student> lstStudent = new List<Student>();

                lstStudent = (new BLLStudent()).GetByCourse(CourseID);

                DateTime TestDate = new DateTime();
                TestDate = DateTime.Parse(dateToolStripComboBox.SelectedItem.ToString());

                if((new BLLTranscript()).Get(TestDate, CourseID, lstStudent[0].StudentID).Status==true)
                {
                    MessageBox.Show("Kỳ thi này đã khóa. Không thể xóa.", "Thông báo",
                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                foreach (Student student in lstStudent)
                {
                    (new BLLTranscript()).Delete(TestDate, CourseID, student.StudentID);
                }

                MessageBox.Show("Xóa kỳ thì thành công.", "Thông báo",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);

                lstTranscript = (new BLLTranscript()).Get(CourseID);
                dateToolStripComboBox.Items.Clear();
                foreach (Transcript transcript in lstTranscript)
                {
                    DateTime date = transcript.TestDate;

                    if (dateToolStripComboBox.Items.Contains(date) == false)
                        dateToolStripComboBox.Items.Add(date);
                }
                dateToolStripComboBox.SelectedIndex = dateToolStripComboBox.Items.Count - 1;
                if (dateToolStripComboBox.SelectedIndex < 0)
                {
                    lstTranscript = new List<Transcript>();
                    bdTranscript.DataSource = lstTranscript;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa kỳ thì không thành công.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
