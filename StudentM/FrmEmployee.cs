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
    public partial class FrmEmployee : Form
    {
        private BindingSource bdEmployee;
        private List<Employee> lstEmployee;
        public FrmEmployee()
        {
            InitializeComponent();
            bdEmployee = new BindingSource();
            lstEmployee = new List<Employee>();
        }

        /// <summary>
        /// Click vào để gọi Form thêm giáo viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            (new FrmNewEmployee()).ShowDialog();
            string MajorID = treMajor.SelectedNode.Tag.ToString();

            //Cập nhật hiển thị
            bdEmployee.DataSource = (new BLLEmployee()).GetByMajor(MajorID);
        }

        /// <summary>
        /// Click vào để gọi form chỉnh sữa nhân viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Gán mã nhân viên hiện tại cho biến static
                Program.EmployeeID = (string)dgvEmployee.Rows[dgvEmployee.CurrentCell.RowIndex].Cells["EmployeeID"].Value;

                (new FrmEditEmployee()).ShowDialog();
                string MajorID = treMajor.SelectedNode.Tag.ToString();

                // Cập nhật hiện thị
                bdEmployee.DataSource = (new BLLEmployee()).GetByMajor(MajorID);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Load form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmEmployee_Load(object sender, EventArgs e)
        {
            // Lấy tất cả chuyên ngành đổ vào TreeView
            List<Major> lstMajor = new List<Major>();
            lstMajor = (new BLLMajor()).GetAll();
            foreach (Major major in lstMajor)
            {
                TreeNode treeNode = new TreeNode(major.MajorName);
                treeNode.Tag = major.MajorID;

                treMajor.Nodes.Add(treeNode);
            }
            // Đổ dữ liệu len DataGirdView
            dgvEmployee.DataSource = bdEmployee;

            // Search theo mã
            cmbSearchToolStripComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Click vào để xóa nhân viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy mã nhân viên hiện tại
                string EmployeeID = (string)dgvEmployee.Rows[dgvEmployee.CurrentCell.RowIndex].Cells["EmployeeID"].Value;

                if (MessageBox.Show("Xóa nhân viên này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                if(EmployeeID=="Admin")
                {
                    MessageBox.Show("Không thể xóa nhân viên này.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Xóa Account và nhân viên
                (new BLLAccount()).Delete(EmployeeID);
                (new BLLEmployee()).Delete(EmployeeID);

                MessageBox.Show("Xóa thành công.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật hiển thị
                string MajorID = treMajor.SelectedNode.Tag.ToString();
                bdEmployee.DataSource = (new BLLEmployee()).GetByMajor(MajorID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa nhân viên này.\n" + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tìm kiếm nhân viên
        ///     1. Theo mã
        ///     2. Theo tên
        ///     3. Theo số điện thoại
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearchToolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int index = cmbSearchToolStripComboBox.SelectedIndex;

                string TextSearch = txtSearchToolStripTextBox.Text;

                if (index == 0)
                    bdEmployee.DataSource = lstEmployee
                        .Where(t => t.EmployeeID.Contains(TextSearch))
                        .Select(t => t)
                        .ToList<Employee>();
                else if (index == 1)
                    bdEmployee.DataSource = lstEmployee
                        .Where(t => t.EmployeeName.Contains(TextSearch))
                        .Select(t => t)
                        .ToList<Employee>();
                else if (index == 2)
                    bdEmployee.DataSource = lstEmployee
                        .Where(t => t.PhoneNumber.Contains(TextSearch))
                        .Select(t => t)
                        .ToList<Employee>();

                //bdEmployee.DataSource = lstEmployee;
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// doubleClick để hiện thị nhân viên theo chuyên ngành
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treMajor_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string MajorID = ((TreeView)sender).SelectedNode.Tag.ToString();
                lstEmployee = (new BLLEmployee()).GetByMajor(MajorID);
                bdEmployee.DataSource = lstEmployee;
            }
            catch (Exception)
            {
            }
        }
    }
}
