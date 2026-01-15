using BLLayer;
using DTLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTrungTamTinHoc
{
    /// <summary>
    /// Chỉnh sửa nhân viên
    /// </summary>
    public partial class FrmEditEmployee : Form
    {
        public FrmEditEmployee()
        {
            InitializeComponent();
        }

        private void FrmEditEmployee_Load(object sender, EventArgs e)
        {
            nudSalary.ThousandsSeparator = true;

            cmbMajor.DataSource = (new BLLMajor()).GetAll();
            cmbMajor.DisplayMember = "MajorName";
            cmbMajor.ValueMember = "MajorID";

            // Custom Fotmat date timepicker
            dtpBirthDay.CustomFormat = "dd/MM/yyyy";

            Employee employee = new Employee();
            // Lấy mã nhân viên từ biến tĩnh
            string EmployeeID = Program.EmployeeID;
            Program.EmployeeID = string.Empty;  // cho biến tĩnh bằng Empty

            employee = (new BLLEmployee()).Get(EmployeeID);

            if (employee == null) return;

            txtTrainerID.Text = employee.EmployeeID;
            txtEmployeeName.Text = employee.EmployeeName;
            dtpBirthDay.Value = employee.BirthDay;
            cmbGender.Text = employee.Gender;
            txtPhoneNumber.Text = employee.PhoneNumber;
            txtEmail.Text = employee.Email;
            cmbAddress.Text = employee.Address;
            cmbStaying.Text = employee.Staying;
            cmbEducation.Text = employee.Education;
            cmbUniversity.Text = employee.University;
            cmbMajor.SelectedValue = employee.MajorID;
            nudSalary.Value = employee.Salary;

            try
            {
                // Đưa hình ảnh lên pictureBox
                byte[] image = employee.Avatar;
                MemoryStream stream = new MemoryStream(image);

                picAvatar.Image = Image.FromStream(stream);
            }
            catch (Exception)
            {
            }
            //chkState.Checked = student.State;
        }
        /// <summary>
        /// Chỉnh sửa
        /// </summary>
        /// <returns></returns>
        private bool Edit()
        {
            try
            {
                Employee employee = new Employee();

                employee.EmployeeID = txtTrainerID.Text;

                employee = (new BLLEmployee()).Get(employee.EmployeeID);

                employee.EmployeeName = txtEmployeeName.Text;
                employee.Gender = cmbGender.Text;
                employee.BirthDay = dtpBirthDay.Value;
                employee.PhoneNumber = txtPhoneNumber.Text;
                employee.Email = txtEmail.Text;
                employee.Address = cmbAddress.Text;
                employee.Staying = cmbStaying.Text;
                employee.Education = cmbEducation.Text;
                employee.University = cmbUniversity.Text;

                employee.Salary = nudSalary.Value;
                try
                {
                    employee.MajorID = cmbMajor.SelectedValue.ToString();
                }
                catch (Exception)
                {

                    MessageBox.Show("Chuyên ngành không hợp lệ.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbMajor.Focus();
                    return false;
                }

                try
                {
                    // Lưu hình ảnh từ pictureBox về cơ sở dữ liệu
                    MemoryStream stream = new MemoryStream();
                    picAvatar.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    employee.Avatar = stream.ToArray();
                }
                catch (Exception)
                {
                }


                if (string.IsNullOrEmpty(employee.EmployeeID) ||
                    string.IsNullOrEmpty(employee.EmployeeName))
                {
                    MessageBox.Show("Bạn chưa nhập mã hoặc tên nhân viên.",
                  "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmployeeName.Focus();
                    return false;
                }

                (new BLLEmployee()).Update(employee);
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể chỉnh sửa nhân viên này. Vui lòng kiểm tra lại thông tin đã nhập.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Chọn hình ảnh từ đĩa khi click vào pictureBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picAvatar_Click(object sender, EventArgs e)
        {
            // 
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string FileName = ofd.FileName;

                if (string.IsNullOrEmpty(FileName)) return;

                try
                {
                    // Hiển thị hình ảnh trên pictureBox
                    picAvatar.Image = Image.FromFile(FileName);
                }
                catch (Exception)
                {
                    MessageBox.Show("Tệp tin không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSaveAndQuit_Click(object sender, EventArgs e)
        {
            if (Edit() == true) this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
