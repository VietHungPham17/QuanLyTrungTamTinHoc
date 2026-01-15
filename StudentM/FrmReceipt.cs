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
    public partial class FrmReceipt : Form
    {
        List<Receipt> lstReceipt;
        BindingSource bdReceipt;
        public FrmReceipt()
        {
            InitializeComponent();
            lstReceipt = new List<Receipt>();
            bdReceipt = new BindingSource();
        }

        private void FrmReceipt_Load(object sender, EventArgs e)
        {
            // Đăng nhập bằng quyền Admin mới có thể sửa và xóa hóa đơn
            if ((new BLLEmployee()).Get(Program.Username).MajorID != "MJO00000")
            {
                deleteToolStripButton.Enabled = false;
                editToolStripButton.Enabled = false;
            }
            string StudentID = Program.StudentID;
            string CourseID = Program.CourseID;

            Program.CourseID = string.Empty;
            Program.StudentID = string.Empty;

            EmployeeID.DataSource = (new BLLEmployee()).GetAll();
            EmployeeID.DisplayMember = "EmployeeName";
            EmployeeID.ValueMember = "EmployeeID";

            Course.DataSource = (new BLLCourse()).GetAll();
            Course.DisplayMember = "CourseName";
            Course.ValueMember = "CourseID";

            //Receipt receipt = new Receipt();
            lstReceipt = (new BLLReceipt()).Get(StudentID, CourseID);

            // Cập nhật hiển thị
            bdReceipt.DataSource = lstReceipt;
            dgvReceipt.DataSource = bdReceipt;
        }

        /// <summary>
           /// Xóa hóa đơn
           /// </summary>
           /// <param name="sender"></param>
           /// <param name="e"></param>
        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa hóa đơn này?", "Thông báo",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                int indexReceipt = dgvReceipt.CurrentCell.RowIndex;
                string ReceiptID = (string)dgvReceipt.Rows[indexReceipt].Cells["ReceiptID"].Value;
                decimal Payment = (decimal)dgvReceipt.Rows[indexReceipt].Cells["Payment"].Value;

                (new BLLReceipt()).Delete(ReceiptID);

                // Message
                MessageBox.Show("Đã xóa xong.", "Thông báo",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);

                int indexRegister = dgvReceipt.CurrentCell.RowIndex;
                string StudentID = (string)dgvReceipt.Rows[indexRegister].Cells["StudentID"].Value;
                string CourseID = (string)dgvReceipt.Rows[indexRegister].Cells["CourseID"].Value;

                // Cập nhật hiện thị
                bdReceipt.DataSource = (new BLLReceipt()).Get(StudentID, CourseID);

                // Cập nhật lại thông tin đăng ký
                Register register = new Register();
                register = (new BLLRegister()).Get(StudentID, CourseID);
                register.Payment -= Payment;
                register.Debt += Payment;                
                (new BLLRegister()).Update(register);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa không thành công.\n" + ex.Message, "Thông báo",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                int indexReceipt = dgvReceipt.CurrentCell.RowIndex;
                string ReceiptID = (string)dgvReceipt.Rows[indexReceipt].Cells["ReceiptID"].Value;
                (new FrmEditReceipt(ReceiptID)).ShowDialog();

                // Cập nhật hiện thị
                int indexRegister = dgvReceipt.CurrentCell.RowIndex;
                string StudentID = (string)dgvReceipt.Rows[indexRegister].Cells["StudentID"].Value;
                string CourseID = (string)dgvReceipt.Rows[indexRegister].Cells["CourseID"].Value;
                bdReceipt.DataSource = (new BLLReceipt()).Get(StudentID, CourseID);
            }
            catch (Exception)
            {
            }
        }

        private void quitToolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
