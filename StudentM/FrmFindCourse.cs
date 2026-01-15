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
    /// <summary>
    /// Tìm khóa học
    /// </summary>
    public partial class FrmFindCourse : Form
    {
        private BindingSource bdCourse;
        private List<Course> lstCourse;
        public FrmFindCourse()
        {
            InitializeComponent();
            bdCourse = new BindingSource();
            lstCourse = new List<Course>();
        }

        private void FrmFindCourse_Load(object sender, EventArgs e)
        {
            // Lấy tất cả khóa học
            lstCourse = (new BLLCourse()).GetAll();
            bdCourse.DataSource = lstCourse;
            dgvCourse.DataSource = bdCourse;

            // Search theo mã
            cmbSearchToolStripComboBox.SelectedIndex = 0;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }      

        /// <summary>
        /// Lấy mã khóa học khi doubleClick vào
        /// </summary
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCourse_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            selectToolStripButton_Click(null, null);
        }

        /// <summary>
        /// Click vào để gọi form sữa khóa học
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                Program.CourseID = (string)dgvCourse.Rows[dgvCourse.CurrentCell.RowIndex].Cells["CourseID"].Value;
                (new FrmEditCourse()).ShowDialog();

                // Cập nhật hiển thị
                lstCourse = (new BLLCourse()).GetAll();
                bdCourse.DataSource = lstCourse;
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Click vào để xóa khóa học
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa khóa học này?", "Thông báo", MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question) == DialogResult.No) return;
            try
            {
                string CourseID = (string)dgvCourse.Rows[dgvCourse.CurrentCell.RowIndex].Cells["CourseID"].Value;

                // Xóa
                (new BLLCourse()).Delete(CourseID);

                MessageBox.Show("Đã xóa xong.", "Thông báo", MessageBoxButtons.OK,
                 MessageBoxIcon.Information);

                // Cập nhật hiển thị
                lstCourse = (new BLLCourse()).GetAll();
                bdCourse.DataSource = lstCourse;
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa không thành công.", "Thông báo", MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
            }
        }

        private void quitToolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Click vào để chọn khóa học
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dgvCourse.CurrentCell.RowIndex;

                string CourseID = (string)dgvCourse.Rows[index].Cells["CourseID"].Value;
                Program.CourseID = CourseID;
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn chưa chọn khóa học", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}