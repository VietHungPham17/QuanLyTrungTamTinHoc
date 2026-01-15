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
    public partial class FrmCourse : Form
    {
        private BindingSource bdCourse;
        private List<Course> lstCourse;
        public FrmCourse()
        {
            InitializeComponent();
            bdCourse = new BindingSource();
            lstCourse = new List<Course>();
        }

        private void FrmCourse_Load(object sender, EventArgs e)
        {
            // Search mặc định là mã khóa học
            searchToolStripComboBox.SelectedIndex = 0;

            // Lấy tất cả cấp độ, đổ dữ liệu vào TreeView
            List<Level> lstLevel = new List<Level>();
            lstLevel = (new BLLLevel()).GetAll();
            foreach (Level level in lstLevel)
            {
                TreeNode treeNode = new TreeNode(level.LevelName);
                treeNode.Tag = level.LevelID;

                treLevel.Nodes.Add(treeNode);
            }

            // Đổ dữ liệu lên DataGirdView dùng bindingsourse
            dgvCourse.DataSource = bdCourse;
        }
        /// <summary>
        /// Tạo khóa học mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newCourseToolStripButton_Click(object sender, EventArgs e)
        {           
            try
            {
                (new FrmNewCourse()).ShowDialog();
                // Cập nhật lại DataGirdView
                lstCourse = (new BLLCourse()).GetByLevel(treLevel.SelectedNode.Tag.ToString());
                bdCourse.DataSource = lstCourse;
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// Cập nhật khóa học
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editCourseToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy mã khóa học hiện tại gán váo biến Static để truyền dữ liệu qua form chỉnh sữa
                Program.CourseID = (string)dgvCourse.Rows[dgvCourse.CurrentCell.RowIndex].Cells["CourseID"].Value;
                (new FrmEditCourse()).ShowDialog();
                // Cập nhật lại DataGirdView
                lstCourse = (new BLLCourse()).GetByLevel(treLevel.SelectedNode.Tag.ToString());
                bdCourse.DataSource = lstCourse;
            }
            catch (Exception)
            {

            }
        }
        /// <summary>
        /// Xóa khóa học
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteCourseToolStripButton_Click(object sender, EventArgs e)
        {

            try
            {
                // Lấy mã khóa học hiện tại 
                string CourseID = (string)dgvCourse.Rows[dgvCourse.CurrentCell.RowIndex].Cells["CourseID"].Value;

                if (MessageBox.Show("Bạn muốn xóa khóa học này?", "Thông báo", MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question) == DialogResult.No) return;

                // Xóa
                (new BLLCourse()).Delete(CourseID);

                MessageBox.Show("Đã xóa xong.", "Thông báo", MessageBoxButtons.OK,
                 MessageBoxIcon.Information);

                // Cập nhật hiển thị
                bdCourse.DataSource = (new BLLCourse()).GetByLevel(treLevel.SelectedNode.Tag.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa không thành công.", "Thông báo", MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sự kiện doubleClick vào TreeView 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treLevel_DoubleClick(object sender, EventArgs e)
        {
            // EmployeeID là comboBox, để hiển thị tên nhân viên
            EmployeeID.DataSource = (new BLLEmployee()).GetAll();
            EmployeeID.DisplayMember = "EmployeeName";
            EmployeeID.ValueMember = "EmployeeID";

            // Cập nhật hiển thị
            lstCourse = (new BLLCourse()).GetByLevel(treLevel.SelectedNode.Tag.ToString());
            bdCourse.DataSource = lstCourse;

            dgvCourse_CellClick(null, null);
        }

        /// <summary>
        /// Tìm kiếm khóa học:
        ///     1. Theo mã
        ///     2. Theo tên      
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchToolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            // Lấy nội dung trong ô tìm kiếm
            string TextSearch = searchToolStripTextBox.Text;
            // Seach theo mã
            if (searchToolStripComboBox.SelectedIndex == 0)
                bdCourse.DataSource = lstCourse
                    .Where(c => c.CourseID.Contains(TextSearch))
                    .Select(c => c).ToList<Course>();
            else
            // Search theo tên
                  if (searchToolStripComboBox.SelectedIndex == 1)
                bdCourse.DataSource = lstCourse
                    .Where(c => c.CourseName.Contains(TextSearch))
                    .Select(c => c).ToList<Course>();
        }
        /// <summary>
        /// Thay đổi trạng thái:
        ///     1. Hoạt động
        ///     2. Kết thúc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void statusToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy mã khóa học hiện tại
                string CourseID = (string)dgvCourse.Rows[dgvCourse.CurrentCell.RowIndex].Cells["CourseID"].Value;

                // Lấy khóa học theo mã khóa học
                Course course = new Course();
                course = (new BLLCourse()).Get(CourseID);
                if (course == null) return;

                // Thay đổi tên button
                if (course.Status == false)
                {
                    statusToolStripButton.Text = "Kết thúc";
                }
                else
                    statusToolStripButton.Text = "Hoạt động";

                // Thay đổi trạng thái
                course.Status = !course.Status;
                (new BLLCourse()).Update(course);

                // Cập nhật hiển thị
                lstCourse = (new BLLCourse()).GetByLevel(treLevel.SelectedNode.Tag.ToString());
                bdCourse.DataSource = lstCourse;
            }
            catch (Exception)
            {

            }
        }

        private void dgvCourse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Lấy mã khóa học hiện tại
                string CourseID = (string)dgvCourse.Rows[dgvCourse.CurrentCell.RowIndex].Cells["CourseID"].Value;

                // Lấy khóa học theo mã khóa học
                Course course = new Course();
                course = (new BLLCourse()).Get(CourseID);
                if (course == null) return;

                // Thay đổi tên button
                if (course.Status == true)
                {
                    statusToolStripButton.Text = "Kết thúc";
                }
                else
                    statusToolStripButton.Text = "Hoạt động";
            }
            catch (Exception)
            {
            }
        }
    }

}