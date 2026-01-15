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
    /// Tìm học viên
    /// </summary>
    public partial class FrmFindStudent : Form
    {
        private List<Student> lstStudent;
        private BindingSource bdStudent;
        public FrmFindStudent()
        {
            InitializeComponent();
            lstStudent = new List<Student>();
            bdStudent = new BindingSource();
        }

        private void FrmFindStudent_Load(object sender, EventArgs e)
        {
            // Search theo mã
            cmbSearchToolStripComboBox.SelectedIndex = 0;

            //Load tất cả học viên lên dataGirdView
            lstStudent= (new BLLStudent()).GetAll();
            bdStudent.DataSource = lstStudent;
            dgvStudent.DataSource = bdStudent;

        }

        /// <summary>
        /// Tìm kiếm học viên
        ///     1. Theo mã
        ///     2. Theo tên
        ///     3. Theo số điện thoại
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchToolStripTextBox_TextChanged(object sender, EventArgs e)
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

        private void quitToolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Xóa học viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa học viên này?", "Xác nhận",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            try
            {
                int index = dgvStudent.CurrentCell.RowIndex;
                string StudentID = (string)dgvStudent.Rows[index].Cells["StudentID"].Value;
                string StudentName = (string)dgvStudent.Rows[index].Cells["StudentName"].Value;

                Student student = new Student();
                student.StudentID = StudentID;

                // Xóa
                (new BLLStudent()).Delete(student.StudentID);

                MessageBox.Show("Đã xóa xong.", "Thông báo",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật hiển thị
                lstStudent = (new BLLStudent()).GetAll();
                bdStudent.DataSource = lstStudent;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa học viên này.\n" + ex.Message, "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Click vào để gọi form cập nhật học viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                // gán mã học viên hiện tại vào biến static
                int index = dgvStudent.CurrentCell.RowIndex;
                Program.StudentID = (string)dgvStudent.Rows[index].Cells["StudentID"].Value;

                (new FrmEditStudent()).ShowDialog();

                // Cập nhật hiển thị
                lstStudent = (new BLLStudent()).GetAll();
                bdStudent.DataSource = lstStudent;
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// lấy mã học viên được chọn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dgvStudent.CurrentCell.RowIndex;
                Program.StudentID = (string)dgvStudent.Rows[index].Cells["StudentID"].Value;
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn chưa chọn học viên.", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Lấy mã học viên được chọn khi double click vào dataGirdView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStudent_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            selectToolStripButton_Click(null, null);
        }
    }
}

