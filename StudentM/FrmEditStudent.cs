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
    /// Chỉnh sữa học viên
    /// </summary>
    public partial class FrmEditStudent : Form
    {
        public FrmEditStudent()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmEditStudent_Load(object sender, EventArgs e)
        {
            // Custom Fotmat date timepicker
            dtpBirthDay.CustomFormat = "dd/MM/yyyy";

            // Lấy mã từ biến tĩnh và gán biến tĩnh bằng Empty
            Student student = new Student();
            string StudentID = Program.StudentID;
            Program.StudentID = string.Empty;

            // Lấy học viên theo mã học viên
            student = (new BLLStudent()).Get(StudentID);

            if (student == null) return;

            // Load dữ liệu lên
            txtStudentID.Text = student.StudentID;
            txtStudentName.Text = student.StudentName;
            dtpBirthDay.Value = student.BirthDay;
            cmbGender.Text = student.Gender;
            txtPhoneNumber.Text = student.PhoneNumber;
            txtEmail.Text = student.Email;
            cmbAddress.Text = student.Address;
            cmbStaying.Text = student.Staying;
            cmbEducation.Text = student.Education;
            cmbUniversity.Text = student.University;

            try
            {
                // Load hình ảnh lên pictureBox
                byte[] image = student.Avatar;
                MemoryStream stream = new MemoryStream(image);

                picAvatar.Image = Image.FromStream(stream);
            }
            catch (Exception)
            {
            }

            //chkState.Checked = student.State;
        }

        private void btnEditAndQuit_Click(object sender, EventArgs e)
        {
            if (Edit() == true) this.Close();
        }

        private bool Edit()
        {
            try
            {
                Student student = new Student();

                // Lấy học viên theo mã
                student.StudentID = txtStudentID.Text;
                student = (new BLLStudent()).Get(student.StudentID);

                student.StudentName = txtStudentName.Text;
                student.Gender = cmbGender.Text;
                student.BirthDay = dtpBirthDay.Value;
                student.PhoneNumber = txtPhoneNumber.Text;
                student.Email = txtEmail.Text;
                student.Address = cmbAddress.Text;
                student.Staying = cmbStaying.Text;
                student.Education = cmbEducation.Text;
                student.University = cmbUniversity.Text;

                try
                {
                    MemoryStream stream = new MemoryStream();
                    picAvatar.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    student.Avatar = stream.ToArray();
                }
                catch (Exception)
                {
                }

                if (string.IsNullOrEmpty(student.StudentID) ||
                    string.IsNullOrEmpty(student.StudentName))
                {
                    MessageBox.Show("Bạn chưa nhập mã hoặc tên học viên.",
                  "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtStudentName.Focus();
                    return false;
                }

                (new BLLStudent()).Update(student);
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể chỉnh sửa học viên này. Vui lòng kiểm tra lại thông tin đã nhập.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void picAvatar_Click(object sender, EventArgs e)
        {
            // Lấy hình ảnh từ đĩa
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

                    MessageBox.Show("Tệp tin không hợp lệ.", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
