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
    public partial class FrmStudent : Form
    {
        private BindingSource bdStudent;
        private List<Student> lstStudent;

        public FrmStudent()
        {
            InitializeComponent();
            bdStudent = new BindingSource();
            lstStudent = new List<Student>();
        }

        private void FrmStudent_Load(object sender, EventArgs e)
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


            cmbSearchToolStripComboBox.SelectedIndex = 0;
        }

        private void txtSearchToolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            string TextSearch = txtSearchToolStripTextBox.Text;
            int indexSearch = cmbSearchToolStripComboBox.SelectedIndex;

            if (indexSearch == 0)
                bdStudent.DataSource = lstStudent
                    .Where(p => p.StudentID.Contains(TextSearch))
                    .Select(p => p)
                    .ToList<Student>();
            else if (indexSearch == 1)
                bdStudent.DataSource = lstStudent
                        .Where(p => p.StudentName.Contains(TextSearch))
                        .Select(p => p)
                        .ToList<Student>();
            else if (indexSearch == 2)
                bdStudent.DataSource = lstStudent
                        .Where(p => p.PhoneNumber.Contains(TextSearch))
                        .Select(p => p)
                        .ToList<Student>();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            (new FrmNewStudent()).ShowDialog();
            notRegisterToolStripButton_Click(null, null);
        }

        private void editToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dgvStudent.CurrentCell.RowIndex;
                string StudentID = (string)dgvStudent.Rows[index].Cells["StudentID"].Value;
                Program.StudentID = StudentID;

                (new FrmEditStudent()).ShowDialog();

                Student student = (new BLLStudent()).Get(StudentID);
                if (student.Status == false)
                {
                    lstStudent = (new BLLStudent()).GetNotRegister();
                    bdStudent.DataSource = lstStudent;
                }
                else
                    RefeshDisplay();
            }
            catch (Exception)
            {
            }
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {

            try
            {
                int index = dgvStudent.CurrentCell.RowIndex;
                string StudentID = (string)dgvStudent.Rows[index].Cells["StudentID"].Value;
                string StudentName = (string)dgvStudent.Rows[index].Cells["StudentName"].Value;

                if (MessageBox.Show("Bạn muốn xóa học viên này?", "Xác nhận",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;

                Student student = new Student();
                student.StudentID = StudentID;

                (new BLLStudent()).Delete(student.StudentID);

                MessageBox.Show("Đã xóa xong.", "Thông báo",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (student.Status == false)
                {
                    lstStudent = (new BLLStudent()).GetNotRegister();
                    bdStudent.DataSource = lstStudent;
                }
                else
                    RefeshDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa học viên này.\n" + ex.Message, "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
        }

        private void stateToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                Student student = new Student();

                int index = dgvStudent.CurrentCell.RowIndex;

                string StudentID = (string)dgvStudent.Rows[index].Cells["StudentID"].Value;

                student = (new BLLStudent()).Get(StudentID);

                DialogResult result = new DialogResult();

                if (student.Status == true)
                {
                    result = MessageBox.Show("Trạng thái hiện tại đang được kích hoạt. Bạn có muốn thay đổi?",
                  "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                else
                    result = MessageBox.Show("Trạng thái hiện tại chưa được kích hoạt. Bạn có muốn thay đổi",
                 "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    student.Status = !student.Status;
                    (new BLLStudent()).Update(student);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể thay đổi trạng thái cho học viên này. Vui lòng kiểm tra lại thông tin đã nhập.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void detailsToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {

                int index = dgvStudent.CurrentCell.RowIndex;
                Program.StudentID = (string)dgvStudent.Rows[index].Cells["StudentID"].Value;
                (new FrmDetailsStudent()).ShowDialog();
            }
            catch (Exception)
            {
            }
        }

        private void RefeshDisplay()
        {
            try
            {
                string CourseID = treCourse.SelectedNode.Tag.ToString();

                // is level
                Level level = (new BLLLevel()).Get(CourseID);
                if (level != null) return;

                lstStudent = (new BLLStudent()).GetByCourse(CourseID);
                bdStudent.DataSource = lstStudent;
            }
            catch (Exception)
            {
            }
        }

        private void treCourse_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string CourseID = treCourse.SelectedNode.Tag.ToString();

                // is level
                Level level = (new BLLLevel()).Get(CourseID);
                if (level != null) return;

                lstStudent = (new BLLStudent()).GetByCourse(CourseID);
                bdStudent.DataSource = lstStudent;
            }
            catch (Exception)
            {
            }
        }

        private void notRegisterToolStripButton_Click(object sender, EventArgs e)
        {
            lstStudent = (new BLLStudent()).GetNotRegister();
            bdStudent.DataSource = lstStudent;
        }

        private void dgvStudent_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int index = dgvStudent.CurrentCell.RowIndex;
                string StudentID = (string)dgvStudent.Rows[index].Cells["StudentID"].Value;
                Program.StudentID = StudentID;

                (new FrmDetailsStudent()).ShowDialog();


                Student student = (new BLLStudent()).Get(StudentID);
                if (student.Status == false)
                {
                    lstStudent = (new BLLStudent()).GetNotRegister();
                    bdStudent.DataSource = lstStudent;
                }
                else
                    RefeshDisplay();
            }
            catch (Exception)
            {
            }
        }
    }
}
