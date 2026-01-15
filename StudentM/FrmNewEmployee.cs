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
    public partial class FrmNewEmployee : Form
    {
        public FrmNewEmployee()
        {
            InitializeComponent();
        }

        private void FrmNewTrainer_Load(object sender, EventArgs e)
        {
            nudSalary.ThousandsSeparator = true;

            // Custom Fotmat date timepicker
            dtpBirthDay.CustomFormat = "dd/MM/yyyy";


            cmbMajor.DataSource = (new BLLMajor()).GetAll();
            cmbMajor.DisplayMember = "MajorName";
            cmbMajor.ValueMember = "MajorID";

            string TrainerID = (new BLLEmployee()).NextID();
            txtTrainerID.Text = TrainerID;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private bool Insert()
        {
            try
            {
                Employee employee = new Employee();

                employee.EmployeeID = txtTrainerID.Text;
                employee.EmployeeName = txtEmployeeName.Text;
                employee.Gender = cmbGender.Text;
                employee.BirthDay = dtpBirthDay.Value;
                employee.PhoneNumber = txtPhoneNumber.Text;
                employee.Email = txtEmail.Text;
                employee.Address = cmbAddress.Text;
                employee.Staying = cmbStaying.Text;
                employee.Education = cmbEducation.Text;
                employee.University = cmbUniversity.Text;
                employee.Status = true;// alwway 
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
                    MessageBox.Show("Bạn chưa nhập mã hoặc tên giáo viên.",
                  "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmployeeName.Focus();
                    return false;
                }
                // Thêm nhân viên, thêm tài khoản
                (new BLLEmployee()).Insert(employee);
                Account account = new Account();
                account.Username = employee.EmployeeID;
                account.Password = employee.EmployeeID;
                account.Status = false;
                (new BLLAccount()).Insert(account);
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể thêm giáo viên này. Vui lòng kiểm tra lại thông tin đã nhập.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void btnNewAndQuit_Click(object sender, EventArgs e)
        {
            if (Insert() == true) this.Close();
        }

        private void picAvatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string FileName = ofd.FileName;

                if (string.IsNullOrEmpty(FileName)) return;
                try
                {
                    picAvatar.Image = Image.FromFile(FileName);
                }
                catch (Exception)
                {
                    MessageBox.Show("Tệp tin không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
